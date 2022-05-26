using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemyAction : IAction
{
    public enum Act
    {
        Move,
        Attack,
        Wait
    }

    [SerializeField] protected Transform target_enemy;
}
