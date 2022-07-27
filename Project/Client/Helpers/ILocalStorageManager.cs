using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public interface ILocalStorageManager
    {
        Task<string> GetLocalStorage(string oKey);
        Task SetLocalStorage(string oKey, string oJson);
        
    }
}
