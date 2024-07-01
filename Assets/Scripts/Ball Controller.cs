using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField] private Vector2 initialForce = new Vector2(10, 0);

    private Rigidbody2D rb;
    private GameManager GM;

    private Vector3 initialPos;
    private Quaternion initialRotation;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();

        initialPos = transform.position;
        initialRotation = transform.rotation;
    }

    void Update() {
        CheckBallPos();
    }

    public void StartRound() {
        int side = Random.Range(0, 2);
        initialForce.y = Random.Range(-5, 5);
        //Genera valores aleatorios para el impulso inicial
        if(side == 0){ rb.AddForce(initialForce, ForceMode2D.Impulse); }
        else{ rb.AddForce(-initialForce, ForceMode2D.Impulse); }
        
    }

    public void ResetBall() {
        rb.velocity = new Vector3(0, 0, 0);
        rb.freezeRotation = true;
        transform.position = initialPos;
        transform.rotation = initialRotation;
        rb.freezeRotation = false;
    }

    private void CheckBallPos() {
        //Punto para el jugador izquierdo
        if(transform.position.x > 9) {
            GM.AddScore("A");
            ResetBall();
        }
        if(transform.position.x < -9) {
            GM.AddScore("B");
            ResetBall();
        }
    }

}
