using System.IO;
using Assets.Scripts.Enums;
using UnityEngine;

public class TestScriptForPersistentDataPath : MonoBehaviour
{
    public SourceFolder Source;
    public PositionInfo PositionInfo;

    private string fileName = "currentObject";

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);

        //saving info from PositionInfo

        SaveFileToPath(Application.persistentDataPath);

        //Load and set loaded position
        PositionInfo.transform.position =
            StringToVector3(LoadTextFromFileByPath(Application.persistentDataPath + "/currentObject"));

        Debug.Log(Application.persistentDataPath);
    }

    private void SaveFileToPath(string path)
    {
        File.WriteAllText(path + "/currentObject", PositionInfo.Position.ToString());
    }

    private string LoadTextFromFileByPath(string path)
    {
        return File.ReadAllText(path);
    }

    private Vector3 StringToVector3(string sVector)
    {
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        string[] sArray = sVector.Split(',');

        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
}
