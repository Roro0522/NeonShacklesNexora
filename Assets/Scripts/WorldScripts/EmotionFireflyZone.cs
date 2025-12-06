using UnityEngine;

public class EmotionFireflyZone : MonoBehaviour
{
    public int requiredEmotion = 4;
    public ParticleSystem fireflies;

    void Start()
    {
        if (EmotionalSystem.Instance.emotionalScore >= requiredEmotion)
        {
            fireflies.Play();
        }
        else
        {
            fireflies.Stop();
            fireflies.gameObject.SetActive(false);
        }
    }
}
