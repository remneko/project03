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
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;       //�ƹ���m(�ؼ��I��m) - ��e��m(�H����m)
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;       //�Q��Mathf.Rad2Deg���ഫ �N���׳����ܨ��׳��
            transform.rotation = Quaternion.Euler(0, 0, rotz); //�N�����ĪG�ܬ��i�HZ�b(�ƹ�)����
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}

