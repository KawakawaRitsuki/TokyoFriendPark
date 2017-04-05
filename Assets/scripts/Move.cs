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

	public static bool flag = true;

	public static string url = "http://192.168.1.7:4567/";
	private UnityWebRequest request;

	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		StartCoroutine(GetBalance());
	}

	IEnumerator GetBalance(){
		while (true) {
			WWW www = new WWW(url);
			yield return www;
			if(www.text != null && www.text != ""){
				string[] splited = www.text.Split (',');

				left = Int32.Parse (splited [0]);
				right = Int32.Parse (splited [1]);
			}
		}
	}

	void FixedUpdate () {
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Mov");

		int i = (int)((left - right) * 0.5);
		if (i > 20)  i = 20;
		if (i < -20) i = -20;
//		if (flag) i = 2;
		int r = i - b;

		if (r > 2)
			r = 2;

		if (r < -2)
			r = -2;
		
		b = r + b;

		foreach (GameObject g in objects) {
			g.transform.Rotate(new Vector3(0f,0f,(float) r));
		}	
	}
}
