namespace ColorMixer.Scripts
{
    public class Singleton<T> where T : new()
    {
        private static T instacne;

        public static T Instance
        {
            get
            {
                if (instacne == null)
                {
                    instacne = new T();
                }

                return instacne;
            }
        }
    }
}