using UnityEngine;

public class FakeBullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    //get bulleten en hastighet Vincent
    public float Speed = 3;
    private void Update()
    {
        //gör att bulleten använder hastigheten för att röra på sig Vincent
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //när bullet kolliderar försvinner den Vincent
        Destroy(gameObject);
    }
}
