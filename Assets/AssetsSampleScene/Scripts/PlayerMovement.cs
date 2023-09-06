using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField]
  public float walkForce;

  [SerializeField]
  private float turnForce;

  [SerializeField]
  private float maxWalkSpeed;

  Vector3 walk;
  Rigidbody rb;

  [SerializeField]
  private bool canWalk = true;

  private bool isWalking = false; //check if we're walking


  private void Start() {
    rb = GetComponent<Rigidbody>();
  }

  private void Update() {
    Walking();
  }

  private void FixedUpdate() {
    if (rb.velocity.magnitude < maxWalkSpeed) {
      rb.AddForce(walk.z * walkForce * transform.forward);
    }

    if (rb.velocity.magnitude < maxWalkSpeed) {
      rb.AddForce(walk.x * walkForce * transform.right);
    }
  }

  private void Walking() {
    if (canWalk) {
      walk = Vector3.zero;

      if (Input.GetKey(KeyCode.W)) {
        walk.z += 1;
      }
      /*if (Input.GetKey(KeyCode.S)) {
        walk.z += -1;
      }
      if (Input.GetKey(KeyCode.A)) {
        walk.x -= 1;
      }
      if (Input.GetKey(KeyCode.D)) {
        walk.x += 1;
      }*/

      isWalking = walk != Vector3.zero; //check if we're walking
    }
  }
}
