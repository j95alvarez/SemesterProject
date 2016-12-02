using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = .5F;
    public int eHealth;
    public GameObject spawn, EneKCount, boss;
    public int DistanceToDelete;
    public float ChkDistInterval;

    public float counter;
    // Use this for initialization
    void Start () {
        gameObject.name = "Enemy";
        //playermove = GetComponent<PlayerMovement>();
        spawn = GameObject.Find("Controller");
        EneKCount = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    void Update() 
	{
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        //Debug.Log(GameObject.Find("Player").transform.position);
        counter += Time.deltaTime;
        if (counter >= ChkDistInterval)
        {
            //ChkDist();
            //Debug.Log("Check Point");
            counter = 0;
        }
        if(eHealth <= 0)
        {
            EneKCount.gameObject.GetComponent<PlayerMovement>().EneDCount += 1;
            boss.gameObject.GetComponent<Spawn>().SpawnCounter--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= 10;
            speed = 0;
            StartCoroutine(resetSpeed());
        }
    }
    void ChkDist()
    {
        //Debug.Log("CK CK");
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > DistanceToDelete)
        {
            spawn.gameObject.GetComponent<Spawn>().SpawnCounter--;
            Destroy(gameObject);
            //Debug.Log("Too Far");
        }
    }

    IEnumerator resetSpeed() {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }
}
