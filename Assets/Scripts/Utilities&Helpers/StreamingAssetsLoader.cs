using System.IO;
using UnityEngine;

public class StreamingAssetsLoader : MonoBehaviour
{
    public string FileName = "GameObjectsInfo.json";

    private void Start()
    {
        var json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, FileName));
        var infos = JsonUtility.FromJson<InfosCollection>(json).ObjectsList;

        foreach (var info in infos)
        {
            Debug.Log(info.Name + " " + info.Position[0]);
        }
    }
}
