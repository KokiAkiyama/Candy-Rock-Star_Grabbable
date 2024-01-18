using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Transfomの座標を直接操作して移動するクラス
/// </summary>
public class TransformMover : MonoBehaviour
{
    //VR上で目の中心(見ている方向)を確認する用のアンカー
    [SerializeField]
    private Transform _centerEyeAnchor = null;

    //移動速度の係数
    [SerializeField]
    private float _moveSpeed = 2;
    [SerializeField]
    private float _rotSpeed = 30;
    //=================================================================================
    //初期化
    //=================================================================================

    //コンポーネントがAddされた時に実行される
    private void Reset()
    {
        //中心のアンカー取得
        _centerEyeAnchor = transform.Find("TrackingSpace/CenterEyeAnchor");
    }

    //=================================================================================
    //更新
    //=================================================================================

    private void Update()
    {
        //スティックを倒してる方向を取得
        Vector2 stickDirection = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        //向いてる方向、スティックを倒してる方向から移動方向計算
        Vector3 moveDirection = _centerEyeAnchor.rotation * new Vector3(stickDirection.x, 0, stickDirection.y);

        //座標を直接操作して移動
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;


        // 2022.11.25: 右スティックで視線方向に回転移動を与える。
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
        {
            // 左回転
            transform.Rotate(0.0f, -_rotSpeed, 0.0f);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
        {
            // 右回転
            transform.Rotate(0.0f, _rotSpeed, 0.0f);
        }
    }
}
