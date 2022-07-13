using TMPro;
using UnityEngine;

namespace Mui
{
    public class DamageNum : MonoBehaviour
    {
         
        public float lifeTimer;                //顯示秒數
        public float upSpeed;                  //文字上升速度
        public GameObject go;
        public GameObject TMPCanvas;
        public TextMeshProUGUI tm;              //傷害文字
        public Animator ani;

        private void Start()
        {
            
            tm = TMPCanvas.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            //在lifeTimer秒後銷毀物件
            Destroy(gameObject, lifeTimer);
        }

        private void FixedUpdate()
        {
            transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0); //文字緩慢上升   
        }

        public void ShowUIDamage(float apk)
        {        
            tm.text = apk.ToString();           //傷害文字顯示
            ani = GetComponent<Animator>();
        }   
    }
}

