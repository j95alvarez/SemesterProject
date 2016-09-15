using UnityEngine;
using System.Collections;

public class SmarterCamera : MonoBehaviour {

    public GameObject player;
    public float xThreshold, yThreshold;
    public int followSpeed;
    public float currentX;
    public double what;
    public Vector3 position;

	// Use this for initialization
	void Start () {
        Camera.main.orthographicSize = 5;
	}
	
	// Update is called once per frame
	void Update () {
        position = player.transform.position;

        currentX = position.x;
        //if(position.x < 1.0/xThreshold) {
        //    transform.Translate(followSpeed*-1*Time.deltaTime, 0, 0);
        //    transform.Translate(1, 0, 0);
        //}
        what = 1.0 / xThreshold;

        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
    }
}
