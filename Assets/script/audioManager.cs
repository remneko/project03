using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mui
{
    public class audioManager : MonoBehaviour
    {
        private AudioSource AudioSource;
        [SerializeField, Header("���𭵮�")]
        public AudioClip audiooclip;
        [SerializeField, Header("�ޯ୵��")]
        public AudioClip audiooclipskill1;
        public AudioClip audiooclipskill2;
        public AudioClip audiooclipskill3;


        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioSource.volume = 1;
                AudioSource.PlayOneShot(audiooclip, 0.2f);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {         
                //AudioSource.PlayOneShot(audiooclipskill1, 1.2f);
                
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                AudioSource.volume = 0.4f;
                AudioSource.PlayOneShot(audiooclipskill2, 1.5f);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                //AudioSource.PlayOneShot(audiooclipskill3, 1.2f);
            }
        }

    }

}
