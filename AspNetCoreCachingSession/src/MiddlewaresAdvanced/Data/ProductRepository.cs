using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewaresAdvanced
{
    public class ProductRepository : IDataRepository
    {
        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "LapTop"
                },
                new Product
                {
                    Id = 2,
                    Name = "Phone"
                }
            };
        }
    }
}
