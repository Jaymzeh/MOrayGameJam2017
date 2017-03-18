using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject deathNode;
    public AudioClip deathSound;

    void TrimPath(GameObject player) {
        Tether path = player.GetComponentInChildren<Tether>();
        Instantiate(deathNode, path.link[path.link.Count-1].transform.position, Quaternion.identity);
    }

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            TrimPath(other.gameObject);
            GameController.Respawn(spawnPoint.transform.position);
            GameController.PlaySFX(deathSound);
        }
    }
}
