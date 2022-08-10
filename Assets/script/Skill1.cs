using UnityEngine;
using System.Collections;

namespace Mui

{
    public class Skill1 : MonoBehaviour
    {
        [SerializeField] public float MinDamage, MaxDamage;                      //(最小傷害,最大傷害)
        static public float Damageplus = 0f;                                            //攻擊加成
        static public float DamageMultiplier = 1f;                                      //攻擊倍率
        static public float critProbabilityplus = 0.1f;                                 //爆擊加成
        static public float critProbabilityMultiplier = 1f;                             //爆擊倍率
        private float DamageAttack;                                              //攻擊傷害
        [SerializeField] private float Repel;
        public GameObject TMPCanvas;
        private float critProbability;                                           //爆擊率
        public bool critBool;
        SpriteRenderer m_SpriteRenderer;
        BoxCollider2D BoxCollider2D;
        Animator Animator;
        public bool startBool;
        private float mpatk;
        public float mpflt;//耗損魔力值




        private void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            BoxCollider2D = GetComponent<BoxCollider2D>();
            Animator = GetComponent<Animator>();
        }

        public void EndAttack()
        {
            gameObject.SetActive(false);

        }

        public void damage(float damage)
        {
            DamageAttack = damage;

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {//傷害動畫//爆擊判定
                critProbability = Random.Range(0f, 1f);

                if (critProbability <= critProbabilityplus)
                {
                    damage(((Random.Range(MinDamage, MaxDamage) + Damageplus) * DamageMultiplier) * critProbabilityMultiplier); //爆擊攻擊傷害範圍隨機
                    critBool = true;
                }
                else
                {
                    damage((Random.Range(MinDamage, MaxDamage) + Damageplus) * DamageMultiplier);//攻擊傷害範圍隨機
                    critBool = false;
                }

                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (!enemy.isAttacked)
                {

                    //生成畫布在每個被打到的敵人身上上面顯示傷害數字(生成物,敵人當前位置,無須旋轉(四元數))
                    //顯示傷害(造成傷害數值)
                    //Mathf確保為整數
                    //DamageNum damage =  Instantiate(damageCanvas,other.transform.position,Quaternion.identity).GetComponent<DamageNum>();
                    DamageNum damage = Instantiate(TMPCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>();

                    damage.ShowUIDamage(Mathf.RoundToInt(DamageAttack));
                    enemy.TakenDamage(Mathf.RoundToInt(DamageAttack));
                    //觸發爆擊動畫
                    if (critBool == true)
                    {
                        damage.ani.SetBool("爆擊機率", true);
                    }
                    else
                    {
                        damage.ani.SetBool("爆擊機率", false);
                    }

                    //擊退效果 (往反方向移動) 從角色中心點位置 向敵人位置方向 (目標點)移動
                    Vector2 difference = other.transform.position - transform.position;
                    difference.Normalize();//保證向量的方向，向量化後向量的大小為1
                    other.transform.position = new Vector2(other.transform.position.x + difference.x * Repel, other.transform.position.y + difference.y * Repel);

                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (startBool == false)
                {
                    if (PlayerAttack.skill01open == true)
                    {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;
                    transform.position = mousePos;
                    m_SpriteRenderer.enabled = true;
                    BoxCollider2D.enabled = true;
                    Animator.SetTrigger("www");
                    startBool = true;
                    }
                    
                }
                
            }
            if (startBool == true)
            {
                StartCoroutine(startani());
            }
        }
        
        IEnumerator startani()
        {
            startBool = false;
            yield return new WaitForSeconds(0.8f);
            m_SpriteRenderer.enabled = false;
            BoxCollider2D.enabled = false;
        }


    }
}


