using Mui;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, ITakenDamage
{
    [SerializeField] private float maxHP = 100;
    public float HP;
    [SerializeField] private float maxSP = 1f;
    public float SP;
    [SerializeField] private float maxEXP = 1f;
    public float EXP;
    public bool isAttacked;
    public GameObject fail;
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

    private void Start()
    {
        HP = maxHP;
        SP = maxSP;
        
        PlayerHp.SetHealthBarValue(1f);
        PlayerSP.SetSPBarValue(1f);
        PlayerEXP.SetEXPBarValue(0f);
    }

    public void TakenDamage(float _amount)
    {
        if (HP >= 0)
        {
            if (!isAttack)
            {
                HP -= _amount;
                StartCoroutine(InvincibleCo());
                Debug.Log("player hurt");

                PlayerHp.SetHealthBarValue(HP / maxHP);
            }
        }
        else
        { 
                fail.SetActive(true);
        }
        
        
    }

    public void DamageAttack(float _ATK)
    {
        if (!isAttack)
        {
            SP -= _ATK;
            StartCoroutine(InvincibleCo());
            Debug.Log("player atk");

            PlayerSP.SetSPBarValue(SP);
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Fallicon")
        {
            EXP += Random.Range(1f, 5f);
            PlayerEXP.SetEXPBarValue(EXP/maxEXP);
        }
    }


    IEnumerator InvincibleCo()
    {
        isAttack = true;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }

}
