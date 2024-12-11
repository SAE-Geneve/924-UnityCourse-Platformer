using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _runForce = 10f;
    [SerializeField] ContactDetector _isGrounded;
    
    private Rigidbody2D _rb;
    
    bool _isJumping = false;
    float _horizontalInput = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isJumping && _isGrounded.ContactDetected)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        
        //_rb.AddForce(Vector2.right * _horizontalInput * _runForce, ForceMode2D.Force);
        _rb.linearVelocityX = _horizontalInput * _runForce;
        
    }

    // PlayerInput => SendMessages
    public void OnJump(InputValue value)
    {
        Debug.Log("On jump : Send Messages");
    }
    
    // PlayerInput => SendMessages
    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("On jump : Unity Events");
        if (context.started)
        {
            // Jump
            Debug.Log("Jump !!!!!!!!!!!!!!!!!!!!!");
            _isJumping = true;
        }
        if (context.canceled)
        {
            Debug.Log("End Jump !!!!!!!!!!!!!!!!!!!!!!!");
            _isJumping = false;
        }
        
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        _horizontalInput = context.ReadValue<float>();
        Debug.Log("On Run : " + _horizontalInput);
    }
    
}
