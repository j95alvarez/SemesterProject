using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float speed;

    public bool shot;
    

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(-shotForce, shotForce));
        shot = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (shot) {
            shot = false;
            StartCoroutine(Delay());
        }

        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            if (col.gameObject.GetComponent<PlayerMovement>().canAttack) {
                col.gameObject.GetComponent<PlayerMovement>().pHealth -= 30;
                Destroy(gameObject);
            }
            
        }
    }
}
