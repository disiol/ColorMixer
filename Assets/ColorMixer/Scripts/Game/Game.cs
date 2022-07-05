using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorMixer.Scripts.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private List<ButtonsIngredientsForLevel> buttonsIngredients = new List<ButtonsIngredientsForLevel>();
        [SerializeField] private GameObject ui;


        private void Start()
        {
            Levels.Instance._buttonsIngredients = buttonsIngredients;
            Levels.Instance.ui = ui;
            Levels.Instance.BananaAndGreenApple();
        }
    }

    [System.Serializable]
    public class ButtonsIngredientsForLevel
    {
        public List<GameObject>  buttonsIngredientsForLevel = new List<GameObject>();
       
    }
}