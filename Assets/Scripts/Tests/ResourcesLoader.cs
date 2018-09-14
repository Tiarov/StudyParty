using System;
using System.Collections;
using UnityEngine;

public class ResourcesLoader : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Method());
    }

    private void Update()
    {
        
    }

    private IEnumerator Method()
    {
        var prefab1 = Resources.Load<GameObject>("Cube3");
        var prefab2 = Resources.Load<GameObject>("Cube2");

        yield return new WaitForSeconds(1);

        var go1 = Instantiate(prefab1);
        var go2 = Instantiate(prefab2);

        yield return new WaitForSeconds(1);

        Destroy(go1);
        Destroy(go2);

        yield return new WaitForSeconds(1);
       
        Resources.UnloadUnusedAssets();
    }
}
