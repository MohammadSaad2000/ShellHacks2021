using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    InputMaster controls;

    public GameObject player;
    public ParticleSystem loseParticleSystem;

    public static GameStateManager mainInstance = null;

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
        loseParticleSystem.transform.position = player.transform.position;
        loseParticleSystem.Play();
        controls.Movement.Disable();
        player.SetActive(false);
    }
}
