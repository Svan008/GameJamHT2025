using UnityEngine;

public class FakeBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
