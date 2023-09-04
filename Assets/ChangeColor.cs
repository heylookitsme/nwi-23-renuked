using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeColor : MonoBehaviour
{
	bool activeColor = false;
	
	Renderer ren; 
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (activeColor) {
			ren = GetComponent<Renderer>();
			ren.material.color=Color.white;
		} else {
			ren = GetComponent<Renderer>();
			ren.material.color=Color.red;
		}
    }
	
	public void ChangeColorOn() {
		activeColor = true;
	}
	
	public void ChangeColorOff() {
		activeColor = false;
	}
}
