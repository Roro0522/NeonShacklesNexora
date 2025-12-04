using UnityEngine;

public class EmotionDoor : MonoBehaviour
{
    [Header("Emotion Requirement")]
    public int requiredEmotion = 3;

    [Header("Dialogue When Emotion Is Too Low")]
    [TextArea]
    public string[] notEnoughEmotionLines;

    private bool opened = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (opened) return;

        int currentEmotion = EmotionalSystem.Instance.emotionalScore;

        if (currentEmotion >= requiredEmotion)
        {
            OpenDoor();
        }
        else
        {
            ShowEmotionDialogue();
        }
    }

    void OpenDoor()
    {
        opened = true;

        foreach (Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.enabled = false;

        this.enabled = false;
    }

    void ShowEmotionDialogue()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(notEnoughEmotionLines);
        }
        else
        {
            Debug.LogWarning("DialogueManager not found in scene!");
        }
    }
}


