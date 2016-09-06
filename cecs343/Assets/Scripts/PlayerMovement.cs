using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jump;
    
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("UP");
            transform.Translate(0, (jump * speed * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("Down");
            transform.Translate(0, -(speed * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Left");
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Right");
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }
    }
}
