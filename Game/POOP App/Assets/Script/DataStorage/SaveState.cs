using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public static class SaveState {

	public static void SavePlayer (PlayerInfo player)
	{
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER","yes");

		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/saveState.txt";
		FileStream stream = new FileStream( path, FileMode.Create );

		PlayerData data = new PlayerData(player);
		Debug.Log(player.L1Time);

		formatter.Serialize(stream, data);
		stream.Close();
		Debug.Log("Data Saved");
	}

	public static PlayerData LoadPlayer()
	{
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER","yes");

		string path = Application.persistentDataPath + "/saveState.txt";

		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream( path, FileMode.Open );

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;

		}
		else
		{
			Debug.LogError("Save file not found in" + path);
			return null;
		}
	}
}
