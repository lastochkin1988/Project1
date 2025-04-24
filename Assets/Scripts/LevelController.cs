using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        public float m_delay = 0.5f;

        private float n_lastSpawnedTime = 0;  
        
        public int score = 0;
        public int hightScore = 0;

        private List<GameObject> m_stones = new List<GameObject>(16);

        private void Start()
        {
            n_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void onStickHit()
        {
            score++;
            hightScore = Mathf.Max(hightScore, score);
            Debug.Log($"score: {score} - hightScore:{hightScore}");
        }

        private void OnEnable()
        {
            GameEvents.onStickHit += onStickHit;
            score = 0;
        }

        private void OnDisable()
        {
            GameEvents.onStickHit -= onStickHit;
        }

        private void GameOver() 
        {
            Debug.Log("Game Over!!!");
            enabled = false;   
        }

        public void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }


        private void Update()
        {
            if (Time.time >= n_lastSpawnedTime + m_delay)
            {
                var stone = spawner.Spawn();
                m_stones.Add(stone);
                n_lastSpawnedTime = Time.time;

                RefreshDelay();
            }
        }


    }
}
