using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] LayerMask _ground;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _currentSpeed;
    private int _moveState;

    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TryMove();
        Flip();

        _animator.SetInteger(AnimatorPlayerController.States.MoveState, _moveState);
    }

    private void FixedUpdate()
    {
        TryJump();
    }

    private void TryMove()
    {
        _currentSpeed = Input.GetAxisRaw("Horizontal") * _movementSpeed;
        _rigidbody.velocity = new Vector2(_currentSpeed, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        float localScaleX = 3.6f;
        float zeroSpeed = 0;

        if (_currentSpeed < zeroSpeed)
        {
            _moveState = (int) AnimationState.Run;
            transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        }
        else if (_currentSpeed > zeroSpeed)
        {
            _moveState = (int) AnimationState.Run;
            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        }
        else
        {
            _moveState = (int) AnimationState.Idle;
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        }
    }

    private void TryJump()
    {
        float xPosition = 0.3f;
        float yPosition = 3.1f;
        float angle = 360;

        _isGrounded = Physics2D.OverlapBox(transform.position, new Vector2(xPosition, yPosition), angle, _ground);

        if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            _animator.Play(AnimatorPlayerController.States.Jump);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private enum AnimationState
    {
        Idle = 0,
        Run = 1
    }
}
