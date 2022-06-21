using UnityEngine;

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

    public ID id;
}
