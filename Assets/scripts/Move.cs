using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class Move : MonoBehaviour {

	private int right = 0;
	private int left = 0;
	public static string url = "http://localhost:4567/";
	void Start()
	{
//		System.Diagnostics.Process process = new System.Diagnostics.Process();
//		process.StartInfo.FileName = "/usr/bin/java";
//		process.StartInfo.UseShellExecute = false;
//		process.StartInfo.RedirectStandardOutput = true;
//		process.StartInfo.RedirectStandardError = false;
//		process.StartInfo.RedirectStandardInput = false;
//		process.StartInfo.Arguments = "-jar Assets/plugins/GetBalance.jar";
//
//		process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputHander);
//		process.StartInfo.CreateNoWindow = true;
//
//		process.EnableRaisingEvents = false;
//		process.Start();
//
//		process.BeginOutputReadLine();
//
		Thread thread = new Thread(new ThreadStart( GetBalance ) );
		thread.Start ();
	}

//	void OutputHander(object sender, System.Diagnostics.DataReceivedEventArgs args)
//	{
//		if (!string.IsNullOrEmpty(args.Data)) {
//			string[] splited = args.Data.Split(',');
//			left = Int32.Parse(splited[0]);
//			right = Int32.Parse(splited[1]);
//		}
//	}

	int b = 0;
	//socket
	//firebase
	//node+socket
	void GetBalance(){
		while (true) {
			UnityWebRequest request = UnityWebRequest.Get (url);
			request.Send ();

			if (request.isError) {
				Debug.Log (request.error);
			} else {
				if (request.responseCode == 200) {
					string text = request.downloadHandler.text;
					string[] splited = text.Split (',');
					left = Int32.Parse (splited [0]);
					right = Int32.Parse (splited [1]);
				}
			}
			Thread.Sleep (10);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Mov");
		GameObject camera = GameObject.FindGameObjectWithTag ("Cam");
		GameObject wall = GameObject.Find("Wall");

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
		camera.transform.LookAt(wall.transform);
	}
}
