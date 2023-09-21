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
  [SerializeField]
  private Collectibles collectibles;
  [SerializeField]
  private List<MeshRenderer> materialsToChange;

  bool hovering = false;

  void Start() {
    }

  void Update() {
    if (Inspection.activeSelf)
      return;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    // makes a ray that aims at what ur mouse is over .transform.parent  gameObject.transform.GetChild(0).gameObject
    RaycastHit hit;

    //making a new color for the box in order to make it transparent a lil cuz u can t just edit the alpha
    Color color = GetComponentInChildren<MeshRenderer>().material.color;

    hovering = false;
    //Debug.DrawRay(Camera.main.transform.position, ray.direction * 30.0f, Color.red, 3.0f);

    if (GetComponent<Collider>().Raycast(ray, out hit, 30f)) // 10f is max distance at which the effect works
    {
      Debug.Log("hovering over " + gameObject.name);
      hovering = true;
      color.a = 0.6f;
      if (Input.GetMouseButtonDown(0)) {
        if (gameObject != dissectionVape) { 
          exitButton.SetActive(true);
        }
        Inspection.SetActive(true);
        inspectionObj.Inspect(index);
        
        if (gameObject.CompareTag("Collectible")) {
          exitButton.SetActive(false);
        }
      }

    }
    else color.a = 1.0f;

    GetComponent<MeshRenderer>().material.color = color;

    if (materialsToChange.Count > 0) {
      if (hovering) {
        materialsToChange.ForEach(meshRenderer => 
        meshRenderer.material.SetFloat("_Lerp", Mathf.Lerp(materialsToChange[0].material.GetFloat("_Lerp"), 0.1f, 0.2f)));
      }
      else {
        materialsToChange.ForEach(material => 
        material.material.SetFloat("_Lerp", Mathf.Lerp(materialsToChange[0].material.GetFloat("_Lerp"), 0, 0.2f)));
      }
    }
 
  }
}
