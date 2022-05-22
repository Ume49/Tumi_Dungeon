using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAction : MonoBehaviour
{
    ///<summary> 返り値：処理が終了しているならtrue </summary>
    virtual public bool _update() { return false; }
}
