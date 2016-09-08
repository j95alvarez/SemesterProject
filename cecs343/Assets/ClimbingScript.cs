using UnityEngine;
using System.Collections;

public class ClimbingScript : MonoBehaviour {
	GameObject player;
	void Start()
	{
		player = GameObject.Find("Player");
	}
	void Update()
	{
		//Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
		if (player.GetComponent<PlayerMovement> ().isClimbing == true) 
		{
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) 
			{
				player.GetComponent<PlayerMovement>().climb = true;
			}
			if (player.GetComponent<PlayerMovement>().climb == true) 
			{
				//Debug.Log("Penis");
				player.GetComponent<Rigidbody2D>().gravityScale = 0f;
				player.GetComponent<BoxCollider2D>().isTrigger = true;
			}
		}
	}
    void OnTriggerEnter2D(Collider2D collide) {
        if (collide.gameObject.name == "Player") 
		{
			collide.GetComponent<PlayerMovement>().isClimbing = true;
            Debug.Log("Climbing = " + player.GetComponent<PlayerMovement>().isClimbing);
        }
    }

    void OnTriggerExit2D(Collider2D collide) {
        collide.GetComponent<PlayerMovement>().isClimbing = false;
        collide.GetComponent<BoxCollider2D>().isTrigger = false;
		player.GetComponent<PlayerMovement>().climb = false;
        StartCoroutine(Wait(.25f));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

}
