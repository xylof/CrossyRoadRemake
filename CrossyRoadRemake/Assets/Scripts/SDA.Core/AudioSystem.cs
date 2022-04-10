using UnityEngine;

namespace SDA.Core
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource backgoroundMusicAudioSource;
        [SerializeField] private AudioSource soundsAudioSource;

        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip gameMusic;
        [SerializeField] private AudioClip death;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip youLose;
        [SerializeField] private AudioClip bestScore;

        #region BACKGROUND_MUSIC

        public void PlayMenuMusic()
        {
            backgoroundMusicAudioSource.Stop();
            backgoroundMusicAudioSource.clip = menuMusic;
            backgoroundMusicAudioSource.Play();
        }

        public void PlayGameMusic()
        {
            backgoroundMusicAudioSource.Stop();
            backgoroundMusicAudioSource.clip = gameMusic;
            backgoroundMusicAudioSource.Play();
        }

        #endregion

        #region SOUNDS

        public void PlayDeathMusic()
        {
            backgoroundMusicAudioSource.Stop();
            soundsAudioSource.PlayOneShot(youLose);
            soundsAudioSource.PlayOneShot(death);
        }

        public void PlayJumpMusic()
        {
            soundsAudioSource.PlayOneShot(jump);
        }

        public void PlayYouLoseMusic()
        {
            soundsAudioSource.PlayOneShot(youLose);
        }

        public void PlayBestScoreMusic()
        {
            soundsAudioSource.PlayOneShot(bestScore);
        }

        #endregion
    }
}
