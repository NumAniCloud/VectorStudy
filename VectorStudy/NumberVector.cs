
using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorStudy
{
    class NumberVector
    {
        public int Number { get; set; }
        public Dictionary<int, int> Elements { get; }

        public NumberVector(int number, Dictionary<int, int> elements)
        {
            Elements = elements;
            Number = number;
        }

        public bool IsPrime()
        {
            return Elements.ContainsKey(Number);
        }

        public float GetLength()
        {
            float squared = 0;
            foreach (var item in Elements)
            {
                squared += item.Value * item.Value;
            }
            return (float)Math.Sqrt(squared);
        }

        public override string ToString()
        {
            var elements = Elements.Select(x => $"{x.Key}^{x.Value}").ToArray();
            var elementSection = string.Join(" * ", elements);
            return $"{Number} = {elementSection}";
        }

        public static NumberVector operator-(NumberVector left, NumberVector right)
        {
            var elements = new Dictionary<int, int>();
            foreach (var item in left.Elements)
            {
                elements[item.Key] = item.Value;
            }
            foreach (var item in right.Elements)
            {
                if (elements.ContainsKey(item.Key))
                {
                    elements[item.Key] -= item.Value;
                }
                else
                {
                    elements[item.Key] = -item.Value;
                }
            }

            int number = 1;
            foreach (var item in elements)
            {
                number *= item.Key * item.Value;
            }

            return new NumberVector(number, elements);
        }

        public static NumberVector CreateForNumber(int number)
        {
            var list = TrialDivision(number);
            var elements = list.GroupBy(x => x).ToDictionary(x => x.First(), x => x.Count());
            return new NumberVector(number, elements);
        }

        private static IEnumerable<int> TrialDivision(int number)
        {
            var result = number;
            var max = Math.Sqrt(number);
            for (int i = 2; i < max + 1; i++)
            {
                //System.Console.WriteLine($"{number} % {i} == {number % i}");
                if (number % i == 0)
                {
                    result = i;
                    break;
                }
            }

            yield return result;

            if (result < number)
            {
                foreach (var item in TrialDivision(number / result))
                {
                    yield return item;
                }
            }
        }
    }
}