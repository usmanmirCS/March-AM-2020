using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARInstructions : MonoBehaviour
{
    public GameObject m_selectionCanvas;
    public Text m_btnText;
    public List<GameObject> m_steps = new List<GameObject>();
    private int m_currentStep;

    public void NextStep()
    {
        if(m_currentStep < m_steps.Count - 1)
        {
            m_steps[m_currentStep].SetActive(false);
            m_currentStep++;
            m_steps[m_currentStep].SetActive(true);

            if(m_currentStep == m_steps.Count - 1)
            {
                m_btnText.text = "Return";
            }
        }
        else
        {
            m_steps[m_currentStep].SetActive(false);
            m_currentStep = 0;
            m_steps[m_currentStep].SetActive(true);

            m_selectionCanvas.SetActive(true);
            gameObject.SetActive(false);
            m_btnText.text = "Next";
        }

    }
}
