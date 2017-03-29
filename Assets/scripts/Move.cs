using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class Move : MonoBehaviour {

	int right = 0;
	int left = 0;
	private int b = 0;

	public static string url = "http://192.168.3.8:4567/";
	private UnityWebRequest request;

	void Start()
	{
//		GameObject.FindGameObjectWithTag ("Particle").GetComponent<ParticleSystem>().Play ();
		StartCoroutine(GetBalance());
	}

	IEnumerator GetBalance(){
		while (true) {
			WWW www = new WWW(url);
			yield return www;
			string[] splited = www.text.Split (',');

			left = Int32.Parse (splited [0]);
			right = Int32.Parse (splited [1]);
		}
	}
	void FixedUpdate () {

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Mov");
//		GameObject camera = GameObject.FindGameObjectWithTag ("Cam");
//		GameObject wall = GameObject.Find("Wall");

		int i = (int)((left - right) * 0.7);
		if (i > 20)  i = 20;
		if (i < -20) i = -20;
		int r = i - b;
		b = i;

		foreach (GameObject g in objects) {
			g.transform.Rotate(new Vector3(0f,0f,(float) r));
		}	

//		int t = right - left;
//		float o = ((3 / 20) * t);

//		camera.transform.localPosition = new Vector3 ((float)o,camera.transform.position.y,camera.transform.position.z);
//		camera.transform.LookAt(wall.transform);
	}
}
