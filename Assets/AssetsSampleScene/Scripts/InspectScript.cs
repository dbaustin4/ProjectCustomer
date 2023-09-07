using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectScript : MonoBehaviour, IDragHandler{

    [SerializeField]
    private bool usePressed = false;

    void Start(){
        Debug.Log("hi mara :)");

<<<<<<< Updated upstream
  }

  public void Inspect() {
    Debug.Log("Inspect Executed");
  }
=======
    }

    void Update(){
        //CheckInput();
    }

    private void FixedUpdate()
    {

    }


    public void OnDrag(PointerEventData eventData){

        Debug.Log("dragging");

    }
>>>>>>> Stashed changes
}

/*
private void CheckInput() {
  if (Input.GetKeyDown(KeyCode.E)) 
      {
    if (!usePressed) usePressed = true;
    else if (usePressed) usePressed = false;
  }
}*/