using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public GameObject player;
    public float speed = .5F;
    //PlayerMovement p;
    public int eHealth;

    // Use this for initialization
    void Start () {
    }

    void Update() 
	{
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(eHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            /*p = col.gameObject.GetComponent<PlayerMovement>();
            p.pHealth -= 20;*/
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= 10;
            speed = 0;
            StartCoroutine(resetSpeed());
        }
    }

    IEnumerator resetSpeed() {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }
}
