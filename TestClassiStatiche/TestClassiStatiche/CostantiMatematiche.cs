
namespace TestClassiStatiche
{
    public static class CostantiMatematiche
    {
        public static float PiGreco = 3.14f;
        public static float g = 9.8f;


        public static double CalcoloCirconferenza(double raggio)
        {
            var result = raggio*2*PiGreco;
            return result;
        }
    }
}
