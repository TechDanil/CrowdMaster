using UnityEngine;

public class PlayerMachineState : StateMachine
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _nextState;

    private PlayerState _currentState;

    private Rigidbody _rigidody;

    private void Awake()
    {
        _rigidody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidody);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        _nextState = _currentState.GetNextState();

        if (_nextState != null)
            Transit(_nextState);
    }

    public override void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = (PlayerState)nextState;

        if (_currentState != null)
            _currentState.Enter(_rigidody);
    }
}
