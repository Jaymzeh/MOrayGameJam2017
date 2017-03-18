using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomGlow : MonoBehaviour {

    public Material spots;
    public float minGlow, maxGlow;
    float glow = 0;
    public float speed = 0.1f;

    bool increase = true;
	void Start () {
        spots = GetComponent<Renderer>().materials[1];
	}
	
	// Update is called once per frame
	void Update () {
        Color colour;
        Renderer rend = GetComponent<Renderer>();
        spots.shader= Shader.Find("Main Color");
        if (increase)
            glow += speed;
        else
            glow -= speed;

        Mathf.Clamp(glow, minGlow, maxGlow);
        colour = new Color(glow, glow, glow);
        spots.SetColor("Main Color", colour);
	}
}
