using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// toma el transform de sí mismo para la referencia posicional.
	[SerializeField] private Transform camTransform;
	// Define cuánto durará el shake y es la variable que se debe modificar para activar el shake.
	public static float shakeDuration = 0f;
	// Amplitud del shake. Mientras más grande el valor, más duro será.
	public static float shakeAmount = 0.7f;
	[SerializeField] private float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
    // -------- Métodos API ---------------
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
            //algoritmo de ubicaciónd de la cámara para generar el shake con la función matemática de Random.insideUnitSphere.
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
        {
            if (shakeDuration!=0)
            {
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
			
		}
	}
    // ----------- Métodos custom --------

    // Método estático para llamarlo desde cualquier otro script de manera más limpia.
    public static void Shake(float time, float amount)
    {

        shakeDuration = time;
        shakeAmount = amount;
    }
}
