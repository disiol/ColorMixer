using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ColorMixer.Scripts.Game.Enums;
using ColorMixer.Scripts.Game.Interfaces;
using ColorMixer.Scripts.Game.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.Scripts.Game
{
    public class Game : MonoBehaviour, IGame
    {
        [SerializeField]
        private List<ButtonsIngredientsForLevel> buttonsIngredients = new List<ButtonsIngredientsForLevel>();

        [SerializeField] private GameObject ui;
        [SerializeField] private GameObject imageFinalColor;
        [SerializeField] private TextMeshProUGUI textColorMatch;
        [SerializeField] private int сonditionsForvictory;
        private GameObject _buttonMix;


        public int currentLevel;
        private bool _wine;
        private Levels _instanceLevels;

        private string _theObtainedColorCorrespondsToTheRequiredColorBy =
            "Полученный цвет на [0]% соответствует необходимому";

        private Color32 _victoryСolor;
        private Color32 _finalColor;
        private Color32 _currentСolor;
        private TextMeshProUGUI _textColorMatchGetComponentTextMeshProUGUI;
        private bool _isCheckWin;

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
            _isCheckWin = false;
            this._instanceLevels.SelectLevel(currentLevel);
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
            if (!_isCheckWin)
            {
                Debug.Log("Game CheckWin ");
                _isCheckWin = true;
                this._finalColor = GameObject.Find("ImageFinalColor").GetComponent<Image>().color;

                this._victoryСolor = _instanceLevels.GetVictoryСolor();
                this._currentСolor = _finalColor;

                var calculationColorSMatchingPercentage = GetDiff(_victoryСolor, _currentСolor);

                this._textColorMatchGetComponentTextMeshProUGUI =
                    textColorMatch.GetComponent<TextMeshProUGUI>();


                this._textColorMatchGetComponentTextMeshProUGUI.text =
                    String.Format(_theObtainedColorCorrespondsToTheRequiredColorBy,
                        calculationColorSMatchingPercentage);
            }

            //      NextLevel();

            //   StartGame();
        }

        private int CalculationColorSMatchingPercentage(Color32 victoryСolor, Color32 currentСolor)
        {
            byte[] victoryСolorA = new[]
            {
                (byte)((victoryСolor.a - currentСolor.a) +
                       (victoryСolor.b - currentСolor.b) +
                       (victoryСolor.g - currentСolor.g) +
                       (victoryСolor.r - currentСolor.r)
                )
            };
            int matchingPercentage = BitConverter.ToInt32(victoryСolorA, 0);
            return matchingPercentage / 4;
        }

        private static int GetDiff(Color32 color, Color32 baseColor)
        {
            int a = color.a - baseColor.a,
                r = color.a - baseColor.a,
                g = color.g - baseColor.g,
                b = color.b - baseColor.b;
            return a * a + r * r + g * g + b * b;
        }

        private void NextLevel()
        {
            if (currentLevel < _instanceLevels.GetLevelsListCount())
            {
                currentLevel++;
            }
            else
            {
                currentLevel = 0;
            }
        }
    }
}