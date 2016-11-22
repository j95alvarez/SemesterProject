using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public Transform mainMenu, optionsMenu, brightnessMenu;

    void Start() {
        mainMenu.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        brightnessMenu.gameObject.SetActive(false);
    }

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

    public void BrightnessMenu(bool clicked) {
        if (clicked)
        {
            brightnessMenu.gameObject.SetActive(clicked);
            optionsMenu.gameObject.SetActive(!clicked);
        }
        else
        {
            brightnessMenu.gameObject.SetActive(clicked);
            optionsMenu.gameObject.SetActive(!clicked);
        }


    }
}
