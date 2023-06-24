using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenGallery : MonoBehaviour
{
    public GameObject loadScreen;

    public Slider scale;
    public int percent;
    public TextMeshProUGUI textPercent;
    private AsyncOperation load;
    public void Load()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        load = SceneManager.LoadSceneAsync(1);

        load.allowSceneActivation = false;

        while (!load.isDone)
        {
            if (load.progress >= .9f && !load.allowSceneActivation)
            {
                yield return new WaitForSeconds(2f);
                load.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    private void Update()
    {
        scale.value = load.progress;
        textPercent.text = (load.progress * 100).ToString();
    }
}
