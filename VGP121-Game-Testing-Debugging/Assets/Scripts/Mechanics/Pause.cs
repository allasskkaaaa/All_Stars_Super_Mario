using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
                Debug.Log("Pause");
            }
            else
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
                Debug.Log("Unpause");
            }

        }
    }
}
