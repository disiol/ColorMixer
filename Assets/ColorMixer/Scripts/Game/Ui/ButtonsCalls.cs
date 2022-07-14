using ColorMixer.Scripts.Game.Enums;
using ColorMixer.Scripts.Game.Interfaces;
using ColorMixer.Scripts.Game.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.Scripts.Game

{
    public class ButtonsCalls : MonoBehaviour, IButtons
    {
        [SerializeField] private Button buttonIngredients;
        [SerializeField] private EnumIngredients selectIngredient;
       
        private GameObject _buttonMix;
        private ColorMix _colorMix;
        private Game _getComponentGame;

        private void Awake()
        {
            this._colorMix = ColorMix.Instance;
        }

        void Start()

        {
            _buttonMix = GameObject.Find("ImageFinalColor");
            
            this.buttonIngredients.GetComponent<Button>().onClick.AddListener(SelectIngredient);
           
            this._buttonMix.GetComponent<Button>().onClick.AddListener(ButtonMix);
        }

        private void SelectIngredient()
        {
            switch (selectIngredient)
            {
                case EnumIngredients.Banana:
                    Banana();
                    break;
                case EnumIngredients.Orange:
                    Orange();
                    break;
                case EnumIngredients.GreenApple:
                    GreenApple();
                    break;
                case EnumIngredients.GreenCucumber:
                    GreenCucumber();
                    break;
                case EnumIngredients.PurpleAubergine:
                    PurpleAubergine();
                    break;
                case EnumIngredients.RedCherry:
                    RedCherry();
                    break;
                case EnumIngredients.RedTomato:
                    RedTomato();
                    break;
            }
        }

        #region ButtonsCalls

        public void GreenApple()
        {
            _colorMix.AddColor(Colors.ColorGreenApple);
        }

        public void Banana()
        {
            _colorMix.AddColor(Colors.ColorBanana);
        }

        public void Orange()
        {
            _colorMix.AddColor(Colors.ColorOrandge);
        }

        public void RedCherry()
        {
            _colorMix.AddColor(Colors.ColorRedCherry);
        }

        public void RedTomato()
        {
            _colorMix.AddColor(Colors.ColorRedTomato);
        }

        public void GreenCucumber()
        {
            _colorMix.AddColor(Colors.ColorGreenCucumber);
        }

        public void PurpleAubergine()
        {
            _colorMix.AddColor(Colors.ColorPurpleAubergine);
        }

        public void ButtonMix()
        {
            _colorMix.SetImageColor();
            this.   _colorMix.SetImageColor();

            this.  _getComponentGame = GameObject.Find("GameManager").GetComponent<Game>();

            this.  _getComponentGame.CheckWin();

        }

        private void OnDestroy()
        {
            this.buttonIngredients.onClick.RemoveAllListeners();
            this._buttonMix.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        #endregion
    }
}