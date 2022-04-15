using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _xOffset;
    private float _yOffset = -2f;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _xOffset, _player.transform.position.y - _yOffset, transform.position.z);
    }
}

