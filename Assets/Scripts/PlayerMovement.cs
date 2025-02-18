using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    
    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // We are using it to mass with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Right movement
        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Left movement
        if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -3f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
