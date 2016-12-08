using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float speed;

    public bool shot;

    public int counter;

    private bool sign;

    // Use this for initialization
    void Start () {
        counter = 0;
        gameObject.name = "Projectile";
        shot = true;
        sign = GameObject.Find("Boss").GetComponent<BossAI>().faceingLeft;

        if (!sign) {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (counter > 2) {
            Destroy(gameObject);
        }
        if (shot) {
            shot = false;
            StartCoroutine(Delay());
        }

        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.name == "Player") {
            if (col.gameObject.GetComponent<PlayerMovement>().canAttack) {
                col.gameObject.GetComponent<PlayerMovement>().pHealth -= 30;
                Destroy(gameObject);
            }  
        }
    
       
    }


}
