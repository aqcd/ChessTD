using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float horizontalInput;
    private float verticalInput;

    private float playerVelocity = 8.0f;

    void Start() {
        updatePlayerPosition();
    }

    void Update() {
        handleMovement();
        updatePlayerPosition();
    }

    void handleMovement() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, 0, verticalInput) * playerVelocity;
    }

    void updatePlayerPosition() {
        GameManager.playerPosition = transform.position;
    }
}
