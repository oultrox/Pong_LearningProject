using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

    private Rigidbody2D rgBody2D;
    //El SerializeField permite a la variable privada modificarse en el inspector de Unity.
    [SerializeField] private float speed = 30;
    
    // ------- Métodos API -----------
    void Start ()
    {
        //Consigue el componente necesario para la traslación
        rgBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    // Permite a través de los axis de los inputs que no sólo abarca teclado, moverse a través de la velocidad con un nuevo vector que toma las posiciones 
    // pertinentes para nosotros, que es el eje Y.
	void FixedUpdate ()
    {
        float v = Input.GetAxis("Vertical");
        this.rgBody2D.velocity = new Vector2(0, v) * speed;

	}
}
