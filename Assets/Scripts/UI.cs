using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject startMenu;
    public GameObject endMenu;
    public void StartLevel() {
        startMenu.SetActive(false);
    }

    public void ExitGame() {
        GameController.ExitGame();
    }
}
