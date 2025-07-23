using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Modules.AddressableSystem
{
    public static class AddressableManager
    {
        public static async UniTask Initialize()
        {

        }

        public static async UniTask<T> LoadAsync<T>(string address) where T : Object
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
                return handle.Result;

            Debug.LogError($"Addressable load failed: {address}");
            return null;
        }

        public static void Release<T>(T obj)
        {
            Addressables.Release(obj);
        }
    }
}
