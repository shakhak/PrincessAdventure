﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace PrincessAdventure
{
    public class StarShardGuiController : MonoBehaviour
    {

        [SerializeField] private GameObject _continueButton;
        [SerializeField] private Image _starFill;

        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _piecePut;
        [SerializeField] private AudioClip _rewardZinger;

        private int currentShards = 0;

        public void LoadStarShardScreen(int numOfShards)
        {
            SoundManager.SoundInstance.PlayEffectSound(_rewardZinger);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_continueButton);

            currentShards = numOfShards;
            _starFill.fillAmount = GetFillValue(currentShards - 1);
            StartCoroutine(PlaceStarShard());
        }

        private IEnumerator PlaceStarShard()
        {
            float waitCount = 0;

            while(waitCount < 4.2f)
            {
                waitCount += Time.deltaTime;
                yield return null;
            }

            _starFill.fillAmount = GetFillValue(currentShards);
            SoundManager.SoundInstance.PlayEffectSound(_piecePut);
        }

        public void ContinueGame()
        {
            SoundManager.SoundInstance.PlayEffectSound(_click);

            if (currentShards == 5) //TODO:  Go to LEVEL UP!!!
            {
                GameManager.GameInstance.ResumeGameFromMenu();
                currentShards = 0;
            }
            else
                GameManager.GameInstance.ResumeGameFromMenu();
        }

        private float GetFillValue(int numOfShards)
        {
            if (numOfShards == 0)
                return 0f;
            if (numOfShards == 1)
                return .17f;
            if (numOfShards == 2)
                return .39f;
            if (numOfShards == 3)
                return .61f;
            if (numOfShards == 4)
                return .82f;
            if (numOfShards == 5)
                return 1f;

            return 0;
        }
    }
}
