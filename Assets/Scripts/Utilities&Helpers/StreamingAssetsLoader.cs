using System.IO;
using UnityEngine;

public class StreamingAssetsLoader : MonoBehaviour
{
    public string FileName = "GameObjectsInfo.json";
    
    public void ReadJson()
    {
        var infos = JsonUtility.FromJson<InfosCollection>(ReadJsonFromStreamingPath()).ObjectsList;

        foreach (var info in infos)
        {
            Debug.Log(info.Name + " " + info.Position[0]);
        }
    }

    public string ReadJsonFromStreamingPath()
    {
        return File.ReadAllText(Path.Combine(Application.streamingAssetsPath, FileName));
    }
}
