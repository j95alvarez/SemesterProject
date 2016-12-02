using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float radius;
    public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(wait(2.0f));
	}

    void OnTriggerEnter2D(Collider2D col)
    {
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
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= damage;
        }
    }

    private IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}