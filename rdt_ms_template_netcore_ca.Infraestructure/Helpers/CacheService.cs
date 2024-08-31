using LazyCache;
using System;

namespace rdt_ms_template_netcore_ca.Infraestructure.Helpers
{
    public class CacheService
    {
        private readonly IAppCache _cache;

        public CacheService(IAppCache cache)
        {
            _cache = cache;
        }

        public string GetCachedData()
        {
            // Definir la clave del caché
            string cacheKey = "myCachedData";

            // Obtener o agregar el valor en la caché
            return _cache.GetOrAdd(cacheKey, () =>
            {
                // Este código solo se ejecutará si el valor no está en la caché
                Console.WriteLine("Fetching data...");
                string data = "This is the cached data";
                return data;
            }, TimeSpan.FromMinutes(5)); // Tiempo de expiración de 5 minutos
        }
    }
}
