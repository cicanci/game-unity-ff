using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinalFrontier.Game.Camera
{
    public class CameraFollow : MonoBehaviour 
    {
        [Tooltip("If the target is not set, the script will look for an object with Player tag")]
        public Transform TargetToFollow;
        [Range(0, 1)]
        public float SmoothTime;

        public float TargetDistance;

        //public Vector3 Offset;

        private void Start()
        {
            if (TargetToFollow == null) 
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player == null)
                {
                    Debug.LogError("No target object set or player tag found to follow");
                }
                else
                {
                    TargetToFollow = player.transform;
                }
            }
        }

        private void Update() 
        {
            if (TargetToFollow != null)
            {
                Vector3 velocity = Vector3.zero;
                Vector3 forward = TargetToFollow.forward * TargetDistance;

                // Offset is not working properly, I'll check that later
                //Vector3 targetPosition = TargetToFollow.position - forward * Offset.z + Vector3.up * Offset.y;
                Vector3 targetPosition = TargetToFollow.position - forward;

                // Lerp seems to be smoother than the SmootDamp
                //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
                transform.position = Vector3.Lerp(transform.position, targetPosition, SmoothTime);
                transform.rotation = TargetToFollow.rotation;

                // LookAt is causing the camera to flip, I'll keep it commented here
                //transform.LookAt(TargetToFollow);
            }
        }
    }
}