using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour {
  //ill add comments to everything later i promis :)
  [SerializeField]
  private AudioClip[] voiceLines;
  [SerializeField]
  private Transform[] targetPositions;
  [SerializeField]
  private GameObject[] vapePieces;
  [SerializeField]
  private Camera mainCamera;
  [SerializeField]
  private GameObject collectButton;
  [SerializeField]
  private int collectableAmount;

  private bool voicelinePlaying = false;
  private bool[] pieceCollected;
  private int amountCollected = 0;
  private int currentSoundIndex = 0;
  private Hover killHover;

  private void Start() {
    pieceCollected = new bool[vapePieces.Length];
  }

  private void Update() {
    CheckObject();
  }

  private void CheckObject() {
    if (!voicelinePlaying && Input.GetMouseButtonDown(0)) {
      Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

      RaycastHit hitInfo;
      if (Physics.Raycast(ray, out hitInfo)) {
        GameObject obj = hitInfo.collider.gameObject;

        for (int i = 0; i < vapePieces.Length; i++) {
          if (obj == vapePieces[i]) {
            Debug.Log("piece " + i + " clicked");
            PlaySound(vapePieces[i]);

            killHover = vapePieces[i].GetComponent<Hover>();
            
            if (amountCollected < collectableAmount) {
              amountCollected += 1;
              TeleportToTarget(vapePieces[i], i);
              vapePieces[i] = null;
            }
            else {
              Debug.Log("allow other voiceline to play");
            }

            break; //end loop after finding clicked piece
          }
        }
      }
    }
  }

  private void PlaySound(GameObject obj) {
    AudioSource audioSource = obj.GetComponent<AudioSource>();
    if (audioSource != null && voiceLines.Length > currentSoundIndex && voiceLines[currentSoundIndex] != null) {
      voicelinePlaying = true;
      audioSource.PlayOneShot(voiceLines[currentSoundIndex]);
      StartCoroutine(WaitForVoiceline(audioSource.clip.length));
      currentSoundIndex++;
    }
  }

  IEnumerator WaitForVoiceline(float duration) {
    yield return new WaitForSeconds(duration);
    voicelinePlaying = false;
    collectButton.SetActive(true);
  }

  private void TeleportToTarget(GameObject obj, int targetIndex) {
    if (targetIndex >= 0 && targetIndex < targetPositions.Length) {
      Transform target = targetPositions[targetIndex];
      obj.transform.position = target.position;
    }
  }


  public void SetCollectedTrue(int index) {
    if (index >= 0 && index < pieceCollected.Length) {
      pieceCollected[index] = true;
      Debug.Log("collected " + index + " is true");
    }
  }

  public void InactivateCollectButtonAndHover() {
    collectButton.SetActive(false);
    killHover.enabled = false;
  }
}
