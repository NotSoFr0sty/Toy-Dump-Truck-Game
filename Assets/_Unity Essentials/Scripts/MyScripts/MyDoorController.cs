using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour {

    private Animator animator;

    void Start() {

        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")) {

            animator.SetTrigger("Door_Open");
        }
    }
}
