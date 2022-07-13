using TMPro;
using UnityEngine;

namespace Mui

{ 
    public class Slash : MonoBehaviour
    {
        [SerializeField] private float MinDamage, MaxDamage;                //(�̤p�ˮ`,�̤j�ˮ`)
        private float DamageAttack;                                         //�����ˮ`
        [SerializeField] private float Repel;
        public GameObject TMPCanvas;
        private float critProbability;                                      //�z���v
        public bool critBool;
                                                                            

        public void EndAttack()
        {
            gameObject.SetActive(false);

        }

        public void OnTriggerEnter2D(Collider2D other)
        {          

                if (other.CompareTag("Enemy"))
                {//�ˮ`�ʵe//�z���P�w
                    critProbability = Random.Range(0f, 1f);

                    if (critProbability <= 0.5f)
                    {
                        DamageAttack = Random.Range(MinDamage, MaxDamage) * 1.5f;       //�z�������ˮ`�d���H��
                        critBool = true;
                    }
                    else
                    {
                        DamageAttack = Random.Range(MinDamage, MaxDamage);       //�����ˮ`�d���H��
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
    }
}

