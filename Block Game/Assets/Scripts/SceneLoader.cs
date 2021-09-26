using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
