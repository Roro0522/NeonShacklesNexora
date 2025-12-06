using UnityEngine;

public class NPC_HighEmotion : MonoBehaviour
{
    public int requiredEmotion = 4;

    void Start()
    {
        if (EmotionalSystem.Instance == null)
        {
            Debug.LogWarning("NPC_HighEmotion: EmotionalSystem not found");
            return;
        }

        int emotion = EmotionalSystem.Instance.emotionalScore;
        gameObject.SetActive(emotion >= requiredEmotion);
    }
}
