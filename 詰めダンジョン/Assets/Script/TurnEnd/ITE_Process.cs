using UnityEngine;

// ターン終了時の処理インターフェース
public abstract class ITE_Process : MonoBehaviour {
   
    /// <returns> 処理が終了してるならtrue </returns>
    public abstract void Execute();
}