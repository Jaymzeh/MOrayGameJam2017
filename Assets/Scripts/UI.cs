using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public static UI Instance;
    public GameObject startMenu;
    public GameObject warning;

    void Awake() {
        Instance = this;
    }

    public void StartLevel() {
        startMenu.SetActive(false);
        GameController.Respawn();
    }

    public static void ShowWarning() {
        Instance.StartCoroutine("Warning");
    }

    IEnumerator Warning() {
        float timer = 0;
        Debug.Log("Turning on warning");
        warning.SetActive(true);

        yield return new WaitForSeconds(3);
        
        Debug.Log("Turning off warning");
        warning.SetActive(false);
        yield return null;
    }

    public void ExitGame() {
        GameController.ExitGame();
    }
}
