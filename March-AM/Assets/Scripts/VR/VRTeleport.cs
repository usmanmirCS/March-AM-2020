using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    public Transform m_VrRig;
    public string m_buttonName;

    private LineRenderer m_teleportLine;
    private bool m_validTeleport;
    private RaycastHit m_hit;

    // Start is called before the first frame update
    void Start()
    {
        m_teleportLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(m_buttonName))
        {
            if (Physics.Raycast(transform.position, transform.forward, out m_hit))
            {
                m_teleportLine.enabled = true;
                m_teleportLine.SetPosition(0, transform.position);
                m_teleportLine.SetPosition(1, m_hit.point);
                m_validTeleport = true;
            }
            else
            {
                m_teleportLine.enabled = false;
                m_validTeleport = false;
            }
        }
        else if(Input.GetButtonUp(m_buttonName))
        {
            m_teleportLine.enabled = false;
            if(m_validTeleport)
            {
                m_VrRig.position = m_hit.point;
            }
        }
    }
}
