using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        StartCoroutine(Wait(2.0F));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy 1") {
            if (collision.gameObject.GetComponent<PlayerStatus>().health > 0) {
                collision.gameObject.GetComponent<PlayerStatus>().health -= 10;
            }
            Debug.Log("phealth is: " + collision.gameObject.GetComponent<PlayerStatus>().health);
        }

        Destroy(this.gameObject);
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
