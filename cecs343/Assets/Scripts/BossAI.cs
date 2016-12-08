using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {
    public GameObject player, projectile;
    public int bossHP;

    [SerializeField]
    private float speed, offest;

    
    public bool faceingLeft;


    [SerializeField]
    private bool canRush;

    public bool shot;

    [SerializeField]
    private int shotForce;

    private int halfHP;
    // Use this for initialization
    void Start() {
        faceingLeft = false;
        canRush = true;
        gameObject.GetComponent<Spawn>().enabled = false;
        halfHP = (bossHP / 2);
    }

    // Update is called once per frame
    void Update() {
        if (bossHP <= 0) {
            Time.timeScale = 0;
        }

        if (bossHP < halfHP) {
            gameObject.GetComponent<Spawn>().enabled = true;
        }

        NeedsFlip();
        RangeAttack();
        RushAttack();
    }

    void NeedsFlip() {
        if (CheckSide() < 0 && !faceingLeft)
        {
            faceingLeft = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else
        {

            if (faceingLeft && CheckSide() > 0) {
                faceingLeft = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    void RangeAttack() {

        if (CalculateMagnitude() > 5)
        {
            if (!shot) {
                shot = true;
                if (faceingLeft) {
                    Instantiate(projectile, new Vector3(transform.position.x - offest, transform.position.y, transform.position.z), Quaternion.identity);
                }

                else {
                    Instantiate(projectile, new Vector3(transform.position.x + offest, transform.position.y, transform.position.z), Quaternion.identity);
                }
                
                StartCoroutine(Shot());
            }

        }
        else {
            
        }
    }

    void RushAttack() {
        if (CalculateMagnitude() < 5 && canRush) {
            canRush = false;
            if (faceingLeft) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-shotForce, 0));
            }
            else {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(shotForce, 0));
            }

            StartCoroutine((Wait()));
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3);
        canRush = true;
    }

    IEnumerator Shot() {
        yield return new WaitForSeconds(5);
        shot = false;
    }

    float CalculateMagnitude() {
        Vector3 vec = new Vector3((gameObject.transform.position.x - player.gameObject.transform.position.x), gameObject.transform.position.y - player.gameObject.transform.position.y, 0);
        float mag = Mathf.Sqrt(Mathf.Pow(vec.x, 2) + Mathf.Pow(vec.y, 2));
        //Debug.Log("Magnitude: " + mag);
        return Mathf.Sqrt(Mathf.Pow(vec.x, 2) + Mathf.Pow(vec.y, 2));

    }

    float CheckSide() {
        return (player.gameObject.transform.position.x - gameObject.transform.position.x);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (col.gameObject.GetComponent<PlayerMovement>().canAttack)
            {
                col.gameObject.GetComponent<PlayerMovement>().pHealth -= 20;
            }

        }
    }
}
