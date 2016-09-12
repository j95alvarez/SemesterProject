using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public GameObject target, prefab;
    public bool NeedRev = false;
    public bool isClimbing, climb;
    public float GetScaleX;
    public float GetScaleY;

    private int pHealth = 100;

    Object nasd;

    
    public float offest;
    // Use this for initialization
    void Start() {
        GetScaleX = transform.localScale.x;
        GetScaleY = transform.localScale.y;
        isClimbing = false;
        climb = false;

    }

    // Update is called once per frame
    void Update() {

        //Moving Direction Detacter
        //Use NeedRev to determin does the 
        //left right key need to reverse
        if (Input.GetAxis("Horizontal") > 0.1) {
            //Debug.Log("Pos");
            transform.localScale = new Vector2(GetScaleX, GetScaleY);
            NeedRev = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.1) {
            //Debug.Log("Neg");
            transform.localScale = new Vector2(-GetScaleX, GetScaleY);
            NeedRev = true;
        }

        // Basic player movement and 
        if (Input.GetKey(KeyCode.Space) && !isClimbing) {
            //Debug.Log("UP");
            VerticalMove(jump * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            //while player change face direction
            if (NeedRev) {
                //Debug.Log("reverse1");
                HorizontalMove((speed * Time.deltaTime));
            } else {
                //Debug.Log("Left");
                HorizontalMove(-(speed * Time.deltaTime));
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (NeedRev) {
                //Debug.Log("reverse2");
                HorizontalMove(-(speed * Time.deltaTime));
            } else {
                //Debug.Log("Right");
                HorizontalMove(speed * Time.deltaTime);
            }

        }

        if (Input.GetKeyDown(KeyCode.Z) && !isClimbing) {
            //Debug.Log("Attack");
            Attack();
        }

        if (climb) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                VerticalMove(speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                VerticalMove(-(speed * Time.deltaTime));
            }
        }
    }

    void HorizontalMove(float amount) {
        transform.Translate(amount, 0, 0);
    }

    void VerticalMove(float amount) {
        transform.Translate(0, amount, 0);
    }

    
    void Attack() {
        StartCoroutine(Wait(3.0F));
        if (NeedRev)
            Instantiate(prefab, new Vector3(transform.position.x - offest, transform.position.y, transform.position.z), Quaternion.identity);
        else
            Instantiate(prefab, new Vector3(transform.position.x + offest, transform.position.y, transform.position.z), Quaternion.identity);
        Debug.Log(NeedRev);
        //nasd = Instantiate(prefab, new Vector3(transform.position.x + offest, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        //Destroy(nasd);
    }


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy 1") {
            if (pHealth > 0) {
                pHealth -= 10;
            }
            Debug.Log("phealth is: " + pHealth);
        }
    }
}
