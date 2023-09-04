using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVideo : MonoBehaviour
{
	bool activeColor = false;
	Material og_Material;

	[SerializeField] private Material normal;
	[SerializeField] private Material shiny;

	public UnityEvent pauseMotion;
	public UnityEvent resumeMotion;


	Renderer ren; 
	void Start() {
		og_Material = GetComponent<Renderer>().material;
		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().ResumeMotion);
	}

    // Update is called once per frame
    void Update()
    {
        if (activeColor) {
			//ren = GetComponent<Renderer>();
			//ren.material = shiny;

			GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green * 10);
		} else {
			ren = GetComponent<Renderer>();
			ren.material = og_Material;
		}
    }
	
	public void ChangeColorOn() {
		activeColor = true;
		pauseMotion.Invoke();
	}
	
	public void ChangeColorOff() {
		activeColor = false;
		resumeMotion.Invoke();
	}
}
