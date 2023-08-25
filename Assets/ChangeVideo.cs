using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ChangeVideo : MonoBehaviour
{
	bool activeColor = false;
	[SerializeField] private Material normal;
	[SerializeField] private Material shiny;

	
	Renderer ren; 
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (activeColor) {
			ren = GetComponent<Renderer>();
			ren.material = shiny;
		} else {
			ren = GetComponent<Renderer>();
			ren.material = normal;
		}
    }
	
	public void ChangeColorOn() {
		activeColor = true;
	}
	
	public void ChangeColorOff() {
		activeColor = false;
	}
}
