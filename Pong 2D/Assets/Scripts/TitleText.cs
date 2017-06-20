using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleText : MonoBehaviour {

    [SerializeField] private int textType;

    //Dependiendo del numero del tipo del texto el código actuará diferente cuando se active el trigger de clickearlo.
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
