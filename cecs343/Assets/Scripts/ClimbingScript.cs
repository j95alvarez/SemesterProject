using UnityEngine;
using System.Collections;

public class ClimbingScript : MonoBehaviour {
	GameObject player;
	void Start() {
		player = GameObject.Find("Player");
	}
	void Update() {
		if (player.GetComponent<PlayerMovement> ().climb) {
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
				player.GetComponent<PlayerMovement>().isClimbing = true;
                player.layer = 12;
			}
			if (player.GetComponent<PlayerMovement>().isClimbing) {
				player.GetComponent<Rigidbody2D>().gravityScale = 0f;
			}
		}
	}

    void OnTriggerEnter2D(Collider2D collide) {
        if (collide.gameObject.name == "Player") 
		{
			collide.GetComponent<PlayerMovement>().climb = true;
           // Debug.Log("Climbing = " + player.GetComponent<PlayerMovement>().isClimbing);
        }
    }

    void OnTriggerExit2D(Collider2D collide) {
        if (collide.gameObject.name == "Player") {
            collide.GetComponent<PlayerMovement>().isClimbing = false;
            player.GetComponent<PlayerMovement>().climb = false;
            player.layer = 0;
            StartCoroutine(Wait(.001f));
        }
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

}
