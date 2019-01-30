using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int shotsLeft;
	public float speed = 10f;
	public float rotationSpeed = 90;
	public float force = 250f;
	public GameObject ball;
	public GameObject cannon;
    //public Animator animator;
    // public float InputX;
    // public float InputY;
    // public float Jump;

	private Rigidbody rb;
	private Transform t;
    // Start is called before the first frame update
    void Start()
    {
         shotsLeft = 5;
         rb = GetComponent<Rigidbody>();
         t = GetComponent<Transform>();
         //animator = GetComponent<Animator>();
    }
    public int getShotsLeft(){
        return shotsLeft;
    }
    // Update is called once per frame
    void Update()
    {
        
        // InputX = Input.GetAxis("Vertical");
        // animator.SetFloat("InputX", InputX);

        // Jump = Input.GetAxis("Jump");
        // animator.SetFloat("Jump", Jump);

        if (Input.GetKey(KeyCode.W)){
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.S)){
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
            rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            rb.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * force);
        }


        if (Input.GetKeyDown(KeyCode.Tab) && shotsLeft != 0)
        {
           shotsLeft--;
           GameObject newBall = GameObject.Instantiate(ball, cannon.transform.position, cannon.transform.rotation) as GameObject;
           newBall.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
           newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * 400);
        }
    }
}
