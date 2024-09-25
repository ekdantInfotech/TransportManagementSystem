using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Application.Interface;
using Transport.Core.Domain.Models;
using Transport.Infrastructure.Data;

namespace Transport.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly TransportDbContext _db;

        public ProductRepository(TransportDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.product.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
