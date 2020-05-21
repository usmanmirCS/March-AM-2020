using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; //to use Actions
using System.Linq; //to use ToArray();
using UnityEngine.Windows.Speech; //to use Voice Recognition;

public class SpeechRecognition : MonoBehaviour
{
    private Dictionary<string, Action> m_keywordActions = new Dictionary<string, Action>();

    private KeywordRecognizer m_keywordRecognizer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
