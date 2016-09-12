using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    //spawning would be MaxSpawnDistance - SafeDistnaces
    //popcorn!
    public float setDTime;
    public float time;
    public float SafeDistnace;       //min
    public float MaxSpawnDistance;   //max
    public int Amount;
    private float RandomPoint;
    private int NegPosXRandom;

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
        for (int i = 0; i< Amount; i++)
        {
            RandomPoint = Random.Range(SafeDistnace, MaxSpawnDistance);
            do
            {
                NegPosXRandom = Random.Range(-1, 2);
            } while (NegPosXRandom == 0);
            Vector3 Range = new Vector3(transform.position.x + (RandomPoint* NegPosXRandom), transform.position.y, transform.position.z);
            //Debug.Log("Point X = " + RandomPoint * NegPosXRandom + " Spawn !");
             GameObject newName = (GameObject)Instantiate(GameObject.Find("Enemy 1"), Range, transform.rotation);
            newName.name = GameObject.Find("Enemy 1").name;
            //GameObject.Find("Enemy 1").transform.name = "Enimy_1";
        }
    }
}
