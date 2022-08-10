using UnityEngine;

namespace Mui
{
    public class PlayerFollow : MonoBehaviour
    {
        public Transform Target;
        private void Start()
        {
            Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            InvokeRepeating("FollowPlayer", 0f ,0.001f);

        }

        private void FollowPlayer()
        {
            transform.position = new Vector3(Target.position.x - 0.5f, Target.position.y -1.3f, Target.position.z);
        }

        
    }
}