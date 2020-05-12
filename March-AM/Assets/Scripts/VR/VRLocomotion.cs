using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public Transform m_VRRig;
    public string m_horizontal;
    public string m_vertical;
    public Transform m_director;
    public LayerMask m_groundLayer;
    public Transform m_VRHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition;
        touchPosition.x = Input.GetAxis(m_horizontal);
        touchPosition.y = Input.GetAxis(m_vertical);
        //touchPosition.Normalize(); //If not round Axis

        Vector3 playerRight = touchPosition.x * m_director.right;
        Vector3 playerForward = touchPosition.y * m_director.forward;

        m_VRRig.position += playerRight;
        m_VRRig.position += playerForward;
        m_VRRig.position = new Vector3(m_VRRig.position.x, GetLayerMask(m_VRRig.position.y), m_VRRig.position.z);
    }

    float GetLayerMask(float y)
    {
        RaycastHit hit;
        if(Physics.Raycast(m_VRHead.position, Vector3.down, out hit, 100f, m_groundLayer))
        {
            return hit.point.y;
        }
        return y;
    }
}
