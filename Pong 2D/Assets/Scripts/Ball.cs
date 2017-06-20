using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Variables
    [SerializeField] private float speed = 30;
    private Rigidbody2D rgBody2D;
    public GameManager gameManager;
    private float xOriginalPos;
    private float yOriginalPos;
    public static float random;
    private TrailRenderer lineRender;

    // -----------API métodos-----------
    // Use this for initialization
    void Start ()
    {

        this.rgBody2D = GetComponent<Rigidbody2D>();
        this.rgBody2D.velocity = Vector2.right * speed;
        xOriginalPos = this.transform.position.x;
        yOriginalPos = this.transform.position.y;
        random = 0;
        lineRender = GetComponent<TrailRenderer>();

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
            NewRandom();
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
            StartCoroutine(RestartBall());
        }
        if (collision.gameObject.name == "WallRight")
        {
            gameManager.AddPointPlayer();
            StartCoroutine(RestartBall());
        }
        //¡Shake!
        CameraShake.Shake(0.1f,0.5f);
    }

    // -----------Métodos custom-----------
    IEnumerator RestartBall()
    {
        
        this.speed = 0;
        this.rgBody2D.velocity = Vector2.right * speed;
        //esta forma es como modificamos la posición de un objeto, utilizamos su transform.position pero como eso es una propiedad ReadOnly, lo que hacemos es
        //substituirla con nuestras coordenadas deseadas.
        this.transform.position = new Vector3(xOriginalPos, yOriginalPos);
        //Desactivamos el Trail effect
        lineRender.enabled = false;
        lineRender.time = 0;
        yield return new WaitForSeconds(0.5f);
        this.speed = 30;
        //Aquí le damos la velocidad.
        this.rgBody2D.velocity = Vector2.right * speed;
        random = 0;
        //Activamos trail effect
        lineRender.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lineRender.time = 0.7f;
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

    private void NewRandom()
    {
        random = UnityEngine.Random.Range(-2f, 2f);
    }

}
