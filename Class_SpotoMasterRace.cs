using System;
using System.Collections.Generic;

namespace SpotoMasterRace
{
    static internal class Class_SpotoMasterRace
    {
        #region Utilities

        static internal int GetFrequency<T>(List<T> collection, T item)
        {
            List<T> list = new List<T>(collection);

            int originalDim = list.Count;
            while (list.IndexOf(item) >= 0)
                list.Remove(item);
            int dimWithoutItem = list.Count;
            return originalDim - dimWithoutItem;
        }

        static internal List<T> RemoveDuplicates<T>(List<T> collection)
        {
            List<T> list = new List<T>();
            List<T> tmpList = new List<T>(collection);

            foreach (T item in collection)
            {
                bool duplicate = true;
                while (tmpList.IndexOf(item) >= 0)
                {
                    duplicate = false;
                    tmpList.Remove(item);
                }
                if (tmpList.Count >= 0 && !duplicate)
                    list.Add(item);
            }
            return list;
        }

        static internal double Sum(List<double> collection)
        {
            double sum = 0;
            foreach (double item in collection)
                sum += item;
            return sum;
        }

        #endregion Utilities

        #region Descriptive Statistics

        #region Significant Statistics for Nominal Scales

        static internal List<string> Mode(List<string> collection)
        {
            List<string> list = new List<string>(collection);

            List<string> mode = new List<string>();
            int modeFrequency = 0;
            int itemFrequency = 0;
            //find the higher frequency
            foreach (string item in list)
            {
                itemFrequency = GetFrequency(list, item);
                if (itemFrequency > modeFrequency)
                    modeFrequency = itemFrequency;
            }
            //find the mode
            foreach (string item in list)
            {
                itemFrequency = GetFrequency(list, item);
                if (itemFrequency == modeFrequency)
                    if (!mode.Contains(item))
                        mode.Add(item);
            }
            return mode;
        }

        static internal int NumberOfEquivalentClasses<T>(List<T> collection)
        { return RemoveDuplicates(collection).Count; }

        #endregion Significant Statistics for Nominal Scales

        #region Significant Statistics for Ordinal Scales

        static internal Dictionary<double, double> Proportions(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, double> keyvalue = new Dictionary<double, double>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            int dim = keyvalue.Count;
            Dictionary<double, double> proportions = new Dictionary<double, double>();
            foreach (KeyValuePair<double, double> keyvaluepair in keyvalue)
                proportions.Add(keyvaluepair.Key, keyvaluepair.Value / collection.Count);
            return proportions;
        }

        static internal Dictionary<double, double> ProportionsPercentages(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, double> keyvalue = new Dictionary<double, double>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            int dim = keyvalue.Count;
            Dictionary<double, double> proportions = Proportions(collection);
            foreach (KeyValuePair<double, double> keyvaluepair in keyvalue)
                proportions[keyvaluepair.Key] = (keyvaluepair.Value / collection.Count) * 100;
            return proportions;
        }

        static internal Dictionary<double, int> CumulativeFrequencies(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list = RemoveDuplicates(list);
            list.Sort();
            Dictionary<double, int> keyvalue = new Dictionary<double, int>(list.Count);
            for (int i = 0; i < list.Count; i++)
                keyvalue[list[i]] = GetFrequency(collection, list[i]);
            double[] keys = new double[keyvalue.Keys.Count];
            keyvalue.Keys.CopyTo(keys, 0);
            for (int i = 0; i < keys.Length; i++)
                keyvalue[keys[i]] += (i - 1 < 0 ? 0 : keyvalue[keys[i - 1]]);
            return keyvalue;
        }

        static internal Dictionary<double, double> CumulativeFrequenciesPercentages(List<double> collection)
        {
            Dictionary<double, int> keyvalue = CumulativeFrequencies(collection);
            int dim = keyvalue.Count;
            Dictionary<double, double> keypercentage = new Dictionary<double, double>();
            foreach (KeyValuePair<double, int> keyvaluepair in keyvalue)
                keypercentage.Add(keyvaluepair.Key, (keyvaluepair.Value * 100) / collection.Count);
            return keypercentage;
        }

        static internal double[] MedianOrdinal(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            if (list.Count % 2 == 0)
                //even
                return new double[] { list[(list.Count / 2) - 1],
                    list[((list.Count / 2) + 1) -1] };
            else
                //odd
                return new double[] { list[((list.Count + 1) / 2) - 1] };
        }

        static internal double[] Quartiles(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            return new double[] {
                Math.Floor(Convert.ToDouble(((1.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((1.0 / 4.0) * (list.Count + 1)) - 1)))],
                Math.Floor(Convert.ToDouble(((2.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((2.0 / 4.0) * (list.Count + 1)) - 1)))],
                Math.Floor(Convert.ToDouble(((3.0 / 4.0) * (list.Count + 1)) - 1)) < 0 ? list[0] : list[Convert.ToInt32(Math.Floor(Convert.ToDouble(((3.0 / 4.0) * (list.Count + 1)) - 1)))] };
        }

        static internal double XPercentile(List<double> collection, short xpercentage)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            int index = Convert.ToInt32(Math.Floor(((double)list.Count * ((double)xpercentage % 100.0)) / 100.0));
            return list[index <= 0 ? 0 : (index - 1)];
        }

        static internal double PercentileRank(List<double> collection, double key)
        {
            Dictionary<double, int> dict = CumulativeFrequencies(collection);
            if (dict.ContainsKey(key))
                return (dict[key] / (double)collection.Count) * 100.0;
            else
                return 0;
        }

        #endregion Significant Statistics for Ordinal Scales

        #region Significant Statistics for Interval and Ratio Scales

        static internal double Mean(List<double> collection)
        { return Sum(collection) / collection.Count; }

        static internal double MedianInterval(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            if (list.Count % 2 == 0)
                //even
                return Mean(new List<double>(new double[] { list[(list.Count / 2) - 1], list[((list.Count / 2) + 1) - 1] }));
            else
                //odd
                return list[((list.Count + 1) / 2) - 1];
        }

        static internal double Range(List<double> collection)
        {
            List<double> list = new List<double>(collection);
            list.Sort();
            return list[list.Count - 1] - list[0];
        }

        static internal double InterquartileDifference(List<double> collection)
        {
            double[] quartiles = Quartiles(collection);
            return quartiles[2] - quartiles[0];
        }

        static internal double Deviance(List<double> collection)
        {
            double sumOfSquares = 0;
            double mean = Mean(collection);
            foreach (double item in collection)
                sumOfSquares += Math.Pow(item - mean, 2);
            return sumOfSquares;
        }

        static internal double VariancePopulation(List<double> collection)
        { return Deviance(collection) / collection.Count; }

        static internal double VarianceSample(List<double> collection)
        { return Deviance(collection) / (collection.Count - 1); }

        static internal double StandardDeviationPopulation(List<double> collection)
        { return Math.Sqrt(VariancePopulation(collection)); }

        static internal double StandardDeviationSample(List<double> collection)
        { return Math.Sqrt(VarianceSample(collection)); }

        static internal double CoefficientOfVariationPopulation(List<double> collection)
        { return StandardDeviationPopulation(collection) / Math.Abs(Mean(collection)); }

        static internal double CoefficientOfVariationSample(List<double> collection)
        { return StandardDeviationSample(collection) / Math.Abs(Mean(collection)); }

        static internal double ZScorePopulation(List<double> collection, double item)
        { return (item - Mean(collection)) / StandardDeviationPopulation(collection); }

        static internal double ZScoreSample(List<double> collection, double item)
        { return (item - Mean(collection)) / StandardDeviationSample(collection); }

        //useless
        static internal double TScorePopulation(List<double> collection, double item)
        { return Mean(collection) + ZScorePopulation(collection, item) * StandardDeviationPopulation(collection); }

        //useless
        static internal double TScoreSample(List<double> collection, double item)
        { return Mean(collection) + ZScoreSample(collection, item) * StandardDeviationSample(collection); }

        #endregion Significant Statistics for Interval and Ratio Scales

        #endregion Descriptive Statistics
    }
}