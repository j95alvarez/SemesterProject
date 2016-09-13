using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    public bool Sign;

    // Use this for initialization
    void Start () {
        GameObject target;
        target = GameObject.Find("Player");
        Sign = target.GetComponent<PlayerMovement>().needRev;
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
            col.gameObject.GetComponent<EnemyAI>().eHealth -= 20;
        }
        Destroy(this.gameObject);
    }
    
    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
