using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.name == "Stage") {
			Thread.Sleep (3000);
			transform.position = new Vector3 (1.34f,6f,2.25f);
		}

		if (c.name == "Cubef") {
			transform.position = new Vector3 (1.34f,6f,2.25f);
			GameObject.FindGameObjectWithTag ("Particle").GetComponent<ParticleSystem>().Play ();
		}

	}
}
