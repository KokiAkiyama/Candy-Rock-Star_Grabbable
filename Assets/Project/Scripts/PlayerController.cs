using Oculus.Interaction;
using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] OVRSkeleton skeleton_L;
    [SerializeField] OVRSkeleton skeleton_R;
    void Start()
    {
        PoseProvider.Instance
            .Paper.Left.WhenSelected+=() =>
            {

                var thumbTip = skeleton_L.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform;
                RaycastHit hit;
                if(Physics.Raycast(thumbTip.position, thumbTip.up, out hit, 10f,LayerMask.GetMask("Zombie")))
                {
                    hit.rigidbody.GetComponent<ZombieController>()
                    .ChangeMat();
                }


            };
        PoseProvider.Instance
            .Paper.Right.WhenSelected+=() =>
            {

                var thumbTip = skeleton_R.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform;
                RaycastHit hit;
                if(Physics.Raycast(thumbTip.position, thumbTip.up, out hit, 10f,LayerMask.GetMask("Zombie")))
                {
                    hit.rigidbody.GetComponent<ZombieController>()
                    .ChangeMat();
                }


            };
    }

    void OnDrawGizmos()
    {
        var thumbTip = skeleton_L.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform;
        DebugGizmos.Color = Color.red;
        DebugGizmos.DrawLine(thumbTip.position, thumbTip.position + thumbTip.up * 10f);
    }

}
