using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public string nextScene;

	void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameController.ChangeScene(nextScene);
        }
    }
}
