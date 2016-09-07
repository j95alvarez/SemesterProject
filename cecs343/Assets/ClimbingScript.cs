using UnityEngine;
using System.Collections;

public class ClimbingScript : MonoBehaviour {
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collide) {
        if (collide.gameObject.name == "Player") {
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
                Debug.Log("Penis");
                player.GetComponent<PlayerMovement>().isClimbing = true;
                player.GetComponent<Rigidbody2D>().gravityScale = 0f;
                player.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            
            Debug.Log("Climbing = " + player.GetComponent<PlayerMovement>().isClimbing);
        }
    }

    void OnTriggerExit2D(Collider2D collide) {
        player.GetComponent<PlayerMovement>().isClimbing = false;
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        StartCoroutine(Wait(.25f));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

}
