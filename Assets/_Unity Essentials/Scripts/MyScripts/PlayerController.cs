using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;
    public float jumpForce = 1.0f;
    public float restoringTorque = 1.0f;
    public bool stuntMode;
    public bool canJump;
    public bool canRight;

    private bool stunting; // Whether the player is flipping in the air or not.
    private Vector3 forwardDirectionWhileStunting; // Holds the last transform.forward of the player right before stunting

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        // stunting = false;
        // canJump = false;
        canRight = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Jump") && (canJump || canRight)) {

            float truckRollRotation = transform.rotation.eulerAngles.z;
            int truckRollRotationSign = (truckRollRotation < 180) ? -1 : 1;
            float truckPitchRotation = transform.rotation.eulerAngles.x;
            int truckPitchRotationSign = (truckPitchRotation < 180) ? -1 : 1;

            // If truck is upright, then perform a normal jump
            if (canJump && (truckRollRotation < 45 || truckRollRotation > 315) && (truckPitchRotation < 60 || truckPitchRotation > 300)) {

                canJump = false;
                rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
            }
            else if (canRight && ((truckRollRotation > 60 && truckRollRotation < 180) || (truckRollRotation >= 180 && truckRollRotation < 300))) {

                rb.AddForce(1 * Vector3.up, ForceMode.VelocityChange); //little hop
                rb.AddTorque(truckRollRotationSign * restoringTorque * transform.forward);
            }
            else if (canRight && ((truckPitchRotation > 80 && truckPitchRotation < 100) || (truckPitchRotation > 260 && truckPitchRotation < 280))) {

                rb.AddForce(1 * Vector3.up, ForceMode.VelocityChange); //little hop
                rb.AddTorque(truckPitchRotationSign * restoringTorque * transform.right);
            }
        }
    }

    private void FixedUpdate() {

        // Move player forwards based on Vertical input
        Vector3 forwardMovement;
        float moveVertical = Input.GetAxis("Vertical");
        if (!stunting) {
            forwardMovement = speed * moveVertical * Time.fixedDeltaTime * transform.forward;
            float truckPitchRotationInRadians = transform.rotation.eulerAngles.x * Mathf.Deg2Rad;
            forwardMovement *= Mathf.Abs(Mathf.Cos(truckPitchRotationInRadians));
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

    private void OnCollisionStay(Collision other) {
        canRight = true;
    }

    private void OnCollisionExit(Collision other) {

        if (!stuntMode) {
            canRight = false;
        }
    }
}
