using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour {

    public float RotationSpeed = 1.0f;
    public GameObject onCollectParticleEffect;
    private PlayerController player;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {

        transform.Rotate(0, RotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")) {

            if (!(currentScene.buildIndex == 0)) // Add to score only if the current scene is not the menu scene
                player.AddToScore(1);
            Destroy(gameObject);
            Instantiate(onCollectParticleEffect, transform.position, transform.rotation);
        }

    }
}
