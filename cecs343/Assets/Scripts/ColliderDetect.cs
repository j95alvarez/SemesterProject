using UnityEngine;
using System.Collections;

public class ColliderDetect : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy 1")
        {
            Debug.Log("Collision with "+ collision.gameObject.name);
        }
    }
}
