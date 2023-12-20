using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
