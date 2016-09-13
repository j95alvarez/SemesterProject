﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public GameObject target, prefab;
    public bool needRev;
    public bool isClimbing, climb;
    public float getScaleX, getScaleY, facing, bulletspeed, radius;
    public int pHealth;
    //KNOCKS
    public float KnockForce;
    public float KnockTime;
    public bool KnockRight;
    private float KnockCounter = 0;
    public Transform groundPoint;
    public LayerMask groundMask;

    public float offest;

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start() {
        getScaleX = transform.localScale.x;
        getScaleY = transform.localScale.y;
        isClimbing = climb = needRev = false;
        //facing = 1;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //Debug.Log(transform.localPosition);
        if (pHealth == 0)
            dead();
        //Moving Direction Detacter
        //Use NeedRev to determin does the 
        //left right key need to reverse
        if (Input.GetAxis("Horizontal") > 0.1) {
            //Debug.Log("Pos");
            transform.localScale = new Vector2(getScaleX, getScaleY);
            needRev = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.1) {
            //Debug.Log("Neg");
            transform.localScale = new Vector2(-getScaleX, getScaleY);
            needRev = true;
        }

        // Basic player movement and 
        if (Input.GetKey(KeyCode.Space) && !isClimbing) {
            //Debug.Log("UP");
            //Vector2 moveDirection = 
            

            // True or false if the overlap circle is on the layer mask

            // This stuff here transform the sprite depending on the number
            // If the value is 1, the sprite/character will face right
            // If the value is -1, the character will face left
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if ((Input.GetAxisRaw("Horizontal") == -1))
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) && (Physics2D.OverlapCircle(groundPoint.position, radius, groundMask)))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            //while player change face direction
            //facing = -1;
            if (needRev) {
                //Debug.Log("reverse1");
                HorizontalMove((speed * Time.deltaTime));
            } else {
                //Debug.Log("Left");
                HorizontalMove(-(speed * Time.deltaTime));
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            //facing = 1;
            if (needRev) {
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
    public void Knocked()
    {
        KnockCounter = 0;
        while (KnockTime > KnockCounter)
        {
            KnockCounter += Time.deltaTime;
            if (KnockRight)
                rb2D.velocity = new Vector2(-KnockForce, KnockForce);
            if (!KnockRight)
                rb2D.velocity = new Vector2(KnockForce, KnockForce);
        }
        Debug.Log("Knock Knock Knock");
    }

    void HorizontalMove(float amount) {
        transform.Translate(amount, 0, 0);
    }

    void VerticalMove(float amount) {
        transform.Translate(0, amount, 0);
    }

    
    void Attack() {
        StartCoroutine(Wait(3.0F));
        if (needRev)
            Instantiate(prefab, new Vector3(transform.position.x - offest, transform.position.y, transform.position.z), Quaternion.identity);
        else
            Instantiate(prefab, new Vector3(transform.position.x + offest, transform.position.y, transform.position.z), Quaternion.identity);
        //var nasd = (GameObject)Instantiate(prefab, new Vector3(transform.position.x + (offest*facing), transform.position.y, transform.position.z), Quaternion.identity);
        //nasd.GetComponent<bullet>().speed = bulletspeed * facing;
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        //Destroy(nasd);
    }
    void dead()
    {
        Destroy(gameObject);//blah blah blah
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy 1")
        {
            if (collision.transform.position.x > transform.position.x)
                KnockRight = true;
            else if (collision.transform.position.x < transform.position.x)
                KnockRight = false;
            Knocked();
        }
        
    }
}
