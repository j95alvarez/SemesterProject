using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private bool pause;
    public Transform pauseMenu;

    // Use this for initialization
    void Start () {
        pauseMenu.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu(true);
            Time.timeScale = 0;
        }
	}

    void PauseMenu(bool pause) {
        pauseMenu.gameObject.SetActive(pause);
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
