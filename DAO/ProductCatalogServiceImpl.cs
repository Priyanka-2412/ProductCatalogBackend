using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProductCatalogBackend.Entities;
using ProductCatalogBackend.Util;


namespace ProductCatalogBackend.DAO
{
    public class ProductCatalogServiceImpl : IProductCatalogService
    {
        public void AddCategory(Category category)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("db.properties"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories (Name) VALUES (@Name)", conn);
                cmd.Parameters.AddWithValue("@Name", category.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddAttribute(AttributeDefinition attribute)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("db.properties"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Attributes (CategoryId, Name, DataType) VALUES (@CategoryId, @Name, @DataType)", conn);
                cmd.Parameters.AddWithValue("@CategoryId", attribute.CategoryId);
                cmd.Parameters.AddWithValue("@Name", attribute.Name);
                cmd.Parameters.AddWithValue("@DataType", attribute.DataType);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddProduct(Product product, List<ProductAttribute> attributes)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("db.properties"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (CategoryId, Name) OUTPUT INSERTED.Id VALUES (@CategoryId, @Name)", conn);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                int productId = (int)cmd.ExecuteScalar();

                foreach (ProductAttribute attr in attributes)
                {
                    SqlCommand attrCmd = new SqlCommand("INSERT INTO ProductAttributes (ProductId, AttributeId, Value) VALUES (@ProductId, @AttributeId, @Value)", conn);
                    attrCmd.Parameters.AddWithValue("@ProductId", productId);
                    attrCmd.Parameters.AddWithValue("@AttributeId", attr.AttributeId);
                    attrCmd.Parameters.AddWithValue("@Value", attr.Value);
                    attrCmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = DBConnUtil.GetConnection("db.properties"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE CategoryId = @CategoryId", conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        CategoryId = reader.GetInt32(1),
                        Name = reader.GetString(2)
                    });
                }
            }
            return products;
        }
    }
}
