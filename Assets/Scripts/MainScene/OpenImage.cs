using UnityEngine;
using UnityEngine.UI;

public class OpenImage : MonoBehaviour
{
    public Image fullScreenImage;

    public ChangeWindow changeWindow;
    public void Start()
    {
        changeWindow = FindObjectOfType<ChangeWindow>();
        fullScreenImage = GameObject.FindGameObjectWithTag("fullScreenImage").GetComponent<Image>();
    }

    public void Open()
    {
        fullScreenImage.sprite = GetComponent<Image>().sprite;
        changeWindow.OpenImage();
    }
}
