using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic;
using Input;
using UnityEngine;

namespace GamePlay
{
    public class GamePlayManager : MonoBehaviour
    {
        private DiscView CurrentDisc = null;
        private GoalKeeperController goalKeeper;
        private List<Target> targets = new List<Target>();
        public int CurrentGameLevel { get; set; } = 1;

        public float respawnDelay = 1.5f;
        [SerializeField] private float speedUpStep = 1f;
        [SerializeField] private Spawner spawner;
       
        public event Action<Transform> OnDiscSpawned;
        public event Action<int> OnLevelIncreased;
        

        public void StartGame()
        {
            UnfreezeGame();
            SpawnPlayer();
            SpawnKeeper();
            SpawnTargets();
            SpawnDisc();
           
            
        }

        private void SpawnPlayer()
        {
            spawner.SpawnPlayer();
        }

        private void SpawnTargets()
        {
            targets = spawner.SpawnTargets();
            foreach (var target in targets)
            {  
                target.OnDeath += OnTargetDestroy;
            }
        }

        private void SpawnDisc()
        {
            if (CurrentDisc != null)
            {
                Destroy(CurrentDisc.gameObject);
            }

            CurrentDisc = spawner.SpawnDisc();
            OnDiscSpawned?.Invoke(CurrentDisc.transform);
        }

        private void SpawnKeeper()
        {
            goalKeeper = spawner.SpawnKeeper();
            OnDiscSpawned += goalKeeper.OnDiscRespawned;
            goalKeeper.OnEnemyCathedDisc += OnLevelFail;

        }


        private void OnTargetDestroy(Target target)
        {
            target.OnDeath -= OnTargetDestroy;
            targets.Remove(target);
            Destroy(target.gameObject);
            if (targets.Count <= 0)
            {
                OnLevelWin();
            }
        }

        private void OnLevelWin()                   
        {
            Destroy(CurrentDisc.gameObject);
            goalKeeper.Reset();
            GoToNextLevel();
            CurrentGameLevel++;
            OnLevelIncreased?.Invoke(CurrentGameLevel);
        }

        private void OnLevelFail()
        {
            RestartLevel();
           
        }

        private void RestartLevel()
        {
            Destroy(CurrentDisc.gameObject);
            foreach (var target in targets)
            {
                StartCoroutine(ScaleDownAndDestroy(target.gameObject));
            }

            goalKeeper.Reset();
            StartCoroutine(SetupLevelAfterDelay());
        }

        private void GoToNextLevel()
        {   
            StartCoroutine(SetupLevelAfterDelay());
           
            IncreaseGameDifficalty();
        }

        private void IncreaseGameDifficalty()
        {
            goalKeeper.SpeedUp(speedUpStep);
        }


        private IEnumerator SetupLevelAfterDelay()
        {
            yield return new WaitForSeconds(respawnDelay);
            SpawnTargets();
            SpawnDisc();
        }

      
        private IEnumerator ScaleDownAndDestroy(GameObject gameObject)
        {
            var timeLeft = respawnDelay;
            var transform = gameObject.transform;
            while (timeLeft >= 0f)
            {
                timeLeft -= Time.deltaTime;
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 1 - timeLeft / respawnDelay);
                yield return null;
            }
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnDiscSpawned -= goalKeeper.OnDiscRespawned;
           
        }

        public void FreezeGame()
        {
            Time.timeScale = 0f;
        }
        
        public void UnfreezeGame()
        {
            Time.timeScale = 1f;
        }

        
    }
}