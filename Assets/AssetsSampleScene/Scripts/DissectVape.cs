using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissectVape : MonoBehaviour {

  [SerializeField]
  private GameObject[] pieces; //array to hold the pieces of the vape
  [SerializeField]
  private AudioClip[] voiceLines; //array to hold the voice lines
  [SerializeField]
  private float flySpeed = 1000f; //how fast the obj flies away
  [SerializeField]
  private GameObject exitButton; //exit button

  private AudioSource audioSource; //audio 
  private bool canDissect = true; //bool to check if we can dissect
  private int currentPiece = 0; //index to keep track of currentPiece 
  
  private void Start() {
    audioSource = GetComponent<AudioSource>(); //get AudioSource component and assign to audioSource
  }

  private void Update() {
    Dissect(); //call Dissect method
  }

  private void Dissect() {
    if (Input.GetKeyDown(KeyCode.E) && canDissect) { //if E pressed and if canDissect is true
      if (currentPiece < pieces.Length) { //check if currentPiece is less than length of pieces array
        canDissect = false; //say we can't dissect anymore
        pieces[currentPiece].GetComponent<Rigidbody>().AddForce(transform.up * flySpeed); //makes the obj fly up

        if (currentPiece < voiceLines.Length && voiceLines[currentPiece] != null) { //check if currentPiece is in range for voiceLines array and if it's not null
          audioSource.clip = voiceLines[currentPiece]; //set the audio to the current one in the array
          audioSource.Play(); //plays the audio
          StartCoroutine(EnableDissectionAfterVoiceLine(audioSource.clip.length)); //wait until audio clip is done playing before continueing
        }
        StartCoroutine(DisappearAfterDelay(pieces[currentPiece], 5f)); //make piece disappear after 5 seconds
        currentPiece++; //increment currentPiece by 1
      }
      else {
        exitButton.SetActive(true); //make exit button appear again
      }
    }
  }

  IEnumerator EnableDissectionAfterVoiceLine(float delay) { //creates a delay before you can dissect next obj
    yield return new WaitForSeconds(delay); //wait for the delay amount of time
    canDissect = true; //say we can dissect again
  }

  IEnumerator DisappearAfterDelay(GameObject obj, float delay) { //make obj disappear after a delay
    yield return new WaitForSeconds(delay); //wait for the delay amount of time
    if (obj != null) { //check if obj still exists (in case it got destroyed before delay)
      obj.SetActive(false); //disable obj
    }
  }
}
