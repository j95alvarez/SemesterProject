using UnityEngine;
using System.Collections;

public class GrenadeAttack : MonoBehaviour {

    public GameObject grenade;
    private float offest;
    public float force;

    public bool canGrenade;
    // Use this for initialization
    void Start()
    {
        canGrenade = true;
        offest = this.gameObject.GetComponent<PlayerMovement>().offest;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && canGrenade)
        {
            throwGrenade();
        }
    }

    void throwGrenade()
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
