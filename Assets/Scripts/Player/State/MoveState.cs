using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;

    [SerializeField] private PlayerInput _playerInput;


    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
        _staminaAccumulator.StartAccumalate();
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
    }

    private void OnDirectionChanged(Vector2 direction)
    {
        Ridgibody.velocity = new Vector3(direction.x, 0f, direction.y) * _speedRatio; 

        if (Ridgibody.velocity.magnitude > _maxSpeed)
            Ridgibody.velocity *= _maxSpeed / Ridgibody.velocity.magnitude;

        if (Ridgibody.velocity.magnitude != 0)
            Ridgibody.MoveRotation(Quaternion.LookRotation(Ridgibody.velocity, Vector3.up));
    }
}
