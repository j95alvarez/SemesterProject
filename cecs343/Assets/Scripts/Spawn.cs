using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    //spawning would be MaxSpawnDistance - SafeDistnaces
    //popcorn!
    public float setSpawnTime;
    public float timer;
    public float SafeDistnace;       //min
    public float MaxSpawnDistance;   //max
    public int Amount;
    public int SpawnCounter=0;
    public int SpawnLimit;

    private float RandomPoint;
    private int NegPosXRandom;
    public Object prefeb;

    private bool isBoss;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //count second.
        if(SpawnCounter < SpawnLimit - 1)
        {
            timer += Time.deltaTime;
            if (timer > setSpawnTime)
            {
                SpawnEnemy();
                timer = 0;
            }
        }else if(SpawnCounter >= SpawnLimit - 1)
        {
            timer = 0;
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
            GameObject newName = (GameObject)Instantiate(prefeb, Range, transform.rotation);
            newName.name = prefeb.name;
            SpawnCounter++;
        }
    }
}
