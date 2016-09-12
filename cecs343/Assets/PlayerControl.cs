using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;

    bool isGrounded;

    Rigidbody2D player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, player.velocity.y);
        player.velocity = moveDirection;

        // True or false if the overlap circle is on the layer mask
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        // This stuff here transform the sprite depending on the number
        // If the value is 1, the sprite/character will face right
        // If the value is -1, the character will face left
        if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if ((Input.GetAxisRaw("Horizontal") == -1)) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            player.AddForce(new Vector2(0, jumpHeight));
        }
    
	}

    void onDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }
}
