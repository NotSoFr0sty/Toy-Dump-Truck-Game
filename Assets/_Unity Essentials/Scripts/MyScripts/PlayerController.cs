using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;
    public float jumpForce = 1.0f;
    public bool canJump;
    public bool canRight;

    private bool stunting; // Whether the player is flipping in the air or not.
    private Vector3 forwardDirectionWhileStunting; // Holds the last transform.forward of the player right before stunting

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        // stunting = false;
        // canJump = false;
        // canRight = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Jump") && (canJump || canRight)) {
            canJump = false;
            rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate() {

        // Move player forwards based on Vertical input
        Vector3 forwardMovement;
        float moveVertical = Input.GetAxis("Vertical");
        if (!stunting) {
            forwardMovement = speed * moveVertical * Time.fixedDeltaTime * transform.forward;
            // TODO: forwardMovement *= cosine yadayada...
        }
        else {
            forwardMovement = speed * moveVertical * Time.fixedDeltaTime * forwardDirectionWhileStunting;
        }
        rb.MovePosition(transform.position + forwardMovement);

        // Rotate player based on Horizontal input
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
