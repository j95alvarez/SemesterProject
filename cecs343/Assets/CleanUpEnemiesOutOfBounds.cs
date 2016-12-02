using UnityEngine;
using System.Collections;

public class CleanUpEnemiesOutOfBounds : MonoBehaviour {

    public GameObject spawn, boss;


    void Start() {
        spawn = GameObject.Find("Controller");
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name != "Wall Right" && col.gameObject.name != "Wall Left") {
            boss.gameObject.GetComponent<Spawn>().SpawnCounter--;
            Destroy(col.gameObject);
        }
    }
}
