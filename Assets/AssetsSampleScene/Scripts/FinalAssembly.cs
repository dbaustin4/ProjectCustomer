using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAssembly : MonoBehaviour {

  [SerializeField]
  Collectibles collectibles;
  [SerializeField]
  CameraSwitch cameraSwitch;
  [SerializeField]
  private Transform targetPosition; // Set this in the inspector to be the position where the objects should converge
  [SerializeField]
  private GameObject[] collectedPieces; // List of objects that will move
  [SerializeField]
  private GameObject assembledVape; // The object that will be activated after the others reach the target
  [SerializeField]
  private float flySpeed = 5f;

  private bool assembling = false; // Flag to track if assembly is in progress

  private void Update() {
    if (collectibles.doneCollecting) {
      if (cameraSwitch.currentCamera == 10 && Input.GetKeyDown(KeyCode.E) && !assembling) {
        StartCoroutine(AssembleObjects());
      }
    }
  }

  private IEnumerator AssembleObjects() {
    assembling = true;

    //calculate the initial positions of collected pieces
    Vector3[] initialPositions = new Vector3[collectedPieces.Length];
    for (int i = 0; i < collectedPieces.Length; i++) {
      initialPositions[i] = collectedPieces[i].transform.position;
    }

    float elapsedTime = 0f;
    float journeyLength = Vector3.Distance(initialPositions[0], targetPosition.position);

    while (elapsedTime < journeyLength / flySpeed) {
      elapsedTime += Time.deltaTime;
      float fractionOfJourney = elapsedTime / (journeyLength / flySpeed);

      for (int i = 0; i < collectedPieces.Length; i++) {
        collectedPieces[i].transform.position = Vector3.Lerp(initialPositions[i], targetPosition.position, fractionOfJourney);
      }

      yield return null;
    }

    //deactivate all collected pieces
    for (int i = 0; i < collectedPieces.Length; i++) {
      collectedPieces[i].SetActive(false);
    }

    //activate the assembled object
    assembledVape.SetActive(true);

    assembling = false; //reset the assembling flag
  }
}
