using UnityEngine;

namespace Mui
{ 
    public class Destroyer : MonoBehaviour
    {
        
        [SerializeField] private float lifeTimer;

        private void Start()
        {   /// <summary>
            /// �g�L�X���A�R���Ӫ���
            /// </summary>
            Destroy(gameObject, lifeTimer);
        }
    }
}


