using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Blog;
using PestkitOnion.Application.Dtos.Tag;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository repository, IMapper mapper, IAuthorRepository authorRepository, ITagRepository tagRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
        }

        public async Task CreateAsync(CreateBlogDto create)
        {
            bool result = await _repository.CheckUniqueAsync(c => c.Title == create.title);
            if (result) throw new Exception("Title was used");

            bool authorResult = await _authorRepository.CheckUniqueAsync(c => c.Id == create.authorId);
            if (!authorResult) throw new Exception("Author not exsist");

            Blog item = _mapper.Map<Blog>(create);
            item.Tags = new List<BlogTag>();
            foreach (var tagId in create.tagIds)
            {
                bool tagResult = await _tagRepository.CheckUniqueAsync(x => x.Id == tagId);
                if (!tagResult) throw new Exception("Tag not exsist");
                item.Tags.Add(new BlogTag { TagId = tagId });
            }

            await _repository.AddAsync(item);
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            string[] includes = { $"{nameof(Blog.Tags)}" };

            Blog item = await _repository.GetByIdAsync(id, IsDeleted: true, includes: includes);

            if (item == null) throw new Exception("Not Found");

            _repository.Delete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemBlogDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Blog> items = await _repository
                .GetAllWhere(skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemBlogDto> dtos = _mapper.Map<ICollection<ItemBlogDto>>(items);

            return dtos;
        }
        public async Task<ICollection<ItemBlogDto>> GetAllWhereByOrderAsync(int page, int take,
            Expression<Func<Blog, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Blog> items = await _repository
                .GetAllWhereByOrder(orderException: orderExpression, skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemBlogDto> dtos = _mapper.Map<ICollection<ItemBlogDto>>(items);

            return dtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            string[] includes = { $"{nameof(Blog.Tags)}" };
            Blog item = await _repository.GetByIdAsync(id, includes: includes);
            if (item == null) throw new Exception("Not Found");

            _repository.SoftDelete(item);

            foreach (BlogTag blogTag in item.Tags)
            {
                blogTag.IsDeleted = true;
            }

            await _repository.SaveChanceAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Blog item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");

            _repository.ReverseSoftDelete(item);


            foreach (BlogTag blogTag in item.Tags)
            {
                blogTag.IsDeleted = true;
            }

            await _repository.SaveChanceAsync();
        }

        public async Task UpdateAsync(int id, UpdateBlogDto update)
        {
            if (id <= 0) throw new Exception("Bad Request");
            string[] includes = { $"{nameof(Blog.Tags)}" };
            Blog item = await _repository.GetByIdAsync(id, includes: includes);

            if (item == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUniqueAsync(c => c.Title == update.title && c.Id != id);
            if (result) throw new Exception("Title was used");

            bool authorResult = await _authorRepository.CheckUniqueAsync(c => c.Id == update.authorId);
            if (update.authorId != item.AuthorId)
                if (!authorResult) throw new Exception("Author not exsist");

            item = _mapper.Map(update, item);
            item.Tags = item.Tags.Where(pc => update.tagIds.Any(tagId => pc.TagId == tagId)).ToList();

            foreach (var tagId in update.tagIds)
            {
                bool colorResult = await _tagRepository.CheckUniqueAsync(x => x.Id == tagId);
                if (!colorResult) throw new Exception("Tag not exsist");

                if (!item.Tags.Any(pc => pc.TagId == tagId))
                {
                    item.Tags.Add(new BlogTag { TagId = tagId });
                }
            }

            _repository.Update(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<GetBlogDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            string[] includes = { $"{nameof(Blog.Author)}",
                $"{nameof(Blog.Tags)}",
                $"{nameof(Blog.Tags)}.{nameof(BlogTag.Tag)}"};
            Blog item = await _repository.GetByIdAsync(id, includes: includes);
            if (item == null) throw new Exception("Not Found");

            GetBlogDto dto = _mapper.Map<GetBlogDto>(item);

            dto.Tags = new List<IncludeTagDto>();

            foreach (BlogTag tag in item.Tags)
            {
                dto.Tags.Add(_mapper.Map<IncludeTagDto>(tag.Tag));
            }

            return dto;
        }
    }
}
