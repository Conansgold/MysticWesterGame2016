using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

    public float offset = .95f;
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position * offset;
	}
}
