using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAssembly : MonoBehaviour {

  [SerializeField]
  Collectibles collectibles;
  [SerializeField]
  private Transform targetPosition; // Set this in the inspector to be the position where the objects should converge
  [SerializeField]
  private GameObject[] collectedPieces; // List of objects that will move
  [SerializeField]
  private GameObject assembledVape; // The object that will be activated after the others reach the target
  [SerializeField]
  private float flySpeed = 5f; 

  private void Start() {

  }

  private void Update() {
    if (collectibles.doneCollecting) {
      Assemble();
    }
  }

  private void Assemble() {
    if (Input.GetKeyDown(KeyCode.E)) {
      for (int i = 0; i < collectedPieces.Length; i++) {
        collectedPieces[i].transform.position = Vector3.MoveTowards(collectedPieces[i].transform.position, targetPosition.position, flySpeed * Time.deltaTime);

        // If an object reaches the target position, deactivate it
        if (Vector3.Distance(collectedPieces[i].transform.position, targetPosition.position) < 0.01f) {
          collectedPieces[i].SetActive(false);

          // Check if all objects have reached the target position
          if (CheckAllObjectsDeactivated()) {
            assembledVape.SetActive(true);
          }
        }
      }
    }
  }

  bool CheckAllObjectsDeactivated() {
    foreach (var obj in collectedPieces) {
      if (obj.activeSelf) {
        return false;
      }
    }
    return true;
  }
}
