using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public string Key;

    public StreamingAssetsLoader Loader;
    
    public void LoadJsonToPP()
    {
        SaveStringToPlyerPrefs(Loader.ReadJsonFromStreamingPath(), Key);
    }

    public void GetJsonFromPP()
    {
        var result = ReadStringFromPlayerPrefsByKey(Key);
        Debug.Log(result);
    }

    public void CleanPP()
    {
        PlayerPrefs.DeleteAll();
    }

    private void SaveStringToPlyerPrefs(string s, string key)
    {
        PlayerPrefs.SetString(key, s);
    }

    private string ReadStringFromPlayerPrefsByKey(string key)
    {
        return PlayerPrefs.GetString(key, "Empty");
    }
}
