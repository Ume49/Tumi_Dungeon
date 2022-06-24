using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Attach : MonoBehaviour
{
    [SerializeField] Transform system;

    void Reset()
    {
        system=transform.parent;
    }

    public void Attach() {
        // System直下の子Transformをまとめて取得
        List<Transform> all_transform=new List<Transform>();
        GetAllChildren.Get(system, all_transform);

        // インターフェース呼び出し
        foreach(var w in all_transform){
            TrySingletonAttach   (w);
            TryBroComponentAttach(w);    
        }

        Debug.Log("アタッチしました。");
    }


    // ISingletonAttach.Singleton_Attachを呼んでみる
    void TrySingletonAttach(Transform t){
        ISingletonAttach singleton_attacher;

        if(! t.TryGetComponent<ISingletonAttach>(out singleton_attacher)) return;

        singleton_attacher.Singleton_Attach();
    }

    void TryBroComponentAttach(Transform t){
        IBroComponent_Attach bro;

        if(! t.TryGetComponent<IBroComponent_Attach>(out bro)) return;

        bro.Brother_Attach();
    }
}
