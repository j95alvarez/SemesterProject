using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    //GameObject enemy;
    public bool Sign;

    GameObject HP;
    private int health;

    // Use this for initialization
    void Start () {
        GameObject target;
        target = GameObject.Find("Player");
        Sign = target.GetComponent<PlayerMovement>().needRev;
        //Debug.Log(Sign);
    }

    // Update is called once per frame
    void Update () {
        if (Sign)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            StartCoroutine(Wait(2.0F));
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            StartCoroutine(Wait(2.0F));
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Enemy 1")
        {
            col.gameObject.GetComponent<EnemyAI>().eHealth -= 10;
        }
        Destroy(this.gameObject);
    }
    /*void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy 1") {
            if (collision.gameObject.GetComponent<PlayerStatus>().health > 0) {
                collision.gameObject.GetComponent<PlayerStatus>().health -= 10;
            }
            Debug.Log("phealth is: " + collision.gameObject.GetComponent<PlayerStatus>().health);
        }

        Destroy(this.gameObject);
    }*/

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
