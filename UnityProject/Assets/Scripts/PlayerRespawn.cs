using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {
	
	public Vector3 respawnPoint;

	void Start () {
	}


	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			Respawn();
		}
	}
	public void Respawn(){
		Application.LoadLevel(1);
	}
}
