using UnityEngine;
using TMPro;

public class EmotionUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void LateUpdate()
    {
        if (EmotionalSystem.Instance == null)
        {
            text.text = "EMOTION: 0";
            return;
        }

        text.text = "EMOTION: " + EmotionalSystem.Instance.emotionalScore;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}







