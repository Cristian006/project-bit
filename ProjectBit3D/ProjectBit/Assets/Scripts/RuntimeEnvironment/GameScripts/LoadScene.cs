using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public bool loadOnStart = false;
    public string sceneToLoad;
    public float secondsToWait = 2f; //Default 2 seconds

    void Awake()
    {
        if (loadOnStart)
        {
            StartCoroutine(Splash());
        }
    }

    public IEnumerator Splash()
    {
        yield return new WaitForSeconds(secondsToWait);
        LoadAScene(sceneToLoad);
    }


    // public string Scene;
    public void LoadAScene(string Scene)
    {
        Application.LoadLevel(Scene);
    }
}
