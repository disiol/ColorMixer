using System.Collections.Generic;
using UnityEngine;

namespace ColorMixer.Scripts.Game.Interfaces
{
    public interface ILevels
    {
        void BananaAndGreenApple();
        void GreenAppleOrangeAndRedCherry();
        void RedTomatoGreenCucumberPurpleAubergine();

        void TermsOfVictory(Color32 CurentСolor);
        void AddButtonsToUi(List<GameObject> ingredients);
    }
}