using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// toma el transform de s� mismo para la referencia posicional.
	public Transform camTransform;
	// Define cu�nto durar� el shake y es la variable que se debe modificar para activar el shake.
	public static float shakeDuration = 0f;
	// Amplitud del shake. Mientras m�s grande el valor, m�s duro ser�.
	public static float shakeAmount = 0.7f;
	[SerializeField] private float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
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

    public static void Shake(float time, float amount)
    {

        shakeDuration = time;
        shakeAmount = amount;
    }
}
