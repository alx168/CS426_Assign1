using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpMovement : MonoBehaviour
{
    public float speed;
    public float offsetX;
    public float total_lengthX;
    public float offsetY;
    public float total_lengthY;
    public bool lerpy;
    public bool lerpx;
    void Start()
    {
    	
    }

    // Follows the target position like with a spring
    void Update()
    {
        if(lerpx == true && lerpy == false){
        	transform.position = new Vector3(Mathf.PingPong(Time.time * speed, total_lengthX) - offsetX, 
        	transform.position.y, transform.position.z);	
        }else if(lerpy == true && lerpx == false){
        	transform.position = new Vector3(transform.position.x, 
        	Mathf.PingPong(Time.time * speed, total_lengthY) - offsetY, transform.position.z);
        }else if(lerpy == true && lerpx == true){
        	transform.position = new Vector3(Mathf.PingPong(Time.time * speed, total_lengthX) - offsetX, 
        	Mathf.PingPong(Time.time * speed, total_lengthY) - offsetY, transform.position.z);
        }
    }
}
