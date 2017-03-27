using System;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour {

	public Text text;
	private int right = 0;
	private int left = 0;

	void Start()
	{
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		process.StartInfo.FileName = "/usr/bin/java";
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = false;
		process.StartInfo.RedirectStandardInput = false;
		process.StartInfo.Arguments = "-jar Assets/plugins/GetBalance.jar";

		process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputHander);
		process.StartInfo.CreateNoWindow = true;

		process.EnableRaisingEvents = false;
		process.Start();

		process.BeginOutputReadLine();
	}

	void OutputHander(object sender, System.Diagnostics.DataReceivedEventArgs args)
	{
		if (!string.IsNullOrEmpty(args.Data)) {
			try{
			string[] splited = args.Data.Split(',');
			left = Int32.Parse(splited[0]);
			right = Int32.Parse(splited[1]);
			}catch(Exception e){
			}
		}
	}

	void Update () {
		text.text = "L:" + left + " R:" + right;
	}
}