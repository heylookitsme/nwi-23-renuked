using UnityEngine;

public class SanityGreen : MonoBehaviour
{
    Renderer ren;

    void Start()
    {
        //ren.material = m_Material;
    }

    void Update() {
        Color emissiveColor = Color.red;

        ren = GetComponent<Renderer>();
        Material m_Material = GetComponent<Renderer>().material;

        m_Material.EnableKeyword("_EMISSION");
        ren.material.color = emissiveColor;
        m_Material.SetColor("_EmissionColor", emissiveColor * 100);
        //m_Material.SetColor("_Color", emissiveColor);

        
    }
}