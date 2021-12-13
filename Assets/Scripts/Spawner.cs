using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Spawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject targetPrefab;
        [SerializeField] private GameObject discPrefab;
        [SerializeField] private GameObject goalKeeper;

        [Header("SpawnPoints")] 
        [SerializeField] private Transform targetsRoot;
        [SerializeField] private Transform playerRoot;
        [SerializeField] private Transform discRoot;
        [SerializeField] private Transform goalKeeperRoot;

        [Space]
        [SerializeField] private SpawnUpMovementHandler spawnEffectHandler;

        
        public DiscCatcherView SpawnPlayer()
        {
            var go = Instantiate(playerPrefab, playerPrefab.transform.position, Quaternion.identity);
            go.transform.SetParent(playerRoot);
            spawnEffectHandler.MakeMovingUpEffect(go.transform);
            return go.GetComponent<DiscCatcherView>();
        }
        
        
        public List<Target> SpawnTargets()
        {
            var targets = new List<Target>();

            foreach (Transform point in targetsRoot)
            {
                var go = Instantiate(targetPrefab, point.position, Quaternion.identity);
                go.transform.SetParent(point);
                targets.Add(go.GetComponent<Target>());
                spawnEffectHandler.MakeMovingUpEffect(go.transform);
            }

            return targets;
        }

        public DiscView SpawnDisc()
        {
            var go = Instantiate(discPrefab, discRoot.transform.position, Quaternion.identity);
            go.transform.SetParent(discRoot);
            spawnEffectHandler.MakeMovingUpEffect(go.transform);
            return go.GetComponent<DiscView>();
        }


        public GoalKeeperController SpawnKeeper()
        {
            var go = Instantiate(goalKeeper, goalKeeperRoot.transform.position, goalKeeper.transform.rotation);
            go.transform.SetParent(goalKeeperRoot);
            spawnEffectHandler.MakeMovingUpEffect(go.transform);
            return go.GetComponent<GoalKeeperController>();
        }
    }
}