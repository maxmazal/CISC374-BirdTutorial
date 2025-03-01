using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool gameIsOver;

    public AudioSource scoreSound;  
    public AudioSource gameOverSound; 

    public Text highScoreText;
    public int highScore;

    public void Start()
    {
        gameIsOver = false;
        highScore = PlayerPrefs.GetInt("highScoreText",0);
        highScoreText.text = "High score: " + highScore.ToString();
    }

    public void checkHighScore(){
        if(playerScore > highScore){
            highScore = playerScore;
            PlayerPrefs.SetInt("highScoreText",highScore);
            highScoreText.text = "High score: " + highScore.ToString();
        }

    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameIsOver)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();


            if (scoreSound != null)
            {
                scoreSound.Play();
            }
        }
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            gameOverScreen.SetActive(true);
            
            if (gameOverSound != null)
            {
                gameOverSound.Play();
                checkHighScore();
            }
        }
    }
}
