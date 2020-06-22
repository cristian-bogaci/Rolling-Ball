using UnityEngine;
using System.Collections;

public class PlaneLooper : MonoBehaviour {

	private int planes = 3;
	private float planeWidth = 300;

	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.GetComponent<Collider>().tag == "Loop"){
			Vector3 planePosition = transform.position;
			planePosition.z += planeWidth * planes;
			transform.position = planePosition;
		}
	}
		
	void Update () {
	
	}
}
