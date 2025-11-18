using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText; //Bu yere direk unityin içinde obje koyuyoruz.
    [SerializeField] GameObject gameOverText; //buda obje
    [SerializeField] float startTime = 5f;

    float timeLeft;
     bool gameOver = false;

    // public bool GameOver
    // {
    //     get { return gameOver;}
    // }
    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {

       DecreaseTime();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    public bool ReturnGameOver()
    {
        return gameOver;
    }

    void DecreaseTime()
    {
         if ( gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1"); //1 decimal play gösterrir . 4.50

        if(timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false; //You are not able to move after this.
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
