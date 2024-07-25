using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 5.0f;
    public float turnSpeed = 120.0f;
    private bool stunting; // Whether the player is flipping in the air or not.
    private Vector3 forwardDirectionWhileStunting; // Holds the last transform.forward of the player right before stunting

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        stunting = false;
    }

    // Update is called once per frame
    void Update() {

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
    }
}
