using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpotoMasterRace
{
    public partial class FormSpotoMasterRace : Form
    {
        /*TODO:
         * Sets list of SetTheory in Probability Theory?
         * Avoid Duplicates in Probability Theory (it's a non-ordered set)
         * GetFrequency<T>(BindingList<StructSet<T>> collection, StructSet<T> item) check if list A contains at least one of the elements of B
         */

        private bool showHelp = true;
        private char actualSetName;
        private char nextSetName;
        private int selectedSetIndex;
        private int selectedElementIndex;
        private BindingList<StructSet<string>> sets;
        private StructSet<string> tempSet;
        private StructSet<StructSet<string>> probabilityTempSet;
        private StructSet<string> emptySet = new StructSet<string>('@', new BindingList<string>(), false);
        private List<string> stringCollection;
        private List<double> doubleCollection;

        public FormSpotoMasterRace()
        {
            InitializeComponent();

            this.MinimumSize = new Size(800, 600);
            this.Size = new Size(800, 600);

            //remove this if debugging
            tabControl_SpotoMasterRace.TabPages.Remove(tabPage_ProbabilityTheory);

            #region Number representation

            //making things work like:
            //numbers are expressed with this notation: X.Y where X is the integer part and Y is the decimal part (if present), no group separator
            //examples: 100000000.00001     101  1.1     1.123   11111.1     0.1
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberGroupSeparator = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            #endregion Number representation

            #region Set Theory

            nextSetName = 'A';
            actualSetName = 'A';
            selectedSetIndex = 0;
            selectedElementIndex = 0;
            sets = new BindingList<StructSet<string>>();
            probabilityTempSet = new StructSet<StructSet<string>>('E');
            tempSet = new StructSet<string>(nextSetName);
            listBox_Sets.DataSource = sets;
            listBox_Set1.DataSource = sets;
            listBox_Elements.DataSource = tempSet.Elements;
            nextSetName++;

            #endregion Set Theory
        }

        #region Global Misc

        private void tabControl_SpotoMasterRace_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Name)
            {
                case "tabPage_SetTheory":
                    {
                        this.MinimumSize = new Size(800, 600);
                        this.Size = new Size(800, 600);
                        break;
                    }
                case "tabPage_DescriptiveStatistics":
                    {
                        this.MinimumSize = new Size(594, 531);
                        this.Size = new Size(594, 531);
                        break;
                    }
                case "tabPage_Combinatorics":
                    {
                        this.MinimumSize = new Size(594, 353);
                        this.Size = new Size(594, 353);
                        break;
                    }
                default: break;
            }
        }

        private void checkBox_ShowHelp_CheckedChanged(object sender, EventArgs e)
        { showHelp = checkBox_ShowHelp.Checked; }

        private void HelpMessages(string formControl)
        {
            if (showHelp)
                switch (formControl)
                { }
        }

        #endregion Global Misc

        #region Set Theory

        #region Misc

        private void checkBox_FlagOrdered_CheckedChanged(object sender, EventArgs e)
        {
            tempSet.Ordered = checkBox_FlagOrdered.Checked;
            if (!checkBox_FlagOrdered.Checked)
                tempSet.Elements = ClassSpotoMasterRace.RemoveDuplicates(tempSet.Elements);
            for (int i = 0; i < sets.Count; i++)
            {
                if (sets[i].Name == tempSet.Name)
                    sets[i] = new StructSet<string>(tempSet);
            }
            listBox_Elements.DataSource = tempSet.Elements;
            Update_TempSet_Listboxes();
        }

        private void Update_TempSet_Listboxes()
        {
            //update current set
            try
            {
                string strElements = "";
                if (tempSet.Cardinality != 0)
                {
                    foreach (string item in tempSet.Elements)
                        strElements += item + ",";
                    //remove comma and whitespace
                    strElements = strElements.Remove(strElements.Length - 1);
                }
                textBox_CurrentSet.Text = actualSetName + " = " + (checkBox_FlagOrdered.Checked ? "( " : "{ ") + strElements + (checkBox_FlagOrdered.Checked ? " )" : " }");
                label_Cardinality.Text = "Cardinality: " + tempSet.Cardinality;
            }
            catch
            { textBox_CurrentSet.Text = ""; }
            //update listboxes
            try
            {
                if (sets.Count != 0)
                {
                    listBox_Sets.Update();
                    List<string> tmp = new List<string>();
                    foreach (StructSet<string> item in sets)
                        tmp.Add(item.Name.ToString());

                    int old1_index = listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0;
                    int old2_index = listBox_Set2.SelectedIndex >= 0 ? listBox_Set2.SelectedIndex : 0;
                    listBox_Set1.DataSource = new BindingList<string>(tmp);
                    listBox_Set2.DataSource = new BindingList<string>(tmp);
                    listBox_Set1.SelectedIndex = old1_index;
                    listBox_Set2.SelectedIndex = old2_index;

                    //update the bindings
                    sets.Add(emptySet);
                    sets.RemoveAt(sets.Count - 1);
                }
                else
                {
                    listBox_Set1.DataSource = new BindingList<string>(new List<string>());
                    listBox_Set2.DataSource = new BindingList<string>(new List<string>());
                }
            }
            catch
            {
                listBox_Set1.DataSource = new BindingList<string>(new List<string>());
                listBox_Set2.DataSource = new BindingList<string>(new List<string>());
            }
        }

        private void listBox_Sets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedSetIndex = listBox_Sets.SelectedIndex;
                tempSet = sets[selectedSetIndex];
                listBox_Elements.DataSource = tempSet.Elements;
                actualSetName = tempSet.Name;
                checkBox_FlagOrdered.Checked = tempSet.Ordered;
            }
            catch
            { }
            Update_TempSet_Listboxes();
        }

        private void listBox_Elements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedElementIndex = listBox_Elements.SelectedIndex;
                textBox_Element.Text = listBox_Elements.SelectedItem.ToString();
            }
            catch
            { }
            Update_TempSet_Listboxes();
        }

        private bool CheckIfSelectedSets()
        {
            if (listBox_Set1.SelectedIndex >= 0 && listBox_Set2.SelectedIndex >= 0)
                return true;
            return false;
        }

        #endregion Misc

        #region Elements Management

        private void button_InsertElement_Click(object sender, EventArgs e)
        {
            string element = textBox_Element.Text == "" ? "{}" : textBox_Element.Text;
            if (!tempSet.Ordered)
            {
                //not ordered set
                if (!tempSet.Elements.Contains(element))
                    //element is not present => add it
                    tempSet.Elements.Add(element);
                else
                    MessageBox.Show("Can't add an element that is already present in the set.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                tempSet.Elements.Add(element);
            Update_TempSet_Listboxes();
        }

        private void textBox_Element_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_InsertElement_Click(sender, new EventArgs());
                textBox_Element.Text = "";
            }
        }

        private void button_DeleteElement_Click(object sender, EventArgs e)
        {
            try
            { tempSet.Elements.Remove(listBox_Elements.Items[selectedElementIndex].ToString()); }
            catch
            { }
            Update_TempSet_Listboxes();
        }

        private void listBox_Elements_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button_DeleteElement_Click(sender, new EventArgs());
            else if (e.Control && e.KeyCode == Keys.C)
                button_InsertElement_Click(sender, new EventArgs());
        }

        #endregion Elements Management

        #region Sets Management

        private void button_NewSet_Click(object sender, EventArgs e)
        {
            nextSetName = sets.Count > 0 ? sets[sets.Count - 1].Name : '@'; //'@' is the character before 'A'
            nextSetName++;
            tempSet = new StructSet<string>(nextSetName, new BindingList<string>(), checkBox_FlagOrdered.Checked);
            listBox_Elements.DataSource = tempSet.Elements;
            actualSetName = tempSet.Name;
            Update_TempSet_Listboxes();
        }

        private void button_AddSet_Click(object sender, EventArgs e)
        {
            tempSet.Ordered = checkBox_FlagOrdered.Checked;
            for (int i = 0; i < sets.Count; i++)
                if (sets[i].Name == tempSet.Name)
                {
                    MessageBox.Show("This action is not allowed, use the \"Copy\" function.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //new set
                    button_NewSet_Click(sender, e);
                    return;
                }
            sets.Add(new StructSet<string>(tempSet));
            //new set
            button_NewSet_Click(sender, e);
        }

        private void button_DeleteSet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sets.Count; i++)
                if (sets[i].Name == tempSet.Name)
                    sets.Remove(sets[i]);
            //new set
            button_NewSet_Click(sender, e);
        }

        private void listBox_Sets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button_DeleteSet_Click(sender, new EventArgs());
            else if (e.Control && e.KeyCode == Keys.C)
                button_CopySet_Click(sender, new EventArgs());
        }

        private void button_CopySet_Click(object sender, EventArgs e)
        {
            button_NewSet_Click(sender, e);
            if (sets.Count > 0)
                foreach (string item in sets[selectedSetIndex].Elements)
                    tempSet.Elements.Add(item);
            Update_TempSet_Listboxes();
        }

        #endregion Sets Management

        #region Set Operations

        private void button_SetEquality_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                    textBox_CurrentSet.Text = set1.Name + " = " + set2.Name + ": " + ClassSpotoMasterRace.Equality(set1, set2).ToString();
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_SetSubset_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                    textBox_CurrentSet.Text = set1.Name + " ⊆ " + set2.Name + ": " + ClassSpotoMasterRace.Inclusion(set1, set2, false).ToString();
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_SetProperSubset_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                    textBox_CurrentSet.Text = set1.Name + " ⊂ " + set2.Name + ": " + ClassSpotoMasterRace.Inclusion(set1, set2, true).ToString();
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_PowerSet_Click(object sender, EventArgs e)
        {
            //new set
            button_NewSet_Click(sender, e);
            if (sets.Count > 0)
            {
                if (!sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Ordered)
                {
                    bool proceed = true;
                    if (Math.Pow(2.0, sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality) >= 4096)
                        proceed = MessageBox.Show("I need to calculate " + Math.Pow(2.0, sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality) + " (2^" + sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality + ") elements.\nThis can take a lot, do you really want to proceed?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                    if (proceed)
                    {
                        tempSet.Elements = ClassSpotoMasterRace.PowerSet(sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0]);
                        tempSet.Sort();
                    }
                }
                else
                    MessageBox.Show("You must choose an unordered set from the list on the left of the buttons.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Update_TempSet_Listboxes();
        }

        private void button_SetUnion_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                {
                    //new set
                    button_NewSet_Click(sender, e);
                    tempSet.Elements = ClassSpotoMasterRace.Union(set1, set2);
                }
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Update_TempSet_Listboxes();
        }

        private void button_SetIntersection_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                {
                    //new set
                    button_NewSet_Click(sender, e);
                    tempSet.Elements = ClassSpotoMasterRace.Intersection(set1, set2);
                }
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Update_TempSet_Listboxes();
        }

        private void button_SetDifference_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                {
                    //new set
                    button_NewSet_Click(sender, e);
                    tempSet = new StructSet<string>(nextSetName, ClassSpotoMasterRace.Difference(set1, set2), set1.Ordered);
                }
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Update_TempSet_Listboxes();
        }

        private void button_SetSymmetricDifference_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                {
                    //new set
                    button_NewSet_Click(sender, e);
                    tempSet.Elements = ClassSpotoMasterRace.Union(new StructSet<string>('A', ClassSpotoMasterRace.Difference(set1, set2), set1.Ordered), new StructSet<string>('A', ClassSpotoMasterRace.Difference(set2, set1), set1.Ordered));
                }
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Update_TempSet_Listboxes();
        }

        private void button_CartesianProduct_Click(object sender, EventArgs e)
        {
            if (CheckIfSelectedSets())
            {
                StructSet<string> set1 = sets[listBox_Set1.SelectedIndex];
                StructSet<string> set2 = sets[listBox_Set2.SelectedIndex];
                if (set1.Ordered == set2.Ordered && !set1.Ordered)
                {
                    button_NewSet_Click(sender, e);
                    tempSet.Elements = ClassSpotoMasterRace.CartesianProduct(set1, set2);
                }
                else
                    MessageBox.Show("You must choose 2 unordered sets from the 2 lists near the button.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must choose 2 sets from the 2 lists near the button.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Update_TempSet_Listboxes();
        }

        #endregion Set Operations

        #endregion Set Theory

        #region Descriptive Statistics

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

        private void button_CheckDataDescriptiveStatistics_Click(object sender, EventArgs e)
        {
            string commaSeparatedValues = textBox_CollectionDescriptiveStatistics.Text;
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
        { button_XPercentile.Text = numericUpDown_XPercentile.Value + "° Percentage"; }

        #endregion Misc

        #region Nominal

        private void button_Mode_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) != "error")
            {
                string mode = "";
                foreach (string item in ClassSpotoMasterRace.Mode(stringCollection))
                    mode += item + " ";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Mode: " + mode + "\n\n");
            }
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_NumberOfEquivalentClasses_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) != "error")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Number of equivalent classes: " + ClassSpotoMasterRace.NumberOfEquivalentClasses(stringCollection) + "\n\n");
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        #endregion Nominal

        #region Ordinal

        private void button_SortData_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string sortedData = "";
                doubleCollection.Sort();
                foreach (double item in doubleCollection)
                    sortedData += item.ToString() + ",";
                sortedData = sortedData.Remove(sortedData.Length - 1);
                textBox_CollectionDescriptiveStatistics.Text = sortedData;
                richTextBox_ResultsDescriptiveStatistics.AppendText("Sorted data: " + sortedData + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_Proportions_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string proportions = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.Proportions(doubleCollection))
                    proportions += item.Key + " => " + item.Value + "\n";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Proportions: " + proportions + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_ProportionsPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string proportionsPercentage = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.ProportionsPercentages(doubleCollection))
                    proportionsPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Proportions %: " + proportionsPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_CumulativeFrequencies_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string cumulativeFrequencies = "";
                foreach (KeyValuePair<double, int> item in ClassSpotoMasterRace.CumulativeFrequencies(doubleCollection))
                    cumulativeFrequencies += item.Key + " => " + item.Value + "\n";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Cumulative Frequencies: " + cumulativeFrequencies + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_CumulativeFrequenciesPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string cumulativeFrequenciesPercentage = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.CumulativeFrequenciesPercentages(doubleCollection))
                    cumulativeFrequenciesPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Cumulative Frequencies %: " + cumulativeFrequenciesPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_MedianOrdinal_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string medianOrdinal = "";
                foreach (double item in ClassSpotoMasterRace.MedianOrdinal(doubleCollection))
                    medianOrdinal += item + " ";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Median Ordinal: " + medianOrdinal + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_Quartiles_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string quartiles = "";
                foreach (double item in ClassSpotoMasterRace.Quartiles(doubleCollection))
                    quartiles += item + " ";
                richTextBox_ResultsDescriptiveStatistics.AppendText("Quartiles: " + quartiles + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_XPercentile_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText(numericUpDown_XPercentile.Value + "° Percentile: " + ClassSpotoMasterRace.XPercentile(doubleCollection, Convert.ToInt16(numericUpDown_XPercentile.Value)) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_PercentileRank_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumOrdinal.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_ResultsDescriptiveStatistics.AppendText("Percentile Rank of " + Convert.ToDouble(textBox_DatumOrdinal.Text) + ": " + ClassSpotoMasterRace.PercentileRank(doubleCollection, Convert.ToDouble(textBox_DatumOrdinal.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        #endregion Ordinal

        #region Interval/Ratio

        private void button_Mean_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Mean: " + ClassSpotoMasterRace.Mean(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_MedianInterval_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Median Interval: " + ClassSpotoMasterRace.MedianInterval(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_Range_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Range: " + ClassSpotoMasterRace.Range(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_InterquartileDifference_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Interquartile Difference: " + ClassSpotoMasterRace.InterquartileDifference(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_Deviance_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Deviance: " + ClassSpotoMasterRace.Deviance(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_VariancePopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Variance (Population): " + ClassSpotoMasterRace.VariancePopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_VarianceSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Variance (Sample): " + ClassSpotoMasterRace.VarianceSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_StandardDeviationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Standard Deviation (Population): " + ClassSpotoMasterRace.StandardDeviationPopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_StandardDeviationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Standard Deviation (Sample): " + ClassSpotoMasterRace.StandardDeviationSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_CoefficientOfVariationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Coefficient of Variation (Population): " + ClassSpotoMasterRace.CoefficientOfVariationPopulation(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_CoefficientOfVariationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_ResultsDescriptiveStatistics.AppendText("Coefficient of Variation (Sample): " + ClassSpotoMasterRace.CoefficientOfVariationSample(doubleCollection) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_ZScore_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_ResultsDescriptiveStatistics.AppendText("ZScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + ": " + ClassSpotoMasterRace.ZScore(doubleCollection, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        private void button_TScore_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                try
                {
                    Convert.ToDouble(textBox_ZScoreIntervalRatio.Text);
                    Convert.ToDouble(textBox_MeanIntervalRatio.Text);
                    Convert.ToDouble(textBox_StandardDeviationIntervalRatio.Text);
                }
                catch
                {
                    MessageBox.Show("Need ZScore, Mean and Standard Deviation with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_ResultsDescriptiveStatistics.AppendText("TScore of a DATUM with ZScore = " + Convert.ToDouble(textBox_ZScoreIntervalRatio.Text) + " and Mean = " + Convert.ToDouble(textBox_MeanIntervalRatio.Text) + " and Standard Deviation = " + Convert.ToDouble(textBox_StandardDeviationIntervalRatio.Text) + ": " + ClassSpotoMasterRace.TScore(Convert.ToDouble(textBox_ZScoreIntervalRatio.Text), Convert.ToDouble(textBox_MeanIntervalRatio.Text), Convert.ToDouble(textBox_StandardDeviationIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsDescriptiveStatistics.ScrollToCaret();
        }

        #endregion Interval/Ratio

        #endregion Descriptive Statistics

        #region Combinatorics

        #region Misc

        private void numericUpDown_CombinatoricsK_ValueChanged(object sender, EventArgs e)
        {
            button_PermutationsWithoutRepetitions.Text = numericUpDown_CombinatoricsK.Value + "-Permutations WITHOUT Repetitions";
            button_PermutationsWithRepetitions.Text = numericUpDown_CombinatoricsK.Value + "-Permutations WITH Repetitions";
            button_CombinationsWithoutRepetitions.Text = numericUpDown_CombinatoricsK.Value + "-Combinations WITHOUT Repetitions";
            button_CombinationsWithRepetitions.Text = numericUpDown_CombinatoricsK.Value + "-Combinations WITH Repetitions";
        }

        private void numericUpDown_CombinatoricsN_ValueChanged(object sender, EventArgs e)
        { numericUpDown_CombinatoricsK.Value = numericUpDown_CombinatoricsN.Value; }

        #endregion Misc

        private void button_PermutationsWithoutRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            if (k <= n)
                richTextBox_ResultsCombinatorics.AppendText(k + "-Permutations WITHOUT Repetitions of " + n + " elements: " + ClassSpotoMasterRace.FactorialOf(n) / ClassSpotoMasterRace.FactorialOf(Convert.ToInt16(n - k)) + "\n\n");
            else
                MessageBox.Show("K can't be higher than N.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsCombinatorics.ScrollToCaret();
        }

        private void button_PermutationsWithRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            richTextBox_ResultsCombinatorics.AppendText(k + "-Permutations WITH Repetitions of " + n + " elements: " + Math.Pow(n, k) + "\n\n");
            richTextBox_ResultsCombinatorics.ScrollToCaret();
        }

        private void button_CombinationsWithoutRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            if (k <= n)
                richTextBox_ResultsCombinatorics.AppendText(k + "-Combinations WITHOUT Repetitions of " + n + " elements: " + ClassSpotoMasterRace.BinomialCoefficient(n, k) + "\n\n");
            else
                MessageBox.Show("K can't be higher than N.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_ResultsCombinatorics.ScrollToCaret();
        }

        private void button_CombinationsWithRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            richTextBox_ResultsCombinatorics.AppendText(k + "-Combinations WITH Repetitions of " + n + " elements: " + ClassSpotoMasterRace.BinomialCoefficient(Convert.ToInt16(n + k - 1), k) + "\n\n");
            richTextBox_ResultsCombinatorics.ScrollToCaret();
        }

        #endregion Combinatorics

        #region Probability Theory

        #region Misc

        private void textBox_OutcomeSpace_TextChanged(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_OutcomeSpace.Text) != "error")
            {
                BindingList<StructSet<string>> collection = new BindingList<StructSet<string>>();
                foreach (string item in stringCollection)
                {
                    BindingList<string> temp = new BindingList<string>();
                    temp.Add(item);
                    collection.Add(new StructSet<string>('X', temp));
                }
                probabilityTempSet.Elements = collection;
            }
            label_CardinalityOutcomeSpace.Text = "|Ω| = " + probabilityTempSet.Cardinality.ToString();
            label_CardinalitySpaceOfEvents.Text = "|ε| = " + Math.Pow(2.0, probabilityTempSet.Cardinality).ToString();
        }

        private void listBox_SpaceOfEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ClassSpotoMasterRace.GetFrequency(probabilityTempSet.Elements, ((StructSet<string>)listBox_SpaceOfEvents.SelectedItem));
            if (((StructSet<string>)listBox_SpaceOfEvents.SelectedItem).Elements.Count == 0)
                i = 0;
            label_ProbabilityOfX.Text = "Probability of " + probabilityTempSet.Elements[listBox_SpaceOfEvents.SelectedIndex] + " = " + i + "/" + probabilityTempSet.Cardinality;
        }

        #endregion Misc

        private void button_SpaceOfEvents_Click(object sender, EventArgs e)
        {
            if (GetCollectionType(textBox_OutcomeSpace.Text) != "error")
            {
                bool proceed = true;
                if (Math.Pow(2.0, probabilityTempSet.Cardinality) >= 4096)
                    proceed = MessageBox.Show("I need to calculate " + Math.Pow(2.0, probabilityTempSet.Cardinality) + " (2^" + probabilityTempSet.Cardinality + ") elements.\nThis can take a lot, do you really want to proceed?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                if (proceed)
                {
                    probabilityTempSet.Elements = ClassSpotoMasterRace.PowerSet<string>(new StructSet<string>('E', new BindingList<string>(stringCollection), false));
                    probabilityTempSet.Sort();
                    listBox_SpaceOfEvents.DataSource = probabilityTempSet.Elements;
                }
            }
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Probability Theory
    }
}