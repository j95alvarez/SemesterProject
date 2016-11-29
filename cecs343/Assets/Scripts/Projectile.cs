using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float speed;

    public bool shot;

    [SerializeField]
    private int shotForce;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-shotForce, shotForce));
        
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= 30;
            Destroy(gameObject);
        }
    }
}
