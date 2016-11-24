using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {
    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded, _jump;

    [SerializeField]
    private float jumpForce;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _jump = true;
        }

        if (IsGrounded() && _jump) {
            _jump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
	}

    private bool IsGrounded() {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0) {
            foreach (Transform point in groundPoints) {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++) {
                    if (colliders[i].gameObject != gameObject) {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
