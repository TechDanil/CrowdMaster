using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private DiedState _diedState;
    [SerializeField] private HealthContainer _healthContainer;

    public Player Player { get; private set; }

    public event UnityAction<Enemy> Died;

    private Rigidbody _rigidbody;

    private float _minDamage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _healthContainer.Died += OnEnemyDie;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnEnemyDie;
    }

    private void OnEnemyDie()
    {
        enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died?.Invoke(this);
    }

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        EnemyStateMachine state = GetComponent<EnemyStateMachine>();

        if (force > _minDamage && state != _diedState)
        {
            _healthContainer.TakeDamage((int)force);
            state.Transit(_diedState);
            _diedState.ApplyDamage(rigidbody, force);
            return true;
        }

        return false;
    }
}
