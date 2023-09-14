using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject Inspection;

    [SerializeField]
    private List<Transform> targetTransforms = new List<Transform>(); //list of target pos & rot
    
    [SerializeField]
    private float transitionDuration = 2.0f; //transition duration
    
    [SerializeField]
    private int currentTarget = 0; //keep track of which target we are at
    
    private bool isTransitioning = false;

    void Start()
    {
        SetCameraToCurrentTarget(); //start off with camera pos/rot of the current obj script is attached to
    }
    private void Update()
    {

        if (Inspection.active)
            return;

        if (isTransitioning)
            return; //exit current method from executing

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetPreviousTarget(); //prev target pos/rot
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetNextTarget(); //next target pos/rot
        }
    }

    private void SetCameraToCurrentTarget()
    {
        if (currentTarget >= 0 && currentTarget < targetTransforms.Count)
        { //Check if currentTarget is a valid number in targetTransforms list
            transform.position = targetTransforms[currentTarget].position; //set current pos to obj this script is attached to
            transform.rotation = targetTransforms[currentTarget].rotation; //set current rot to obj this script is attached to
        }
    }

    private void SetPreviousTarget()
    { //go to previous pos/rot from list
        if (isTransitioning)
            return; //exit current method from executing

        currentTarget = (currentTarget - 1 + targetTransforms.Count) % targetTransforms.Count; //calculate number of previous target, looping around list if needed (if last go to first, if first go to last)
        StartCoroutine(TransitionCamera(targetTransforms[currentTarget])); //start transition to previous target 
    }

    private void SetNextTarget()
    { //go to next pos/rot from list
        if (isTransitioning)
            return; //exit current method from executing

        currentTarget = (currentTarget + 1) % targetTransforms.Count; //calculate number of next target, looping around list if needed (if last go to first, if first go to last)
        StartCoroutine(TransitionCamera(targetTransforms[currentTarget])); //start transition to next target 
    }

    IEnumerator TransitionCamera(Transform targetTransform)
    {
        isTransitioning = true;
        float t = 0.0f;

        Vector3 startingPosition = transform.position; //set start pos to current pos (the obj that this script is attached to)
        Quaternion startingRotation = transform.rotation; //set start rot to current rot (the obj that this script is attached to)

        while (t < 1.0f)
        {
            t += Time.deltaTime / transitionDuration; //++t based on time passed and transition duration for smooth lerping(interpolation)

            transform.position = Vector3.Lerp(startingPosition, targetTransform.position, t); //go from current pos to target pos with duration of t
            transform.rotation = Quaternion.Slerp(startingRotation, targetTransform.rotation, t); //go from current rot to target pos with duration of t

            yield return null; //wait until next frame before continueing loop
        }
        isTransitioning = false;
    }
}
