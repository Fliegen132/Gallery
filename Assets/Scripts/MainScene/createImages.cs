using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class createImages : MonoBehaviour
{
    public GameObject prefabImage;
    private Transform parent;
    private string url = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private void Start()
    {
        StartCoroutine(GetImage(url));
        parent = GameObject.FindGameObjectWithTag("Content").transform;
        Screen.orientation = ScreenOrientation.Portrait;

    }

    private IEnumerator GetImage(string urlImg)
    {
        for (int i = 1; ; i++)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlImg + i + ".jpg");
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("error");
                yield break;
            }
            else
            {
                Image go = Instantiate(prefabImage).GetComponent<Image>();
                go.transform.SetParent(parent);
                Texture2D texture2D = DownloadHandlerTexture.GetContent(request) as Texture2D;
                go.GetComponent<Image>().sprite = Sprite.Create(texture2D,
                    new Rect(0, 0, texture2D.width, texture2D.height),
                    new Vector2(0, 0));
            }
        }
    }
}
