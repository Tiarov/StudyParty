using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoManager : MonoBehaviour
{
    public GameObject Prefab;
    [SerializeField]
    private JsonDownloader _loadManager;
    private List<GameObjectInfo> _infoList;

    private void Start()
    {
        _loadManager.DownloadIsCompliteEvent += OnDownloadIsComplite;
        DownloadInfo();
    }

    public void DownloadInfo()
    {
        _loadManager.StartDownloadInfo();
    }

    public void CreatePrefabs()
    {
        if (_infoList == null || _infoList.Count == 0)
            return;

        StartCoroutine(CreateGameObjects());
    }

    public void OnDownloadIsComplite()
    {
        _infoList = new List<GameObjectInfo>(_loadManager.GetGoInfo());
    }

    public IEnumerator CreateGameObjects()
    {
        foreach (var info in _infoList)
        {
            Instantiate(Prefab, new Vector3(info.Position[0], info.Position[1], info.Position[2]), Quaternion.identity).name = info.Name;
            yield return new WaitForEndOfFrame();
        }
    }
}
