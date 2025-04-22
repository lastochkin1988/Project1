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
        private void Start()
        {
            n_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
        }

        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
        }

        private void GameOver() 
        {
            Debug.Log("Game Over!!!");
            enabled = false;   
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
                spawner.Spawn();
                n_lastSpawnedTime = Time.time;

                RefreshDelay();
            }
        }


    }
}
