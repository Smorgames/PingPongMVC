using UnityEngine;

namespace Services.Interfaces
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string assetPath) where T : Object;
    }
}