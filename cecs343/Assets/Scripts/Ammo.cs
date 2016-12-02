using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ammo : MonoBehaviour {
    public GameObject player;
    private Text ammo,killCount;
    private int maxAmmo;

    // Use this for initialization
    void Start () {
        ammo = GetComponent<Text>();
        maxAmmo = player.GetComponent<ShootController>().maxShots;
        ammo.text = "Ammo: " + (player.GetComponent<ShootController>().shots) + " / " + maxAmmo;
        ammo.text += " Grenade: 1 / 1";
        ammo.text += " Kill: " + killCount;
    }
	
	// Update is called once per frame
	void Update () {
        ammo.text = (!player.GetComponent<PlayerMovement>().canShoot) ? 
            "Ammo: Reloading..." : "Ammo: " + (player.GetComponent<ShootController>().shots) + " / " + maxAmmo + " ";

        ammo.text += (!player.GetComponent<GrenadeAttack>().canGrenade) ?
            "\nGrenade: Reloading..." : "\nGrenade: 1 / 1\t\t\t\t";
        ammo.text += " Kill: " + player.GetComponent<PlayerMovement>().EneDCount.ToString();
    }
}
