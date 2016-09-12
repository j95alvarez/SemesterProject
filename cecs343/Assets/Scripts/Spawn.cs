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
    public int count;
    public int max;

    // Use this for initialization
    void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //count second.
        time += Time.deltaTime;

        // Every x intervals, spawn more monsters unless monster cap has been reached. Count has to be decremented as enemies are killed to reenable spawner, or reinstantiated to 0 to implement waves.
        if (time > setDTime && count < max)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    // Spawns AMOUNT enemies every iteration.
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
            Debug.Log("Point X = " + RandomPoint * NegPosXRandom + " Spawn !");
            Instantiate(GameObject.Find("Enemy 1"), Range, transform.rotation);
            count++;
        }
    }
}
