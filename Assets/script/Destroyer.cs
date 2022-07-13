using UnityEngine;

namespace Mui
{ 
    public class Destroyer : MonoBehaviour
    {
        
        [SerializeField] private float lifeTimer;

        private void Start()
        {   /// <summary>
            /// 經過幾秒後，刪除該物件
            /// </summary>
            Destroy(gameObject, lifeTimer);
        }
    }
}


