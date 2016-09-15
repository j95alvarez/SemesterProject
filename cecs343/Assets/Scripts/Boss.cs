using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public float speed = .5F;
    public int eHealth;
    public int AttackRange;
    public float AttackFreq;
    public GameObject prefab;
    public float timer = 0;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        Debug.Log(transform.position);
        if (AttackRange >= Vector3.Distance(GameObject.Find("Player").transform.position, transform.position))
        {
            //Debug.Log("Loaded");
            Fire();
        }
        
        //Debug.Log(GameObject.Find("Player").transform.position);
        if (eHealth <= 0)
        {
            Destroy(gameObject);
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
    void Fire()
    {
        //float timer = 0;
        timer += Time.deltaTime;
        if(timer >= AttackFreq)
        {
            Debug.Log("Fire In The Hole !");
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //Debug.Log(transform.position.x);
            timer = 0;
        }
        
    }
    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }
}