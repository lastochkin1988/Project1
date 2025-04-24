using System.Collections;
using System.Collections.Generic;
using Golf.Assets.Scripts.States;
using UnityEngine;
using TMPro;

namespace Golf
{
    public class GameplayStates : GameState
    {
        public LevelController LevelController;
        public PlayerController PlayerController;
        public GameState gameOverState;
        public TMP_Text scoreText;

        protected override void OnEnable()
        {
            base.OnEnable();

            LevelController.enabled = true;
            PlayerController.enabled = true;

            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
        }
        public void OnStickHit()
        {
            scoreText.text = $"HScore : {LevelController.score}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }

        protected override void OnDisable()
        {

            base.OnDisable();

            GameEvents.onCollisionStone -= OnGameOver;


            LevelController.enabled = false;
            PlayerController.enabled = false;
        }
    }
}
