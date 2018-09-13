using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDownloader : MonoBehaviour
{
    private string _fileName = "/currentObject";
    private string downloadUrl = "http://www.dropbox.com/s/xbihd47dgyu5cgb/GameObjectsInfo.json?dl=1";

    public Action DownloadIsCompliteEvent;

    public void StartDownloadInfo()
    {
        TryDownload(downloadUrl);
    }

    public IEnumerable<GameObjectInfo> GetGoInfo()
    {
        var url = Application.persistentDataPath + _fileName;

        return ParseJson(File.ReadAllText(url));
    }

    private void SaveFileToPath(string path, string text)
    {
        File.WriteAllText(path + "/currentObject", text);
    }

    private void TryDownload(string url)
    {
        StartCoroutine(Download(url, Application.persistentDataPath));
    }

    private IEnumerator Download(string url, string path)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            if (www.error != null)
            {
                throw new Exception("WWW download had an error:" + www.error);
            }

            var json = www.text;

            SaveFileToPath(path, json);

            if (DownloadIsCompliteEvent != null)
                DownloadIsCompliteEvent();
        }
    }

    private GameObjectInfo[] ParseJson(string json)
    {
        return JsonUtility.FromJson<InfosCollection>(json).ObjectsList;
    }
}
