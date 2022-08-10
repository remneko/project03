using UnityEngine;
using TMPro;

namespace Mui
{
    public class monstersgenerate : MonoBehaviour
    {
        private Vector3 MTgenerate;
        static public int killquantity = 0;
        static public int killBossquantity = 0;
        public int Maxkillquantity;
        public int MaxkillBossquantity;
        public int Maxgroundquantity = 30;
        public TextMeshProUGUI killquantitytext;
        public GameObject canvas1;
        public GameObject canvas2;
        public GameObject MT1;
        public GameObject MT2;
        public GameObject MT3;
        public GameObject MT4;
        public GameObject MT5;
        public GameObject MT6;
        private int a = 1;
        public AudioClip AudioClip;
        private AudioSource AudioSource;

        private void Start()
        {
            killBossquantity = 0;
            canvas1.SetActive(false);
            canvas2.SetActive(false);
            killquantity = 0;
            Time.timeScale = 1;
            AudioSource = GetComponent<AudioSource>();
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
                if (killquantity >= Maxkillquantity)
                {
                    Instantiate(MT6, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
                     a = 0;
                    AudioSource.clip = AudioClip;
                    AudioSource.Play();
                }
            }
            if (PlayerHealth.HP <= 0)
            {
                Time.timeScale = 0;
                canvas2.SetActive(true);
            }
            if (killBossquantity >= MaxkillBossquantity)
            {
                Time.timeScale = 0;
                canvas1.SetActive(true);
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
            if (killquantity >= 30 && killquantity < 70)
            {
                Instantiate(MT3, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 40 && killquantity < 80)
            {
                Instantiate(MT4, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
            if (killquantity >= 70 && killquantity < 100)
            {
                Instantiate(MT5, new Vector3(transform.position.x + MTgenerate.x, transform.position.y + MTgenerate.y, 0), Quaternion.identity);
            }
        }
    }
}
