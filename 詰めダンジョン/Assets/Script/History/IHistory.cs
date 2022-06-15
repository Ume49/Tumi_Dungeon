using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class IHistory
{
    // 中身が何なのか識別するID
    public enum ID
    {
        Move,
        Attack,
        Pickup,
        Deth
    }

    ID id;
}
