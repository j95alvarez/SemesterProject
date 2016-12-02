using UnityEngine;
using System.Collections;

public class GrenadeAttack : MonoBehaviour {

    public GameObject grenade;
    private float offest;
    public float forceIncrement;
    public float startTime;

    public bool canGrenade;
    // Use this for initialization
    void Start()
    {
        canGrenade = true;
        offest = this.gameObject.GetComponent<PlayerMovement>().offest;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canGrenade)
        {
            startTime = Time.time;
        }
        if(Input.GetKeyUp(KeyCode.X) && canGrenade)
        {
            float force = (Time.time - startTime) * forceIncrement;
            if (force < 200) force = 200;
            else if (force > 600) force = 600;
            throwGrenade(force);
        }
    }

    void throwGrenade(float force)
    {
        this.gameObject.GetComponent<ShootController>().throwGrenade -= 1;
        Vector3 spawnLocation = transform.position;

        if (this.gameObject.GetComponent<PlayerMovement>().needRev)
        {
            spawnLocation.x -= offest;
            GameObject thrown = (GameObject)Instantiate(grenade, spawnLocation, Quaternion.identity);
            thrown.GetComponent<Grenade>().addForce(new Vector3(force * Mathf.Cos(45) * -1, force * Mathf.Sin(45), 0)); // Throw grenade at an angle.
        }
        else
        {
            spawnLocation.x += offest;
            GameObject thrown = (GameObject)Instantiate(grenade, spawnLocation, Quaternion.identity);
            thrown.GetComponent<Grenade>().addForce(new Vector3(force*Mathf.Cos(45),force*Mathf.Sin(45),0)); // Throw grenade at an angle.
        }

    }
}
