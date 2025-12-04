using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition Instance;

    public Image fadeImage; 
    public float fadeTime = 1f;

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
            return;
        }

        Color c = fadeImage.color;
        c.a = 0f;                        
        fadeImage.color = c;
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeRoutine(sceneName));
    }

    IEnumerator FadeRoutine(string scene)
    {
        float t = 0;
        Color c = fadeImage.color;

        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeTime);
            fadeImage.color = c;
            yield return null;
        }

        SceneManager.LoadScene(scene);

        yield return null; 

        t = 0;
        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            c.a = Mathf.Lerp(1, 0, t / fadeTime);
            fadeImage.color = c;
            yield return null;
        }
    }
}


