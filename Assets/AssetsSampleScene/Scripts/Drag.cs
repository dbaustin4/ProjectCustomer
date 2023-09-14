using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour{


    //from here idk much it s just the tutorial
    private Vector3 lastPos, currPos; //bro said we need these so uhh
    private float rotationSpeed = -0.2f; // bro from tutorial said f speed is negative it goes WITH the mouse and if it s positive its inverted
    //i trust the bro 



    void Start(){
        
        lastPos= Input.mousePosition;

    }

    void Update(){

        if (Input.GetMouseButton(0)){ //getmousebutton returns true if it s pressed getmousebuttondown returns the frame or smth ??

            currPos = Input.mousePosition;
            Vector3 offset = currPos - lastPos;
            transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed);//this does the spinny around it s own axis
            //i did only horiz cuz idk how to do all the rotations (:
            
        }
        lastPos = Input.mousePosition;  


    }
}
