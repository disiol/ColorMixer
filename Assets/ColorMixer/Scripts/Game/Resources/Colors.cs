using UnityEngine;

namespace ColorMixer.Scripts.Game.Resources

{
    public class Colors : Singleton<Colors>
    {
        public static Color32 ColorGreenApple => new Color32((byte)101, (byte)213, (byte)100, (byte)225);
        public static Color32 ColorOrandge => new Color32((byte)225, (byte)143, (byte)0, (byte)225);
        public static Color32 ColorBanana => new Color32((byte)225, (byte)234, (byte)15, (byte)225);
        public static Color32 ColorRedCherry => new Color32((byte)190, (byte)14, (byte)49, (byte)225);
        public static Color32 ColorRedTomato => new Color32((byte)225, (byte)27, (byte)0, (byte)225);
        public static Color32 ColorGreenCucumber => new Color32((byte)57, (byte)168, (byte)43, (byte)225);
        public static Color32 ColorPurpleAubergine => new Color32((byte)88, (byte)43, (byte)168, (byte)225);

        public static Color32 Victorious–°olorBananaAndGreenApple =>
            new Color32((byte)163, (byte)224, (byte)58, (byte)225);

        public static Color32 Victorious–°olorGreenAppleOrangeAndRedCherry =>
            new Color32((byte)172, (byte)123, (byte)50, (byte)225);

        public static Color32 Victorious–°oloRedTomatoGreenCucumberPurpleAubergine =>
            new Color32((byte)132, (byte)11, (byte)27, (byte)225);
    }
}