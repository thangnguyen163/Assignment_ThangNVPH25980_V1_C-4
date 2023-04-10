using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IProductServices
    {
        public bool Add(Products products);
        public bool Update(Products products);
        public bool Delete(Guid Id);
        public List<Products> GetAllProducts();
        public Products GetProductsById(Guid Id);
        public List<Products> GetProductsByName(string Name);
        public List<ProductView> GetAllProductView();
        public ProductView GetProductViewById(Guid Id);
    }
}
