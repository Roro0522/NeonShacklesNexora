using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackingMinigame : MonoBehaviour
{
    [Header("Nodes")]
    public List<Button> nodes;

    [Header("Timing")]
    public float allowedTime = 7f;

    [Header("Visuals")]
    public Color hintColor = Color.cyan;
    public Color normalColor = Color.white;
    public float hintDuration = 0.5f;

    private float timer;

    private HashSet<int> correctNodes = new HashSet<int>();
    private HashSet<int> clickedNodes = new HashSet<int>();

    private string targetScene;
    private HackingUI owner;

    public void Begin(string sceneToLoad, HackingUI ui)
    {
        owner = ui;
        targetScene = sceneToLoad;

        SetupMinigame();
    }

    void SetupMinigame()
    {
        timer = allowedTime;
        correctNodes.Clear();
        clickedNodes.Clear();

        PickCorrectNodes();
        AddButtonListeners();

        StopAllCoroutines();
        StartCoroutine(ShowHints());
    }

    void Update()
    {
        if (!gameObject.activeInHierarchy) return;

        timer -= Time.unscaledDeltaTime;
        if (timer <= 0f)
        {
            FailHack();
        }
    }

    void PickCorrectNodes()
    {
        if (nodes == null || nodes.Count == 0)
        {
            Debug.LogError("HackingMinigame: No nodes assigned!");
            return;
        }

        while (correctNodes.Count < 3)
        {
            correctNodes.Add(Random.Range(0, nodes.Count));
        }
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
        else
        {
            FailHack();
        }
    }

    void SuccessHack()
    {
        Debug.Log("Hack success!");
        
        if (owner != null)
        owner.Close();

        if (string.IsNullOrEmpty(targetScene))

        return;
        
        if (FadeTransition.Instance != null)
        {
            FadeTransition.Instance.FadeToScene(targetScene);
        }
        
        else
        
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    void FailHack()
    {
        Debug.Log("Hack failed!");

        if (owner != null)
            owner.Close();
    }
}








