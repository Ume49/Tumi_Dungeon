using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Call_なんたらクラスのUpdateでの呼び出しを管理するクラス
// Call_PlayerMove.is_allow_moveへの書き込みも行う（極小なので）
public class Input_Controller : MonoBehaviour
{
    
    [SerializeField] UnityEvent attack_event;
    [SerializeField] UnityEvent<Direction> move_event;
    [SerializeField] UnityEvent<Direction> changeFront_event;
    
    // キー
    [SerializeField] KeyCode attack_key;
    [SerializeField] List<ArrowKey_to_Direction> move_key;  // ArrowKey_to_Directinoの詳細は最下部に記述
    [SerializeField] KeyCode dontMove_key;  // 押している間、移動を禁止するキー

    void Update()
    {
        // Warning 処理は一度に一回しか行わないので、ifの最後に必ずreturnを置く

        // 攻撃チェック
        if(Input.GetKeyDown(attack_key)){
            attack_event.Invoke();
            return;
        }
        
        // 移動チェック
        foreach(var elem in move_key){
            if(Input.GetKey(elem.check_key)){
                // 方向を変更
                changeFront_event.Invoke(elem.output_direction);

                // 移動禁止キーが押されてたら終わり
                if(Input.GetKey(dontMove_key)) return;

                // 移動
                move_event.Invoke(elem.output_direction);
            }
        }
    }

    // 十字ボタン用に、どこを押したらなんの方向を吐き出すか、ということを登録するための構造体
    [System.Serializable]
    public struct ArrowKey_to_Direction{
        public KeyCode   check_key;
        public Direction output_direction;
    }
}
