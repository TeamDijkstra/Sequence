using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        public AudioSource SFXPlayer; // ȿ���� ����ϱ� ���� �÷��̾�
        public AudioSource BGMPlayer; // ����� ����ϱ� ���� �÷��̾�

        [SerializeField] public AudioClip[] MainAudioClip; // ����� ����
        [SerializeField] private AudioClip[] SFXAudioClips; // ȿ���� ����

        public float VolumeSFX = 1.0f; // ȿ���� ����
        public float VolumeBGM = 1.0f; // ����� ����

        //Dictionary<key, value>�� ������� �ҷ��´�
        Dictionary<string, AudioClip> audioclipdic = new Dictionary<string, AudioClip>();
        private void Awake()
        {
            BGMPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>(); // BGM�÷��̾�
            SFXPlayer = GameObject.Find("SFXSoundPlayer").GetComponent<AudioSource>(); // ȿ�����÷��̾�

            // SFXAudioClips���� �����Ŭ������ Dictionary���� ����
            foreach (AudioClip audioclip in SFXAudioClips)
            {
                audioclipdic.Add(audioclip.name, audioclip);
            }

            PlayBGMSound();
        }

        public void PlaySFXSound(string name, float volum = 1.0f)
        {
            if (audioclipdic.ContainsKey(name) == false) // ȿ������ ���ٸ�
            {
                Debug.Log(name + "�� audioClipsDic�� �����ϴ�.");
                return;
            }

            SFXPlayer.PlayOneShot(audioclipdic[name], volum * VolumeSFX);

        }

        public void PlayBGMSound()
        {
            BGMPlayer.loop = true;
        }
        private void Update()
        {
            BGMPlayer.volume = VolumeBGM;
        }
    }
}
