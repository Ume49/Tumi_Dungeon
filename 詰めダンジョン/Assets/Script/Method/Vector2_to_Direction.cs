using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2_to_Direction
{
    /// <summary>ベクトルを分解してx,y要素の正負からDirectionを作成、指定されたリストに追加する</summary>
    static public void Make_andAddtoList(Vector2 v, List<Direction> output_list){
        
        if(v.x > 0){
            output_list.Add(Direction.RIGHT);
        }else
        if(v.x < 0){
            output_list.Add(Direction.LEFT);
        }

        if(v.y > 0){
            output_list.Add(Direction.UP);
        }else
        if(v.y < 0){
            output_list.Add(Direction.DOWN);
        }
    }
}
