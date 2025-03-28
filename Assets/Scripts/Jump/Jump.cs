using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float jumpCooldown = 1f;
    public float recoveryHeight = 3f;
    private Rigidbody rb;
    private float lastJumpTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastJumpTime + jumpCooldown)
        {
            CorrectUprightAndJump();
        }
    }
    void Kaas()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
    }
    void CorrectUprightAndJump()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position += Vector3.up * recoveryHeight;
        Kaas();
    }
}
