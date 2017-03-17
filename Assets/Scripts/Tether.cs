using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour {

    public GameObject ropeLink;

    void Start () {
        if (ropeLink == null)
            Debug.LogError("RopeLink prefab has not been assigned.");
	}

    void AddLink() {
        Transform end = transform;

        while (end.childCount > 0)
            end = end.GetChild(0);

        GameObject newLink = Instantiate(ropeLink, end.position, end.rotation);
        newLink.transform.parent = end;
        newLink.GetComponent<HingeJoint>().connectedBody = newLink.transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    float timer = 0;
    public float delay = 1;
	void Update () {
        timer += Time.deltaTime;

        if (timer >= delay) {
            AddLink();
            timer = 0;
            //this.enabled = false;
        }
	}
}
