using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class sendJson : MonoBehaviour {

	public bool sendRequest = false;
	public bool changeUsername = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (sendRequest) {
			Debug.Log ("sendInfoToServer gonna be called...");
			sendRequest = false;
			sendInfoToServer("test_deviceId", "test_time", "test_score", "test_levelId" );
		}
		
		if (changeUsername) {
			Debug.Log ("sendUsernameToServer gonna be called...");
			changeUsername = false;
			sendUsernameToServer("test_deviceId", "test_nickname");
		}
	}


	// This sends the data to the server
	public void sendInfoToServer(string deviceId, string time, string score, string levelId) {

		var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://3.89.35.102/php/AddScore.php");
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";
		httpWebRequest.Credentials = new System.Net.NetworkCredential("poosdadmin", "DontForgetThis321");

		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = "{\"device_id\":\"" + deviceId + "\"," + 	// device_id
						"\"time\":\"" + time + "\"," +			// time
						"\"score\":\"" + score + "\"," +		// score
						"\"level_id\":\"" + levelId + "\"}";	// level_id


			// Test stuff 
			/* 
			string json = "{\"device_id\":\"test\"," + 	// device_id
						"\"time\":\"test\"," +			// time
						"\"score\":\"test\"," +			// score
						"\"level_id\":\"test\"}"; 		// level_id
			*/

			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();
		}

		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

		Debug.Log("response = " + httpResponse);

		using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
		{
			var result = streamReader.ReadToEnd();
		}
	}

	// Sends a username and deviceId pair to the server
	public void sendUsernameToServer(string deviceId, string nickname) {

		var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://3.89.35.102/php/SetNickname.php");
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";
		httpWebRequest.Credentials = new System.Net.NetworkCredential("poosdadmin", "DontForgetThis321");

		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = "{\"device_id\":\"" + deviceId + "\"," + 	// device_id
						"\"nickname\":\"" + nickname + "\"}";		// username

			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();

			Debug.Log("json = " + json);
		}

		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

		Debug.Log("response = " + httpResponse);

		using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
		{
			var result = streamReader.ReadToEnd();
		}
	}
	
}
