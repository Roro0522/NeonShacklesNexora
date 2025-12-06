using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea]
    public string[] dialogueLines;

    public bool autoTrigger = false; 
    private bool playerInside = false;
    private bool hasTriggered = false;  

    void Update()
    {

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
        if (hasTriggered) return; 

        hasTriggered = true; 

        DialogueManager.Instance.StartDialogue(dialogueLines);
    }
}

