using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(this);
        }
    }
}
