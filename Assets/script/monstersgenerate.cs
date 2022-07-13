using UnityEngine;

namespace Mui
{
    public class monstersgenerate : MonoBehaviour
    {
        private Vector3 MTgenerate;
        static public int killquantity;
        public int Maxkillquantity;
        public GameObject MT;

        private void Start()
        {
            if (killquantity != Maxkillquantity)
            {
                
                InvokeRepeating("Monstersgenerate", 0f, 2f);
            }
        }

        private void Update()
        {         
            MTgenerate.x = Random.Range(-15f, 15f);
            MTgenerate.y = Random.Range(-10f, 10f);
        }

        private void Monstersgenerate()
        {
            Instantiate(MT, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
        }
    }
}
