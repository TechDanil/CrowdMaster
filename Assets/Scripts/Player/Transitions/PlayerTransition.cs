using UnityEngine;

public abstract class PlayerTransition : Transition
{
   [SerializeField] private PlayerState _state;

    public PlayerState State => _state;
}
