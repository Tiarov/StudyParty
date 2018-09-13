using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class AssetsLoader : MonoBehaviour
    {
        private const string BUNDLE_URL = "file:///{0}/AssetBundles/";
        private const string ASSET_URL = "https://www.dropbox.com/s/5uulc63anf4k9a2/bundlewithbackground?dl=1";

        public bool fromPersistentData;
        public string BundleName = "myfirstasset";
        public string AssetName = "ColorizedPrefab";

        [SerializeField]
        private int _version = 0;

        public void DownloadAsset()
        {
            StartCoroutine(DownloadAsset(ASSET_URL));
        }

        public void LoadAssetToScene()
        {
            StartCoroutine(LoadAsset(fromPersistentData ? "file:///" + Application.persistentDataPath + "/" : String.Format(BUNDLE_URL, Application.dataPath),
                BundleName, AssetName));
        }

        private IEnumerator LoadAsset(string path, string bundleName, string assetName)
        {
            //while (!Caching.ready)
            //    yield return null;
            

            using (WWW www = new WWW(path + bundleName))
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

        private IEnumerator DownloadAsset(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                var bytes = request.downloadHandler.data;

                File.WriteAllBytes(Application.persistentDataPath + "/" + BundleName, bytes);
            }

            LoadAssetToScene();
        }
    }
}
