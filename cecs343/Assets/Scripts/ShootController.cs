using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    public int maxShots = 10;
    public float reloadTime, specialReload, grenadeReload;
    public int shots, specialShot, throwGrenade;
	// Use this for initialization
	void Start () {
        shots = maxShots;
        throwGrenade = 1;
        specialShot = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (shots <= (maxShots - 10) || Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reloading...");
            this.gameObject.GetComponent<PlayerMovement>().canShoot = false;
            StartCoroutine(Wait(reloadTime, 1));
            shots = maxShots;
        }

        if (specialShot <= (maxShots - 10))
        {
            this.gameObject.GetComponent<PlayerMovement>().specialShot = false;
            StartCoroutine(Wait(specialReload, 2));
            specialShot = 1;
        }
        if (throwGrenade == 0)
        {
            this.gameObject.GetComponent<GrenadeAttack>().canGrenade = false;
            StartCoroutine(Wait(grenadeReload, 3));
            throwGrenade = 1;
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
        else if (controller == 3)
        {
            Debug.Log("Done Reloading Grenade");
            this.gameObject.GetComponent<GrenadeAttack>().canGrenade = true;
        }
        
    }
}
