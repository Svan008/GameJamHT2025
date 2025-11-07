using UnityEngine;

public class DestroyInRange : MonoBehaviour
{
    [Header("Keybinds")]
    [SerializeField] private KeyCode key1 = KeyCode.Space;
    [SerializeField] private KeyCode key2 = KeyCode.None; // Optional second key

    [Header("Settings")]
    [SerializeField] private float destroyRange = 5f; // 5 tiles = 5 units
    [SerializeField] private string playerTag = "Player";

    private Transform player;

    private void Start()
    {
        // Find player once by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning($"DestroyInRange: No object with tag '{playerTag}' found!");
        }
    }

    private void Update()
    {
        if (player == null) return;

        // Check distance
        float distance = Vector2.Distance(transform.position, player.position);

        // If player is close enough
        if (distance <= destroyRange)
        {
            // Check for either key
            if (Input.GetKeyDown(key1) || (key2 != KeyCode.None && Input.GetKeyDown(key2)))
            {
                Destroy(gameObject);
            }
        }
    }

    // Optional: visualize range in Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, destroyRange);
    }
}

//Oliwer