using UnityEngine;

namespace GJ.Calculation
{
    public static class Calculator
    {
        public static int RandomNumber(int mini,int max)
        {
             
            return Random.Range(mini, max);
        }
    }
}

