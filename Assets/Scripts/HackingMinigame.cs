using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingMinigame : MonoBehaviour
{
    public List<Button> nodes;
    public float allowedTime = 7f;

    public Color hintColor = Color.cyan;
    public Color normalColor = Color.white;
    public float hintDuration = 0.5f;

    private float timer;

    private HashSet<int> correctNodes = new HashSet<int>();
    private HashSet<int> clickedNodes = new HashSet<int>();

    private string targetScene; 

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void StartHack(string sceneToLoad)
    {
        targetScene = sceneToLoad;
        gameObject.SetActive(true);
    }

    void OnEnable()
    {
        timer = allowedTime;
        correctNodes.Clear();
        clickedNodes.Clear();

        PickCorrectNodes();
        AddButtonListeners();
        StartCoroutine(ShowHints());
    }

    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer <= 0)
            FailHack();
    }

    void PickCorrectNodes()
    {
        while (correctNodes.Count < 3)
            correctNodes.Add(Random.Range(0, nodes.Count));
    }

    void AddButtonListeners()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            int index = i;
            nodes[i].onClick.RemoveAllListeners();
            nodes[i].onClick.AddListener(() => OnNodeClicked(index));
        }
    }

    IEnumerator ShowHints()
    {
        foreach (int idx in correctNodes)
            nodes[idx].image.color = hintColor;

        yield return new WaitForSecondsRealtime(hintDuration);

        foreach (Button b in nodes)
            b.image.color = normalColor;
    }

    void OnNodeClicked(int idx)
    {
        if (correctNodes.Contains(idx))
        {
            clickedNodes.Add(idx);

            if (clickedNodes.Count == correctNodes.Count)
                SuccessHack();
        }
        else FailHack();
    }

    void SuccessHack()
    {
        Debug.Log("Hack success!");
        HackingUI.Instance.Close();

        if (string.IsNullOrEmpty(targetScene))
        {
            Debug.LogWarning("No scene target set! Make sure HackingUI.Open(sceneName) is used.");
            return;
        }

        FadeTransition.Instance.FadeToScene(targetScene);
    }

    void FailHack()
    {
        Debug.Log("Hack failed!");
        HackingUI.Instance.Close();
    }
}





