using Mui;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, ITakenDamage
{
    static public float maxHP = 100;
    static public float HP;
    static public float maxSP = 1f;
    static public float SP;
    static public float maxEXP = 1f;
    static public float EXP;
    static public float maxMP = 1f;
    static public float MP;
    static public float DEF;//防禦力
    public TextMeshProUGUI score;
    public TextMeshProUGUI score1;
    static public int scoreint = 0;
    public GameObject HPBAR;
    public bool isAttacked;
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }
    public AudioClip hurtsaud;
    private AudioSource AudioSource;

    private void Start()
    {
        HP = maxHP;
        SP = maxSP;
        MP = maxMP;
        PlayerHp.SetHealthBarValue(1f);
        PlayerSP.SetSPBarValue(1f);
        PlayerEXP.SetEXPBarValue(0f);
        PlayerMP.SetMPBarValue(1f);
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        score.text = "score:" + scoreint.ToString();
        score1.text = "score:" + scoreint.ToString();
        MP = PlayerMP.GetMPBarValue();
    }

    public void TakenDamage(float _amount)
    {
        if (HP >= 0)
        {
            if (!isAttack)
            {
                HP -= Enemy.damage - DEF;
                StartCoroutine(InvincibleCo());
                PlayerHp.SetHealthBarValue(HP / maxHP);
            }
        }
        else
        {
            Dead();
        }
        
        
    }

    private void Dead()
    {
        
        HPBAR.SetActive(false);
        gameObject.SetActive(false);
    }

    public void DamageAttack(float _ATK)
    {
        if (!isAttack)
        {
            SP -= _ATK;
            StartCoroutine(InvincibleCo());
            PlayerSP.SetSPBarValue(SP);
        }
    }
    public void DamageMagicAttack(float _MATK)
    {
        if (!isAttack)
        {
            MP -= _MATK;
            StartCoroutine(InvincibleCo());
            PlayerMP.SetMPBarValue(MP);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Fallicon")
        {           
                EXP += Random.Range(0.01f, 0.2f);
                PlayerEXP.SetEXPBarValue(EXP/maxEXP);          
        }
        else if(target.gameObject.tag == "Fallicon2")
        {
                MP += 0.05f;
                PlayerMP.SetMPBarValue(MP);
        }
        else if (target.gameObject.tag == "Fallicon3")
        {
            if (target.gameObject.name.Contains("技能1升級道具")) //contains包含
            {
                falliconfollow.TMP1LV += 1;
            }
            if (target.gameObject.name.Contains("技能2升級道具"))
            {
                falliconfollow.TMP2LV += 1;
            }
            if (target.gameObject.name.Contains("技能3升級道具"))
            {
                falliconfollow.TMP3LV += 1;
            }
        }
        if (target.gameObject.tag == "Enemy")
        {

        }
    }

    IEnumerator InvincibleCo()
    {
        isAttack = true;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }

}
