using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class AssetsLoader : MonoBehaviour
    {
        public string BundleName = "myfirstasset";
        public string AssetName = "ColorizedPrefab";

        private string _bundleUrl = "file:///{0}/AssetBundles/{1}";
        private int _version;
        private AssetBundle _bundle;

        private void Start()
        {
            StartCoroutine(DownloadAndCache(BundleName, AssetName));
        }

        private IEnumerator DownloadAndCache(string bundleName, string assetName)
        {
            while (!Caching.ready)
                yield return null;
            using (WWW www = WWW.LoadFromCacheOrDownload(string.Format(_bundleUrl, Application.dataPath, bundleName), 0))
            {
                yield return www;
                if (www.error != null)
                {
                    throw new Exception("WWW download had an error:" + www.error);
                }

                _bundle = www.assetBundle;

                if (String.IsNullOrEmpty(assetName))
                {
                    Instantiate(_bundle.mainAsset);
                }
                else
                {
                    Instantiate(_bundle.LoadAsset(assetName));
                }

                //_bundle.Unload(true);
                _bundle.Unload(false);
            }
        }
    }
}
