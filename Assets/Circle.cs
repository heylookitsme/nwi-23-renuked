using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    bool isPaused = false;
    Quaternion targetRotation;
    Quaternion cachedRotation;

    void Start()
    {
     
    }

    public void PauseMotion()
    {
        isPaused = true;
    }

    public void PauseMotion(Vector3 freezeLocation, Quaternion freezeRotation)
    {
        isPaused = true;
        targetRotation = freezeRotation;
        cachedRotation = transform.rotation;

        //transform.rotation = targetRotation;
    }

    public void ResumeMotion()
    {
        isPaused = false;
        //transform.rotation = cachedRotation;
    }

    public void ResumeMotionOG()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        } 
            
    }
}
