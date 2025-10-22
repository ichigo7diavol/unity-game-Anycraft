using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Anycraft.Features.Utilities
{
    public static class RuntimeEditorUtils
    {
        public static TAsset LoadFirstAssetOfType<TAsset>()
            where TAsset : Object
        {
#if UNITY_EDITOR
            var guids = AssetDatabase.FindAssets($"t:{typeof(TAsset).Name}");

            if (guids.Length <= 0)
            {
                return null;
            }
            var path = AssetDatabase.GUIDToAssetPath(guids[0]);
            var asset = AssetDatabase.LoadAssetAtPath<TAsset>(path);

            return asset;
#else
            return null;
#endif
        }

        public static List<TAsset> LoadAssetsOfType<TAsset>()
            where TAsset : Object
        {
#if UNITY_EDITOR
            var result = new List<TAsset>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(TAsset).Name}");

            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<TAsset>(path);

                if (asset != null)
                {
                    result.Add(asset);
                }
            }
            return result;
#else
            return null;
#endif
        }
    }
}