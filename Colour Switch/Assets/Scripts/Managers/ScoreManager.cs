﻿using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private static ScoreManager _instance;
        public static ScoreManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.Log("ScoreManager is null");

                return _instance;
            }
        }

        public int score;
        public bool adWatched = false;
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            score = 0;
        }

        public void AddScore()
        {
            score++;
        }

        public void ResetScore()
        {
            score = 0;
            adWatched = false;
        }
    }
}
