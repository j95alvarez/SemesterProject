using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public float setDTime;
    public float time;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //count second.
        time += Time.deltaTime;
        if (time > setDTime)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    void SpawnEnemy()
    {
        Vector3 Range = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("Spawn !");
        Instantiate(GameObject.Find("Enemy 1"), Range, transform.rotation);
    }
}
