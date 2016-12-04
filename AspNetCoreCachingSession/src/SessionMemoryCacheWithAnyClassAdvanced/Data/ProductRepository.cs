using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public class ProductRepository : IDataRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISession _session => _httpContextAccessor.HttpContext.Session;

    public ProductRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public List<Product> GetAll()
    {
        var productFromSession = _httpContextAccessor.HttpContext.Session.Get<Product>("productFromSession");
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
            },
            productFromSession
        };
    }
}
