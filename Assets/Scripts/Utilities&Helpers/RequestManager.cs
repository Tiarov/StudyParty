using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{
    public string GetRequestUrl = "google.com/";
    public string PostRequestUrl = "http://dev.bidon-tech.com/PlaceVR/api/Account/Login";

    private void Start()
    {
        GET();
        POST();
    }

    public void GET()
    {
        StartCoroutine(GetRequest());
    }

    public void POST()
    {
        StartCoroutine(Postrequest());
    }

    public IEnumerator GetRequest()
    {
        using (var getRequest = UnityWebRequest.Get(GetRequestUrl))
        {
            yield return getRequest.SendWebRequest();
            Debug.Log("GET Request");

            if (getRequest.error != null)
            {
                Debug.Log("Server does not respond : " + getRequest.responseCode);
            }
            else
            {
                Debug.Log("Server responded : " + getRequest.responseCode);
            }
        }
    }

    public IEnumerator Postrequest()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>
        {
            new MultipartFormDataSection("Login", "sharod.christen@lron0re.com"),
            new MultipartFormFileSection("Password", "SimpleAsHell111")
        };

        using (var postRequest = UnityWebRequest.Post(PostRequestUrl, formData))
        {
            yield return postRequest.SendWebRequest();
            Debug.Log("POST Request");

            if (postRequest.error != null)
            {
                Debug.Log("Server does not respond : " + postRequest.responseCode);
            }
            else
            {
                Debug.Log("Server responded : " + postRequest.downloadHandler.text);
            }
        }
    }
}

