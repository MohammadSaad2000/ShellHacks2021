using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    InputMaster controls;

    public GameObject player;
    public ParticleSystem loseParticleSystem;
    public AudioSource loseSoundEffect;

    public Vector3 startPosition;
    public Vector3 centerPosition;
    public Vector3 redPosition;
    public Vector3 bluePosition;
    public Vector3 greenPosition;

    public static GameStateManager mainInstance = null;;

    private void Awake()
    {
        if (mainInstance != null && mainInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mainInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controls = InputManager.controls;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Lose()
    {
        StopAllCoroutines();
        loseParticleSystem.transform.position = player.transform.position;
        loseParticleSystem.Play();
        controls.Movement.Disable();
        player.SetActive(false);
        loseSoundEffect.Play();
        StartCoroutine(pauseforSeconds());
    }

    IEnumerator pauseforSeconds()
    {
        yield return new WaitForSeconds(1.5f);
        if (StoryManager.checkPointNumber == 0)
        {
            player.transform.position = startPosition;
        }
        else if (StoryManager.checkPointNumber == 1)
        {
            player.transform.position = centerPosition;
        }
        else if (StoryManager.checkPointNumber == 2)
        {
            player.transform.position = redPosition;
        }
        else if (StoryManager.checkPointNumber == 3)
        {
            player.transform.position = bluePosition;
        }
        else if (StoryManager.checkPointNumber == 4)
        {
            player.transform.position = greenPosition;
        }
        player.transform.eulerAngles = new Vector3(0,0,0);
        player.SetActive(true);
        Movement.isMoving = false;
        controls.Movement.Enable();

    }
}
