using CinemaDirector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public Cutscene startMenu;
    public GameObject endMenu;
    public void StartLevel() {
        startMenu.Play();
    }

    public void ExitGame() {
        GameController.ExitGame();
    }
}
