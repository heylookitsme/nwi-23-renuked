using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseActivator : MonoBehaviour
{
	public UnityEvent pauseMotion;
	public UnityEvent resumeMotion;


	Renderer ren;
	void Start()
	{
		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<FigureEight>().ResumeMotion);
		pauseMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<Circle>().PauseMotion);
		resumeMotion.AddListener(GameObject.FindGameObjectWithTag("XROrigin").GetComponent<Circle>().ResumeMotion);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ChangeColorOn()
	{
		pauseMotion.Invoke();
	}

	public void ChangeColorOff()
	{
		resumeMotion.Invoke();
	}
}
