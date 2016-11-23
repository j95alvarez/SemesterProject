using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public GameObject target, prefab, SpecialBullet1;
    public bool needRev,isClimbing, climb, inAir, canShoot, specialShot;
    public float getScaleX, getScaleY, facing, bulletspeed, speed;
    public int pHealth, splashDPS , EneDCount;

    public float jumpCounter;

    //KNOCKS
    public float KnockForce, KnockTime;
    public bool KnockRight;
    private float KnockCounter = 0;

    //Projectile Variables
    public float special1Cooldown;
    private float special1TimeLeft;

    public float offest;

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start() {
        EneDCount = 0;
        getScaleX = transform.localScale.x;
        getScaleY = transform.localScale.y;
        isClimbing = climb = needRev = inAir = false;
        //facing = 1;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        canShoot = specialShot = true;
    }


    // Update is called once per frame
    void Update() {
        
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

        if (Input.GetKey(KeyCode.LeftArrow)) {
            //while player change face direction
            //facing = -1
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

        if (Input.GetKeyDown(KeyCode.Z) && !isClimbing && canShoot) {
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

        if (Input.GetKeyDown(KeyCode.X) && specialShot)
        {
            Special1();
        }

        special1TimeLeft -= Time.deltaTime; // Progress special cooldown

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
        this.gameObject.GetComponent<ShootController>().shots -= 1;

        if (needRev)
            Instantiate(prefab, new Vector3(transform.position.x - offest, transform.position.y, transform.position.z), Quaternion.identity);
        else
            Instantiate(prefab, new Vector3(transform.position.x + offest, transform.position.y, transform.position.z), Quaternion.identity);

        prefab.GetComponent<bullet>().speed = bulletspeed;
    }

    void Special1()
    {
        this.gameObject.GetComponent<ShootController>().specialShot -= 1;
        Vector3 spawnLocation = transform.position;

        if (needRev)
            spawnLocation.x -= offest;
        else
            spawnLocation.x += offest;

        Instantiate(SpecialBullet1, spawnLocation, Quaternion.identity);

        special1TimeLeft = special1Cooldown;

    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        
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
        if (collision.gameObject.name == "Boss")
        {
            if (collision.transform.position.x > transform.position.x)
                KnockRight = true;
            else if (collision.transform.position.x < transform.position.x)
                KnockRight = false;
            Knocked();
        }

        if (collision.gameObject.name == "ground") {
            inAir = false;
        }
        
    }
}
