using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

    public float speed = 10;

    public GameObject player;
    public int dir;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = player.GetComponent<PlayerController2D>().collisions.faceDir;
    }

	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * dir, GetComponent<Rigidbody2D>().velocity.y);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Topple")
        {
            coll.rigidbody.AddForceAtPosition(GetComponent<Rigidbody2D>().velocity * 15, gameObject.transform.position);
            //coll.rigidbody.AddForce(GetComponent<Rigidbody2D>().velocity*7);
            Debug.Log("Collision");
        }
        Destroy(gameObject);
    }
}
