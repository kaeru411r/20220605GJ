using UnityEngine;

namespace GJ.Calculation
{
    public static class Calculator
    {
        public static int RandomInt(int mini,int max)
        {
             
            return Random.Range(mini, max);
        }

        public static float RandomFloat(float mini,float max)
        {
            return Random.Range(mini, max);
        }
    }
}

