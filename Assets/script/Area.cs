using UnityEngine;

namespace Mui
{
    public class Area : MonoBehaviour
    {
        public GameObject bulletEffect;
        private int da;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")  && !other.gameObject.GetComponent<ITakenDamage>().isAttack)
            {
                Instantiate(bulletEffect, transform.position, Quaternion.identity);
                FindObjectOfType<CameraController>().CameraShake(0.2f);
                da = Random.Range(8, 12);
                FindObjectOfType<PlayerHealth>().TakenDamage(da);
                PlayerHp.SetHealthBarValue(PlayerHp.GetHealthBarValue() - da / 100);

            }
        }
        
    }
}
