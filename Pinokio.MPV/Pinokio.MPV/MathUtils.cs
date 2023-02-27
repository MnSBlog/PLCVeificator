using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinokio.MPV
{
    internal class MathUtils
    {
        // 평균 계산 함수
        public static float CalculateMean(List<float> numbers)
        {
            float sum = 0;
            foreach (float num in numbers)
            {
                sum += num;
            }
            return sum / numbers.Count;
        }

        // 분산 계산 함수
        public static float CalculateVariance(List<float> numbers)
        {
            float mean = CalculateMean(numbers);
            float sum = 0;
            foreach (float num in numbers)
            {
                sum += (num - mean) * (num - mean);
            }
            return sum / numbers.Count;
        }
        public static List<float> ScaleNumbers(List<float> numbers)
        {
            float max = numbers.Max();
            float min = numbers.Min();
            List<float> scaledNumbers = new List<float>();
            foreach (float num in numbers)
            {
                float scaledNum = (num - min) / (max - min);
                scaledNumbers.Add(scaledNum);
            }
            return scaledNumbers;
        }
    }
}
