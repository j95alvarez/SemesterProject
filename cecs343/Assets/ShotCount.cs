using UnityEngine;
using System.Collections;

public class ShotCount : MonoBehaviour {
    private static int maxShot = 10;
    public int shotCount;
    // Use this for initialization
    void Start () {
        shotCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (shotCount == 10) {
            this.gameObject.GetComponent<PlayerMovement>().canShoot = false;
            StartCoroutine(Wait(2.0f));
            shotCount = 0;
        }
	}

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Done reloading");
        this.gameObject.GetComponent<PlayerMovement>().canShoot = true;
        Debug.Log(this.gameObject.GetComponent<PlayerMovement>().canShoot);
    }
}
