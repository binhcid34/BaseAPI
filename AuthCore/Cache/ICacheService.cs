using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Cache
{
    public interface ICacheService
    {
       public bool TryGetValue<TItem>(string key, out TItem? value);
        public void SetCache<TItem>(string key,  TItem value, int SlidingExpirationCahce, int AbsoluteExpiration, int SizeCache);
        public bool ClearCache();
        public bool RemoveCache(string key);


    }
}
