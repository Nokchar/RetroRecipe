using System.Collections;
using UnityEngine;

namespace HSJ
{
    public class SoundManager : Singleton<SoundManager>
    {
        public enum SoundType
        {
            BGM,
            Effect,
            MaxCount
        }

        [field: SerializeField]
        public AudioSource[] audioSources { get; private set; } = new AudioSource[(int)SoundType.MaxCount];
        [field: SerializeField]
        public SerializableDictionary<string, AudioClip> audioClips { get; private set; } = new SerializableDictionary<string, AudioClip>();

        public void PlayBackgroundMusic()
        {
            audioSources[(int)SoundType.BGM].Play();
        }

        public void StopBackgroundMusic()
        {
            audioSources[(int)SoundType.BGM].Stop();
        }

        public void PauseBackgroundMusic()
        {
            audioSources[(int)SoundType.BGM].Pause();
        }

        public void ResumeBackgroundMusic()
        {
            audioSources[(int)SoundType.BGM].UnPause();
        }

        public void PlaySoundEffect(string key, bool loop = false)
        {
            if (audioClips.ContainsKey(key))
            {
                audioSources[(int)SoundType.Effect].clip = audioClips[key];
                audioSources[(int)SoundType.Effect].loop = loop;
                audioSources[(int)SoundType.Effect].Play();
            }
            else
            {
                Debug.LogWarning($"Sound effect with key '{key}' not found.");
            }
        }

        public void StopSoundEffect()
        {
            audioSources[(int)SoundType.Effect].Stop();
        }

        public void PauseSoundEffect()
        {
            audioSources[(int)SoundType.Effect].Pause();
        }

        public void ResumeSoundEffect()
        {
            audioSources[(int)SoundType.Effect].UnPause();
        }

        public void SetVolume(SoundType soundType, float volume)
        {
            audioSources[(int)soundType].volume = Mathf.Clamp01(volume);
        }

        public void FadeInBackgroundMusic(string key, float duration)
        {
            if (audioClips.ContainsKey(key))
            {
                StartCoroutine(FadeIn(audioSources[(int)SoundType.BGM], audioClips[key], duration));
            }
            else
            {
                Debug.LogWarning($"Background music with key '{key}' not found.");
            }
        }

        public void FadeOutBackgroundMusic(float duration)
        {
            StartCoroutine(FadeOut(audioSources[(int)SoundType.BGM], duration));
        }

        private IEnumerator FadeIn(AudioSource audioSource, AudioClip newClip, float duration)
        {
            audioSource.clip = newClip;
            audioSource.volume = 0;
            audioSource.Play();

            float startVolume = 0f;
            float targetVolume = 1f;
            float startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                audioSource.volume = Mathf.Lerp(startVolume, targetVolume, (Time.time - startTime) / duration);
                yield return null;
            }

            audioSource.volume = targetVolume;
        }

        private IEnumerator FadeOut(AudioSource audioSource, float duration)
        {
            float startVolume = audioSource.volume;
            float startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                audioSource.volume = Mathf.Lerp(startVolume, 0, (Time.time - startTime) / duration);
                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }

        public void AddAudioClip(string key, AudioClip clip)
        {
            if (!audioClips.ContainsKey(key))
            {
                audioClips.Add(key, clip);
            }
            else
            {
                Debug.LogWarning($"Audio clip with key '{key}' already exists.");
            }
        }

        public void RemoveAudioClip(string key)
        {
            if (audioClips.ContainsKey(key))
            {
                audioClips.Remove(key);
            }
            else
            {
                Debug.LogWarning($"Audio clip with key '{key}' not found.");
            }
        }

        public bool IsPlaying(SoundType soundType)
        {
            return audioSources[(int)soundType].isPlaying;
        }
    }
}
