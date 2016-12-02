using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

    public float timer;
    public GameObject explosion;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(wait(timer));
    }

    public void addForce(Vector3 vector)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(vector);
    }

    private IEnumerator wait(float waitTime)
    {
           yield return new WaitForSeconds(waitTime);
           Instantiate(explosion,this.gameObject.transform.position, Quaternion.identity);
           Destroy(this.gameObject);
    }
}
