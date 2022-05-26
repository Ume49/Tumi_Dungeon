using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate Transform Map_Func(int x, int y);

public class EnemyJudge_isAttack : IEnemyJudge
{
    [SerializeField] EnemyAction_Operator enemyaction_operator;
    [SerializeField] Attack attack_script;
    [SerializeField] string player_name;
    public override void Judge()
    {
        // �אڃI�u�W�F�N�g���擾���郊�X�g
        List<Transform> neighbor = new List<Transform>();

        // ���ΓI�Ȉʒu�̃}�b�v�����擾���郉���_��
        Map_Func obj = (delta_x, delta_y) => map.dynamic_object_map[index_position.index.x + delta_x, index_position.index.y + delta_y];

        // �S���̗אڂ����I�u�W�F�N�g���擾
        neighbor.Add(obj(-1, 0));
        neighbor.Add(obj(+1, 0));
        neighbor.Add(obj(0, -1));
        neighbor.Add(obj(0, +1));

        // �擾�����I�u�W�F�N�g����v���C���[��T��
        // �v���C���[�̔��ʕ��@��transform.name�̈�v
        foreach (var w in neighbor)
        {
            if (w.name == player_name)
            {
                // �v���C���[���������Ȃ�U���\��

                return;
            }
        }
    }
}

