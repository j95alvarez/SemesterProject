using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    private static int maxShots = 10;
    public int shots;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (shots > maxShots || Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reloading...");
            this.gameObject.GetComponent<PlayerMovement>().canShoot = false;
            StartCoroutine(Wait(2.0f));
            shots = 1;
        }
	}

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Done Reloading");
        this.gameObject.GetComponent<PlayerMovement>().canShoot = true;
    }
}
