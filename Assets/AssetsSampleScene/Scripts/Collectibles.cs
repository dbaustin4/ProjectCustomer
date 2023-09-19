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
  private int voicelineIndex = 0;


  private bool voicelinePlaying = false;
  private bool[] pieceClicked;

  void Start() {
    pieceClicked = new bool[vapePieces.Length];
  }

  void Update() {
    CheckObject();
  }

  void CheckObject() {
    if (!voicelinePlaying && Input.GetMouseButtonDown(0)) {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      RaycastHit hitInfo;
      if (Physics.Raycast(ray, out hitInfo)) {
        GameObject obj = hitInfo.collider.gameObject;

        for (int i = 0; i < vapePieces.Length; i++) {
          if (obj == vapePieces[i] && !pieceClicked[i]) {
            Debug.Log("piece " + i + " clicked");
            pieceClicked[i] = true;
            TeleportToTarget(vapePieces[i], i);
            PlaySound(vapePieces[i], voicelineIndex);
            voicelineIndex +=1;
            break; //end loop after finding clicked vape
          }
        }
      }
    }
  }

  void PlaySound(GameObject obj, int soundIndex) {
    AudioSource audioSource = obj.GetComponent<AudioSource>();
    if (audioSource != null && voiceLines.Length > soundIndex && voiceLines[soundIndex] != null) {
      voicelinePlaying = true;
      audioSource.PlayOneShot(voiceLines[soundIndex]);
      StartCoroutine(WaitForVoiceline(audioSource.clip.length));
    }
  }

  IEnumerator WaitForVoiceline(float duration) {
    yield return new WaitForSeconds(duration);
    voicelinePlaying = false;
  }

  void TeleportToTarget(GameObject obj, int targetIndex) {
    if (targetIndex >= 0 && targetIndex < targetPositions.Length) {
      Transform target = targetPositions[targetIndex];
      obj.transform.position = target.position;
    }
  }
}
