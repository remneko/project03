using System.Threading.Tasks;
using UnityEngine;

namespace Mui 
{
    public class PlayerAttack : MonoBehaviour
    {
        private float sa = 0.2f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                float ca = PlayerSP.GetSPBarValue() - sa;
                
                if (ca >= 0.2f)
                {
                FindObjectOfType<PlayerHealth>().DamageAttack(sa);
                PlayerSP.SetSPBarValue(ca);
                Attack();
                StartCoroutine(FindObjectOfType<CameraController>().CameraShake(0.2f,0.2f));
                }
            }
            PlayerSP.SetSPBarValue(PlayerSP.GetSPBarValue() + 0.002f);
        }

        private void Attack()
        {
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;       //滑鼠位置(目標點位置) - 當前位置(人物位置)
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;       //利用Mathf.Rad2Deg來轉換 將弧度單位轉至角度單位
            transform.rotation = Quaternion.Euler(0, 0, rotz); //將攻擊效果變為可隨Z軸(滑鼠)移動
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}

