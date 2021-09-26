using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Script : MonoBehaviour
{

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("success");
    }

}
