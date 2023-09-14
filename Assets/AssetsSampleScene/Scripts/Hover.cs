using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {
  // same shid from interactCheck but here    

  public GameObject Inspection; //the place where objects get inspected look in the project
                                //there s like all the 'vapes' in a lil corner with a camera i ll explain the camera in person <3

  public InspectScript inspectionObj; //the array of vapes also look in the project it s basically the parent of the 3 obj that are gonna rotate

  public int index = 0; //yk what this is

  [SerializeField]
  private GameObject dissectionVape;
  [SerializeField]
  private GameObject exitButton;

  void Start() {

  }

  void Update() {
    if (Inspection.active)
      return;
    Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
    // makes a ray that aims at what ur mouse is over .transform.parent  gameObject.transform.GetChild(0).gameObject
    RaycastHit hit;

    //making a new color for the box in order to make it transparent a lil cuz u can t just edit the alpha
    Color color = GetComponent<MeshRenderer>().material.color;


    if (GetComponent<Collider>().Raycast(ray, out hit, 10f)) // 10f is max distance at which the effect works
    {
      Debug.Log("hovering over " + gameObject.name);

      color.a = 0.6f;
      if (Input.GetMouseButtonDown(0)) {
        if (gameObject != dissectionVape) exitButton.SetActive(true);

        Inspection.SetActive(true);
        inspectionObj.Inspect(index);
      }

    }
    else color.a = 1.0f;

    GetComponent<MeshRenderer>().material.color = color;

  }
}
