using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private bool pause;
    public Transform pauseMenu, gameOverMenu;
    public GameObject player;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu(true);
            Time.timeScale = 0;
        }

        if (player.gameObject.GetComponent<PlayerMovement>().pHealth <= 0) {
            GameOverMenu(true);
            Time.timeScale = 0;
        }
	}

    void PauseMenu(bool pause) {
        pauseMenu.gameObject.SetActive(pause);
    }

    void GameOverMenu(bool active) {
        gameOverMenu.gameObject.SetActive(active);
    }

    public void Continue(bool clicked) {
        PauseMenu(!clicked);
        Time.timeScale = 1;
    }

    public void Quit(string name)
    {
        Application.LoadLevel(name);
    }
}
