using UnityEngine;

public class FinalChoiceTerminal : MonoBehaviour
{
    private bool playerInside = false;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            FinalChoiceUIHandler.Instance.OpenUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerInside = false;
    }
}


