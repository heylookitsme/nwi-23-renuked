using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    bool isPaused = false;
    void Start()
    {
     
    }

    public void PauseMotion()
    {
        isPaused = true;
    }

    public void ResumeMotion()
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
