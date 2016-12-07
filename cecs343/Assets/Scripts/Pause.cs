using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private bool pause, active;
    public Transform pauseMenu, gameOverMenu, gameCompleted;
    public GameObject player, boss;


    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        gameCompleted.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu(true);
            Time.timeScale = 0;
        }

        if (player.gameObject.GetComponent<PlayerMovement>().pHealth <= 0) {
			player.GetComponent<PlayerMovement> ().animatorObj.Play ("Player_Dead");
			StartCoroutine (delay ());
        }

        if (boss.gameObject.GetComponent<BossAI>().bossHP <= 0) {
            GameCompleted(true);
            Time.timeScale = 0;
        }
	}

    void PauseMenu(bool pause) {
        pauseMenu.gameObject.SetActive(pause);
    }

    void GameOverMenu(bool active) {
        gameOverMenu.gameObject.SetActive(active);
    }

    void GameCompleted(bool active) {
        gameCompleted.gameObject.SetActive(active);
    }

	IEnumerator delay()
	{
		yield return new WaitForSeconds (.5f);
		GameOverMenu(true);
		Time.timeScale = 0;
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
