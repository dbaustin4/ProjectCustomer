using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectScript : MonoBehaviour {

  [SerializeField]
  private bool usePressed = false;

  void Start() {
    Debug.Log("hi mara :)");
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
}
