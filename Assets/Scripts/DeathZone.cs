using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public GameObject spawnPoint;
    public AudioClip deathSound;

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameController.Respawn(spawnPoint.transform.position);
        }
    }
}
