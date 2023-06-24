using UnityEngine;

public class ChangeWindow : MonoBehaviour
{
    public GameObject allImages;

    public void OpenImage()
    {
        allImages.SetActive(false);
        Screen.orientation = ScreenOrientation.AutoRotation;

    }
    public void CloseImage()
    {
        allImages.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
