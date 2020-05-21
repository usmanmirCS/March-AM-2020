using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilitBrush : MonoBehaviour
{
    public List<GameObject> m_drawnTrails = new List<GameObject>();
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
        m_drawnTrails.Add(m_currentTrail);
    }

    void MenuDown()
    {
        if(m_drawnTrails.Count > 0)
        {
            GameObject trailToBeDeleted = m_drawnTrails[m_drawnTrails.Count - 1];
            m_drawnTrails.Remove(trailToBeDeleted);
            Destroy(trailToBeDeleted);
        }
    }

    void GrabReleased()
    {
        m_currentTrail.transform.SetParent(null);
        m_drawnTrails.Add(m_currentTrail);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paint")
        {
            m_prefabTrail.GetComponent<TrailRenderer>().material = collision.collider.GetComponent<Renderer>().material;
        }
    }
}
