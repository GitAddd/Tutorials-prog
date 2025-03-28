using UnityEngine;

public class jumpforce : MonoBehaviour
{
    public float jumpForce = 10f;  
    private Rigidbody rb;          

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}