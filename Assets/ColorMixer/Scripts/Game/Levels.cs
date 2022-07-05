using System;
using System.Collections.Generic;
using ColorMixer.Scripts.Game.Interfaces;
using UnityEngine;

namespace ColorMixer.Scripts.Game
{
    public class Levels : SingletonMono<Levels>, ILevels
    {
        private Color32 _victoriousСolor;

        public List<ButtonsIngredientsForLevel> _buttonsIngredients = new List<ButtonsIngredientsForLevel>();

        public GameObject ui;
        private GameObject _buttonsIngredient;

        public void BananaAndGreenApple()
        {
            _victoriousСolor = Colors.VictoriousСolorBananaAndGreenApple;
            List<GameObject> ingredients = _buttonsIngredients[0].buttonsIngredientsForLevel;
            TermsOfVictory(_victoriousСolor);
            AddButtonsToUi(ingredients);
        }


        public void GreenAppleOrangeAndRedCherry()
        {
            _victoriousСolor = Colors.VictoriousСolorGreenAppleOrangeAndRedCherry;
            List<GameObject> ingredients = _buttonsIngredients[1].buttonsIngredientsForLevel;
            TermsOfVictory(_victoriousСolor);
            AddButtonsToUi(ingredients);
        }

        public void RedTomatoGreenCucumberPurpleAubergine()
        {
            _victoriousСolor = Colors.VictoriousСoloRedTomatoGreenCucumberPurpleAubergine;
            List<GameObject> ingredients = _buttonsIngredients[2].buttonsIngredientsForLevel;
            TermsOfVictory(_victoriousСolor);
            AddButtonsToUi(ingredients);
        }

        public void TermsOfVictory(Color32 currentСolor)
        {
//TODO       TermsOfVictory     throw new System.NotImplementedException();
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