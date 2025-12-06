using UnityEngine;

public class HackingTerminal : MonoBehaviour
{
    public string sceneToLoad = "Hope";
    public HackingUI hackingUI;

    private bool inside = false;

    void Start()
    {
        if (hackingUI == null)
            hackingUI = FindObjectOfType<HackingUI>();
    }

    void Update()
    {
        if (!inside || hackingUI == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            hackingUI.Open(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            inside = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            inside = false;
    }
}




