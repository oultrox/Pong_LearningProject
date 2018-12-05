using UnityEngine;
using System.Collections;
using Eitrum;

public class CameraShake : EiComponent
{
	[SerializeField] private Transform camTransform;
    [SerializeField] private float decreaseFactor = 1.0f;

    public static float shakeDuration = 0f;
	public static float shakeAmount = 0.7f;
	
	Vector3 originalPos;
	
    // -------- Métodos API ---------------
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
        SubscribeUpdate();
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	public override void  UpdateComponent(float timer)
	{
		if (shakeDuration > 0.1)
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
