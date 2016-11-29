using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {
    public GameObject player, projectile;

    [SerializeField]
    private float speed, offest;

    public bool shot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RangeAttack();
    }

    void RangeAttack() {
        if (CalculateMagnitude() > 5)
        {
            if (!shot) {
                shot = true;
                Instantiate(projectile, new Vector3(transform.position.x - offest, transform.position.y + offest, transform.position.z), Quaternion.identity);
                StartCoroutine(Shot());
            }
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator Shot() {
        yield return new WaitForSeconds(5);
        shot = false;
    }

    float CalculateMagnitude() {
        Vector3 vec = new Vector3((gameObject.transform.position.x - player.gameObject.transform.position.x), gameObject.transform.position.y - player.gameObject.transform.position.y, 0);
        float mag = Mathf.Sqrt(Mathf.Pow(vec.x, 2) + Mathf.Pow(vec.y, 2));
        Debug.Log("Magnitude: " + mag);
        return Mathf.Sqrt(Mathf.Pow(vec.x, 2) + Mathf.Pow(vec.y, 2));

    }
}
