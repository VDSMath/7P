using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

	public float speed;
	public Vector3 movement;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		movement = new Vector3 (0,0,0);
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		movement = new Vector3 (speed * Input.GetAxis("Horizontal"), 0, 0);
		rb.AddForce (movement);
	}
}
