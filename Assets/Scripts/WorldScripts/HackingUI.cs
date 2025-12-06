using UnityEngine;

public class HackingUI : MonoBehaviour
{
    public GameObject panel;

    private HackingMinigame minigame;

    void Awake()
    {
        if (panel == null)
        {
            Debug.LogError("HackingUI: Panel is not assigned!");
            return;
        }

        minigame = panel.GetComponent<HackingMinigame>();

        if (minigame == null)
        {
            Debug.LogError("HackingUI: No HackingMinigame found on Panel!");
            return;
        }

        panel.SetActive(false);
    }

    public void Open(string sceneName)
    {
        if (minigame == null) return;

        panel.SetActive(true);
        Time.timeScale = 0f; 

        minigame.Begin(sceneName, this);
    }

    public void Close()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}


