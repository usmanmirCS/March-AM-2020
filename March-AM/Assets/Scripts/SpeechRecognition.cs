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
        m_keywordActions.Add("Spawn cube", SpawnCube);
        m_keywordActions.Add("Ra za na ba do a", SpawnCube);
        m_keywordActions.Add("Create ball", SpawnSphere);

        m_keywordRecognizer = new KeywordRecognizer(m_keywordActions.Keys.ToArray());

        m_keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_keywordRecognizer.Start();
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        m_keywordActions[args.text].Invoke();
    }


    public Transform m_spawnLocation;

    public GameObject m_prefabCube;

    void SpawnCube()
    {
        Instantiate(m_prefabCube, m_spawnLocation.position, m_spawnLocation.rotation);
    }

    public GameObject m_prefabSphere;

    void SpawnSphere()
    {
        Instantiate(m_prefabSphere, m_spawnLocation.position, m_spawnLocation.rotation);
    }
}
