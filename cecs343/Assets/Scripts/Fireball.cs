using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
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
