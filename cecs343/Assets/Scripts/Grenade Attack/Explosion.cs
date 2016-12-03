using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float knockback;
    public int damage;

    Animator animatorObj;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(wait(1.5f));
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Rigidbody2D physic = col.gameObject.GetComponent<Rigidbody2D>();
        Vector2 epicenter = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        Vector2 target = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);

        if (col.gameObject.name == "Enemy")
        {
            col.gameObject.GetComponent<EnemyAI>().eHealth -= damage;
        }

        if (col.gameObject.name == "Patrolling Enemy")
        {
            col.gameObject.GetComponent<PatrollingScript>().eHealth -= damage;
        }

        if (col.gameObject.name == "Projectile")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "Boss")
        {
            col.gameObject.GetComponent<BossAI>().bossHP -= damage;
        }
        physic.AddForce((target-epicenter) * 1000);
    }


    private IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}