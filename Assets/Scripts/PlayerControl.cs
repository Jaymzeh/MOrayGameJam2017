using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public static PlayerControl Instance;

    public float walkingSpeed = 1f;
    public float turningSpeed = 1f;
    public Transform groundCheck;
    public LayerMask ground;
    bool grounded;
    Animator anim;
    Rigidbody rBody;
    Light lamp;
    float lampTimer = 0;
    float lampCooldownTimer = 0;
    public float lampCooldown = 10;
    public bool canUseLamp = true;
    public static Vector3 Position { get { return Instance.transform.position; } }

    void Start() {
        Instance = this;
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        lamp = GetComponentInChildren<Light>();
    }

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

            if (Input.GetButtonDown("Fire1") && canUseLamp) {
                lamp.enabled = true;
                GameController.lampOn = true;
                canUseLamp = false;
            }

            if (lamp.enabled) {//Turn off lamp after 3 seconds
                lampTimer += Time.deltaTime;
                if (lampTimer > 3) {
                    lamp.enabled = false;
                    lampTimer = 0;
                }
            }

            if (!canUseLamp) {
                lampCooldownTimer += Time.deltaTime;
                if (lampCooldownTimer >= lampCooldown) {
                    canUseLamp = true;
                    lampCooldownTimer = 0;
                }
            }
            //GameController.lampOn = lamp.enabled;
        }
    }
}