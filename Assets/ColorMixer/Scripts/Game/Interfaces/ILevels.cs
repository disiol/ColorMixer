using System.Collections.Generic;
using UnityEngine;

namespace ColorMixer.Scripts.Game.Interfaces
{
    public interface ILevels
    {
        void BananaAndGreenApple();
        void GreenAppleOrangeAndRedCherry();
        void RedTomatoGreenCucumberPurpleAubergine();

        Color32 GetVictoryСolor();
        int GetLevelsListCount();
        void AddButtonsToUi(List<GameObject> ingredients);
    }
}