using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    private Vector3 vic;
    public bool DodgeTriggered;

    public float speed = .5F;
    public int eHealth;
    public GameObject spawn, EneKCount;
    public int DistanceToDelete;
    public float ChkDistInterval;

    public float counter;
    public float timerDelay;

    // Use this for initialization
    void Start () {
        DodgeTriggered = false;
        //playermove = GetComponent<PlayerMovement>();
        spawn = GameObject.Find("Controller");
        EneKCount = GameObject.Find("Player");
    }

    void Update() 
	{
        //chk alt per
        timerDelay += Time.deltaTime;
        if (timerDelay >= 1f)
        {
            vic = GameObject.Find("Player").transform.position;
            timerDelay = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, vic, speed * Time.deltaTime);

        //
        if (DodgeTriggered)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            //Debug.Log("DodgeTriggered");
        }else
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            //Debug.Log("No thing happends");
        }

        //Debug.Log(GameObject.Find("Player").transform.position);
        counter += Time.deltaTime;
        if (counter >= ChkDistInterval)
        {
            ChkDist();
            //Debug.Log("Check Point");
            counter = 0;
        }
        if(eHealth <= 0)
        {
            EneKCount.gameObject.GetComponent<PlayerMovement>().EneDCount += 1;
            spawn.gameObject.GetComponent<Spawn>().SpawnCounter--;
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
