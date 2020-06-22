using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	
	public GameObject particles;
	public bool dead;
	public bool didDie;
	public int deathcount;
	public GameObject player;

	// Use this for initialization
	void Start () {

		deathcount = PlayerPrefs.GetInt ("deathcount",deathcount);
		didDie = false;
		dead = false;
	}
	

	// Update is called once per frame
	void Update () {
		if(dead == true && didDie == false){
			GetComponent<Rigidbody>().isKinematic = true;
			Instantiate(particles, transform.position, Quaternion.identity);
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
			didDie = true;
		}
	}

	void OnCollisionEnter (Collision hit){
		if(hit.collider.tag == "Obstacle"){
			dead = true;
			if(player.GetComponent<ScoreTrigger>().score > player.GetComponent<ScoreTrigger>().highScore){
				player.GetComponent<ScoreTrigger>().highScore = player.GetComponent<ScoreTrigger>().score;
				PlayerPrefs.SetInt("highscore", player.GetComponent<ScoreTrigger>().highScore);
			}
			deathcount++;
			PlayerPrefs.SetInt("deathcount",deathcount);
		}
	} 
}
