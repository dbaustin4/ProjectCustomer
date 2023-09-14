using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectScript : MonoBehaviour {

  public GameObject[] InspectionObjects; // array with all the vapes
  private int currIndex; // picks which vape it shows

  void Start() {
    Debug.Log("hi mara :)");

  }

  public void Inspect() {
    Debug.Log("Inspect Executed");
  }

  public void Inspect(int index) { //put in which vape u want displayed when u interact

    Debug.Log("Inspect Executed");
    currIndex = index; //takes the index and makes it the currrent shown vape
    InspectionObjects[index].SetActive(true);//makes it active so u can see and rotate it
  }

  public void TurnOffInspect() {

    InspectionObjects[currIndex].SetActive(false); //turns it off bruh

  }


}

