using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class GameController : MonoBehaviour
    {
        public MainMenuState MainMenuState;

        private void Start()
        {
            MainMenuState.gameObject.SetActive(true);
        }
    }
}
