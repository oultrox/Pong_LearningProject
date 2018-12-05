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
	
    // -------- M�todos API ---------------
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
            //algoritmo de ubicaci�nd de la c�mara para generar el shake con la funci�n matem�tica de Random.insideUnitSphere.
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

    // ----------- M�todos custom --------
    // M�todo est�tico para llamarlo desde cualquier otro script de manera m�s limpia.
    public static void Shake(float time, float amount)
    {
        shakeDuration = time;
        shakeAmount = amount;
    }
}
