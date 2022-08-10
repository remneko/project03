using UnityEngine;
using System.Collections;

namespace Mui

{
    public class Skill1 : MonoBehaviour
    {
        [SerializeField] public float MinDamage, MaxDamage;                      //(�̤p�ˮ`,�̤j�ˮ`)
        static public float Damageplus = 0f;                                            //�����[��
        static public float DamageMultiplier = 1f;                                      //�������v
        static public float critProbabilityplus = 0.1f;                                 //�z���[��
        static public float critProbabilityMultiplier = 1f;                             //�z�����v
        private float DamageAttack;                                              //�����ˮ`
        [SerializeField] private float Repel;
        public GameObject TMPCanvas;
        private float critProbability;                                           //�z���v
        public bool critBool;
        SpriteRenderer m_SpriteRenderer;
        BoxCollider2D BoxCollider2D;
        Animator Animator;
        public bool startBool;
        private float mpatk;
        public float mpflt;//�ӷl�]�O��




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
            {//�ˮ`�ʵe//�z���P�w
                critProbability = Random.Range(0f, 1f);

                if (critProbability <= critProbabilityplus)
                {
                    damage(((Random.Range(MinDamage, MaxDamage) + Damageplus) * DamageMultiplier) * critProbabilityMultiplier); //�z�������ˮ`�d���H��
                    critBool = true;
                }
                else
                {
                    damage((Random.Range(MinDamage, MaxDamage) + Damageplus) * DamageMultiplier);//�����ˮ`�d���H��
                    critBool = false;
                }

                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (!enemy.isAttacked)
                {

                    //�ͦ��e���b�C�ӳQ���쪺�ĤH���W�W����ܶˮ`�Ʀr(�ͦ���,�ĤH��e��m,�L������(�|����))
                    //��ܶˮ`(�y���ˮ`�ƭ�)
                    //Mathf�T�O�����
                    //DamageNum damage =  Instantiate(damageCanvas,other.transform.position,Quaternion.identity).GetComponent<DamageNum>();
                    DamageNum damage = Instantiate(TMPCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>();

                    damage.ShowUIDamage(Mathf.RoundToInt(DamageAttack));
                    enemy.TakenDamage(Mathf.RoundToInt(DamageAttack));
                    //Ĳ�o�z���ʵe
                    if (critBool == true)
                    {
                        damage.ani.SetBool("�z�����v", true);
                    }
                    else
                    {
                        damage.ani.SetBool("�z�����v", false);
                    }

                    //���h�ĪG (���Ϥ�V����) �q���⤤���I��m �V�ĤH��m��V (�ؼ��I)����
                    Vector2 difference = other.transform.position - transform.position;
                    difference.Normalize();//�O�ҦV�q����V�A�V�q�ƫ�V�q���j�p��1
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


