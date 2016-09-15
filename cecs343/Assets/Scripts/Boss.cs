using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public float speed = .5F;
    public int eHealth;
    public int AttackRange;
    public float AttackFreq;
    public GameObject prefab;
    public float timer = 0;
    public float FaceDir;
    public bool turn;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        //Debug.Log(gameObject.transform.position.x - GameObject.Find("Player").transform.position.x);
        if (AttackRange >= Vector3.Distance(GameObject.Find("Player").transform.position, transform.position))
        {
            //Debug.Log("Loaded");
            //Fire();
            StartCoroutine(Wait(2.0f));
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
        FaceDir = this.gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;
        timer += Time.deltaTime;
        if(timer >= AttackFreq)
        {
            Debug.Log("Fire In The Hole !");
            if (FaceDir > 0)
            {
                Instantiate(prefab, new Vector3(this.gameObject.transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
                timer = 0;
                turn = false;
            }
            if (FaceDir < 0)
            {
                Instantiate(prefab, new Vector3(this.gameObject.transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
                timer = 0;
                turn = true;
            }
        }
        
    }
    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        Fire();
    }
}