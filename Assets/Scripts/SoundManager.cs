using UnityEngine;

namespace Space
{
    [RequireComponent (typeof (AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        private AudioSource aud;

        [Header("音效")]
        public AudioClip soundEnemyHit;
        public AudioClip soundEnemyDead;
        public AudioClip soundPlayerHit;
        public AudioClip soundPlayerDead;
        public AudioClip soundWin;
        public AudioClip soundLose;
        public AudioClip soundCoin;
        public AudioClip soundFire;

        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="sound">要播放的音效</param>
        /// <param name="min">最小音量</param>
        /// <param name="max">最大音量</param>
        public void PlaySound(AudioClip sound , float min = 0.8f,float max = 1.2f)
        {
            float random = Random.Range(min, max);
            aud.PlayOneShot(sound , random);
        }
    }
}

