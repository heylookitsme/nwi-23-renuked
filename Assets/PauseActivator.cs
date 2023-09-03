using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseActivator : MonoBehaviour
{
	bool activeColor = false;
	Material m_Material;

	[SerializeField] private Material normal;
	[SerializeField] private Material shiny;

	
	Renderer ren; 
	void Start () {
		m_Material = GetComponent<Renderer>().material;
	}

    // Update is called once per frame
    void Update()
    {
        if (activeColor) {
			ren = GetComponent<Renderer>();
			ren.material = shiny;
		} else {
			ren = GetComponent<Renderer>();
			ren.material = m_Material;
		}
    }
	
	public void ChangeColorOn() {
		activeColor = true;
		//FigureEight.instance.isPaused = true; 
		// send out an event saying that you should slow down 
	}
	
	public void ChangeColorOff() {
		activeColor = false;
		//FigureEight.instance.isPaused = false;
		// send out event saying that you should quit 
	}
}
