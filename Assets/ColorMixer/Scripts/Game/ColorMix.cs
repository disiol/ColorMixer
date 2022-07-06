using System.Collections.Generic;
using ColorMixer.Scripts.Game.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.Scripts.Game
{
    public class ColorMix : SingletonMono<ColorMix>, IColorMix
    {

        private int _caunterIngredients;
        private List<Color> _aColors;
        private Image _imageFinalColor;
        private Color _componentColor;


        void Start()

        {
            _imageFinalColor = GameObject.Find("ImageFinalColor").GetComponent<Image>();

            this._aColors = new List<Color>();
        }

        public void AddColor(Color color)
        {
            this._aColors.Add(color);
        }

        public void SetImageColor()
        {
            if ( this._aColors !=null &  this._aColors.Count > 0)
            { 
                _componentColor = CombineColors( this._aColors);
                _imageFinalColor.color = _componentColor;
            }
        }

        private Color CombineColors(List<Color> aColors)
        {
            Color result = new Color(0, 0, 0, 0);
            foreach (Color c in aColors)
            {
                result += c;
            }
            result /= aColors.Count;
            this._aColors.Clear();

            return result;
        }
    }
}