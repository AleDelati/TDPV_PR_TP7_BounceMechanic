using UnityEngine;

public class PlatformController : MonoBehaviour {

    [SerializeField] private bool PlatfA = true;
    [SerializeField] private float PlatfSpeed = 3.0f;

    void Start() {
        
    }

    void Update() {
        CheckInput();
    }

    private void CheckInput() {
        if (PlatfA) {
            //Movimiento plataforma izquierda
            if(Input.GetKey(KeyCode.W) && transform.position.y < 5) {
                transform.position = transform.position + new Vector3(0, PlatfSpeed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.S) && transform.position.y > -5) {
                transform.position = transform.position - new Vector3(0, PlatfSpeed * Time.deltaTime, 0);
            }
        } else {
            //Movimiento plataforma derecha
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5) {
                transform.position = transform.position + new Vector3(0, PlatfSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -5) {
                transform.position = transform.position - new Vector3(0, PlatfSpeed * Time.deltaTime, 0);
            }
        }
    }

}
