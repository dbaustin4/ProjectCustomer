using System;
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

    //dw abt the formatting it s 4am

    public GameObject Inspection; //the place where objects get inspected look in the project
    //there s like all the 'vapes' in a lil corner with a camera i ll explain the camera in person <3
    public InspectScript inspectionObj; //the array of vapes also look in the project it s basically the parent of the 3 obj that are gonna rotate
    public int index = 0; //yk what this is

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
       if (Input.GetKeyDown(KeyCode.E))
       {
                /*if (!usePressed) usePressed = true; //if false set to true
                else if (usePressed) usePressed = false; //if true set to false */
                //vape1.GetComponent<InspectScript>().Inspect(1); //execute Inspect method from InspectScript (attached to obj vape1)


                // CHANGES 

                Debug.Log("interact");

             //so u just get the whole 'mini scene' that has the camera and the rotating vapes and shid and enable it so it pops up
             Inspection.SetActive(true);
             inspectionObj.Inspect(index); //you put in index which vape u wanna show
        canInteract = false;
         }
        // array of vapes better seen in unity in the inspectobj thingie
    }
  }

  private void OnCollisionEnter(Collision collision) { //check collision
    if (collision.gameObject == desk) { //check if we collide with desk
      canInteract = true;
    }
  }
}
