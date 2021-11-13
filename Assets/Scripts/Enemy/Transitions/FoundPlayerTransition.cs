using UnityEngine;

public class FoundPlayerTransition : EnemyTransition
{
    [SerializeField] private float _foundDistance;

    public override void Enable()
    {
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < _foundDistance)
            NeedTransit = true;
    }


}
