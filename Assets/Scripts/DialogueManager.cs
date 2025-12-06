using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public CanvasGroup dialogueGroup;     
    public TextMeshProUGUI dialogueText;
    public GameObject continueHint;

    private Queue<string> dialogueLines = new Queue<string>();
    private bool dialogueActive = false;

    void Awake()
    {
        Instance = this;

        if (dialogueGroup != null)
        {
            dialogueGroup.alpha = 0f;
            dialogueGroup.interactable = false;
            dialogueGroup.blocksRaycasts = false;
        }

        if (continueHint != null)
            continueHint.SetActive(false);
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(string[] lines)
    {
        if (dialogueGroup == null)
        {
            Debug.LogError("DialogueManager: dialogueGroup not assigned!");
            return;
        }

        dialogueLines.Clear();
        foreach (string line in lines)
            dialogueLines.Enqueue(line);

        dialogueActive = true;

        dialogueGroup.alpha = 1f;
        dialogueGroup.interactable = true;
        dialogueGroup.blocksRaycasts = true;

        if (continueHint != null)
            continueHint.SetActive(true);

        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueLines.Dequeue();
        if (dialogueText != null)
            dialogueText.text = line;
    }

    void EndDialogue()
    {
        dialogueActive = false;

        if (dialogueGroup != null)
        {
            dialogueGroup.alpha = 0f;
            dialogueGroup.interactable = false;
            dialogueGroup.blocksRaycasts = false;
        }

        if (continueHint != null)
            continueHint.SetActive(false);
    }
}

