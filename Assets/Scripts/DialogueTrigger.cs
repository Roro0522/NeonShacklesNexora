using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea]
    public string[] dialogueLines;

    public bool autoTrigger = false; 
    private bool playerInside = false;
    private bool hasTriggered = false;  // prevents repeat

    void Update()
    {
        // Player must press E (if autoTrigger == false)
        if (!autoTrigger && playerInside && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInside = true;

            // Auto-trigger ONCE
            if (autoTrigger && !hasTriggered)
            {
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void TriggerDialogue()
    {
        if (hasTriggered) return; // prevent repeats

        hasTriggered = true; 

        DialogueManager.Instance.StartDialogue(dialogueLines);
    }
}

