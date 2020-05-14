using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light m_spotLight;

    void TriggerDown()
    {
        m_spotLight.enabled = !m_spotLight.enabled;
    }
}
