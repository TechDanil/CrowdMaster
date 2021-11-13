using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] private EnemyState _firstState;

    private EnemyState _nextState;

    private EnemyState _currentState;

    private Rigidbody _rigidody;

    public Player Player { get; private set; }


    private void Awake()
    {
        _rigidody = GetComponent<Rigidbody>();
        Player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidody, Player);
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

        _currentState = (EnemyState)nextState;

        if (_currentState != null)
            _currentState.Enter(_rigidody, Player);
    }
}
