using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Domain.Models;

namespace Transport.Core.Application.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
    }
}
