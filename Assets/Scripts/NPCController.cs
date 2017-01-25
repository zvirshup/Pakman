using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {
	public float speed;
	public Rigidbody npc;
	public Vector3 move;
	public int lives;
	public Text livesDisplay;
	// Use this for initialization
	void Start () {
		npc=GetComponent<Rigidbody> ();	
		Vector3 move = new Vector3 (Random.Range(-10,10), 0.0f, Random.Range(-10,10));
		npc.AddForce (move * speed);
		lives = 3;
		livesDisplay.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vel = npc.velocity;      //to get a Vector3 representation of the velocity 
		if (vel.magnitude <= 1){
		move = new Vector3 (Random.Range(-10,10), 0.0f, Random.Range(-10,10));
		}
		npc.AddForce (move * speed);
	}
	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.CompareTag ("Wall")) {
			move = new Vector3 (Random.Range (-10, 10), 0.0f, Random.Range (-10, 10));
			npc.AddForce (move * speed);
		}
		if (other.gameObject.CompareTag ("Player")) {
			lives--;
			livesDisplay.text = "Lives: " + lives;
		}
	}
}
