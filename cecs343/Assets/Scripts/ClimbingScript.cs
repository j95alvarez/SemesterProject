using UnityEngine;
using System.Collections;

public class ClimbingScript : MonoBehaviour {
	GameObject player;
    PlayerMovement playerMovement;
    Rigidbody2D rigidBody;

	void Start() {
		player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        rigidBody = player.GetComponent<Rigidbody2D>();
	}
	void Update() {
		if (player.GetComponent<PlayerMovement> ().climb) {
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
				playerMovement.isClimbing = true;
                player.layer = 12;
			}
			if (playerMovement.isClimbing) {
				rigidBody.gravityScale = 0f;
                //player.GetComponent<BoxCollider2D>().isTrigger = true;
			}
		}
	}

    void OnTriggerEnter2D(Collider2D collide) {
        if (collide.gameObject.name == "ClimbTrigger") 
		{
            Debug.Log("Enter Ladder");
			playerMovement.climb = true;
           // Debug.Log("Climbing = " + player.GetComponent<PlayerMovement>().isClimbing);
        }
    }

    void OnTriggerExit2D(Collider2D collide) {
        if (collide.gameObject.name == "ClimbTrigger") {
            Debug.Log("Exit Ladder");
            playerMovement.isClimbing = false;
            //collide.GetComponent<BoxCollider2D>().isTrigger = false;
            playerMovement.climb = false;
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
