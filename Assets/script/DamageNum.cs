using TMPro;
using UnityEngine;

namespace Mui
{
    public class DamageNum : MonoBehaviour
    {
         
        public float lifeTimer;                //��ܬ��
        public float upSpeed;                  //��r�W�ɳt��
        public GameObject go;
        public GameObject TMPCanvas;
        public TextMeshProUGUI tm;              //�ˮ`��r
        public Animator ani;

        private void Start()
        {
            
            tm = TMPCanvas.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            //�blifeTimer���P������
            Destroy(gameObject, lifeTimer);
        }

        private void FixedUpdate()
        {
            transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0); //��r�w�C�W��   
        }

        public void ShowUIDamage(float apk)
        {        
            tm.text = apk.ToString();           //�ˮ`��r���
            ani = GetComponent<Animator>();
        }   
    }
}

