using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ColorMixer.Scripts.Game.Enums;
using ColorMixer.Scripts.Game.Interfaces;
using ColorMixer.Scripts.Game.Ui;
using UnityEngine;

namespace ColorMixer.Scripts.Game
{
    public class Game : MonoBehaviour, IGame
    {
        [SerializeField]
        private List<ButtonsIngredientsForLevel> buttonsIngredients = new List<ButtonsIngredientsForLevel>();

        [SerializeField] private GameObject ui;

        public int _currentLevel;
        private bool _wine;
        private Levels _instanceLevels;

        private void Awake()
        {
            _instanceLevels = Levels.Instance;
            
        }

        private void Start()
        {
            this._instanceLevels._buttonsIngredients = buttonsIngredients;
            this._instanceLevels.ui = ui;

            StartGame();
        }

        public void StartGame()
        {
            this._instanceLevels.SelectLevel(_currentLevel);
        }


        public void LoadGame()
        {
            //TODO LoadGame
        }

        public void SafeGame()
        {
            //TODO SafeGame
        }


        public void CheckWin()
        {
            throw new NotImplementedException();
        }
    }
}