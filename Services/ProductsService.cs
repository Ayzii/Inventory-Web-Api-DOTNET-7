using Server.Data;
using Server.DTOs;
using Server.Models;
using Server.Repository;

namespace Server.Services
{
    public class ProductsService : Repository<Products>
    {
        private readonly DatabaseContext databaseContext;
        public ProductsService(DatabaseContext context) : base(context)
        {
            databaseContext = context;
        }

        public bool IsProductExist(Products_DTO products_DTO)
        {
            return databaseContext.Products
                .Any(s => s.Name.ToLower() == products_DTO.Name.ToLower());
        }
    }
}
