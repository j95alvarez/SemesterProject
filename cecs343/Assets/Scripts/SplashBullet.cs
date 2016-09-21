using UnityEngine;
using System.Collections;

public class SplashBullet : MonoBehaviour {
    public float speed;
    public float duration; // How long this ability lasts, in seconds.
    public float hitsPerSecond; // How many times it hits per second.

    private bool sign;
    private int damagePerTick;
    private int dps; // Does this much damage per second.
    private float startTime;
    private float internalCooldown; // How long before it attempts to inflict damage again.
    // Use this for initialization
    void Start () {
        sign = GameObject.Find("Player").GetComponent<PlayerMovement>().needRev;
        dps = GameObject.Find("Player").GetComponent<PlayerMovement>().splashDPS;
        if (sign) speed = -speed; // If player is facing left, then make bullet travel left.
        startTime = Time.time;
        internalCooldown = 1/hitsPerSecond;
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (startTime + duration < Time.time) Destroy(gameObject); // Destroy object after duration seconds.

        internalCooldown -= Time.deltaTime;
        Debug.Log(internalCooldown);
        StartCoroutine(Wait(2.0F));
    }
    // On contact with an enemy, inflict damage every frame.
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.name == "Enemy 1" && internalCooldown <= 0)
        {
            Debug.Log("Splash attack did damage.");
            col.gameObject.GetComponent<EnemyAI>().eHealth -= 1;
        }
    }
    
    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
