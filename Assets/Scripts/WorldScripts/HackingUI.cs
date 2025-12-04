using UnityEngine;

public class HackingUI : MonoBehaviour
{
    public static HackingUI Instance;

    [HideInInspector] 
    public string sceneTarget;  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        gameObject.SetActive(false);
    }

    public void Open(string sceneName)
    {
        sceneTarget = sceneName;

        GetComponent<HackingMinigame>().StartHack(sceneName);

        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}



