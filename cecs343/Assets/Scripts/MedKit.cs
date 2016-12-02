//Author: Danny Chau
/*
 * healAmount: Amount to heal the player.
 * Overheal: 0 makes medkits heal to full hp, 1 makes medkits heal over full hp.
 */

using UnityEngine;
using System.Collections;

public class MedKit : MonoBehaviour {
    public int healAmount;
    public int overHeal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    // If this item makes contact with a player, Heal the player.
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
        {
            PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
            if(overHeal == 1) // If overheal is 1, medpacks will heal the player over max hp.
            {
                player.pHealth += healAmount;           
            }
            else // If overheal is 0, medpacks will heal to max hp only.
            {
                if (player.pHealth == player.maxHealth) ; //If player health == max health, don't pick up the medkit.
                else if (player.pHealth + healAmount > player.maxHealth) //If player would heal more than his max hp, then heal to max and not more.
                {
                    player.pHealth = player.maxHealth;
                    Destroy(gameObject);
                }
                else //If player would not heal more than his max hp, heal full amount.
                {
                    player.pHealth += healAmount;
                    Destroy(gameObject);
                }
            }
        }
    }
}
