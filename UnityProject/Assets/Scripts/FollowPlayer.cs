using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public float pos;

	void Start () {
	
	}

	void Update () {
		Vector3 cameraPos = player.transform.position;
		cameraPos.x = GetComponent<Camera>().transform.position.x;
		cameraPos.y = GetComponent<Camera>().transform.position.y;
		cameraPos.z += 23;
		GetComponent<Camera>().transform.position = cameraPos;

	}
}
