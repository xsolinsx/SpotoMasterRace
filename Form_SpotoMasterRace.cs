using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpotoMasterRace
{
    public partial class Form_SpotoMasterRace : Form
    {
        private List<string> stringCollection;
        private List<double> doubleCollection;

        public Form_SpotoMasterRace()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberGroupSeparator = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            //making things work like:
            //numbers are expressed with this notation: X.Y where X is the integer part and Y is the decimal part (if present), no group separator
            //examples: 100000000.00001     101  1.1     1.123   11111.1     0.1
        }

        #region Misc

        private string GetCollectionType(string commaSeparatedValues)
        {
            try
            {
                //try creating a collection at nominal level
                commaSeparatedValues = commaSeparatedValues.Replace(" ", "");
                stringCollection = new List<string>(commaSeparatedValues.Split(new char[] { ',' }));
            }
            catch
            { return "error"; }
            try
            {
                doubleCollection = new List<double>();
                //try creating a collection at at a higher level
                commaSeparatedValues = commaSeparatedValues.Replace(" ", "");
                string[] commaSeparatedValuesArray = commaSeparatedValues.Split(new char[] { ',' });
                string[] dividedNumbers = new string[2];
                foreach (string item in commaSeparatedValuesArray)
                    doubleCollection.Add(Convert.ToDouble(item));
                return "double";
            }
            catch
            { return "string"; }
        }

        private void button_CheckData_Click(object sender, EventArgs e)
        {
            string commaSeparatedValues = textBox_Collection.Text;
            string result = GetCollectionType(commaSeparatedValues);
            if (result == "error")
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (result == "string")
                    MessageBox.Show("Data valid only at NOMINAL level.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    if (result == "double")
                        MessageBox.Show("Data validity DEPENDS on the exercise.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Unexpected Error.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void numericUpDown_XPercentage_ValueChanged(object sender, EventArgs e)
        { button_XPercentage.Text = numericUpDown_XPercentage.Value + "° Percentage"; }

        #endregion Misc

        #region Descriptive Statistics

        #region Nominal

        private void button_Mode_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) != "error")
            {
                string mode = "";
                foreach (string item in Class_SpotoMasterRace.Mode(stringCollection))
                    mode += item + " ";
                richTextBox_Results.AppendText("Mode: " + mode + "\n\n");
            }
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_NumberOfEquivalentClasses_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) != "error")
                richTextBox_Results.AppendText("Number of equivalent classes: " + Class_SpotoMasterRace.NumberOfEquivalentClasses(stringCollection) + "\n\n");
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        #endregion Nominal

        #region Ordinal

        private void button_SortData_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string sortedData = "";
                doubleCollection.Sort();
                foreach (double item in doubleCollection)
                    sortedData += item.ToString() + ",";
                sortedData = sortedData.Remove(sortedData.Length - 1);
                textBox_Collection.Text = sortedData;
                richTextBox_Results.AppendText("Sorted data: " + sortedData + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_Proportions_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string proportions = "";
                foreach (KeyValuePair<double, double> item in Class_SpotoMasterRace.Proportions(doubleCollection))
                    proportions += item.Key + " => " + item.Value + "\n";
                richTextBox_Results.AppendText("Proportions: " + proportions + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_ProportionsPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string proportionsPercentage = "";
                foreach (KeyValuePair<double, double> item in Class_SpotoMasterRace.ProportionsPercentages(doubleCollection))
                    proportionsPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_Results.AppendText("Proportions %: " + proportionsPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_CumulativeFrequencies_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string cumulativeFrequencies = "";
                foreach (KeyValuePair<double, int> item in Class_SpotoMasterRace.CumulativeFrequencies(doubleCollection))
                    cumulativeFrequencies += item.Key + " => " + item.Value + "\n";
                richTextBox_Results.AppendText("Cumulative Frequencies: " + cumulativeFrequencies + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_CumulativeFrequenciesPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string cumulativeFrequenciesPercentage = "";
                foreach (KeyValuePair<double, double> item in Class_SpotoMasterRace.CumulativeFrequenciesPercentages(doubleCollection))
                    cumulativeFrequenciesPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_Results.AppendText("Cumulative Frequencies %: " + cumulativeFrequenciesPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_MedianOrdinal_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string medianOrdinal = "";
                foreach (double item in Class_SpotoMasterRace.MedianOrdinal(doubleCollection))
                    medianOrdinal += item + " ";
                richTextBox_Results.AppendText("Median Ordinal: " + medianOrdinal + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_Quartiles_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                string quartiles = "";
                foreach (double item in Class_SpotoMasterRace.Quartiles(doubleCollection))
                    quartiles += item + " ";
                richTextBox_Results.AppendText("Quartiles: " + quartiles + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_XPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText(numericUpDown_XPercentage.Value + "° Percentage: " + Class_SpotoMasterRace.XPercentile(doubleCollection, Convert.ToInt16(numericUpDown_XPercentage.Value)) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_PercentileRank_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumOrdinal.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_Results.AppendText("Percentile Rank of " + Convert.ToDouble(textBox_DatumOrdinal.Text) + ": " + Class_SpotoMasterRace.PercentileRank(doubleCollection, Convert.ToDouble(textBox_DatumOrdinal.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        #endregion Ordinal

        #region Interval/Ratio

        private void button_Mean_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Mean: " + Class_SpotoMasterRace.Mean(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_MedianInterval_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Median Interval: " + Class_SpotoMasterRace.MedianInterval(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_Range_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Range: " + Class_SpotoMasterRace.Range(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_InterquartileDifference_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Interquartile Difference: " + Class_SpotoMasterRace.InterquartileDifference(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_Deviance_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Deviance: " + Class_SpotoMasterRace.Deviance(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_VariancePopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Variance (Population): " + Class_SpotoMasterRace.VariancePopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_VarianceSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Variance (Sample): " + Class_SpotoMasterRace.VarianceSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_StandardDeviationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Standard Deviation (Population): " + Class_SpotoMasterRace.StandardDeviationPopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_StandardDeviationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Standard Deviation (Sample): " + Class_SpotoMasterRace.StandardDeviationSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_CoefficientOfVariationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Coefficient of Variation (Population): " + Class_SpotoMasterRace.CoefficientOfVariationPopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_CoefficientOfVariationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
                richTextBox_Results.AppendText("Coefficient of Variation (Sample): " + Class_SpotoMasterRace.CoefficientOfVariationSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_ZScorePopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_Results.AppendText("ZScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + " (Population): " + Class_SpotoMasterRace.ZScorePopulation(doubleCollection, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_ZScoreSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_Results.AppendText("ZScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + " (Sample): " + Class_SpotoMasterRace.ZScoreSample(doubleCollection, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_TScorePopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_Results.AppendText("TScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + " (Population): " + Class_SpotoMasterRace.TScorePopulation(doubleCollection, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        private void button_TScoreSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_Collection.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_Results.AppendText("TScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + " (Sample): " + Class_SpotoMasterRace.TScoreSample(doubleCollection, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Results.ScrollToCaret();
        }

        #endregion Interval/Ratio

        #endregion Descriptive Statistics
    }
}