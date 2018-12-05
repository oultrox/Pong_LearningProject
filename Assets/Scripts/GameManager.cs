using Eitrum;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : EiComponent {

    public int playerScore;
    public int enemyScore;
    public Text playerText;
    public Text enemyText;

    //------- API métodos ---------

    // Use this for initialization
    void Start ()
    {
        this.playerScore = 0;
        this.enemyScore = 0;
    }

    public void AddPointPlayer()
    {
        this.playerScore++;      
        this.playerText.text = this.playerScore + "";
    }
    public void AddPointEnemy()
    {
        this.enemyScore++;
        this.enemyText.text = this.enemyScore +"";
    }

    // ---------- Métodos custom -----------
    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }
}
