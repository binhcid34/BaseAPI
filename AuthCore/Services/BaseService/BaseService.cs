using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Cache;
using WebCore.Extension.Log;

namespace WebCore.Services.BaseService
{
    public class BaseService
    {
        #region property
        public ICacheService _cacheService;
        public ILogService _logService;
        #endregion
        #region contructors
        public BaseService(ICacheService cacheService, ILogService logService)
        {
            _cacheService = cacheService;
            _logService = logService;
        }
        #endregion
    }
}
