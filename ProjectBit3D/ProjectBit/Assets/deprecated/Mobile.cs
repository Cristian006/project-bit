using UnityEngine;

public class Mobile : MonoBehaviour
{
    [SerializeField]
    private bool mobile;

    public void Play()
    {
#if UNITY_EDITOR
        if(mobile)
        {
            loadMobile();
        }
        else
        {
            loadPC();
        }
#elif UNITY_UNITY_STANDALONE
        loadPC();
#elif UNITY_ANDROID || UNITY_IOS
        loadMobile();
#endif
    }
    private void loadMobile()
    {
        Application.LoadLevel("Mobile");
    }

    private void loadPC()
    {
        Application.LoadLevel("GameLevel1");
    }
}
