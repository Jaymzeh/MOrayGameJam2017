using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour {

    public GameObject linkPrefab;
    public List<GameObject> link;
    public float targetDistance = 4;
    float distance;

    void Start() {
        link = new List<GameObject>();
        DropLink();
    }

    void DropLink() {
        GameObject newLink = Instantiate(linkPrefab, transform.position - (transform.forward * 0.5f), Quaternion.identity);

        if (GameObject.Find(transform.parent.name + "_Tether") == null)
            new GameObject(transform.parent.name + "_Tether");
        newLink.transform.parent = GameObject.Find(transform.parent.name + "_Tether").transform;

        link.Add(newLink);
        UpdateLine();
    }

    void UpdateLine() {
        for(int i = 0; i < link.Count-1; i++) {
            link[i].GetComponent<LineRenderer>().SetPosition(0, link[i].transform.position);
            link[i].GetComponent<LineRenderer>().SetPosition(1, link[i+1].transform.position);
        }
    }

    void Update() {
        if (link.Count > 0)
            distance = Vector3.Distance(transform.position, link[link.Count-1].transform.position);
        if (distance >= targetDistance)
            DropLink();
    }
}
