using UnityEngine;

public class ActivateTextAfterTime : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float requiredTime = 3f; // seconds player must stay
    [SerializeField] private GameObject textToActivate; // Text2
    [SerializeField] private string playerTag = "Player";

    private float timer = 0f;
    private bool playerInside = false;
    private bool activated = false;

    private void Update()
    {
        if (playerInside && !activated)
        {
            timer += Time.deltaTime;

            if (timer >= requiredTime)
            {
                if (textToActivate != null)
                    textToActivate.SetActive(true);

                activated = true; // prevent multiple activations
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
