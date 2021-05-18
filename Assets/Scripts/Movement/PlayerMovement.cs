using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float horizontalInput;
    private float previousHorizontalInput;
    private float verticalInput;
    private float previousVerticalInput;

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
        Rigidbody rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = new Vector3(Mathf.Abs(horizontalInput) >= Mathf.Abs(previousHorizontalInput) ? horizontalInput : 0, 
                                                  0, 
                                                  Mathf.Abs(verticalInput) >= Mathf.Abs(previousVerticalInput) ? verticalInput : 0) * playerVelocity;
        previousHorizontalInput = horizontalInput;
        previousVerticalInput = verticalInput;
    }

    void updatePlayerPosition() {
        GameManager.playerPosition = transform.position;
    }
}
