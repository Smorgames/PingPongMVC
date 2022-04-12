using UnityEngine;

namespace Services
{
    public class AssetProvider : IAssetProvider
    {
        public T LoadAsset<T>(string assetPath) where T : Object => 
            Resources.Load<T>(assetPath);
    }
}