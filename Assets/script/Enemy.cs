using System.Collections;                                   //協程函數 目的要處理多段傷害問題
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
        public float hurtLength;                            //效果持續多久
        private float hurtCounter;                          //計數器
        [HideInInspector]
        public bool isAttacked;
        public int damage00; //造成的傷害數值
        static public int damage; //(對外)造成的傷害數值
        public GameObject die1Effect;
        public GameObject die2Effect;
        public GameObject deathfall;  //死亡掉落物品
        public GameObject deathfall2;
        public GameObject deathfall31;
        public GameObject deathfall32;
        public GameObject deathfall33;
        private int fallchange;  //掉落數量
        private int fallchg;  //掉落機率
        private Vector3 falln01;     //掉落距離
        public int sc;
        public bool TFBoss;
        static public TextMeshProUGUI TMP1;

        public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

        private void Start()
        {
            Hp = MaxHp;
            damage = damage00;
            Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            TMP1 = GameObject.Find("BOSS擊殺數").GetComponent<TextMeshProUGUI>();
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
