using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrincessAdventure
{

    public class SoundManager : MonoBehaviour
    {


        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _effectsSource;


		public static SoundManager SoundInstance;

		#region Unity Functions
		private void Awake()
		{
			if (SoundInstance == null)
			{
				DontDestroyOnLoad(this);
				SoundInstance = this;
			}
			else if (SoundInstance != this)
			{
				Destroy(gameObject);
			}
		}
        #endregion

        private void Start()
        {
			float music = 1f;
			if (PlayerPrefs.HasKey("MusicVolume"))
				music = PlayerPrefs.GetFloat("MusicVolume");

			float sfx = 1;
			if (PlayerPrefs.HasKey("SfxVolume"))
				sfx = PlayerPrefs.GetFloat("SfxVolume");

			ChangeMusicVolume(music);
			ChangeSfxVolume(sfx);
		}

        public void PlayEffectSound(AudioClip clip)
        {
			if(clip != null)
				_effectsSource.PlayOneShot(clip);
        }

		public void ChangeMusic(AudioClip track, bool isLoop)
        {
			_musicSource.Stop();
			_musicSource.loop = isLoop;
			_musicSource.clip = track;
			_musicSource.PlayDelayed(.5f);
        }

		public void ChangeMusicVolume(float value)
        {
			_musicSource.volume = value;
        }

		public void ChangeSfxVolume(float value)
		{
			_effectsSource.volume = value;
		}

		public float GetSfxVolume()
        {
			return _effectsSource.volume;

		}

		public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
		{
			if (clip == null)
				return null;

			GameObject tempGO = new GameObject("TempAudio"); // create the temp object
			tempGO.transform.position = pos; // set its position
			AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
			aSource.clip = clip; // define the clip
								 // set other aSource properties here, if desired
			aSource.volume = _effectsSource.volume;
			aSource.spatialBlend = 1;
			aSource.rolloffMode = AudioRolloffMode.Linear;
			aSource.minDistance = 0;
			aSource.maxDistance = 20;


			aSource.Play(); // start the sound
			Destroy(tempGO, clip.length); // destroy object after clip duration
			return aSource; // return the AudioSource reference
		}

	}
}
