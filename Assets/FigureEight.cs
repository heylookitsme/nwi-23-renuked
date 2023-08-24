using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureEight : MonoBehaviour
{
		public float speed;   
		float m_Speed = 0.2f;
		float m_XScale = 6;
		float m_YScale = 6;
		 
		private Vector3 m_Pivot;
		private Vector3 m_PivotOffset;
		private float m_Phase;
		private bool m_Invert = false;
		private float m_2PI = 2 * Mathf.PI;
		    // Start is called before the first frame update
    void Start()
    {

		m_Pivot = transform.position;
	
    }

    // Update is called once per frame
    void Update()
    {
    m_PivotOffset = Vector3.up * 2 * m_YScale;
   
    m_Phase += m_Speed * Time.deltaTime;
    if(m_Phase > m_2PI)
    {
        m_Invert = !m_Invert;
        m_Phase -= m_2PI;
    }
    if(m_Phase < 0) m_Phase += m_2PI;
   
    transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
    transform.position = new Vector3(Mathf.Sin(m_Phase) * m_XScale + transform.position.x, Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale + transform.position.y, transform.position.z);
	transform.LookAt(transform.position);
    }
}
