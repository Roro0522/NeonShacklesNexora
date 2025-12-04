using UnityEngine;

public class HackingTerminal : MonoBehaviour
{
    public string sceneToLoad = "Hope"; // set Scene2 or Scene3 here

    private bool inside;

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            HackingUI.Instance.Open(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) inside = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) inside = false;
    }
}


