using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void LaunchScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
