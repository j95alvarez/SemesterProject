using UnityEngine;
using System.Collections;

public class FadeAwayDamage : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(Wait(3.0F));
        }
        
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        Destroy(this.gameObject);
    }
}
