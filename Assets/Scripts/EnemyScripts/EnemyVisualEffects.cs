using UnityEngine;
using System.Collections;

public class EnemyVisualEffects : MonoBehaviour
{
    private SpriteRenderer sr;
    public float flashDuration = 0.1f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FlashWhite()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        Color original = sr.color;
        sr.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        sr.color = original;
    }

    public void PlayDeathEffect()
    {
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        sr.color = Color.red;

        float t = 0f;
        Vector3 originalScale = transform.localScale;

        while (t < 1f)
        {
            t += Time.deltaTime;

            transform.localScale = Vector3.Lerp(originalScale, new Vector3(originalScale.x, 0.1f, originalScale.z), t);

            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f - t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
