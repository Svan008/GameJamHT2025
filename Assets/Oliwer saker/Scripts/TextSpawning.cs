using UnityEngine;

public class TextSpawning : MonoBehaviour
{
    [SerializeField] private float elapsedTime = 0f;
    private bool timerStarted = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Start counting if timer started
        if (timerStarted)
        {
            elapsedTime += Time.deltaTime;

            // Optional: trigger animation after 4 seconds
            if (elapsedTime >= 4f)
            {
                anim.SetBool("StartPlaying", true);
            }
        }

        // If Space is pressed → destroy text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timerStarted = true;
        }
    }
}

//Oliwer