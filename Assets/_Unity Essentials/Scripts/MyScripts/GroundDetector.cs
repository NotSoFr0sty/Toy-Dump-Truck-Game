using UnityEngine;

public class GroundDetector : MonoBehaviour {
    public GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {

        if (!other.CompareTag("Player")) {

            playerController.canJump = true;
        }
    }
}
