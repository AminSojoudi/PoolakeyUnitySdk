using System.Threading.Tasks;
using Poolakey.Scripts.Data;
using UnityEngine;

namespace Poolakey.Scripts.Callbacks
{
    public class BaseCallbackProxy<T> : AndroidJavaProxy
    {
        protected Result<T> result;
        public BaseCallbackProxy(string address) : base(address) { }

        public async Task<Result<T>> WaitForResult()
        {
            while (result == null || result.data == null)
                await Task.Delay(100);
            return (Result<T>)result;
        }
    }
}