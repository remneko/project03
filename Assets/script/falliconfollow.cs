using Unity.VisualScripting;
using UnityEngine;

namespace Mui
{
    public class falliconfollow : MonoBehaviour
    {
        public Transform target;
        public int MoveSpeed;

        private void Awake()
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
        private void Start()
        {
            InvokeRepeating("Follow",2f,0.01f);
        }

        private void Update()
        {
            
        }

        private void Follow()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.gameObject.tag == "Player")
            {
                Destroy(gameObject, 0f);
            }
        }
    }
}

