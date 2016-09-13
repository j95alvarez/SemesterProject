using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject player;
	public int zoom = 5;


	// Use this for initialization
	void Start () 
	{
        Camera.main.orthographicSize = zoom;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -1);
	}
}
