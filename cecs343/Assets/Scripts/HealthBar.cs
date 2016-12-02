using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	static int healthBarY = 15; 
	public GameObject healthBar;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(player.GetComponent<PlayerMovement>().pHealth, healthBarY);
    }
}
