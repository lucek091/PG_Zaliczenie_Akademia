using System;

namespace ProgramPunktowy
{
    public class DeleteExtremeValues : PointBook
    {
        public override StaticticsOfGivenValues CalculateStatictics()
        {

            float bestValue = float.MaxValue;
            float worstValue = float.MinValue;

            foreach (float point in Points)
            {
                bestValue = Math.Min(point, bestValue);
                worstValue = Math.Max(point, worstValue);

            }

            Points.Remove(worstValue);
            Points.Remove(bestValue);


            return base.CalculateStatictics();
        }
    }
}
