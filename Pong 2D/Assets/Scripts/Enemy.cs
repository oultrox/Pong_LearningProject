using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform theBall;
    public float speed = 30;
    private Rigidbody2D rg2D;
    private float ballposY;

    // ------- Métodos API ---------
    private void Awake()
    {
        rg2D = this.GetComponent<Rigidbody2D>();       
    }
    void Update()
    {
        // esto toma la posicion en la que el enemigo piensa que la pelota está.
        ballposY = theBall.transform.position.y + Ball.random;
        
        // 0 es el centro de la pantalla, si la pelota no está ahí significa que estamos jugando.
        if (theBall.position.x != 0)
        {
            //La IA se basa en preguntar en base a las coordenadas Y de la supuesta posición de la pelota respecto a su posición Y.
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
            //Si la pelota está en 0 reiniciamos la posicion del enemigo.
            rg2D.transform.position = new Vector2(rg2D.transform.position.x, theBall.transform.position.y - 0.1f);
        }
    }
}
