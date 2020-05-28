using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator m_anim;

    private GameObject m_touchingObject;
    private GameObject m_heldObject;

    private Vector3 m_oldPosition;
    private Vector3 m_handVelocity;

    private Vector3 m_oldEulerAngles;
    private Vector3 m_angularVelocity;

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
        m_handVelocity = transform.position - m_oldPosition;
        m_oldPosition = transform.position;

        m_angularVelocity = transform.eulerAngles - m_oldEulerAngles;
        m_oldEulerAngles = transform.eulerAngles;

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", true);
            if(m_touchingObject)
            {
                Grab();
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                Release();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("TriggerDown");
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("TriggerUp");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            if(m_heldObject)
            {
                m_heldObject.SendMessage("MenuDown");
            }
        }
    }

    void Grab()
    {
        m_heldObject = m_touchingObject;
        //m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = m_heldObject.GetComponent<Rigidbody>();
        fx.breakForce = 5000;
        fx.breakTorque = 5000;

        m_heldObject.transform.SetParent(transform);
    }

    void Release()
    {
        m_heldObject.SendMessage("GrabReleased");
        m_heldObject.transform.SetParent(null);
        //m_heldObject.GetComponent<Rigidbody>().isKinematic = false;

        Destroy(GetComponent<FixedJoint>());

        Rigidbody rb = m_heldObject.GetComponent<Rigidbody>();

        rb.velocity = m_handVelocity * 50 / rb.mass;
        rb.angularVelocity = m_angularVelocity * 50 / rb.mass;

        m_heldObject = null;
    }

    private void OnJointBreak(float breakForce)
    {
        m_heldObject.SendMessage("GrabReleased");
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }
}