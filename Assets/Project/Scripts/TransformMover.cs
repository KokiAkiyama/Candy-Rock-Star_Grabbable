using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Transfom�̍��W�𒼐ڑ��삵�Ĉړ�����N���X
/// </summary>
public class TransformMover : MonoBehaviour
{
    //VR��Ŗڂ̒��S(���Ă������)���m�F����p�̃A���J�[
    [SerializeField]
    private Transform _centerEyeAnchor = null;

    //�ړ����x�̌W��
    [SerializeField]
    private float _moveSpeed = 2;
    [SerializeField]
    private float _rotSpeed = 30;
    //=================================================================================
    //������
    //=================================================================================

    //�R���|�[�l���g��Add���ꂽ���Ɏ��s�����
    private void Reset()
    {
        //���S�̃A���J�[�擾
        _centerEyeAnchor = transform.Find("TrackingSpace/CenterEyeAnchor");
    }

    //=================================================================================
    //�X�V
    //=================================================================================

    private void Update()
    {
        //�X�e�B�b�N��|���Ă�������擾
        Vector2 stickDirection = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        //�����Ă�����A�X�e�B�b�N��|���Ă��������ړ������v�Z
        Vector3 moveDirection = _centerEyeAnchor.rotation * new Vector3(stickDirection.x, 0, stickDirection.y);

        //���W�𒼐ڑ��삵�Ĉړ�
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;


        // 2022.11.25: �E�X�e�B�b�N�Ŏ��������ɉ�]�ړ���^����B
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
        {
            // ����]
            transform.Rotate(0.0f, -_rotSpeed, 0.0f);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
        {
            // �E��]
            transform.Rotate(0.0f, _rotSpeed, 0.0f);
        }
    }
}
