using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public float speed;
    public GameObject Dir;
    public bool Sign;

    // Use this for initialization
    void Start()
    {
        Dir = GameObject.Find("Boss");
        Sign = Dir.GetComponent<Boss>().turn;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sign)
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(speed * Time.deltaTime, 0, 0);
        StartCoroutine(Wait(2.0F));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().pHealth -= 20;
        }
        Destroy(this.gameObject);
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
