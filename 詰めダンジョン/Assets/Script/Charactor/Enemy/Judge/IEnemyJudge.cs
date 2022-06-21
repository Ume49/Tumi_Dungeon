using UnityEngine;

public abstract class IEnemyJudge : MonoBehaviour {
    [SerializeField] protected MAP map;
    [SerializeField] protected CurrentPosition_OnMap index_position;

    public abstract void Judge();

    private void Reset() {
        index_position = GetComponent<CurrentPosition_OnMap>();

        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }
}