using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {
  [SerializeField]
  private AudioClip[] voiceLines; //array to hold all voicelines
  [SerializeField]
  private Transform[] targetPositions; //array to hold the target transform
  [SerializeField]
  private GameObject[] vapePieces; //array to hold all the collectible vape pieces
  [SerializeField]
  private Camera mainCamera; //main camera for ray
  [SerializeField]
  private GameObject collectButton; //collect button for (de)activating
  [SerializeField]
  private int collectableAmount; //amount of pieces to be collected

  private bool voicelinePlaying = false; //bool to check if a voiceline is playing
  private bool[] pieceCollected; //bool to check if a piece is collected
  private int amountCollected = 0; //check how many pieces are collected
  private int currentSoundIndex = 0; //to check which voiceline plays currently
  private Hover killHover; //to deactivate hover once a collectible is collected

  public bool doneCollecting = false; //public to let FinalAssembly know we're done collecting all the pieces

  private void Start() {
    pieceCollected = new bool[vapePieces.Length]; //initialize array to check if collected per piece
  }

  private void Update() {
    CheckObject(); //call CheckObject method
  }

  private void CheckObject() { //check objects if they are collectibles and if they are they get collected
    if (!voicelinePlaying && Input.GetMouseButtonDown(0)) { //if there's no voiceline playing and left mouse click was pressed
      Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //create ray from main camera to mouse position on screen

      RaycastHit hitInfo; //store info about the object that the ray hits
      if (Physics.Raycast(ray, out hitInfo)) { //check if ray hits any object and store info if true
        GameObject obj = hitInfo.collider.gameObject; //get game object that was hit by ray

        for (int i = 0; i < vapePieces.Length; i++) { //loop through every piece in the array vapePieces
          if (obj == vapePieces[i]) { //check if hit obj is equal to i from vapePieces array
            PlaySound(vapePieces[i]); //play sound linked to current vape piece
            killHover = vapePieces[i].GetComponent<Hover>(); //get Hover component of the current vape piece and assign it to disable hover 

            if (amountCollected < collectableAmount) { //if amount collected is less than collectable amount
              amountCollected += 1; //increment collected amount
              TeleportToTarget(vapePieces[i], i); //call TeleportToTarget method to move piece to the table
              vapePieces[i] = null; //set current vape piece to null to show it's collected
            }
            break; //end loop after finding clicked piece
          }
        }
      }
    }
    if (amountCollected == collectableAmount) doneCollecting = true; //if amount collected is equal to collectable amount set doneCollecting to true
  }

  private void PlaySound(GameObject obj) { //lets voiceline play
    AudioSource audioSource = obj.GetComponent<AudioSource>(); //get AudioSource component from provided GameObject
    if (audioSource != null && voiceLines.Length > currentSoundIndex && voiceLines[currentSoundIndex] != null) { //check if audio component exists & if there are voicelines & if current voiceline isn't null
      voicelinePlaying = true; //set voicelinePlaying to true to know there's one currently playing
      audioSource.PlayOneShot(voiceLines[currentSoundIndex]); //play current voiceline once
      StartCoroutine(WaitForVoiceline(audioSource.clip.length)); //wait for duration of the voiceline
      currentSoundIndex++; //increment current sound to move to the next voiceline
    }
  }

  IEnumerator WaitForVoiceline(float duration) { //make sure voiceline is done playing before continueing
    yield return new WaitForSeconds(duration); //wait for the duration of time
    voicelinePlaying = false; //once the wait is over voicelinePlaying gets set to false to indicate it's done
    collectButton.SetActive(true); //activate collectButton to collect the vape piece
  }

  private void TeleportToTarget(GameObject obj, int targetIndex) { //make vape piece teleport to target position
    if (targetIndex >= 0 && targetIndex < targetPositions.Length) { //check if targetIndex is in range
      Transform target = targetPositions[targetIndex]; //assign the Transform target to the targetPos of current index
      obj.transform.position = target.position; //set the position of obj to match targetPos
    }
  }

  public void SetCollectedTrue(int index) { //set pieceCollected bool to true for specific clicked piece
    if (index >= 0 && index < pieceCollected.Length) { //check if index is in range
      pieceCollected[index] = true; //set pieceCollected of index to true
    }
  }

  public void InactivateCollectButtonAndHover() { //inactiva collectButton and Hover script component once collected (done through "collect" button click)
    collectButton.SetActive(false); //disable collectButton
    killHover.enabled = false; //disable Hover script component
  }
}
