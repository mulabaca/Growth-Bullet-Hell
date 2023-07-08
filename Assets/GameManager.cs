using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    private bool isPaused = false;

    public GameObject pauseMenu;

    public InputAction pause;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pause = player.GetComponent<PlayerInput>().actions["pause"];
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.triggered){
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            //pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            //pauseMenu.SetActive(false);
        }
    }


}
