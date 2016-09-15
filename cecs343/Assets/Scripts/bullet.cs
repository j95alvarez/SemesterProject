using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    public bool sign;

    // Use this for initialization
    void Start () {
        sign = GameObject.Find("Player").GetComponent<PlayerMovement>().needRev;
    }

    // Update is called once per frame
    void Update () {
        if (sign)
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(speed * Time.deltaTime, 0, 0);
        
        StartCoroutine(Wait(2.0F));
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
