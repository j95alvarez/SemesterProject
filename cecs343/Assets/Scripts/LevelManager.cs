using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public Transform mainMenu, playMenu;

    void Start() {
        mainMenu.gameObject.SetActive(true);
        playMenu.gameObject.SetActive(false);
    }

    public void LoadScene(string game) {
        Application.LoadLevel(game);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PlayMenu(bool clicked) {
        playMenu.gameObject.SetActive(clicked);
        mainMenu.gameObject.SetActive(!clicked);
    }
}
