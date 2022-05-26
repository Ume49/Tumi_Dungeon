using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAction : MonoBehaviour
{
    ///<summary> 処理が終了してるならtrueを返す </summary>
    public abstract bool _update();
}
