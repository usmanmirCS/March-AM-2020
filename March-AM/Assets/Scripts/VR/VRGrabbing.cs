using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrabbing : MonoBehaviour
{
    public Animator m_anim;

    public string m_grip;
    private bool m_gripHeld;

    private GameObject m_touchingObject;
    private GameObject m_heldObject;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
        {
            m_touchingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_touchingObject = null;
    }

    private void Update()
    {
        if(Input.GetAxis(m_grip) > 0.5f && !m_gripHeld)
        {
            m_anim.SetBool("isGrabbing", true);
            m_gripHeld = true;
            if(m_touchingObject)
            {
                Grab();
            }
        }
        if(Input.GetAxis(m_grip) < 0.5f && m_gripHeld)
        {
            m_anim.SetBool("isGrabbing", false);
            m_gripHeld = false;
            if(m_heldObject)
            {
                Release();
            }
        }
    }

    void Grab()
    {
        m_heldObject = m_touchingObject;
        m_heldObject.transform.SetParent(transform);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Release()
    {
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }


}
