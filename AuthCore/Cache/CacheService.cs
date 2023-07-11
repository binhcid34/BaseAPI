using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Common;
using WebCore.Extension.Log;
using WebCore.Shared.Constants;

namespace WebCore.Cache
{
    public class CacheService : ICacheService
    {
        #region Properties
        private IMemoryCache _cache;
        public static List<string> entriesCache = new List<string>();
        private ILogService _logService;
        private const int SlidingExpiration = 60;
        private const int AbsoluteExpiration = 120;
        private const int SizeCache = 480;
        #endregion

        #region Constructors

        #endregion
        public CacheService(IMemoryCache memoryCache, ILogService logService)
        {
            _cache = memoryCache;
            _logService = logService;
        }
        #region methods
        public bool TryGetValue<TItem>(string key, out TItem value)
        {
            try
            {
                bool isGetCache = _cache.TryGetValue(key, out value);
                return true;
            }catch(Exception ex)
            {
                _logService.addLogService("CacheService", LogKey.LogError, ex.Message);
                throw;
            }
        }

        public void SetCache<TItem>(string key, TItem value, int SlidingExpirationCahce = SlidingExpiration, int AbsoluteExpiration = AbsoluteExpiration, int SizeCache = SizeCache)
        {
            CommonFunc.AddIfNotExist(entriesCache, key);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromMinutes(SlidingExpirationCahce))
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(AbsoluteExpiration))
                   .SetPriority(CacheItemPriority.Normal)
                   .SetSize(SizeCache);
            _cache.Set(key, value, cacheEntryOptions);
        }

        public bool ClearCache()
        {
            foreach(var entry in entriesCache)
            {
                this.RemoveCache(entry);
            }
            return true;
        }

        public bool RemoveCache(string key)
        {
            _cache.Remove(key);
            return true;
        }
        #endregion
    }
}
