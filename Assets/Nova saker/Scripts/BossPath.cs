using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPath : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public GameObject PointC;
    public GameObject PointD;//referar till båda punkterna i unity
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;// så man har en start punkt
        anim.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;// ger vilke direction enemyn vill gå vilket är mot currentPoint

        

        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);// om punkten är punkt B gå mot punkte C
        }
        else if (currentPoint == PointC.transform)
        {
            rb.velocity = new Vector2(-speed, 0);// om punkten är punkt C gå mot punkte D
        }
        else if (currentPoint == PointD.transform)
        {
            rb.velocity = new Vector2(speed, 0);// om punkten är punkt D gå mot punkte A
        }
        else if (currentPoint == PointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);// om punkten är punkt A gå mot punkte B
        }

        

        if (Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == PointA.transform)//om enmyn har nått currentpoint och den är B ska currnet point sättas till punktA
        {
            print("byt till B");
            flip();
            currentPoint = PointB.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == PointB.transform)//om enmyn har nått currentpoint och den är A ska currnet point sättas till punktB
        {
            print("byt till C");
            flip();
            currentPoint = PointC.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == PointC.transform)//om enmyn har nått currentpoint och den är B ska currnet point sättas till punktA
        {
            print("byt till D");
            flip();
            currentPoint = PointD.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == PointD.transform)//om enmyn har nått currentpoint och den är B ska currnet point sättas till punktA
        {
            print("byt till A");
            flip();
            currentPoint = PointA.transform;
        }
    }
    private void flip() 
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale; // gör så den flipar
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointC.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
        // gör punkterna tydligare
    }
}
