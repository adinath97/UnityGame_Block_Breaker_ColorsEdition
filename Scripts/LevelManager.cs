using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject bodyText;
    [SerializeField] GameObject attributionText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject playerPaddle;
    [SerializeField] GameObject ball;
    public static bool startGame, playerWin;
    public static int bricksDestroyed;

    void Start()
    {
        youWinText.SetActive(false);
        gameOverText.SetActive(false);
        titleText.SetActive(true);
        bodyText.SetActive(true);
        attributionText.SetActive(true);
        startGame = false;
        playerWin = false;
        bricksDestroyed = 0;
        playerPaddle.GetComponent<SpriteRenderer>().enabled = false;
        ball.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !LoseCollider.playerLost) {
            titleText.SetActive(false);
            bodyText.SetActive(false);
            attributionText.SetActive(false);
            playerPaddle.GetComponent<SpriteRenderer>().enabled = true;
            ball.GetComponent<SpriteRenderer>().enabled = true;
            startGame = true;
        }

        if(LoseCollider.playerLost) {
            //reset level
            gameOverText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(bricksDestroyed >= 28) {
            //reset level
            youWinText.SetActive(true);
            playerWin = true;
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


    }
}
