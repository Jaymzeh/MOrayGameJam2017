using CinemaDirector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject startMenu;
    public GameObject camera;
    public GameObject endMenu;
    public void StartLevel() {
        startMenu.SetActive(false);
        camera.SetActive(false);
        GameController.Respawn();
    }

    public void ExitGame() {
        GameController.ExitGame();
    }
}
