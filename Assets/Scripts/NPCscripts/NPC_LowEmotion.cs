using UnityEngine;

public class NPC_LowEmotion : MonoBehaviour
{
    public int maxEmotionAllowed = 3;

    void Start()
    {
        if (EmotionalSystem.Instance == null)
        {
            Debug.LogWarning("NPC_LowEmotion: EmotionalSystem not found");
            return;
        }

        int emotion = EmotionalSystem.Instance.emotionalScore;
        gameObject.SetActive(emotion <= maxEmotionAllowed);
    }
}
