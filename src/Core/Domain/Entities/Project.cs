using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Domain.Entities
{
    public class Project:BaseNameEntity
    {
        public ICollection<ProjectImage>? ProjectImages { get; set; }

    }
}
