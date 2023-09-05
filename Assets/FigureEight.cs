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
	private float m_Phase;
	private float m_Phase_z;
	private float timer = 0;

	enum motionState {
		Focusing, 
		Unfocusing, 
		Cruising,
		Still,
	}

	private motionState currMotion = motionState.Cruising;

	Quaternion targetRotation;
	Quaternion cachedRotation;
	private Vector3 cachedPos;
	private Vector3 targetPos;

	float deltaX;
	float deltaZ;
	float idealX;
	float idealZ;

	// Start is called before the first frame update

	void Start()
    {
		
		transform.position = new Vector3(0,
			transform.position.y, m_YScale);
		m_Pivot = transform.position;

	}

	// event reciever: if "name" was recieved -> find object with "name" and then pause in front of it. lerp to and from. if "empty" recieved" leave 
	public void PauseMotion()
    {
		currMotion = motionState.Still;
	}

	public void CruiseMotion()
	{
		currMotion = motionState.Cruising;
	}


	// you have let go of a select, and you need to interpolate from your current position -> back to your "former" position (wherever that is) 
	public void ResumeMotion()
	{
		currMotion = motionState.Unfocusing;

		targetPos = cachedPos;
		cachedPos = transform.position;

		targetRotation = cachedRotation;
		cachedRotation = transform.rotation;

		timer = 0;
	}

	// you have started a select, and you need to interpolate to a target position
	public void PauseAndGoto(Vector3 elementPos, Quaternion elementRot)
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

		targetRotation = elementRot;
		cachedRotation = transform.rotation;
		timer = 0;
	}

	// Update is called once per frame
	void Update()
    {

		if (currMotion == motionState.Cruising)
		{
			m_Phase_z = m_Phase;
			m_Phase += m_Speed * Time.deltaTime;

			/* transform.position = new Vector3(
			Mathf.Sin(m_Phase) * m_XScale,
			transform.position.y,
			Mathf.Cos(m_Phase) * m_YScale); */

			// datum: drop and do a circle anywhere 
			/* transform.position = new Vector3(
			transform.position.x + ((Mathf.Sin(m_Phase) - Mathf.Sin(m_Phase_z)) * m_XScale),
			transform.position.y,
			transform.position.z + ((Mathf.Cos(m_Phase) - Mathf.Cos(m_Phase_z)) * m_YScale));
			*/

			// come back home 

			deltaX = ((Mathf.Sin(m_Phase) - Mathf.Sin(m_Phase_z)) * m_XScale);
			deltaZ = ((Mathf.Cos(m_Phase) - Mathf.Cos(m_Phase_z)) * m_YScale);
			idealX = Mathf.Sin(m_Phase) * m_XScale; 
			idealZ = Mathf.Cos(m_Phase) * m_YScale;

			if (Mathf.Abs(transform.position.x - idealX) > 1)
            {
				// we are too far. lets try to get closer. for now we will jsut get closer with subtraction because i dont really want to lerp and dont know how this would help in this situation 
				if (transform.position.x > idealX)
					deltaX -= (m_Phase - m_Phase_z) * m_XScale;
				else
					deltaX += (m_Phase - m_Phase_z) * m_XScale;
			}

			if (Mathf.Abs(transform.position.z - idealZ) > 1)
			{
				// we are too far. lets try to get closer. for now we will jsut get closer with subtraction because i dont really want to lerp and dont know how this would help in this situation 
				if (transform.position.z > idealZ)
					deltaZ -= (m_Phase - m_Phase_z) * m_YScale;
				else
					deltaZ += (m_Phase - m_Phase_z) * m_YScale;
			}

			transform.position = new Vector3(
			transform.position.x + deltaX,
			transform.position.y,
			transform.position.z + deltaZ);
		}
		else if (currMotion == motionState.Focusing)
		{
			// add to timer while we are still paused, unless we already are at max seconds 
			timer += Time.deltaTime;
			// updated the position by timer/total time 
			transform.position = Vector3.Lerp(cachedPos, targetPos, timer / 2);
			transform.rotation = Quaternion.Lerp(cachedRotation, targetRotation, timer / 2);
		}
		 else if (currMotion == motionState.Unfocusing) {
			// add to timer while we are still paused, unless we already are at max seconds 
			timer += Time.deltaTime;
			// updated the position by timer/total time 
			transform.position = Vector3.Lerp(cachedPos, targetPos, timer / 2);
			//transform.rotation = Quaternion.Lerp(cachedRotation, targetRotation, timer / 2);

			if (timer > 2)
            {
				currMotion = motionState.Cruising;
				timer = 0;
            }

		}

	}
}
