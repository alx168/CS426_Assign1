using UnityEngine;

public class wallColors : MonoBehaviour
{
    private Color color1 = new Vector4(1f,1f,1f,1f);
    private Color color2 = new Vector4(1f,1f,1f,1f);
    private Renderer rend;
    private Random rng = new Random();

    [SerializeField]
    float duration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(color1, color2, lerp);
    }
    private void OnTriggerEnter(Collider other){
    	if (other.tag == "Ball"){
    		color1 = color2;
    		color2 = new Vector4(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1);	
    	}
    }
}
