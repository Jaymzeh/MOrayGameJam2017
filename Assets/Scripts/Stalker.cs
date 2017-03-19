using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stalker : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject path;
    Vector3[] node;
    int index = 0;
    float chaseTimer = 0;

	void Start () {
        agent = GetComponent<NavMeshAgent>();

        node = new Vector3[path.transform.childCount];
        for (int i = 0; i < path.transform.childCount; i++) {
            node[i] = path.transform.GetChild(i).position;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.lampOn) {
            chaseTimer += Time.deltaTime;
            if (chaseTimer >= 10)
                GameController.lampOn = false;
            agent.acceleration = 4;
            agent.speed = 12;
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else {
            agent.speed = 10;
            if (Vector3.Distance(transform.position, node[index]) < 2) {
                index++;
            }
            if (index > path.transform.childCount - 1)
                index = 0;
            agent.SetDestination(node[index]);

        }
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameController.Respawn();
        }
    }
}
