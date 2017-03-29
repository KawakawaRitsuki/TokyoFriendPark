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

//	public static string url = "http://127.0.0.1:4567/";
	public static string url = "http://192.168.3.8:4567/";

	void Start()
	{
		new Thread(new ThreadStart(GetBalance)).Start();
	}

	void GetBalance(){
		while (true) {
			UnityWebRequest request = new UnityWebRequest(url);
			request.Send ();

			if (request.isError) {
				Debug.Log (request.error);
			} else {
				if (request.responseCode == 200 && request != null) {
					string[] splited = request.downloadHandler.text.Split (',');

					left = Int32.Parse (splited [0]);
					right = Int32.Parse (splited [1]);
				}
			}
			Thread.Sleep (10);
		}
	}

	public Text t;
	// Update is called once per frame
	void FixedUpdate () {

//		GetBalance ();

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Mov");
		GameObject camera = GameObject.FindGameObjectWithTag ("Cam");
//		GameObject wall = GameObject.Find("Wall");
//		t.text = "R: " + right + "L: " + left;

		int i = (left - right) / 2;
		if (i > 20)  i = 20;
		if (i < -20) i = -20;
		int r = i - b;
		b = i;

		foreach (GameObject g in objects) {
			g.transform.Rotate(new Vector3(0f,0f,(float) r));
		}	

		int t = right - left;
		int o = (int)(((float)4 / 20) * t);

		camera.transform.localPosition = new Vector3 ((float)o,camera.transform.position.y,camera.transform.position.z);
//		camera.transform.LookAt(wall.transform);
	}
}
