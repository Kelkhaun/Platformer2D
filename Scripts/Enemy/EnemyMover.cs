using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint1;
    [SerializeField] private Transform _targetPoint2;

    [SerializeField] private float _movementSpeed;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[] { _targetPoint1, _targetPoint2 };
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _movementSpeed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void Flip()
    {
        if (transform.position == _targetPoint1.transform.position)
        {
            _spriteRenderer.flipX = false;
        }
        else if (transform.position == _targetPoint2.transform.position)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
