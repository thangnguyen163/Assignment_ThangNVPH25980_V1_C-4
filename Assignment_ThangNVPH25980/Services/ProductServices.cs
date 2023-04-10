using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class ProductServices : IProductServices
    {
        OuteDBContext context;
        List<ProductView> _lstProducts;
        IColorServices _colorServices;
        ISizeServices _sizeServices;
        ICategoryServices _categoryServices;
        
        public ProductServices()
        {
            context = new OuteDBContext();
            _lstProducts = new List<ProductView>();
            _colorServices = new ColorServices();
            _sizeServices = new SizeServices();
            _categoryServices = new CategoryServices();
            
        }
        public bool Add(Products products)
        {
            try
            {
                context.Products.Add(products);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var p = context.Products.Find(Id);
                context.Products.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Products> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public ProductView GetProductViewById(Guid Id)
        {
            ProductView productView=GetAllProductView().FirstOrDefault(x=>x.Id==Id);
            return productView;

        }

        public Products GetProductsById(Guid Id)
        {
            return context.Products.FirstOrDefault(x => x.Id == Id);
        }

        public List<Products> GetProductsByName(string Name)
        {
            return context.Products.Where(x => x.Name.Contains(Name)).ToList();
        }


        public bool Update(Products products)
        {
            try
            {
                var p = context.Products.Find(products.Id);               
                    p.Name = products.Name;
                    p.Image = products.Image;
                    p.AvailableQuantity = products.AvailableQuantity;
                    p.Price = products.Price;
                    p.SizeId = products.SizeId;
                    p.ColorId = products.ColorId;
                    p.CategoryId = products.CategoryId;
                    p.Status = products.Status;
                    context.Products.Update(p);
                    context.SaveChanges();
                       
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductView> GetAllProductView()
        {
            return _lstProducts =
                    (from a in GetAllProducts()
                     join b in _colorServices.GetAllColor() on a.ColorId equals b.Id
                     join c in _sizeServices.GetAllSize() on a.SizeId equals c.Id
                     join d in _categoryServices.GetAllCategory() on a.CategoryId equals d.Id 
                     where a.Status<3
                     select new ProductView()
                     {
                         Id = a.Id,
                         Name = a.Name,
                         Image = a.Image,
                         Price = a.Price,
                         AvailableQuantity = a.AvailableQuantity,
                         Status = a.Status,
                         Color = b.Name,
                         Size = c.Name,
                         Category = d.Name,
                     }).ToList();
        }
    }
}
