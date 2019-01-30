using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
	public ScoreManager scoreM;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other){
    	if(other.tag == "Ball"){
    		ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
    		ps.Play();
    		scoreM.add();
    		Destroy(other.gameObject);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
