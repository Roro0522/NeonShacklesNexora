using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;   

public class AutoReturnToMenu : MonoBehaviour
{
    public float delay = 10f;

    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(delay);

        if (FadeTransition.Instance != null)
            FadeTransition.Instance.FadeToScene("MainMenu");
        else
            SceneManager.LoadScene("MainMenu");
    }
}
