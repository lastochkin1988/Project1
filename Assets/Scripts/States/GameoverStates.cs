using System.Collections;
using System.Collections.Generic;
using Golf.Assets.Scripts.States;
using UnityEngine;

namespace Golf
{
    public class GameoverStates : GameState
    {
        public GameState mainMenuState;
        public LevelController levelController;

        public void Restart()
        {
            levelController.ClearStones();

            Exit();
            mainMenuState.Enter();
        }
    }
}
