using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rgBody2D;
    //El SerializeField permite a la variable privada modificarse en el inspector de Unity.
    [SerializeField] private float speed = 30;
	void Start ()
    {
        //Consigue el componente necesario para la traslación
        rgBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float v = Input.GetAxis("Vertical");
        this.rgBody2D.velocity = new Vector2(0, v) * speed;

	}
}
