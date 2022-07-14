using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ColorMixer.Scripts.Game.Enums;
using ColorMixer.Scripts.Game.Interfaces;
using ColorMixer.Scripts.Game.Ui;
using TMPro;
using Unity.VisualScripting;
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
        [SerializeField] private GameObject obtainedColorCorrespondsToTheRequired;
        [SerializeField] private int сonditionsForVictory;
        private TextMeshProUGUI _textColorMatch;
        private Button _buttonColorMatch;


        public int currentLevelNumber;
        private Levels _instanceLevels;

        private String _victory = "Победа !!!";
        private String _tryAgain = "Пробуйте еще раз";

        private string _theObtainedColorCorrespondsToTheRequiredColorBy =
            "{0} \n Полученный цвет на {1}% соответствует необходимому";


        private Color32 _victoryСolor;
        private Color32 _currentСolor;
        private TextMeshProUGUI _textColorMatchGetComponentTextMeshProUGUI;
        private bool _isCheckWin;

        private void Awake()
        {
            this._instanceLevels = Levels.Instance;
        }

        private void Start()
        {
            this._instanceLevels._buttonsIngredients = buttonsIngredients;
            this._instanceLevels.ui = ui;
            this._textColorMatchGetComponentTextMeshProUGUI =
                obtainedColorCorrespondsToTheRequired.GetComponent<TextMeshProUGUI>();

            this._buttonColorMatch = obtainedColorCorrespondsToTheRequired.GetComponent<Button>();
            this._buttonColorMatch.onClick.AddListener(StartGame);


            StartGame();
        }

        public void StartGame()
        {
            this.obtainedColorCorrespondsToTheRequired.SetActive(false);
            _isCheckWin = false;
            CleanUi();
            this._instanceLevels.SelectLevel(currentLevelNumber);
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

                this._victoryСolor = _instanceLevels.GetVictoryСolor();
                this._currentСolor = imageFinalColor.GetComponent<Image>().color;

                var calculationColorSMatchingPercentage =
                    CalculationColorSMatchingPercentage(this._victoryСolor, this._currentСolor);

                if (calculationColorSMatchingPercentage >= this.сonditionsForVictory)
                {
                    ShowObtainedColorCorrespondsToTheRequired(calculationColorSMatchingPercentage, this._victory);
                    NextLevel();
                }
                else
                {
                    ShowObtainedColorCorrespondsToTheRequired(calculationColorSMatchingPercentage, this._tryAgain);
                }
            }
        }

        private void ShowObtainedColorCorrespondsToTheRequired(int calculationColorSMatchingPercentage,
            string victoryOrTryAgain)
        {
            this.obtainedColorCorrespondsToTheRequired.SetActive(true);

            this._textColorMatchGetComponentTextMeshProUGUI.text =
                String.Format(_theObtainedColorCorrespondsToTheRequiredColorBy, victoryOrTryAgain,
                    calculationColorSMatchingPercentage);

            CleanUi();
        }

        //TODO refactoring
        private int CalculationColorSMatchingPercentage(Color32 victoryСolor, Color32 currentСolor)
        {
            int victoryСolorPercent = 100;

            int diffСolors = GetDiffСolors(victoryСolor, currentСolor);

            int calculationColorSMatchingPercentage;

            if (diffСolors < 0)
            {
                calculationColorSMatchingPercentage = victoryСolorPercent + diffСolors;
            }
            else
            {
                calculationColorSMatchingPercentage = victoryСolorPercent - diffСolors;
            }


            return calculationColorSMatchingPercentage;
        }

        private static int GetDiffСolors(Color32 victoryСolor, Color32 currentСolor)
        {
            int a = victoryСolor.a - currentСolor.a,
                r = victoryСolor.a - currentСolor.a,
                g = victoryСolor.g - currentСolor.g,
                b = victoryСolor.b - currentСolor.b;
            int diff = a / 2 + r / 2 + g / 2 + b / 2;
            return diff;
        }


        private void NextLevel()
        {
            if (currentLevelNumber < _instanceLevels.GetLevelsListCount())
            {
                currentLevelNumber++;
            }
            else
            {
                currentLevelNumber = 0;
            }
        }

        private void CleanUi()
        {
            Transform uiTransform = ui.transform;
            var childCount = uiTransform.childCount;
            int i = 0;

            //Array to hold all child obj
            GameObject[] allChildren = new GameObject[childCount];

            //Find all child obj and store to that array
            foreach (Transform child in uiTransform)
            {
                allChildren[i] = child.gameObject;
                i += 1;
            }

            //Now destroy them
            foreach (GameObject child in allChildren)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}