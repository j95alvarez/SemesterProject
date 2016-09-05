using UnityEngine;
using System.Collections;

public class FadeAwayDamage : MonoBehaviour {
    private SpriteRenderer rend;
    private ParticleSystem jumpParticle;
    private Color fadeCol;
    private Color startCol;
    public float fadeTime;
    private float t = 0;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        jumpParticle = GetComponent<ParticleSystem>();
        startCol = rend.material.color;
        fadeCol = new Color(startCol.r, startCol.g, startCol.b, 0);
        jumpParticle.Emit(6);
    }

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
