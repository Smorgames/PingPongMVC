using UnityEngine;

namespace Services
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string assetPath) where T : Object;
    }
}