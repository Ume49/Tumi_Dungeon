using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICommand
{
    public enum ID{
        Attack,
        Move
    }

    // 何を派生しているか識別するためのID
    public ID id;
}
