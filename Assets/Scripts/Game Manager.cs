using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private int targetFPS = 60;
    [SerializeField] private int gameState = 0;
    /* Game States: 
     *              0 - Sin comenzar
     *              1 - En partida
    */

    public int playerAScore = 0;
    public int playerBScore = 0;

    private TextMeshProUGUI ScoreA;
    private TextMeshProUGUI ScoreB;

    private Canvas tutorialUI;

    private GameObject ball;

    void Start() {
        Application.targetFrameRate = targetFPS;
        ball = GameObject.Find("Ball");
        ScoreA = GameObject.Find("ScoreA").GetComponent<TextMeshProUGUI>();
        ScoreB = GameObject.Find("ScoreB").GetComponent<TextMeshProUGUI>();
        tutorialUI = GameObject.Find("UI Tutorial").GetComponent<Canvas>();
    }

    void Update() {
        CheckInput();
    }

    private void CheckInput() {
        if (Input.GetKeyDown(KeyCode.R)) {
            //Reinicia la partida
            ball.GetComponent<BallController>().ResetBall();
            gameState = 0;
        }
        if(gameState == 0 && Input.GetKeyDown(KeyCode.Space)) {
            //Si el juego aun no comienza y se presiona la tecla space, da inicio a la partida
            ball.GetComponent<BallController>().StartRound();
            gameState = 1;

            //Oculta el tutorial si esta visible
            if (tutorialUI.enabled) { tutorialUI.enabled = false; }
        }
    }

    public void AddScore(string player) {
        if(player == "A") {
            playerAScore++;
        }
        if(player == "B") {
            playerBScore++;
        }
        gameState = 0;
        UpdateScore();
    }

    private void UpdateScore() {
        ScoreA.text = playerAScore.ToString();
        ScoreB.text = playerBScore.ToString();
    }
}
