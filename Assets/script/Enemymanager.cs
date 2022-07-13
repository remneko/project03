using UnityEngine;

namespace Mui
{ 
    public class Enemymanager : MonoBehaviour
    {
        private GameObject Target;

        private void Start()
        {
            Target = GameObject.FindWithTag("Enemy");
        }
        private void Update()
        {
            if (Target)
            {

            }
        }
    }
}

