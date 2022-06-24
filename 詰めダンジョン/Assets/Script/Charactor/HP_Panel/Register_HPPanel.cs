using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register_HPPanel : MonoBehaviour , ISingletonAttach
{
    [SerializeField] GameObject hppanel_prefab;
    [SerializeField] Camera main_camera;
    [SerializeField] Charactor_Paramater charactor_paramater;

    private void Awake() {
        // HPを表示するパネルを生成
        var instance = Instantiate(hppanel_prefab, transform);

        // 設定項目を取得
        var desc = instance.GetComponent<HPpanel_Desc>();

        // カメラを設定
        desc.canvas.worldCamera = main_camera;

        // HPパネルと実際のHPとの関連付け
        desc.hp_displayer.param = charactor_paramater;
    }

    private void Start() {
        // 生成時点で用済みなので削除
        Destroy(this);
    }

    private void Reset() {
        // HPの情報を格納してあるインスタンスを取得
        charactor_paramater = GetComponent<Charactor_Paramater>();
    }

    public void Singleton_Attach(){
        // 適当にメインカメラを設定 *気に食わない場合は手動でよろ
        main_camera = Resources.FindObjectsOfTypeAll<Camera>()[0];
    }
}
