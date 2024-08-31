using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using rdt_ms_template_netcore_ca.Application.Queries;
using rdt_ms_template_netcore_ca.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rdt_ms_template_netcore_ca.TestUnit.Test
{
    public class ProductTest
    {
        [Fact]
        public void TestProduct()
        {
            //Pruebas unitarias controller ProductController
            //Prueba Unitaria 1 - todos los productos
            //Arrange
            var product = new GetAllProductQuery();
            //Act
            bool isValidallProducts = product.Equals(product);
            //Assert
            Assert.True(isValidallProducts, "La prueba no funciono con exito");

        }
        [Fact]
        public void TestProduct2()
        {
            //Prueba Unitaria 2 - todos los productos X id
            //Arrange
            uint ProductId = 2;
            var product_2 = new GetProductByIdQuery(ProductId);
            //Act
            bool isValidallProductsXid = product_2.Equals(product_2);
            //Assert
            Assert.True(isValidallProductsXid, "La prueba no funciono con exito");
        }
    }
}
