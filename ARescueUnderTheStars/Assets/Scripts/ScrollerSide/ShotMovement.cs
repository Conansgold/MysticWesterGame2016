using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

    public float speed = 10;

    public float timer = 6;

    public GameObject player;
    public int dir;

    Vector3 direction;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = player.GetComponent<PlayerController2D>().collisions.faceDir;
        direction = new Vector3(transform.localScale.x, dir * transform.localScale.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * dir, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = direction;
    }

	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag != "Player")
        {
            if (coll.transform.tag == "Topple" || coll.transform.tag == "Box")
            {
                coll.rigidbody.AddForceAtPosition(GetComponent<Rigidbody2D>().velocity * 30, gameObject.transform.position);
                //coll.rigidbody.AddForce(GetComponent<Rigidbody2D>().velocity*7);
            }
            Destroy(gameObject);
        }
    }
}
