using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class sendJson : MonoBehaviour {

	public bool sendRequest = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// level id
		// device id
		// time
		// score


		if (sendRequest) {
			sendInfoToServer("test_deviceId", "test_time", "test_score", "test_levelId" );
			sendRequest = false;
		}
		
	}

	// IEnumerator WaitForWWW(WWW www) {
	// 	yield return www;
		
		
	// 	string txt = "";
	// 	if (string.IsNullOrEmpty(www.error))
	// 		txt = www.text;  //text of success
	// 	else
	// 		txt = www.error;  //error
	// 	GameObject.Find("Txtdemo").GetComponent<Text>().text =  "++++++\n\n" + txt;
	// }

	// void TaskOnClick()
	// {
	// 	try
	// 	{
	// 		GameObject.Find("Txtdemo").GetComponent<Text>().text = "starting..";   

	// 		string ourPostData = "{\"plan\":\"TESTA02\"";
	// 		Dictionary<string,string> headers = new Dictionary<string, string>();
	// 		headers.Add("Content-Type", "application/json");
			
	// 		//byte[] b = System.Text.Encoding.UTF8.GetBytes();
	// 		byte[] pData = System.Text.Encoding.ASCII.GetBytes(ourPostData.ToCharArray());

	// 		///POST by IIS hosting...
	// 		WWW api = new WWW("http://192.168.1.120/si_aoi/api/total", pData, headers);

	// 		///GET by IIS hosting...
	// 		///WWW api = new WWW("http://192.168.1.120/si_aoi/api/total?dynamix={\"plan\":\"TESTA02\"");

	// 		StartCoroutine(WaitForWWW(api));
	// 	}
	// 	catch (UnityException ex) { Debug.Log(ex.Message); }
	// }



	public void sendInfoToServer(string deviceId, string time, string score, string levelId) {

		var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://3.89.35.102/php/AddScore.php");
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";
		httpWebRequest.Credentials = new System.Net.NetworkCredential("poosdadmin", "DontForgetThis321");

		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = "{\"device_id\":\"test\"," + 	// device_id
						"\"time\":\"test\"," +			// time
						"\"score\":\"test\"," +			// score
						"\"level_id\":\"test\"}"; 		// level_id

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

	void sendUsernameToServer(string deviceId, string username) {

		var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://3.89.35.102/php/AddScore.php");
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";
		httpWebRequest.Credentials = new System.Net.NetworkCredential("poosdadmin", "DontForgetThis321");

		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = "{\"device_id\":\"test\"," + 	// device_id
						"\"time\":\"test\"," +			// time
						"\"score\":\"test\"," +			// score
						"\"level_id\":\"test\"}"; 		// level_id

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
	
}
