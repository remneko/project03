using System.Collections;                                   //��{��� �ت��n�B�z�h�q�ˮ`���D
using UnityEngine;
using TMPro;

namespace Mui
{
    public class Enemy : MonoBehaviour , ITakenDamage
    {
        [SerializeField] private float MoveSpeed;
        public Transform Target;
        [SerializeField] private float MaxHp;
        public float Hp;
        [Header("Hurt")] private SpriteRenderer sp;
        public float hurtLength;                            //�ĪG����h�[
        private float hurtCounter;                          //�p�ƾ�
        [HideInInspector]
        public bool isAttacked;
        public int damage00; //�y�����ˮ`�ƭ�
        static public int damage; //(��~)�y�����ˮ`�ƭ�
        public GameObject die1Effect;
        public GameObject die2Effect;
        public GameObject deathfall;  //���`�������~
        public GameObject deathfall2;
        public GameObject deathfall31;
        public GameObject deathfall32;
        public GameObject deathfall33;
        private int fallchange;  //�����ƶq
        private int fallchg;  //�������v
        private Vector3 falln01;     //�����Z��
        public int sc;
        public bool TFBoss;
        static public TextMeshProUGUI TMP1;

        public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

        private void Start()
        {
            Hp = MaxHp;
            damage = damage00;
            Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            TMP1 = GameObject.Find("BOSS������").GetComponent<TextMeshProUGUI>();
            sp = GetComponent<SpriteRenderer>();
            
        }

        private void Update()
        {
            FollowPlayer();
            hurtCounter -= Time.deltaTime;

            if (hurtCounter <= 0)
            {
                sp.material.SetFloat("_FlashAmount", 0);
            }
            
        }

        private void FollowPlayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
        }

        public void TakenDamage(float _amount)
        {
            isAttack = true;
            StartCoroutine(isAttackCo());
            Hp -= _amount;

            HurtShader();
            if (Hp <= 0)
            {
                Instantiate(die1Effect, transform.position, Quaternion.identity);
                Instantiate(die2Effect, transform.position, Quaternion.identity);
                fallchange = Random.Range(1,3);
                for (int i = 0; i < fallchange; i++)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y,falln01.z) , Quaternion.identity);
                }
                fallchg = Random.Range(0, 20);
                if (fallchg > 5)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall2, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y, falln01.z), Quaternion.identity);
                }
                if (fallchg == 0)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall31, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y, falln01.z), Quaternion.identity);
                }
                if (fallchg == 1)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall32, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y, falln01.z), Quaternion.identity);
                }
                if (fallchg == 2)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall33, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y, falln01.z), Quaternion.identity);
                }
                monstersgenerate.killquantity += 1;
                PlayerHealth.scoreint += sc;
                if (TFBoss == true)
                {
                    monstersgenerate.killBossquantity += 1;
                    TMP1.text = monstersgenerate.killBossquantity.ToString();
                }
                Destroy(gameObject,0.2f);
            }

        }

        private void HurtShader()
        {
            sp.material.SetFloat("_FlashAmount", 1);
            hurtCounter = hurtLength;
        }

        IEnumerator isAttackCo()
        {
            yield return new WaitForSeconds(0.4f);
            isAttacked = false;
        }
    }
}
