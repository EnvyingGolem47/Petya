using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BetaPlayScript : MonoBehaviour
{

    public GameObject panel;
    public Text text2;

    public float progressofloading;

    public void change()
    {
        print("loading scene");

        panel.SetActive(true);

        text2.text = "Progress: 0.0";

        print("starting coroutine");

        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Petya");

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            
            progressofloading = operation.progress;
            text2.text = "Progress: " + progressofloading;

            yield return null;
        }

        progressofloading = operation.progress;
    }
}
