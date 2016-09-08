using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public GameObject player;
    public float speed = .5F;
    PlayerStatus p;

    // Use this for initialization
    void Start () {
	
	}

    void Update() 
	{
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        if (col.gameObject.name == "Player") {
            p = col.gameObject.GetComponent<PlayerStatus>();
            p.health -= 20;
            speed = 0;

            StartCoroutine(resetSpeed());

        }
    }

    IEnumerator resetSpeed() {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }
}
