using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public float speed = .5F;
    public int eHealth;

    public float counter;
    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
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
    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(1);
        speed = .5f;
    }
}
