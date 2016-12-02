using UnityEngine;
using System.Collections;

public class PatrollingScript : MonoBehaviour {
    public bool facingLeft, canFlip;

    public GameObject EneKCount;

    public int eHealth;

    [SerializeField]
    private int amount;

	// Use this for initialization
	void Start () {
        EneKCount = GameObject.Find("Player");
        facingLeft = true;
        canFlip = false;
        gameObject.name = "Patrolling Enemy";
        eHealth = 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (eHealth <= 0)
        {
            EneKCount.gameObject.GetComponent<PlayerMovement>().EneDCount += 1;
            Destroy(gameObject);
        }

        if (!facingLeft && canFlip)
        {
            canFlip = false;
            facingLeft = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else
        {

            if (facingLeft && canFlip)
            {
                canFlip = false;
                facingLeft = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }

        
        if (facingLeft)
            transform.Translate(-amount * Time.deltaTime, 0, 0);
        else
            transform.Translate(amount * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= 10;
        }
    }
}
