using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _coins;

    public void AddCoin()
    {
        _coins++;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
