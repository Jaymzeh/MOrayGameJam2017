using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float walkingSpeed = 1f;
    public float turningSpeed = 1f;
    public Transform groundCheck;
    public LayerMask ground;
    bool grounded;
    Animator anim;
    Rigidbody rBody;

	void Start () {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f, ground);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject)
                grounded = true;

            anim.SetBool("Ground", grounded);

            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * turningSpeed, 0), Space.World);
            transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * walkingSpeed));

            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
            anim.SetFloat("vSpeed", rBody.velocity.y);
        }
    }
}
