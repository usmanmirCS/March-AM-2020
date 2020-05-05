using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text m_shotCounterText;

    [HideInInspector]
    public int m_count;

    // Update is called once per frame
    void Update()
    {
        m_shotCounterText.text = "Shots Fired: " + m_count;
    }
}
