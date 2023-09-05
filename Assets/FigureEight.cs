using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureEight : MonoBehaviour
{
	public float speed;   
	float m_Speed = 0.12f;
	//float m_Speed = 0.000015f;
	float m_XScale = 16;
	float m_YScale = 16;
		 
	private Vector3 m_Pivot;
	private Vector3 m_PivotOffset;
	private float m_Phase;
	private Vector3 cachedPos;
	private Vector3 targetPos;
	private float timer = 0;


	Quaternion targetRotation;
	Quaternion cachedRotation;

	enum motionState {
		Focusing, 
		Unfocusing, 
		Cruising, 
		Lol,
	}

	private motionState currMotion = motionState.Cruising;

	// Start is called before the first frame update

	void Start()
    {
		m_Pivot = transform.position;
	
    }

	// event reciever: if "name" was recieved -> find object with "name" and then pause in front of it. lerp to and from. if "empty" recieved" leave 
	public void PauseMotion()
    {
		currMotion = motionState.Lol;
	}

	public void ResumeMotion()
	{
		currMotion = motionState.Unfocusing;
		targetPos = transform.position;
		transform.rotation = cachedRotation;
		timer = 0;
	}

	public void AutomaticallyResumeMotion()
	{
		currMotion = motionState.Cruising;
	}

	public void PauseAndGoto(Vector3 elementPos, Quaternion freezeRotation)
	{
		currMotion = motionState.Focusing;
		// TODO: REALIZED THE PROBLEM WITH THIS. BECAUSE POSITION + ROTATION SHOULD BE CALCULATED IN TANDEM. I.E DEPENDING ON WHERE + WHERE THE VIDEO IS "FACING" WE WANT TO DO SOME MATH AND SHIT. BECUASE ITS NOT ALWAYS GOING TO BE Z 
		/* 
		 * renderer = GetComponent<MeshRenderer>();
		 * size = renderer.bounds.size;
		 * then presumably do - size.y//2
		 */
		// transform.position = new Vector3(elementPos.x, elementPos.y, elementPos.z + 1);
		targetPos = new Vector3(elementPos.x, elementPos.y, elementPos.z + 3);
		cachedPos = transform.position;

		targetRotation = freezeRotation;
		cachedRotation = transform.rotation;
		transform.rotation = targetRotation;
	}

	// Update is called once per frame
	void Update()
    {

		if (currMotion == motionState.Cruising)
		{
			m_PivotOffset = Vector3.up * 2 * m_YScale;
			m_Phase += m_Speed * Time.deltaTime;

			transform.position = new Vector3(
			Mathf.Sin(m_Phase) * m_XScale,
			transform.position.y,
			Mathf.Cos(m_Phase) * m_YScale);

			cachedPos = transform.position;
		}
		else if (currMotion == motionState.Focusing)
		{
			// add to timer while we are still paused, unless we already are at max seconds 
			timer += Time.deltaTime;
			// updated the position by timer/total time 
			transform.position = Vector3.Lerp(cachedPos, targetPos, timer / 2);

		}
		 else if (currMotion == motionState.Unfocusing) {
			// add to timer while we are still paused, unless we already are at max seconds 
			timer += Time.deltaTime;
			// updated the position by timer/total time 
			transform.position = Vector3.Lerp(targetPos, cachedPos, timer / 2);

			if (timer > 2)
			{
				currMotion = motionState.Cruising;
				timer = 0;
			}
		}

	}
}
