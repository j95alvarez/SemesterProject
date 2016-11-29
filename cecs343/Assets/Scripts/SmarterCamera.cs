using UnityEngine;
using System.Collections;

public class SmarterCamera : MonoBehaviour {

    public GameObject player;
    public float xThreshold, yThreshold;
    public float followSpeed;
    public int maxZoom, minZoom;

    // Use this for initialization
    void Start () {
        Camera.main.orthographicSize = 4;
        followSpeed = 1*GameObject.Find("Player").GetComponent<PlayerMovement>().speed;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        var position = Camera.main.WorldToViewportPoint(player.transform.position);

        if(position.x < 1.0/xThreshold)
        {
            transform.Translate(followSpeed*-1*Time.deltaTime, 0, 0); 
        }
        if(position.x > (xThreshold-1)/xThreshold)
        {
            transform.Translate(followSpeed * Time.deltaTime, 0, 0);
        }
        if(position.y < 1.0 / yThreshold)
        {
            transform.Translate(0, followSpeed * -1 * Time.deltaTime, 0);
        }
        if(position.y > (yThreshold-1)/ yThreshold)
        {
            transform.Translate(0, followSpeed * Time.deltaTime, 0);
        }

        if(Input.GetKeyDown(KeyCode.Equals)) zoomIn();
        if(Input.GetKeyDown(KeyCode.Minus)) zoomOut();

    }

    void zoomIn ()
    {
        if (Camera.main.orthographicSize > minZoom)
            Camera.main.orthographicSize--;
    }
    void zoomOut ()
    {
        if (Camera.main.orthographicSize < maxZoom)
            Camera.main.orthographicSize++;
    }
}
