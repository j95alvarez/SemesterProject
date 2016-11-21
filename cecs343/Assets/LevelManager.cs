using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public Transform mainMenu, optionsMenu;

    public void LoadScene(string game) {
        Application.LoadLevel(game);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OptionsMenu(bool clicked) {
        if (clicked == true)
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(!clicked);
        }
        else
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(!clicked);
        }
    }
}
