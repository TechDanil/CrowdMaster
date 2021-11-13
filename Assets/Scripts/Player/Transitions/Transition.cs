using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public bool NeedTransit { get; protected set; }

    protected virtual void OnEnable()
    {
        NeedTransit = false;

        Enable();
    }

    public abstract void Enable();
}
