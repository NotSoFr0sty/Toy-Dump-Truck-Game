using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public float RotationSpeed = 1.0f;
    public GameObject onCollectParticleEffect;
    private PlayerController player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {

        transform.Rotate(0, RotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other) {

        Destroy(gameObject);
        Instantiate(onCollectParticleEffect, transform.position, transform.rotation);
        player.AddToScore(1);

    }
}
