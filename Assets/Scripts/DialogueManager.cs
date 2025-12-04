using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public GameObject continueHint;

    private Queue<string> dialogueLines = new Queue<string>();
    private bool dialogueActive = false;

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(string[] lines)
    {
        dialogueLines.Clear();

        foreach (string line in lines)
            dialogueLines.Enqueue(line);

        dialogueActive = true;

        dialogueBox.SetActive(true);
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
        dialogueText.text = line;
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
        continueHint.SetActive(false);
    }

    void Awake()
    {
        if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);   // <--- REQUIRED
    }
    else
    {
        Destroy(gameObject);
    }
    }

}

