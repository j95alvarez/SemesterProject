using UnityEngine;
using System.Collections;

public class MortarProjectile : MonoBehaviour {
    public GameObject projectile;
    private GameObject mortar;

    [SerializeField]
    private bool isActive;

    [SerializeField]
    private int shotForce;
   
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (!isActive) {
            isActive = true;
            StartCoroutine(Delay());
        }
	}

    IEnumerator Delay() {
        Debug.Log("Started");
        mortar = (GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        mortar.gameObject.GetComponent<Projectile>().shot = false;
        yield return new WaitForSeconds(5);

        Debug.Log("Ended");
        mortar.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, shotForce));
        //mortar.gameObject.GetComponent<Projectile>().ChangeGravity();
        //StartCoroutine(Wait());

        mortar.gameObject.GetComponent<Projectile>().shot = true;
        //mortar.gameObject.GetComponent<Projectile>().ChangeGravity();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
        mortar.gameObject.GetComponent<Projectile>().shot = true;
        //mortar.gameObject.GetComponent<Projectile>().ChangeGravity();
    }
}
