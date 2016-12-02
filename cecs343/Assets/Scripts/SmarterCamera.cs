using UnityEngine;
using System.Collections;

public class SmarterCamera : MonoBehaviour {

    public GameObject player;
    public float xThreshold, yThreshold;
    public int maxZoom, minZoom;
    public float smoothCoeff;

    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        Camera.main.orthographicSize = 4;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        var viewPosition = Camera.main.WorldToViewportPoint(player.transform.position);
        var position = player.transform.position;
        position.z = transform.position.z;

        if(viewPosition.x < 1.0/xThreshold || viewPosition.x > (xThreshold-1)/xThreshold || viewPosition.y < 1.0 / yThreshold || viewPosition.y > (yThreshold-1)/yThreshold)
        {
            transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothCoeff);
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
