using UnityEngine;

namespace FinalFrontier.Game.Camera
{
    public class CameraFollow : MonoBehaviour 
    {
        [Tooltip("If the target is not set, the script will look for an object with Player tag")]
        public Transform TargetToFollow;
        [Range(0, 100)]
        public float SmoothTime;
        [Range(0, 100)]
        public float TargetDistance;

        private void Awake()
        {
            if (TargetToFollow != null)
            {
                return;
            }

            var player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogError("No target object set or player tag found to follow");
            }
            else
            {
                TargetToFollow = player.transform;
            }
        }

        private void Update() 
        {
            if (TargetToFollow == null)
            {
                return;
            }

            Vector3 targetPosition = TargetToFollow.position - (TargetToFollow.forward * TargetDistance);
            transform.position = Vector3.Lerp(transform.position, targetPosition, SmoothTime * Time.deltaTime);
            transform.rotation = TargetToFollow.rotation;
        }
    }
}