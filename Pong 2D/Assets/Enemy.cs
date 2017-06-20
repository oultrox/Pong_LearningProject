using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform theBall;
    public float speed = 1;
    private Rigidbody2D rg2D;
    private float ballposY;
    private void Awake()
    {
        rg2D = this.GetComponent<Rigidbody2D>();       
    }
    void Update()
    {
        ballposY = theBall.transform.position.y + Ball.random;
        
        // 0 is center screen
        if (theBall.position.x != 0)
        {
            //transform.position = new Vector3(transform.position.x, theBall.position.y, transform.position.z);
            if (ballposY > rg2D.transform.position.y + 0.2)
            {
                rg2D.velocity = new Vector2(rg2D.velocity.x, speed);
            }
            else if (ballposY < rg2D.transform.position.y - 0.2)
            {
                rg2D.velocity = new Vector2(rg2D.velocity.x, -speed);
            }
            else
            {
                rg2D.velocity = new Vector2(rg2D.velocity.x, 0);
            }
        }else
        {
            //rg2D.transform.position = new Vector2(0,rg2D.transform.position.y);
        }
    }
}
