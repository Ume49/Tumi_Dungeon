using UnityEngine;

public class R_FrontChange : IReverseAction
{
    public Direction has_chage_front_direction;
    [SerializeField] Front front;


    public override bool _update()
    {
        front.Change_Direction(has_chage_front_direction);
        return true;
    }
}