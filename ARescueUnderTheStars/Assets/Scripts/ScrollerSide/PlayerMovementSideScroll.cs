using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController2D))]
public class PlayerMovementSideScroll : MonoBehaviour {

    float gravity = -20;
    Vector3 velocity;

    PlayerController2D controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
	}
}
