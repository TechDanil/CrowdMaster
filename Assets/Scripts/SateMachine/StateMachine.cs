using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public abstract void Transit(State nextState);
}
