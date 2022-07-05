using UnityEngine;

public class Call_DirectionChange : MonoBehaviour {
    [SerializeField] Front player_front;

    public void Call(Direction input_direction) {
        player_front.Change_Direction(input_direction);
    }
}