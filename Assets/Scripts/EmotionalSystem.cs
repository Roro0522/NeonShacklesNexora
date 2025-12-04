using UnityEngine;

public class EmotionalSystem : MonoBehaviour
{
    public static EmotionalSystem Instance;

    public int emotionalScore = 0;

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

    public void AddEmotion(int value)
    {
        emotionalScore += value;
        
        
        if (EmotionalEffects.Instance != null)
            EmotionalEffects.Instance.UpdateEnvironment(emotionalScore);
    }
}

