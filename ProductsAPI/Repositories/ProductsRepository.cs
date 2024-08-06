using ProductsAPI.Domains;
using ProductsAPI.Interface;
using ProductsAPI.Context;

namespace ProductsAPI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ContextAPP _context;

        public ProductsRepository(ContextAPP context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Products> Get()
        {
            return _context.Products.ToList();
        }

        public Products GetById(Guid id)
        {
            return _context.Products.Find(id)!;
        }

        public void Post(Products newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void Put(Guid id, Products newProduct)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct != null)
            {
                existingProduct.NameProduct = newProduct.NameProduct;
                existingProduct.PriceProduct = newProduct.PriceProduct;

                _context.Products.Update(existingProduct);
                _context.SaveChanges();
            }
        }
    }
}
