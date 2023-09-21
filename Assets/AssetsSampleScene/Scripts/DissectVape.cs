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
  private GameObject exitButton;

  private AudioSource audioSource;
  private bool canDissect = true;
  private int currentPiece = 0;
  
  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void Update() {
    Dissect();
  }

  private void Dissect() {
    if (Input.GetKeyDown(KeyCode.E) && canDissect) {
      if (currentPiece < pieces.Length) {
        canDissect = false;
        pieces[currentPiece].GetComponent<Rigidbody>().AddForce(transform.up * flySpeed); //makes the obj fly up

        if (currentPiece < voiceLines.Length && voiceLines[currentPiece] != null) {
          audioSource.clip = voiceLines[currentPiece]; //set the audio to the current one in the array
          audioSource.Play(); //plays the audio
          StartCoroutine(EnableDissectionAfterVoiceLine(audioSource.clip.length)); //wait until audio clip is done playing before continueing
        }
        StartCoroutine(DisappearAfterDelay(pieces[currentPiece], 5f)); //make piece disappear after 5 seconds
        currentPiece++;
      }
      else {
        exitButton.SetActive(true); //make exit button appear again
      }
    }
  }

  IEnumerator EnableDissectionAfterVoiceLine(float delay) { //creates a delay before you can dissect next obj
    yield return new WaitForSeconds(delay);
    canDissect = true;
  }

  IEnumerator DisappearAfterDelay(GameObject obj, float delay) { //make obj disappear after a delay
    yield return new WaitForSeconds(delay);

    //check if obj still exists (in case it was destroyed before the delay)
    if (obj != null) {
      obj.SetActive(false); //hide obj
    }
  }
}
