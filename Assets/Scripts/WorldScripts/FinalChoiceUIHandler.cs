using UnityEngine;

public class FinalChoiceUIHandler : MonoBehaviour
{
    public static FinalChoiceUIHandler Instance;

    public GameObject uiRoot; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        uiRoot.SetActive(false);
    }

    public void OpenUI()
    {
        uiRoot.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PressConnect()
    {
        Time.timeScale = 1f;

        int emotion = EmotionalSystem.Instance.emotionalScore;

        if (emotion >= 4)
            FadeTransition.Instance.FadeToScene("Ending_Good");
        else
            FadeTransition.Instance.FadeToScene("Ending_Bad");
    }

    public void PressAbort()
    {
        Time.timeScale = 1f;
        uiRoot.SetActive(false);
    }
}

