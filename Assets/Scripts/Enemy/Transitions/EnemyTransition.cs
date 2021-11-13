using UnityEngine;

public abstract class EnemyTransition : Transition
{
    [SerializeField] private EnemyState _state;

    public EnemyState State => _state;

    protected Player Player { get; private set; }

    public void Init(Player player)
    {
        Player = player;
    }
}
