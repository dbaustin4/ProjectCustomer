using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCheck : MonoBehaviour {

  [SerializeField]
  private bool usePressed = false;
  [SerializeField]
  private bool canInteract = false;

  private GameObject desk;

  void Start() {
    desk = GameObject.FindGameObjectWithTag("Desk");
  }

  void Update() {
    CheckInput();
  }

  private void FixedUpdate() {
    
  }

  private void CheckInput() {
    if (Input.GetKeyDown(KeyCode.E)) {
      if (!usePressed) usePressed = true;
      else if (usePressed) usePressed = false;
    }
  }

  private void Interaction() {
    /*if (canInteract) {

    }*/
  }

  private void OnCollisionEnter(Collision collision) {
     if(collision.gameObject == desk) {
      canInteract = true;
      Debug.Log("collided with desk");
    }
  }
}
