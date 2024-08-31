using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using rdt_ms_template_netcore_ca.Infraestructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using rdt_ms_template_netcore_ca.Infraestructure.Helpers;
using System.Data.Entity;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Net.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace rdt_ms_template_netcore_ca.Infraestructure.Repositories
{
    
    public class ProductRepository(UsersContext dbContext) : IProductRepository
    {
        //inyeccion de dependencia;
        
        private readonly ObjectCache _cacheService = System.Runtime.Caching.MemoryCache.Default;
        private readonly CacheItemPolicy _policy;
        private readonly HttpClient _httpClient;
        private readonly UsersContext _dbContext;

        public ProductRepository(ObjectCache cacheService, CacheItemPolicy policy, UsersContext dbContext) : this(dbContext)
        {
           _cacheService = cacheService;
           _dbContext = dbContext;
           _policy = new CacheItemPolicy
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(5))
            };
        }
        public async Task<string> CallEndpointAsync(string endpointPath)
        {
            var response = await _httpClient.GetAsync(endpointPath);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public Dictionary<int, string> GetProductStates()
        {
            var cacheKey = "ProductStates";
            var cachedProductStates = _cacheService[cacheKey] as Dictionary<int, string>;

            if (cachedProductStates == null)
            {
                cachedProductStates = new Dictionary<int, string>
            {
                { 1, "Active" },
                { 0, "Inactive" }
            };

                _cacheService.Add(cacheKey, cachedProductStates, _policy);
            }

            return cachedProductStates;
        }

        Stopwatch cronometro = new Stopwatch();
        

        public string EndpointUrl { get; }

        public async Task<IEnumerable<ProductEntity>> GetAllProductAsync()
        {
            const string fileName = "log_tiempo_metodo_GET.txt";

            try
            {
              
                   cronometro.Start();
                   var products = dbContext.Products.ToList();
                   cronometro.Stop();
                   var res_tiempo = "Log de tiempo de respuesta:" + cronometro.Elapsed.TotalMilliseconds +" |" + DateTime.Now;
                   archivoText(fileName, res_tiempo.ToString());
                   return products;
              
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        private static void archivoText(string fileName, string variable)
        {
            File.WriteAllText(fileName, variable.ToString());
        }
        public async Task<ProductEntity> GetProductByIdAsync(uint id)
        {
            ProductState? productState = null;
            IEnumerable<ProductState>? prod_json = null;
            try
            {
                const string fileName = "log_tiempo_metodo_GETxID.txt";
                cronometro.Start();
                var endpointUrl = "https://66d1ef6262816af9a4f555e4.mockapi.io/api/techdotnet/Products";
                var endpointPath = "https://66d1ef6262816af9a4f555e4.mockapi.io/api/techdotnet/Products";
                var caller = new EndpointCaller(endpointUrl);
                var response = await caller.CallEndpointAsync(endpointPath);
                if (response is not null)
                {
                    prod_json = JsonSerializer.Deserialize<IEnumerable<ProductState>>(response);
                }
                var dato = prod_json.FirstOrDefault(x => x.Id == id);
                var products = dbContext.Products.FirstOrDefault(x => x.Id == id);
                if (products is not null)
                {
                    products.Discount = dato.Discount;
                    products.Total_price = (int?)(products.SalePrice * (100 - dato.Discount.Value) / 100);
                }
                cronometro.Stop();
                var res_tiempo = "Log de tiempo de respuesta:" + cronometro.Elapsed.TotalMilliseconds + " |" + DateTime.Now;
                archivoText(fileName, res_tiempo.ToString());
                return products;
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductEntity> AddProductAsync(ProductEntity entity)
        {
            try
            {
                const string fileName = "log_tiempo_metodo_POSTxID.txt";
                cronometro.Start();
                var estado = GetProductStates();
                entity.Status = estado[0].FirstOrDefault();
                dbContext.Products.Add(entity);
                await dbContext.SaveChangesAsync();
                cronometro.Stop();
                var res_tiempo = cronometro.Elapsed.TotalMilliseconds;
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductEntity> UpdateProductAsync(uint ProductId, ProductEntity entity)
        {
            try
            {
                const string fileName = "log_tiempo_metodo_PUTxID.txt";
                cronometro.Start();
                var Product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == ProductId);

            if (Product is not null)
            {
                Product.Name = entity.Name;
                Product.SalePrice = entity.SalePrice;
                Product.BuyPrice = entity.BuyPrice;
                Product.Quantity = entity.Quantity;
                Product.CategorieId = entity.CategorieId;
                Product.Date = entity.Date;
                Product.MediaId = entity.MediaId;

                await dbContext.SaveChangesAsync();
                cronometro.Stop();
                var res_tiempo = cronometro.Elapsed.TotalMilliseconds;
                return Product;
            }

            return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(uint Id)
        {
            try
            {
                const string fileName = "log_tiempo_metodo_DELETExID.txt";
                cronometro.Start();
                var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product is not null)
            {
                dbContext.Products.Remove(product);

                return await dbContext.SaveChangesAsync() > 0;
            }
                cronometro.Stop();
                var res_tiempo = cronometro.Elapsed.TotalMilliseconds;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
