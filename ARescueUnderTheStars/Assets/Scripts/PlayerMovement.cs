using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;

    float timer = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Modify a passed movementspeed if needed
        MovePlayer(Input.GetAxis("Player1Horizontal"), Input.GetAxis("Player1Verticle"), movementSpeed);


        //Code to have the player always look at the mouse
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    void MovePlayer(float horizontalSpeed, float verticleSpeed, float movementSpeed)
    {

        var move = new Vector3(horizontalSpeed, verticleSpeed, 0);
        gameObject.transform.position += move * movementSpeed * Time.deltaTime;
    }

}
