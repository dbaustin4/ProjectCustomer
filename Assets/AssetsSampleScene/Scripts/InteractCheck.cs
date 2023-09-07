using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCheck : MonoBehaviour {

  //[SerializeField] //so we can see in editor if it's true or false
  //private bool usePressed = false;

  [SerializeField] 
  private bool canInteract = false;

  private GameObject desk;
  private GameObject vape1;

  private void Start() {
    desk = GameObject.FindGameObjectWithTag("Desk"); //find obj with Desk tag
    vape1 = GameObject.FindGameObjectWithTag("Vape1"); //find obj with Vape1 tag
  }

  private void Update() {
    KeyCheck();
  }

  private void FixedUpdate() {
    
  }

  private void KeyCheck() { //check keypress for interaction
    if (canInteract) {
      if (Input.GetKeyDown(KeyCode.E)) {
        /*if (!usePressed) usePressed = true; //if false set to true
        else if (usePressed) usePressed = false; //if true set to false */ 
        vape1.GetComponent<InspectScript>().Inspect(); //execute Inspect method from InspectScript (attached to obj vape1)
        canInteract = false;
      }
    }
  }

  private void OnCollisionEnter(Collision collision) { //check collision
    if (collision.gameObject == desk) { //check if we collide with desk
      canInteract = true;
    }
  }
}
