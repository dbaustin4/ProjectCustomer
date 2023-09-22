using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour {

  [SerializeField]
  private RectTransform cursorRectTransform; //assign the image to this

  private void Start() {
    Cursor.visible = false; //hide cursor
  }

  void Update() {
    Vector3 mousePosition = Input.mousePosition; //variable mousePosition is current mousePos
    cursorRectTransform.position = mousePosition; //the pos of the img is the mousePosition
  }
}
