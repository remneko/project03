using System.Collections;                                   //��{��� �ت��n�B�z�h�q�ˮ`���D
using UnityEngine;

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
        public GameObject explotionEffect;
        public GameObject deathfall;  //���`�������~
        private int fallchange;  //�������v
        private Vector3 falln01;     //�����Z��

        public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

        private void Start()
        {
            Hp = MaxHp;
            Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
                Instantiate(explotionEffect, transform.position, Quaternion.identity);
                fallchange = Random.Range(1,5);
                for (int i = 0; i < fallchange; i++)
                {
                    falln01.x = Random.Range(0f, 2f);
                    falln01.y = Random.Range(0f, 2f);
                    Instantiate(deathfall, new Vector3(transform.position.x + falln01.x, transform.position.y + falln01.y,falln01.z) , Quaternion.identity);
                }
                monstersgenerate.killquantity += 1;
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
