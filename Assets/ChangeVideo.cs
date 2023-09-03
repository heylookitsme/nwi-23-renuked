using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVideo : MonoBehaviour
{
	bool activeColor = false;
	Material m_Material;

	[SerializeField] private Material normal;
	[SerializeField] private Material shiny;

	public UnityEvent pauseMotion;
	public UnityEvent resumeMotion;


	Renderer ren; 
	void Start () {
		m_Material = GetComponent<Renderer>().material;
		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().ResumeMotion);
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
		pauseMotion.Invoke();
	}
	
	public void ChangeColorOff() {
		activeColor = false;
		resumeMotion.Invoke();
	}
}
