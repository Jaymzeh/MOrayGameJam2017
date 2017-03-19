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
    Light light;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        light = GetComponentInChildren<Light>();
        if (path != null) {
            
            node = new Vector3[path.transform.childCount];
            for (int i = 0; i < path.transform.childCount; i++) {
                node[i] = path.transform.GetChild(i).position;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (path != null)
            if (GameController.lampOn) {
                chaseTimer += Time.deltaTime;
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

    IEnumerator eat() {
        light.enabled = true;

        yield return new WaitForSeconds(0.25f);

        GameController.Respawn();
        GetComponent<Animator>().SetBool("Eat", false);
        light.enabled = false;
        yield return null;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {

            if (path == null) {
                GetComponent<Animator>().SetBool("Eat", true);
                StartCoroutine("eat");
            }
            else
                GameController.Respawn();
        }
    }
}
