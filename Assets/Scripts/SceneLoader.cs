using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public GameObject GO;

    private bool isLoaded;
    private bool shouldLoad;
    IEnumerator loadScene;
    public float loadingProgress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TriggerCheck();
    }

    private void TriggerCheck()
    {
        if (shouldLoad)
        {
            //LoadScene();
            LoadGO();
        }
        else
        {
            //UnloadScene();
            UnloadGO();
        }
    }

    private void UnloadGO()
    {
        if (isLoaded)
        {
            GO.SetActive(false);
            isLoaded = false;
        }
    }

    private void LoadGO()
    {
        if (!isLoaded)
        {
            GO.SetActive(true);
            isLoaded = true;
        }
    }

    private void UnloadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    private void LoadScene()
    {
        if(!isLoaded)
        {
            loadScene = AsyncLoad(gameObject.name);
            isLoaded = true;
            StartCoroutine(loadScene);
        }
    }

    private IEnumerator AsyncLoad(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            loadingProgress = Mathf.Clamp01(asyncLoad.progress);
            asyncLoad.allowSceneActivation = false;
            if (asyncLoad.progress == 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }
}
