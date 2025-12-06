using UnityEngine;

public class NPC_LowEmotion : MonoBehaviour
{
    public int maxEmotionAllowed = 3;

    private bool isActive = true;

    void Start()
    {
        UpdateVisibility();
    }

    void Update()
    {
        UpdateVisibility();
    }

    void UpdateVisibility()
    {
        if (EmotionalSystem.Instance == null)
            return;

        int emotion = EmotionalSystem.Instance.emotionalScore;

        bool shouldBeActive = emotion <= maxEmotionAllowed;

        if (isActive != shouldBeActive)
        {
            isActive = shouldBeActive;
            gameObject.SetActive(isActive);
        }
    }
}
