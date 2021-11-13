using UnityEngine;

public class EnemyState : State
{
    [SerializeField] private EnemyTransition[] _transitions;

    public Player Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Player player)
    {
        if (enabled == false)
        {
            Ridgibody = rigidbody;

            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
            }
        }
    }


    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.State;
            }
        }

        return null;
    }
}
