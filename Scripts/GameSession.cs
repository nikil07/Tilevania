using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    int score = 0;


    private void Awake()
    {
        int numberOfSession = FindObjectsOfType<GameSession>().Length;
        if (numberOfSession > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void processPlayerDeath()
    {
        if (playerLives > 1) {
            takeLife();
        }
        else {
            resetGameSession();
        }
    }

    public void takeLife() {
        playerLives--;
        livesText.text = playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void addPoints(int points){
        score += points;
        scoreText.text = score.ToString();
    }

    private void resetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
