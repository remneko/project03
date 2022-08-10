using UnityEngine;
using TMPro;

namespace Mui
{
    public class monstersgenerateD : MonoBehaviour
    {
        private Vector3 MTgenerate;
        static public int killquantity = 0;
        public int Maxkillquantity;
        public int Maxgroundquantity = 30;
        public TextMeshProUGUI killquantitytext;
        public GameObject canvas;
        public GameObject MT1;
        public GameObject MT2;
        public GameObject MT3;
        public GameObject MT4;
        public GameObject MT5;
        private int a = 1;

        private void Start()
        {
            canvas.SetActive(false);
            killquantity = 0;
            Time.timeScale = 1;
            if (killquantity != Maxgroundquantity)
             {
                if (killquantity != Maxkillquantity)
                {
                    InvokeRepeating("Monstersgenerate", 0f, 2f);
                }                   
             }
        }

        private void Update()
        {         
            MTgenerate.x = Random.Range(-15f, 15f);
            MTgenerate.y = Random.Range(-10f, 10f);
            killquantitytext.text = killquantity.ToString();
            if (a == 1)
            {
                if (killquantity >= Maxkillquantity || PlayerHealth.HP <= 0)
                {
                    Time.timeScale = 0;
                    canvas.SetActive(true);
                    a = 0;
                }
            }
            
            
        }

        private void Monstersgenerate()
        {
            if (killquantity <= Maxkillquantity)
            {
                Instantiate(MT1, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 20 && killquantity < 40)
            {
                Instantiate(MT2, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 30 && killquantity < 60)
            {
                Instantiate(MT4, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 40 && killquantity < 80)
            {
                Instantiate(MT5, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 50 && killquantity < 100)
            {
                Instantiate(MT3, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
        }
    }
}
