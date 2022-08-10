using UnityEngine;
using TMPro;

namespace Mui
{
    public class falliconfollow : MonoBehaviour
    {
        public Transform target;
        public int MoveSpeed;
        public int falliconchg; //辨別掉落物為何類物品
        private TextMeshProUGUI TMP1;
        private TextMeshProUGUI TMP2;
        private TextMeshProUGUI TMP3;
        private TextMeshProUGUI TMP4;
        static public int TMP1LV = 1;
        static public int TMP2LV = 1;
        static public int TMP3LV = 1;
        static public int TMP4LV = 1;

        private void Awake()
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
            TMP1 = GameObject.Find("技能1等級").GetComponent<TextMeshProUGUI>();
            TMP2 = GameObject.Find("技能2等級").GetComponent<TextMeshProUGUI>();
            TMP3 = GameObject.Find("技能3等級").GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            InvokeRepeating("Follow",2f,0.01f);
        }
        private void Follow()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }       
        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.gameObject.tag == "Player")
            {
                if (falliconchg == 0) Destroy(gameObject, 0f);
                else if (falliconchg == 1)
                {
                    TMP1.text = TMP1LV.ToString();
                    Skill1.Damageplus += 25;
                    Destroy(gameObject, 0f);
                }
                else if (falliconchg == 2)
                {
                    TMP2.text = TMP2LV.ToString();
                    Skill2.Damageplus += 25;
                    Destroy(gameObject, 0f);
                }
                else if (falliconchg == 3)
                {
                    TMP3.text = TMP3LV.ToString();
                    Skill3.Damageplus += 25;
                    Destroy(gameObject, 0f);
                }
                
            }
        }
    }
}

