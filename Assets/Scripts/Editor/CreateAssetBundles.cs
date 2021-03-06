﻿using System.IO;
using UnityEditor;

namespace Assets.Scripts.Editor
{
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Build AssetBundles")]
        public static void BuildAllAssetBundles()
        {
            string assetBundleDirectory = "Assets/AssetBundles";
            if (!Directory.Exists(assetBundleDirectory))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
        }
    }
}
