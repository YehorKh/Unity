using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GUIStyle guiStyle;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera camera;
    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity;
    private float _speed;
    private int hp = 3;
    GameObject gm;
    private GameOver _actionTarget;
    private void Start()
    {
        _speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        gm = GameObject.Find("/Controller");
        _actionTarget = gm.GetComponent<GameOver>();
    }

    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _walkDirection = transform.right * x + transform.forward * z;
    }
    public void ReactToHit()
    {
        
        hp--;
        if (hp <= 0)
        {
            _actionTarget.EndGame();
        }

    }
    private void FixedUpdate()
    {
        Walk(_walkDirection);
        DoGravity(_characterController.isGrounded);
    }

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
    }

    private void DoGravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
            _velocity.y = -1f;
        _velocity.y -= _gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
            _velocity.y = _jumpPower;
    }
    private void OnGUI()
    {
        int n = 128;
        float xxx = camera.pixelWidth / 2;
        float yyy = 5.0F;
        GUI.Label(new Rect(xxx, yyy, n, n), hp.ToString() + "♥", guiStyle);



    }
    
}
