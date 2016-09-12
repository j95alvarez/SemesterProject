using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
    public int health;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            if (health > 0)
            {
                health -= 10;
            }
            Debug.Log("health is: " + health);
        }
    }
}
