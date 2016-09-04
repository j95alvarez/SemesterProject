    using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jump;
    public GameObject target, prefab;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            Debug.Log("UP");
            transform.Translate(0, (jump * speed * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            transform.Translate(0, -(speed * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Attack");
            attack();
        }
    }

    void attack ()
    {
        // create a variable called distance to make sure the distance is close enough
        // to inflict damage from a melee attack target.transform.positon = the position
        // of the object to attack and transform.position is the position of the players
        // transform
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // make sure the distance is not greater than 1.5 so the player cannot
        // melee an enemy from to far away
        if (distance < 1.5f)
        {
            Debug.Log("Hit");
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy 1")
        {
            Debug.Log("Collision with " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}
