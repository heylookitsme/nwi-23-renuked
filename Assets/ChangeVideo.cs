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

	public delegate void Freeze(Vector3 freezeLocation, Quaternion freezeRotation);
	public static event Freeze moveMotion;

	Renderer ren; 
	void Start() {
		og_Material = new Material(GetComponent<Renderer>().material);
		moveMotion += GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().PauseAndGoto;
		moveMotion += GameObject.FindGameObjectWithTag("XROrigin").GetComponent<Circle>().PauseMotion;

		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().ResumeMotion);
		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<Circle>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<Circle>().ResumeMotion);
	}

    // Update is called once per frame
    void Update()
    {
        if (activeColor) {
			GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white * 1.2f);
		} else {
			ren = GetComponent<Renderer>();
			ren.material = og_Material;
		}
    }
	
	public void ChangeColorOn() {
		activeColor = true;
		//pauseMotion.Invoke();
		moveMotion(transform.position, transform.rotation);
	}
	
	public void ChangeColorOff() {
		activeColor = false;
		resumeMotion.Invoke();
	}


}
