using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthContainer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _fallDistance;

    private HealthContainer _health;

    public event UnityAction Damaged;

    public event UnityAction Died;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        enabled = false;
        Debug.Log("died");
    }

    private void Awake()
    {
        _health = GetComponent<HealthContainer>();
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage((int)damage);

        if (_health.Health <= 0)
        {
            gameObject.SetActive(false);
            Died?.Invoke();
        }

        Debug.Log("attacked");
    }
}
