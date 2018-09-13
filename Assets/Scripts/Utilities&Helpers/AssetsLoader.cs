using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AssetsLoader : MonoBehaviour
    {
        private const string BUNDLE_URL = "file:///{0}/AssetBundles/{1}";

        public string BundleName = "myfirstasset";
        public string AssetName = "ColorizedPrefab";

        [SerializeField]
        private int _version = 0;

        public void LoadAsset()
        {
            StartCoroutine(DownloadAndCache(BundleName, AssetName));
        }

        private void Start()
        {
            //StartCoroutine(DownloadAndCache(BundleName, AssetName));
        }

        private IEnumerator DownloadAndCache(string bundleName, string assetName)
        {
            while (!Caching.ready)
                yield return null;

            using (WWW www = new WWW(string.Format(BUNDLE_URL, Application.dataPath, bundleName)))
            {
                yield return www;

                if (www.error != null)
                {
                    throw new Exception("WWW download had an error:" + www.error);
                }

                var bundle = www.assetBundle;

                AssetBundleRequest request = bundle.LoadAssetAsync(assetName, typeof(GameObject));

                yield return request;

                Instantiate(request.asset);

                bundle.Unload(false);
                Resources.UnloadUnusedAssets();
            }
        }
    }
}
