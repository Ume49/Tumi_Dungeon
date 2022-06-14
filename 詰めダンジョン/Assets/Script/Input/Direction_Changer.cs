using UnityEngine;

public class Direction_Changer : MonoBehaviour {
    [SerializeField] private Front player_front;

    private void Update() {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Debug.Log(input.x.ToString() + ", " + input.y.ToString());

        if (input.x > 0.0f) {
            player_front.Change_Direction(Direction.RIGHT);
        }
        else
        if (input.x < 0.0f) {
            player_front.Change_Direction(Direction.LEFT);
        }
        else
        if (input.y > 0.0f) {
            player_front.Change_Direction(Direction.UP);
        }
        else
        if (input.y < 0.0f) {
            player_front.Change_Direction(Direction.DOWN);
        }
    }
}