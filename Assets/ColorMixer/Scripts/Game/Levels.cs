using System;
using System.Collections.Generic;
using System.Linq;
using ColorMixer.Scripts.Game.Enums;
using ColorMixer.Scripts.Game.Interfaces;
using ColorMixer.Scripts.Game.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.Scripts.Game
{
    public class Levels : SingletonMono<Levels>, ILevels
    {
        public List<ButtonsIngredientsForLevel> _buttonsIngredients = new List<ButtonsIngredientsForLevel>();

        private Color32 _victoriousСolor;

        private List<EnumLevels> _levelsList;
        private Image _imagVictoriousСolor;

        public GameObject ui;
        private GameObject _buttonsIngredient;


        private void Awake()
        {
            this._levelsList = Enum.GetValues(typeof(EnumLevels))
                .Cast<EnumLevels>()
                .ToList();

            this._imagVictoriousСolor = GameObject.FindWithTag("ImageVictoriousСolor").GetComponent<Image>();
        }


        public void SelectLevel(int currentLevel)
        {
            switch (_levelsList[currentLevel])
            {
                case EnumLevels.BananaAndGreenApple:
                    BananaAndGreenApple();
                    break;
                case EnumLevels.GreenAppleOrangeAndRedCherry:
                    GreenAppleOrangeAndRedCherry();
                    break;
                case EnumLevels.RedTomatoGreenCucumberPurpleAubergine:
                    RedTomatoGreenCucumberPurpleAubergine();
                    break;
            }
        }

        public void BananaAndGreenApple()
        {
            SetVictoriousСolor(Colors.VictoriousСolorBananaAndGreenApple);

            List<GameObject> ingredients = _buttonsIngredients[0].buttonsIngredientsForLevel;
            AddButtonsToUi(ingredients);
        }


        public void GreenAppleOrangeAndRedCherry()
        {
            SetVictoriousСolor(Colors.VictoriousСolorGreenAppleOrangeAndRedCherry);
            List<GameObject> ingredients = _buttonsIngredients[1].buttonsIngredientsForLevel;
            AddButtonsToUi(ingredients);
        }

        public void RedTomatoGreenCucumberPurpleAubergine()
        {
            SetVictoriousСolor(Colors.VictoriousСoloRedTomatoGreenCucumberPurpleAubergine);
            List<GameObject> ingredients = _buttonsIngredients[2].buttonsIngredientsForLevel;
            AddButtonsToUi(ingredients);
        }


        private void SetVictoriousСolor(Color32 victoriousСolor)
        {
            this._victoriousСolor =  victoriousСolor;
            this._imagVictoriousСolor.color = victoriousСolor;
        }


        public Color32 GetVictoryСolor()
        {
            return this._victoriousСolor;
        }

        public int GetLevelsListCount()
        {
            return this._levelsList.Count;
        }


        public void AddButtonsToUi(List<GameObject> ingredients)
        {
            foreach (GameObject ingredientButton in ingredients)
            {
                //
                Instantiate(ingredientButton, this.ui.transform, false);
            }
        }
    }
}