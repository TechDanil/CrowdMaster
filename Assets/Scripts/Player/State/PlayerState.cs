using UnityEngine;

public abstract class PlayerState : State
{
    [SerializeField] private PlayerTransition[] _transitions;

    public void Enter(Rigidbody rigidbody)
    {
        if (enabled == false)
        {
            Ridgibody = rigidbody;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
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

    public PlayerState GetNextState()
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
