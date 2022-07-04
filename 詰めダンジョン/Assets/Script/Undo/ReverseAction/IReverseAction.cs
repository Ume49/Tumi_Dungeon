using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IReverseAction : MonoBehaviour
{
    ///<summary> シーン上の動きを実装する処理、終了したらtrueを返す</summary>
    public abstract bool _update();
}
