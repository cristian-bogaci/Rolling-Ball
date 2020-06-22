using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject panel;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update () {
			if(Input.GetKey(KeyCode.Escape)){
				panel.SetActive(false);
			}
	}

	public void play(){
		Application.LoadLevel(1);
	}

	public void exit(){
		Application.Quit();
	}
	public void instructios(){
		panel.SetActive(true);
	}
}
