using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
    public int health = 200;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
