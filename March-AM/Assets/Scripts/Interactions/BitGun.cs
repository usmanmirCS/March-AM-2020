using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : MonoBehaviour
{
    public GameObject m_prefabBit;
    public Transform m_spawnBit;
    public float m_shootForce;

    void TriggerDown()
    {
        GameObject bit = Instantiate(m_prefabBit, m_spawnBit.position, m_spawnBit.rotation);
        bit.GetComponent<Rigidbody>().AddForce(m_spawnBit.forward * m_shootForce);
        Destroy(bit, 5f);
    }
}
