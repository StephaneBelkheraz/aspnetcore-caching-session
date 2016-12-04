using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedCacheRedisAzure.Redis
{
    public interface ICacheRedis
    {
        T Get<T>(string key);
        void Set<T>(string key, T obj);
    }
}
