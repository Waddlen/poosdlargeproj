using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour {

	public Text HealthText;

    public GameObject LM;

    private LevelManager Level_Manager;

    private int h;

    void Start()
    {
        Level_Manager = LM.GetComponent<LevelManager>();
    }

    void Update()
    {
        h = Level_Manager.current_life;
        string pHealth = h.ToString();

        HealthText.text = pHealth;
    }
}
