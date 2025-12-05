using UnityEngine;

public class MemoryBit : MonoBehaviour
{
    public int emotionalScore = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name); 

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected item"); 
            EmotionalSystem.Instance.AddEmotion(emotionalScore);
            Destroy(gameObject);
        }
    }
}

