using UnityEngine;

public class FakeBullet : MonoBehaviour
{
    public float Speed = 3;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
