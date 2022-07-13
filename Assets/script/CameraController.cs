using System.Collections;
using UnityEngine;

namespace Mui
{ 
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        [SerializeField, Header("�첾�t��")] private float speed =1.9f;
        [SerializeField, Header("����d��")] private float minX, minY, maxX, maxY;

        [Header("Camera Shake")]//���Y�̰�
        private Vector3 shakeActive;//���Y��m
        private float shakeAmplify; 

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            if (shakeAmplify > 0)
            {
                shakeActive = new Vector3(Random.Range(-shakeAmplify, shakeAmplify), Random.Range(-shakeAmplify, shakeAmplify), 0f);//�̰�
                shakeAmplify -= Time.deltaTime;     //�̰ʳv�����
            }
            else
            {
                shakeActive = Vector3.zero;
            }
            transform.position += shakeActive;      //�^�Ǧ�m�����Y��m
        }

        public void CameraShake(float _amount)
        {
            shakeAmplify = _amount;
        }

        public IEnumerator CameraShake(float _maxTime,float _amount)
        {
            Vector3 originalPos = transform.localPosition;
            float Shaketime = 0.0f;

            while (Shaketime < _maxTime)
            {
                float x = Random.Range(-1f, 1f) * _amount;
                float y = Random.Range(-1f, 1f) * _amount;

                transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y,originalPos.z);
                Shaketime += Time.deltaTime;

                yield return new WaitForSeconds(0f);             
            }
        }
        

        private void Follow()
        {
            transform.position =new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);

        }

        private void LateUpdate()
        {
            Vector3 posA = transform.position;
            Vector3 posB = target.position;

            posB.z = -10;

            posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);

            transform.position = posA;
            Follow();
        }


    }

}

