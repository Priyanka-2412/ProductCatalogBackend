using System.Collections.Generic;
using ProductCatalogBackend.Entities;

namespace ProductCatalogBackend.DAO
{
    public interface IProductCatalogService
    {
        void AddCategory(Category category);
        void AddAttribute(AttributeDefinition attribute);
        void AddProduct(Product product, List<ProductAttribute> attributes);
        List<Product> GetProductsByCategory(int categoryId);
    }
}
