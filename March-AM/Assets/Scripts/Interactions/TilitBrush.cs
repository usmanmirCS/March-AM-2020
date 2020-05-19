using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilitBrush : MonoBehaviour
{
    public GameObject m_prefabTrail;
    public Transform m_spawnTrail;

    private GameObject m_currentTrail;

    void TriggerDown()
    {
        m_currentTrail = Instantiate(m_prefabTrail, m_spawnTrail);
    }
    
    void TriggerUp()
    {
        m_currentTrail.transform.SetParent(null);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paint")
        {
            m_prefabTrail.GetComponent<TrailRenderer>().material = collision.collider.GetComponent<Renderer>().material;
        }
    }
}
