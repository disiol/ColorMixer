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
        [SerializeField] private GameObject obtainedColorCorrespondsToTheRequired;
        [SerializeField] private int сonditionsForvictory;
        private TextMeshProUGUI _textColorMatch;
        private Button _buttonColorMatch;


        public int currentLevel;
        private bool _wine;
        private Levels _instanceLevels;

        private string _theObtainedColorCorrespondsToTheRequiredColorBy =
            "Полученный цвет на {0}% соответствует необходимому";

        private Color32 _victoryСolor;
        private Color32 _finalColor;
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
            _isCheckWin = false;
            CleanUi();
            this._instanceLevels.SelectLevel(currentLevel);
        }

        private void CleanUi()
        {
            Transform uiTransform = ui.transform;
            var childCount = uiTransform.childCount;
            Debug.Log(childCount);
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

            Debug.Log(transform.childCount);
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


                this._textColorMatchGetComponentTextMeshProUGUI.text =
                    String.Format(_theObtainedColorCorrespondsToTheRequiredColorBy,
                        calculationColorSMatchingPercentage);
            }

            //      NextLevel();
        }

        // private int CalculationColorSMatchingPercentage(Color32 victoryСolor, Color32 currentСolor)
        // {
        //     
        //     GetDiff(_victoryСolor, _currentСolor);
        // }

        private static int GetDiff(Color32 victoryСolor, Color32 currentСolor)
        {
            int a = victoryСolor.a - currentСolor.a,
                r = victoryСolor.a - currentСolor.a,
                g = victoryСolor.g - currentСolor.g,
                b = victoryСolor.b - currentСolor.b;
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