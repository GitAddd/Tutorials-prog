using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody _rigidbody;

    private bool _running;
    private float _horizontalInput;

    private static float _SPEED = 3f;
    private static float _JUMP_FORCE = 6f;

  
    void Start()
    {

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _running = false;
        
    }

   
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("Jump");
            _rigidbody.AddForce(_JUMP_FORCE * Vector3.up, ForceMode.Impulse);
        }
        else 
        {
            _animator.Play("Idle");
        }
       
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_horizontalInput, 0f, 0f));
            _rigidbody.MovePosition(_rigidbody.position - transform.forward * _SPEED * Time.fixedDeltaTime);

          
            _animator.Play("Run");
            _running = true;    
            
        }else if (_horizontalInput < 0.01f) 
        {
            _running = false;   
        }


        if (!_running)
        {
            _animator.Play("Idle");
        }

    }
}