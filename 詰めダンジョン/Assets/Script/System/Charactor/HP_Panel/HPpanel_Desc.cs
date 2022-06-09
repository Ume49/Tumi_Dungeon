using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resiter_HPPanelクラスが簡単に変数を参照するための中間クラス
public class HPpanel_Desc : MonoBehaviour
{
    public Canvas canvas;
    public HP_Disp hp_displayer;

    private void Start() {
        // Register_HPPannelが生成された時点でこいつはメモリの無駄なのでさっさと削除
        Destroy(this);
    }
}
