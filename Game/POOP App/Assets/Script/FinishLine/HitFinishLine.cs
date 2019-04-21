using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFinishLine : MonoBehaviour 
{
	public GameObject WinUI, UI;
	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject hitObj = collider.gameObject;

		if(hitObj.tag == "Player")
		{
			//transform.parent.gameObject.AddComponent<GameOverScript>();
			//LevelControlScript.instance.youWin();
			Finish();
		}
	}

	public void Finish()
	{
		WinUI.SetActive(true);
		Time.timeScale = 0f;
		UI.SetActive(false);
	}
}
