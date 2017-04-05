using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool flag = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody> ().WakeUp ();
		Vector3 v = GetComponent<Rigidbody> ().velocity;
	}

	void OnTriggerEnter(Collider c){
		if (c.name == "Stage") {
			transform.position = new Vector3 (1.34f,5.7f,1.993f);
			Move.flag = true;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f,0f,0f);
		}

		if (c.name == "Cubef") {
			transform.position = new Vector3 (1.34f,5.7f,1.993f);
			GameObject.FindGameObjectWithTag ("Particle").GetComponent<ParticleSystem>().Play ();
			Move.flag = true;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f,0f,0f);
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.collider.name == "Mov1") {
//			flag = true;
			Move.flag = false;
		}
	}
}
