using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    public bool sign;


    // Use this for initialization
    void Start () {
        sign = GameObject.Find("Player").GetComponent<PlayerMovement>().needRev;
        if (sign) {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        } 
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        StartCoroutine(Wait(2.0F));
    }


    void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.name == "Enemy") {
            col.gameObject.GetComponent<EnemyAI>().eHealth -= 20;
        }

        if (col.gameObject.name == "Patrolling Enemy") {
            col.gameObject.GetComponent<PatrollingScript>().eHealth -= 20;
        }

        if (col.gameObject.name == "Projectile") {
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "Boss") {
            col.gameObject.GetComponent<BossAI>().bossHP -= 20;
        }
        Destroy(this.gameObject);
    }
    
    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
