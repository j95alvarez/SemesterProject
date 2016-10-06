using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    public int maxShots = 10;
    public int shots, specialShot;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (shots <= (maxShots - 10) || Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reloading...");
            this.gameObject.GetComponent<PlayerMovement>().canShoot = false;
            StartCoroutine(Wait(2.0f, 1));
            shots = maxShots;
        }

        if (specialShot <= (maxShots - 10))
        {
            this.gameObject.GetComponent<PlayerMovement>().specialShot = false;
            StartCoroutine(Wait(3.0f, 2));
            specialShot = 1;
        }
	}

    IEnumerator Wait(float waitTime, int controller)
    {
        yield return new WaitForSeconds(waitTime);
        if (controller == 1)
        {
            Debug.Log("Done Reloading");
            this.gameObject.GetComponent<PlayerMovement>().canShoot = true;
        }
        else if (controller == 2)
        {
            Debug.Log("Done Reloading Special");
            this.gameObject.GetComponent<PlayerMovement>().specialShot = true;
        }
        
    }
}
