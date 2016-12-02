using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public bool canStart, isBoss;
	// Use this for initialization
	void Start () {
        canStart = false;
        this.gameObject.GetComponent<Spawn>().enabled = false;
        isBoss = (gameObject.name == "Boss") ? true : false;
    }
	
	// Update is called once per frame
	void Update () {
        if (canStart && !isBoss)
        {
            Debug.Log("isBoss: " + isBoss);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player Began Game");
                this.gameObject.GetComponent<Spawn>().enabled = true;
            }
        }

        else {
            //gameObject.GetComponent<Spawn>().enabled = 
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Player") {
            canStart = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            canStart = false;
        }
        
    }
}
