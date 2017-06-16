using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Variables
    [SerializeField] private float speed = 20;
    private Rigidbody2D rgBody2D;
    public GameManager gameManager;
    private float xOriginalPos;
    private float yOriginalPos;

    // API métodos
    // Use this for initialization
    void Start ()
    {
        this.rgBody2D = GetComponent<Rigidbody2D>();
        this.rgBody2D.velocity = Vector2.right * speed;
        xOriginalPos = this.transform.position.x;
        yOriginalPos = this.transform.position.y;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        //preguntamos con qué colisionó.
        if (collision.gameObject.name == "RacketLeft")
        {
            // Calcular la ubicacion del golpe
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            //Calcular la direccion, hago el tamaño (lenght) del vector igual a 1 via .normalized, para eso sirve.
            Vector2 dir = new Vector2(1, y).normalized;
            
            //aplica la nueva velocidad.
            this.rgBody2D.velocity = dir * speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            // Calcular la ubicacion del golpe
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            //Calcular la direccion, hago el tamaño (lenght) del vector igual a 1 via .normalized, para eso sirve.
            Vector2 dir = new Vector2(-1, y).normalized;
                
            //aplica la nueva velocidad.
            this.rgBody2D.velocity = dir * speed;
        }

        if (collision.gameObject.name == "WallLeft")
        {
            gameManager.AddPointEnemy();
            this.RestartBall();
        }
        if (collision.gameObject.name == "WallRight")
        {
            gameManager.AddPointPlayer();
            this.RestartBall();
        }


    }

    //Métodos custom
    private void RestartBall()
    {
        this.speed = 20;
        //esta forma es como modificamos la posición de un objeto, utilizamos su transform.position pero como eso es una propiedad ReadOnly, lo que hacemos es
        //substituirla con nuestras coordenadas deseadas.
        this.transform.position = new Vector3(xOriginalPos, yOriginalPos);
        this.rgBody2D.velocity = Vector2.right * speed;
        
    }

    float HitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        //ASCII racket art:
        // ||  1 <- at the top of the racket
        // || 
        // ||  0 <-  at the middle of the racket
        // || 
        // || -1 <- at the bottonm of the racket.
        return (ballPos.y - racketPos.y) / racketHeight;
    }

}
