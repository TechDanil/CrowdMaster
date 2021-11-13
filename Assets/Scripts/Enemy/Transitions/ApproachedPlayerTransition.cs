﻿using UnityEngine;

public class ApproachedPlayerTransition : EnemyTransition
{
    [SerializeField] private float _approachedDistance;
   
    public override void Enable()
    {
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < _approachedDistance)
            NeedTransit = true;
    }
}
