using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public class LocalStorageManager : ILocalStorageManager
    {
        private readonly IJSRuntime js;
        public LocalStorageManager(IJSRuntime js)
        {
            this.js = js;
        }
        public async  Task<string> GetLocalStorage(string oKey)
        {
            var oJson = await js.GetFromLocalStorage(oKey);
            return oJson;
        }

        public async Task SetLocalStorage(string oKey, string oJson)
        {
            await js.SetInLocalStorage(oKey, oJson);
        }


    }
}
