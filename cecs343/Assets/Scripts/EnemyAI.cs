using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = .5F;
    public int eHealth;
    public GameObject spawn, EneKCount, boss;
    public int DistanceToDelete;
    public float ChkDistInterval;

    public float counter;
    private bool faceingLeft;
    // Use this for initialization
    void Start () {
        gameObject.name = "Enemy";
        //playermove = GetComponent<PlayerMovement>();
        spawn = GameObject.Find("Controller");
        EneKCount = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        faceingLeft = true;
         
    }

    void Update() 
	{
        NeedsFlip();

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

    void NeedsFlip()
    {
        if (CheckSide() < 0 && !faceingLeft)
        {
            faceingLeft = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else
        {

            if (faceingLeft && CheckSide() > 0)
            {
                faceingLeft = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
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

    float CheckSide() {
        return (EneKCount.gameObject.transform.position.x - gameObject.transform.position.x);
    }
}
