using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class History_Viewer : MonoBehaviour
{
    [SerializeField] History_Stocker history;
    [SerializeField] Text textbox;

    void Reset() {
        history = Resources.FindObjectsOfTypeAll<History_Stocker>()[0];

        textbox = GetComponent<Text>();
    }

    // historyの中身を表示する
    void Update() {
        // とりあえず初期化
        textbox.text="";

        int turn_count=1;
        foreach (var turn in history.histroy_view){
            // 見出し
            textbox.text+="Turn: "+turn_count.ToString()+"\n";

            foreach (var ihistory in turn.oneturn_view){
                // とりあえずID表示
                textbox.text+="  "+ihistory.id.ToString()+"\n";
            }

            turn_count++;
        }
    }
}
