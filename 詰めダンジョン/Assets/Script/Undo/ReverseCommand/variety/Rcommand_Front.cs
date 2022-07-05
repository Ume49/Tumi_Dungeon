using UnityEngine;

public class Rcommand_Front : IReverseCommand
{
    public Direction has_front; // 戻すべき方向
    public Rcommand_Front(Transform chara, Direction front) : base(ID.Front, chara)
    {
        this.has_front = front;
    }
}