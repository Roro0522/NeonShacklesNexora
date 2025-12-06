using UnityEngine;
using UnityEngine.UI;

public class EmotionalEffects : MonoBehaviour
{
    public static EmotionalEffects Instance;

    public Image tint;
    public Color oppressedColor = new Color(0.05f, 0.05f, 0.1f);
    public Color hopefulColor = new Color(0.4f, 0.8f, 1f);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateEnvironment(EmotionalSystem.Instance.emotionalScore);
    }

    public void UpdateEnvironment(int emotionalScore)
    {
        float t = Mathf.InverseLerp(0, 10, emotionalScore);
        tint.color = Color.Lerp(oppressedColor, hopefulColor, t);
    }
}

