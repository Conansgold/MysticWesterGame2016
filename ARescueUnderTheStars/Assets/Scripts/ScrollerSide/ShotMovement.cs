﻿using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
    }
}