using UnityEngine;

public class PersistentTint : MonoBehaviour
{
    private static PersistentTint instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

