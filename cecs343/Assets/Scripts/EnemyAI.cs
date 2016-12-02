using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float speed = .5F;
    public int eHealth;
    public GameObject spawn, EneKCount;
    public int DistanceToDelete;
    public float ChkDistInterval;

    public bool enableTeleport = false;
    public bool EnemyDetectRange = true;
    public float SearchRange = 5;

    public float counter;
    // Use this for initialization
    void Start()
    {
        //playermove = GetComponent<PlayerMovement>();
        spawn = GameObject.Find("Controller");
        EneKCount = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        //Debug.Log(GameObject.Find("Player").transform.position);
        counter += Time.deltaTime;
        if (counter >= ChkDistInterval)
        {
            ChkDist();
            //Debug.Log("Check Point");
            counter = 0;
        }
        if (eHealth <= 0)
        {
            EneKCount.gameObject.GetComponent<PlayerMovement>().EneDCount += 1;
            spawn.gameObject.GetComponent<Spawn>().SpawnCounter--;
            Destroy(gameObject);
        }
        if (enableTeleport)
        {
            doTeleport();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
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

    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }

    void doTeleport()
    {
        //it'll follow u when ur out the range
        // enemy stick to player
        int switcher = 1;
        if (switcher == 1)
        {
            if (EnemyDetectRange)
            {
                //teleport in range
                if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) > SearchRange)
                {
                    setPlace(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
                }
                switcher--;
            }
        }
        else
        {
            Debug.Log("No Teleport" + switcher);//wut? 
        }

    }
    void setPlace(float x, float y)
    {
        int RndNP;
        do
        {
            RndNP = Random.Range(-1, 2);
        } while (RndNP == 0);
        float TeleX = x + 2 * RndNP;
        transform.position = new Vector3(TeleX, y, 0);
    }

}