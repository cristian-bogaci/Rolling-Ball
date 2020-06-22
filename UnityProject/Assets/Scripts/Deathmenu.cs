using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Deathmenu : MonoBehaviour {

	public Button RespawnButton;
	public GameObject player;
	public GameObject panel;

	void Start () {
		GetComponent<Canvas>().enabled = false;

	}
	

	IEnumerator death(){
		if(player.GetComponent<PlayerDeath>().dead == true){
			yield return new WaitForSeconds(1f);
			GetComponent<Canvas>().enabled = true;
		}
	}
		
	void Update () {
		StartCoroutine(death());
		if(GetComponent<Canvas>().enabled == true){
			if(Input.GetKeyDown(KeyCode.Escape)){
				Application.LoadLevel(0);
			}
		}
	}
	public void Respawn(){
		player.GetComponent<PlayerRespawn>().Respawn();

	}
}
