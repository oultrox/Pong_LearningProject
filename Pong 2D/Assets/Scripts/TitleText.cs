using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleText : MonoBehaviour {

    [SerializeField] private int textType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SeleccionHUD()
    {
        if (this.textType == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (this.textType == 2)
        {
            Application.Quit();
        }
        


    }
}
