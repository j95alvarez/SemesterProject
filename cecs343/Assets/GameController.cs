using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public bool canStart;
	// Use this for initialization
	void Start () {
        canStart = false;
        this.gameObject.GetComponent<Spawn>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (canStart) {
            if (Input.GetKeyDown(KeyCode.E)) {
                //Debug.Log("Player Began Game");
                this.gameObject.GetComponent<Spawn>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Player") {
            canStart = true;
        }
    }
}
