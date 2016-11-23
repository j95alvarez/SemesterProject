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
        ammo.text += "\n Special: 1 / 1";
        ammo.text += "\n Kill: " + killCount;
    }
	
	// Update is called once per frame
	void Update () {
        ammo.text = (!player.GetComponent<PlayerMovement>().canShoot) ? 
            "Ammo: Reloading..." : "Ammo: " + (player.GetComponent<ShootController>().shots) + " / " + maxAmmo;

        ammo.text += (!player.GetComponent<PlayerMovement>().specialShot) ?
            "\nSpecial: Reloading..." : "\nSpecial: 1 / 1";
        ammo.text += "\nKill: " + player.GetComponent<PlayerMovement>().EneDCount.ToString();
    }
}
