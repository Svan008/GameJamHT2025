using UnityEngine;

public class TextDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && objectToDeactivate != null)
        {
            Debug.Log("Player entered deactivate zone!");
            objectToDeactivate.SetActive(false);
        }
    }
}

//Oliwer