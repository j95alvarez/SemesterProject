using UnityEngine;
using System.Collections;

public class PatrolFlip : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Patrolling Enemy") {
            col.gameObject.GetComponent<PatrollingScript>().canFlip = true;
            if (col.gameObject.GetComponent<PatrollingScript>().facingLeft) {
                col.gameObject.GetComponent<PatrollingScript>().facingLeft = false;
            }

            else {
                col.gameObject.GetComponent<PatrollingScript>().facingLeft = true;
            }
        }
    }
}
