using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Hand Ability", menuName = "Player/Abilities/Hand", order = 51)]
public class HandAbility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _usefullTime;

    private AttackState _state;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attack)
    {
        if (_coroutine != null)
            Reset();

        _state = attack;

        _coroutine = _state.StartCoroutine(Attack(_state));
        _state.CollisionDetected += OnPlayerAttack;
    }

    private void Reset()
    {
        _state.Ridgibody.velocity = Vector3.zero;
        _state.StopCoroutine(_coroutine);
        _coroutine = null;
        _state.CollisionDetected -= OnPlayerAttack;
    }

    private IEnumerator Attack(AttackState state)
    {
        float time = _usefullTime;

        while(time > 0)
        {
            state.Ridgibody.velocity = state.Ridgibody.velocity.normalized * _attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

    private void OnPlayerAttack(IDamageable damageable)
    {
        if (damageable.ApplyDamage(_state.Ridgibody, _attackForce) == false)
            return;

        _state.Ridgibody.velocity /= 2;
    }
}
