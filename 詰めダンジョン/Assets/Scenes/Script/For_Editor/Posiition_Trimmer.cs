using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// �����̂Ƀo�����Ă�����W��Reset�Ő��`����
public class Posiition_Trimmer : MonoBehaviour
{
    private void Reset()
    {
        Trim();
    }

    public void Trim()
    {
        // �A�^�b�`����Ă���I�u�W�F�N�g�̍��W�𐮐��ɂ���
        Vector3 pos = gameObject.transform.position;

        // ���`����
        Func<float, float> seikei = x => (float)Math.Round(x);

        gameObject.transform.position = new Vector3(seikei(pos.x), seikei(pos.y), seikei(pos.z));
    }
}
