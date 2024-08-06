using Moq;
using ProductsAPI.Domains;
using ProductsAPI.Interface;
using System;
using System.Collections.Generic;
using Xunit;

namespace TesteApiXUnit
{
    public class ProductTest
    {
        [Fact]
        public void Get()
        {
            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), NameProduct = "Produto 1", PriceProduct = 10},
                new Products {IdProduct = Guid.NewGuid(), NameProduct = "Produto 2", PriceProduct = 20},
                new Products {IdProduct = Guid.NewGuid(), NameProduct = "Produto 3", PriceProduct = 30},
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Get()).Returns(products);

            var result = mockRepository.Object.Get();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Post()
        {
            var product = new Products
            {
                IdProduct = Guid.NewGuid(),
                NameProduct = "Produto 4",
                PriceProduct = 40
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Post(product));

            mockRepository.Object.Post(product);

            mockRepository.Verify(x => x.Post(It.Is<Products>(p => p.NameProduct == "Produto 4")), Times.Once);
        }

        [Fact]
        public void GetById()
        {
            var productId = Guid.NewGuid();
            var product = new Products
            {
                IdProduct = productId,
                NameProduct = "Produto 1",
                PriceProduct = 10
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetById(productId)).Returns(product);

            var result = mockRepository.Object.GetById(productId);

            Assert.Equal(productId, result.IdProduct);
        }

        [Fact]
        public void Delete()
        {
            var productId = Guid.NewGuid();

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Delete(productId));

            mockRepository.Object.Delete(productId);

            mockRepository.Verify(x => x.Delete(It.Is<Guid>(id => id == productId)), Times.Once);
        }

        [Fact]
        public void Update()
        {
            var productId = Guid.NewGuid();
            var product = new Products
            {
                IdProduct = productId,
                NameProduct = "Produto 1",
                PriceProduct = 10
            };

            var updatedProduct = new Products
            {
                IdProduct = productId,
                NameProduct = "Produto 1 Atualizado",
                PriceProduct = 15
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Put(productId, updatedProduct));

            mockRepository.Object.Put(productId, updatedProduct);

            mockRepository.Verify(x => x.Put(It.Is<Guid>(id => id == productId), It.Is<Products>(p => p.NameProduct == "Produto 1 Atualizado" && p.PriceProduct == 15)), Times.Once);
        }
    }
}
