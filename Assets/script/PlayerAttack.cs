using System.Threading.Tasks;
using UnityEngine;

namespace Mui 
{
    public class PlayerAttack : MonoBehaviour
    {
        private float ca;
        private float aa = 0.2f;
        private float ma;
        [SerializeField,Header("�]�O1��O")] private float SMP01;
        public GameObject skill01;
        static public bool skill01open;
        [SerializeField, Header("�]�O2��O")] private float SMP02;
        public GameObject skill02;
        static public bool skill02open;
        [SerializeField, Header("�]�O3��O")] private float SMP03;
        public GameObject skill03;
        static public bool skill03open;
        private AudioSource AudioSource;
        [SerializeField, Header("���𭵮�")]
        public AudioClip audiooclip;
        [SerializeField, Header("�ޯ୵��")]
        public AudioClip audiooclipskill1;
        public AudioClip audiooclipskill2;
        public AudioClip audiooclipskill3;

        private void Start()
        {
            skill01 = GameObject.Find("skill1");
            ma = PlayerMP.GetMPBarValue();
            AudioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ca = PlayerSP.GetSPBarValue() - aa;
                
                if (ca >= aa)
                {
                    AudioSource.volume = 1;
                    AudioSource.PlayOneShot(audiooclip, 0.2f);
                    FindObjectOfType<PlayerHealth>().DamageAttack(aa);
                    PlayerSP.SetSPBarValue(ca);
                    Attack();
                    StartCoroutine(FindObjectOfType<CameraController>().CameraShake(0.2f,0.2f));
                }
            }
            PlayerSP.SetSPBarValue(PlayerSP.GetSPBarValue() + 0.002f);

            ma = PlayerMP.GetMPBarValue();

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (ma >= SMP01)
                {
                    ma = PlayerMP.GetMPBarValue() - SMP01;
                    skill01open = true;
                    FindObjectOfType<PlayerHealth>().DamageMagicAttack(SMP01);
                    PlayerMP.SetMPBarValue(ma);
                    Attack1();
                    StartCoroutine(FindObjectOfType<CameraController>().CameraShake(0.2f, 0.2f));
                }
                else if (ma < SMP01)
                {
                    skill01open = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (ma >= SMP02)
                {
                    ma = PlayerMP.GetMPBarValue() - SMP02;
                    skill02open = true;
                    AudioSource.volume = 0.4f;
                    AudioSource.PlayOneShot(audiooclipskill2, 1.5f);
                    FindObjectOfType<PlayerHealth>().DamageMagicAttack(SMP02);
                    PlayerMP.SetMPBarValue(ma);
                    Attack1();
                    StartCoroutine(FindObjectOfType<CameraController>().CameraShake(0.2f, 0.2f));
                    Debug.Log("�ޯ�2�I��");
                }
                else if (ma < SMP02)
                {
                    skill02open = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (ma >= SMP03)
                {
                    ma = PlayerMP.GetMPBarValue() - SMP03;
                    skill03open = true;
                    FindObjectOfType<PlayerHealth>().DamageMagicAttack(SMP03);
                    PlayerMP.SetMPBarValue(ma);
                    Attack1();
                    StartCoroutine(FindObjectOfType<CameraController>().CameraShake(0.2f, 0.2f));
                }
                else if (ma < SMP03)
                {
                    skill03open = false;
                }
            }
        }

        private void Attack()
        {
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;       //�ƹ���m(�ؼ��I��m) - ��e��m(�H����m)
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;       //�Q��Mathf.Rad2Deg���ഫ �N���׳����ܨ��׳��
            transform.rotation = Quaternion.Euler(0, 0, rotz); //�N�����ĪG�ܬ��i�HZ�b(�ƹ�)����
            transform.GetChild(0).gameObject.SetActive(true);
        }
        private void Attack1()
        {
            Vector2 difference = Input.mousePosition;
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;       //�Q��Mathf.Rad2Deg���ഫ �N���׳����ܨ��׳��
            transform.rotation = Quaternion.Euler(0, 0,rotz); //�N�����ĪG�ܬ��i�HZ�b(�ƹ�)����
        }

    }
}

