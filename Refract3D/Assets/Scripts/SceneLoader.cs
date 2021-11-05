using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
        StoryManager.checkPointNumber = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
