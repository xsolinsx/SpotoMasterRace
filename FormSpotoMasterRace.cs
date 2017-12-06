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
         * Parametric distributions
         */

        #region Common

        private Pen functionPen;
        private Pen axisPen;
        private double XFMIN = -1;
        private double XFMAX = 1;
        private double YFMIN = -1;
        private double YFMAX = 1;

        #endregion Common

        #region Set Theory

        private bool showHelp = true;
        private char actualSetName;
        private char nextSetName;
        private int selectedSetIndex;
        private int selectedElementIndex;
        private BindingList<StructSet<string>> sets;
        private StructSet<string> tempSetSetTheory;
        private StructSet<string> emptySet = new StructSet<string>('@', new BindingList<string>(), false);

        #endregion Set Theory

        #region Descriptive Statistics

        private List<string> stringCollectionDescriptiveStatistics;
        private List<double> doubleCollectionDescriptiveStatistics;

        #endregion Descriptive Statistics

        #region Probability Theory

        private BindingList<StructSet<string>> outcomeSpaceProbabilityTheory;
        private StructSet<StructSet<string>> spaceOfEventsProbabilityTheory;

        #endregion Probability Theory

        #region Probability Distributions

        private ClassDraw viewProbabilityDistributions;
        private Graphics videoProbabilityDistributions;
        private Bitmap drawingProbabilityDistributions;
        private Graphics sheetProbabilityDistributions;
        private BindingList<StructSet<string>> outcomeSpaceProbabilityDistributions;
        private StructSet<StructSet<string>> spaceOfEventsProbabilityDistributions;

        #endregion Probability Distributions

        #region Parametric Distributions

        #region Discrete

        private ClassDraw viewDiscreteParametricDistributions;
        private Graphics videoDiscreteParametricDistributions;
        private Bitmap drawingDiscreteParametricDistributions;
        private Graphics sheetDiscreteParametricDistributions;

        #endregion Discrete

        #region Continuous

        private ClassDraw viewContinuousParametricDistributions;
        private Graphics videoContinuousParametricDistributions;
        private Bitmap drawingContinuousParametricDistributions;
        private Graphics sheetContinuousParametricDistributions;

        #endregion Continuous

        #endregion Parametric Distributions

        public FormSpotoMasterRace()
        {
            InitializeComponent();

            #region Number representation

            //making things work like:
            //numbers are expressed with this notation: X.Y where X is the integer part and Y is the decimal part (if present), no group separator
            //examples: 100000000.00001     101  1.1     1.123   11111.1     0.1
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberGroupSeparator = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            #endregion Number representation

            #region Common

            functionPen = new Pen(Color.Black, 2);
            axisPen = new Pen(Color.Black, 1);

            #endregion Common

            #region Set Theory

            nextSetName = 'A';
            actualSetName = 'A';
            selectedSetIndex = 0;
            selectedElementIndex = 0;
            sets = new BindingList<StructSet<string>>();
            tempSetSetTheory = new StructSet<string>(nextSetName);
            listBox_Sets.DataSource = sets;
            listBox_Set1.DataSource = sets;
            listBox_Elements.DataSource = tempSetSetTheory.Elements;
            nextSetName++;

            #endregion Set Theory

            #region Descriptive Statistics

            stringCollectionDescriptiveStatistics = new List<string>();
            doubleCollectionDescriptiveStatistics = new List<double>();

            #endregion Descriptive Statistics

            #region Probability Theory

            outcomeSpaceProbabilityTheory = new BindingList<StructSet<string>>();
            spaceOfEventsProbabilityTheory = new StructSet<StructSet<string>>('E');

            #endregion Probability Theory

            #region Probability Distributions

            viewProbabilityDistributions = new ClassDraw();
            videoProbabilityDistributions = panel_ProbabilityDistributions.CreateGraphics();
            drawingProbabilityDistributions = new Bitmap(panel_ProbabilityDistributions.Width, panel_ProbabilityDistributions.Height, videoProbabilityDistributions);
            sheetProbabilityDistributions = Graphics.FromImage(drawingProbabilityDistributions);

            #endregion Probability Distributions

            #region Parametric Distributions

            #region Discrete

            viewDiscreteParametricDistributions = new ClassDraw();
            videoDiscreteParametricDistributions = panel_DiscreteParametricDistributions.CreateGraphics();
            drawingDiscreteParametricDistributions = new Bitmap(panel_DiscreteParametricDistributions.Width, panel_DiscreteParametricDistributions.Height, videoDiscreteParametricDistributions);
            sheetDiscreteParametricDistributions = Graphics.FromImage(drawingDiscreteParametricDistributions);

            #endregion Discrete

            #region Continuous

            viewContinuousParametricDistributions = new ClassDraw();
            videoContinuousParametricDistributions = panel_ContinuousParametricDistributions.CreateGraphics();
            drawingContinuousParametricDistributions = new Bitmap(panel_ContinuousParametricDistributions.Width, panel_ContinuousParametricDistributions.Height, videoContinuousParametricDistributions);
            sheetContinuousParametricDistributions = Graphics.FromImage(drawingContinuousParametricDistributions);

            #endregion Continuous

            #endregion Parametric Distributions

            tabControl_ParametricDistributions.TabPages.Remove(tabPage_ContinuousParametricDistributions);

            MessageBox.Show("THINK and REASON about what you're doing.\nThis is just meant to help, not to do the exam for you.\nI'm not responsible for your grade, it doesn't matter if it is good or bad.", "DISCLAIMER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        this.MinimumSize = new Size(600, 600);
                        this.Size = new Size(600, 600);
                        break;
                    }
                case "tabPage_Combinatorics":
                    {
                        this.MinimumSize = new Size(600, 400);
                        this.Size = new Size(600, 400);
                        break;
                    }
                case "tabPage_ProbabilityTheory":
                    {
                        this.MinimumSize = new Size(700, 300);
                        this.Size = new Size(700, 300);
                        break;
                    }
                case "tabPage_ProbabilityDistributions":
                    {
                        button_ResetProbabilityDistributions_Click(sender, e);
                        this.MinimumSize = new Size(550, 600);
                        this.Size = new Size(550, 600);
                        break;
                    }
                case "tabPage_ParametricDistributions":
                    {
                        button_ResetDiscreteParametricDistributions_Click(sender, e);
                        button_ResetContinuousParametricDistributions_Click(sender, e);
                        this.MinimumSize = new Size(800, 600);
                        this.Size = new Size(800, 600);
                        break;
                    }
                default: break;
            }
        }

        private List<string> InitializeStringCollection(string commaSeparatedValues)
        {
            try
            { return new List<string>(commaSeparatedValues.Replace(" ", "").Split(',')); }
            catch
            { return null; }
        }

        private List<double> InitializeDoubleCollection(List<string> collection)
        {
            try
            {
                List<double> doubleCollection = new List<double>();
                //try creating a collection at at a higher level
                foreach (string item in collection)
                    doubleCollection.Add(Convert.ToDouble(item));
                return doubleCollection;
            }
            catch
            { return null; }
        }

        private void checkBox_ShowHelp_CheckedChanged(object sender, EventArgs e)
        { showHelp = checkBox_ShowHelp.Checked; }

        private void HelpMessages(string formControl)
        {
            if (showHelp)
                switch (formControl)
                { }
        }

        private void DrawAxes(Graphics sheet, ClassDraw view)
        {
            int xVideoZero = view.XVideo(0);
            int yVideoZero = view.YVideo(0);
            sheet.DrawLine(axisPen, view.XVideo(view.xFoglioMin), yVideoZero, view.XVideo(view.xFoglioMax), yVideoZero);
            sheet.DrawLine(axisPen, xVideoZero, view.YVideo(view.yFoglioMin), xVideoZero, view.YVideo(view.yFoglioMax));
        }

        private void DrawCoordinates(Graphics video, ClassDraw view, double[] probabilities = null)
        {
            double x = 0;
            double y = 0;

            video.DrawString("0", FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo(0), view.YVideo((view.yFoglioMin + view.yFoglioMax) / 2)));
            video.DrawString("0", FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo((view.xFoglioMin + view.xFoglioMax) / 2), view.YVideo(0)));

            do
            {
                x++;
                string xs = x.ToString();
                //video.DrawString("-" + xs, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo(-x), view.YVideo((view.yFoglioMin + view.yFoglioMax) / 2)));
                video.DrawString(xs, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo(+x), view.YVideo((view.yFoglioMin + view.yFoglioMax) / 2)));
            }
            while (x <= view.yVideoMin);

            if (probabilities != null)
            {
                for (int i = 0; i < probabilities.Length; i++)
                {
                    y = probabilities[i];
                    if (y != 0)
                    {
                        string ys = y.ToString();
                        //video.DrawString("-" + ys, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo((view.xFoglioMin + view.xFoglioMax) / 2), view.YVideo(-y)));
                        video.DrawString(ys, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo((view.xFoglioMin + view.xFoglioMax) / 2), view.YVideo(+y)));
                    }
                }
            }
            else
            {
                do
                {
                    y++;
                    string ys = y.ToString();
                    //video.DrawString("-" + ys, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo((view.xFoglioMin + view.xFoglioMax) / 2), view.YVideo(-y)));
                    video.DrawString(ys, FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), new Point(view.XVideo((view.xFoglioMin + view.xFoglioMax) / 2), view.YVideo(+y)));
                }
                while (y <= view.xVideoMax);
            }
        }

        private void FixView(ClassDraw view, Panel panel, Graphics sheet, double xfmin = -1, double xfmax = 1, double yfmin = -1, double yfmax = 1)
        {
            XFMIN = xfmin;
            XFMAX = xfmax;
            YFMIN = yfmin;
            YFMAX = yfmax;
            view.xFoglioMin = XFMIN;
            view.xFoglioMax = XFMAX;
            view.yFoglioMin = YFMIN;
            view.yFoglioMax = YFMAX;
            view.xVideoMin = 0;
            view.xVideoMax = panel.Width;
            view.yVideoMin = panel.Height;
            view.yVideoMax = 0;
            sheet.Clear(Form.DefaultBackColor);
        }

        private void FormSpotoMasterRace_SizeChanged(object sender, EventArgs e)
        {
            button_ResetProbabilityDistributions_Click(sender, e);
            button_ResetDiscreteParametricDistributions_Click(sender, e);
            button_ResetContinuousParametricDistributions_Click(sender, e);
        }

        #endregion Global Misc

        #region Set Theory

        #region Misc

        private void checkBox_FlagOrdered_CheckedChanged(object sender, EventArgs e)
        {
            tempSetSetTheory.Ordered = checkBox_FlagOrdered.Checked;
            if (!checkBox_FlagOrdered.Checked)
                tempSetSetTheory.Elements = ClassSpotoMasterRace.RemoveDuplicates(tempSetSetTheory.Elements);
            for (int i = 0; i < sets.Count; i++)
            {
                if (sets[i].Name == tempSetSetTheory.Name)
                    sets[i] = new StructSet<string>(tempSetSetTheory);
            }
            listBox_Elements.DataSource = tempSetSetTheory.Elements;
            Update_TempSet_Listboxes();
        }

        private void Update_TempSet_Listboxes()
        {
            //update current set
            try
            {
                string strElements = "";
                if (tempSetSetTheory.Cardinality != 0)
                {
                    foreach (string item in tempSetSetTheory.Elements)
                        strElements += item + ",";
                    //remove comma
                    strElements = strElements.Remove(strElements.Length - 1);
                }
                textBox_CurrentSet.Text = actualSetName + " = " + (checkBox_FlagOrdered.Checked ? "( " : "{ ") + strElements + (checkBox_FlagOrdered.Checked ? " )" : " }");
                label_Cardinality.Text = "Cardinality: " + tempSetSetTheory.Cardinality;
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
                tempSetSetTheory = sets[selectedSetIndex];
                listBox_Elements.DataSource = tempSetSetTheory.Elements;
                actualSetName = tempSetSetTheory.Name;
                checkBox_FlagOrdered.Checked = tempSetSetTheory.Ordered;
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
            if (!tempSetSetTheory.Ordered)
            {
                //not ordered set
                if (!tempSetSetTheory.Elements.Contains(element))
                    //element is not present => add it
                    tempSetSetTheory.Elements.Add(element);
                else
                    MessageBox.Show("Can't add an element that is already present in the set.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                tempSetSetTheory.Elements.Add(element);
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
            { tempSetSetTheory.Elements.Remove(listBox_Elements.Items[selectedElementIndex].ToString()); }
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
            tempSetSetTheory = new StructSet<string>(nextSetName, new BindingList<string>(), checkBox_FlagOrdered.Checked);
            listBox_Elements.DataSource = tempSetSetTheory.Elements;
            actualSetName = tempSetSetTheory.Name;
            Update_TempSet_Listboxes();
        }

        private void button_AddSet_Click(object sender, EventArgs e)
        {
            tempSetSetTheory.Ordered = checkBox_FlagOrdered.Checked;
            for (int i = 0; i < sets.Count; i++)
                if (sets[i].Name == tempSetSetTheory.Name)
                {
                    MessageBox.Show("This action is not allowed, use the \"Copy\" function.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //new set
                    button_NewSet_Click(sender, e);
                    return;
                }
            sets.Add(new StructSet<string>(tempSetSetTheory));
            //new set
            button_NewSet_Click(sender, e);
        }

        private void button_DeleteSet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sets.Count; i++)
                if (sets[i].Name == tempSetSetTheory.Name)
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
                    tempSetSetTheory.Elements.Add(item);
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
                if (!sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Ordered)
                {
                    bool proceed = true;
                    if (Math.Pow(2.0, sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality) >= 4096)
                        proceed = MessageBox.Show("I need to calculate " + Math.Pow(2.0, sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality) + " (2^" + sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0].Cardinality + ") elements.\nThis can take a lot, do you really want to proceed?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                    if (proceed)
                    {
                        tempSetSetTheory.Elements = ClassSpotoMasterRace.PowerSet(sets[listBox_Set1.SelectedIndex >= 0 ? listBox_Set1.SelectedIndex : 0]);
                        tempSetSetTheory.Sort();
                    }
                }
                else
                    MessageBox.Show("You must choose an unordered set from the list on the left of the buttons.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("You must create an unordered set before doing this.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    tempSetSetTheory.Elements = ClassSpotoMasterRace.Union(set1, set2);
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
                    tempSetSetTheory.Elements = ClassSpotoMasterRace.Intersection(set1, set2);
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
                    tempSetSetTheory = new StructSet<string>(nextSetName, ClassSpotoMasterRace.Difference(set1, set2), set1.Ordered);
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
                    tempSetSetTheory.Elements = ClassSpotoMasterRace.Union(new StructSet<string>('A', ClassSpotoMasterRace.Difference(set1, set2), set1.Ordered), new StructSet<string>('A', ClassSpotoMasterRace.Difference(set2, set1), set1.Ordered));
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
                    tempSetSetTheory.Elements = ClassSpotoMasterRace.CartesianProduct(set1, set2);
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

        private string GetCollectionTypeDescriptiveStatistics(string commaSeparatedValues)
        {
            //try creating a collection at nominal level
            stringCollectionDescriptiveStatistics = InitializeStringCollection(commaSeparatedValues);
            if (stringCollectionDescriptiveStatistics == null)
                return "error";
            else
            {
                //try creating a collection at at a higher level
                doubleCollectionDescriptiveStatistics = InitializeDoubleCollection(stringCollectionDescriptiveStatistics);
                if (doubleCollectionDescriptiveStatistics == null)
                    return "string";
                else
                    return "double";
            }
        }

        private void button_CheckDataDescriptiveStatistics_Click(object sender, EventArgs e)
        {
            string commaSeparatedValues = textBox_CollectionDescriptiveStatistics.Text;
            string result = GetCollectionTypeDescriptiveStatistics(commaSeparatedValues);
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
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) != "error")
            {
                string mode = "";
                foreach (string item in ClassSpotoMasterRace.Mode(stringCollectionDescriptiveStatistics))
                    mode += item + " ";
                richTextBox_DescriptiveStatistics.AppendText("Mode: " + mode + "\n\n");
            }
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_NumberOfEquivalentClasses_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) != "error")
                richTextBox_DescriptiveStatistics.AppendText("Number of equivalent classes: " + ClassSpotoMasterRace.NumberOfEquivalentClasses(stringCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Invalid Data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        #endregion Nominal

        #region Ordinal

        private void button_SortData_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string sortedData = "";
                doubleCollectionDescriptiveStatistics.Sort();
                foreach (double item in doubleCollectionDescriptiveStatistics)
                    sortedData += item.ToString() + ",";
                sortedData = sortedData.Remove(sortedData.Length - 1);
                textBox_CollectionDescriptiveStatistics.Text = sortedData;
                richTextBox_DescriptiveStatistics.AppendText("Sorted data: " + sortedData + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_Proportions_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string proportions = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.Proportions(doubleCollectionDescriptiveStatistics))
                    proportions += item.Key + " => " + item.Value + "\n";
                richTextBox_DescriptiveStatistics.AppendText("Proportions: " + proportions + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_ProportionsPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string proportionsPercentage = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.ProportionsPercentages(doubleCollectionDescriptiveStatistics))
                    proportionsPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_DescriptiveStatistics.AppendText("Proportions %: " + proportionsPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_CumulativeFrequencies_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string cumulativeFrequencies = "";
                foreach (KeyValuePair<double, int> item in ClassSpotoMasterRace.CumulativeFrequencies(doubleCollectionDescriptiveStatistics))
                    cumulativeFrequencies += item.Key + " => " + item.Value + "\n";
                richTextBox_DescriptiveStatistics.AppendText("Cumulative Frequencies: " + cumulativeFrequencies + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_CumulativeFrequenciesPercentage_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string cumulativeFrequenciesPercentage = "";
                foreach (KeyValuePair<double, double> item in ClassSpotoMasterRace.CumulativeFrequenciesPercentages(doubleCollectionDescriptiveStatistics))
                    cumulativeFrequenciesPercentage += item.Key + " => " + item.Value + "%\n";
                richTextBox_DescriptiveStatistics.AppendText("Cumulative Frequencies %: " + cumulativeFrequenciesPercentage + "\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_MedianOrdinal_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string medianOrdinal = "";
                foreach (double item in ClassSpotoMasterRace.MedianOrdinal(doubleCollectionDescriptiveStatistics))
                    medianOrdinal += item + " ";
                richTextBox_DescriptiveStatistics.AppendText("Median Ordinal: " + medianOrdinal + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_Quartiles_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                string quartiles = "";
                foreach (double item in ClassSpotoMasterRace.Quartiles(doubleCollectionDescriptiveStatistics))
                    quartiles += item + " ";
                richTextBox_DescriptiveStatistics.AppendText("Quartiles: " + quartiles + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_XPercentile_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText(numericUpDown_XPercentile.Value + "° Percentile: " + ClassSpotoMasterRace.XPercentile(doubleCollectionDescriptiveStatistics, Convert.ToInt16(numericUpDown_XPercentile.Value)) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_PercentileRank_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumOrdinal.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_DescriptiveStatistics.AppendText("Percentile Rank of " + Convert.ToDouble(textBox_DatumOrdinal.Text) + ": " + ClassSpotoMasterRace.PercentileRank(doubleCollectionDescriptiveStatistics, Convert.ToDouble(textBox_DatumOrdinal.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE ORDINAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        #endregion Ordinal

        #region Interval/Ratio

        private void button_Mean_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Mean: " + ClassSpotoMasterRace.Mean(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_MedianInterval_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Median Interval: " + ClassSpotoMasterRace.MedianInterval(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_Range_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Range: " + ClassSpotoMasterRace.Range(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_InterquartileDifference_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Interquartile Difference: " + ClassSpotoMasterRace.InterquartileDifference(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_Deviance_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Deviance: " + ClassSpotoMasterRace.Deviance(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_VariancePopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Variance (Population): " + ClassSpotoMasterRace.VariancePopulation(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_VarianceSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Variance (Sample): " + ClassSpotoMasterRace.VarianceSample(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_StandardDeviationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Standard Deviation (Population): " + ClassSpotoMasterRace.StandardDeviationPopulation(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_StandardDeviationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Standard Deviation (Sample): " + ClassSpotoMasterRace.StandardDeviationSample(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_CoefficientOfVariationPopulation_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Coefficient of Variation (Population): " + ClassSpotoMasterRace.CoefficientOfVariationPopulation(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_CoefficientOfVariationSample_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
                richTextBox_DescriptiveStatistics.AppendText("Coefficient of Variation (Sample): " + ClassSpotoMasterRace.CoefficientOfVariationSample(doubleCollectionDescriptiveStatistics) + "\n\n");
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_ZScore_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
            {
                try
                { Convert.ToDouble(textBox_DatumIntervalRatio.Text); }
                catch
                {
                    MessageBox.Show("Need number with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_DescriptiveStatistics.AppendText("ZScore of " + Convert.ToDouble(textBox_DatumIntervalRatio.Text) + ": " + ClassSpotoMasterRace.ZScore(doubleCollectionDescriptiveStatistics, Convert.ToDouble(textBox_DatumIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
        }

        private void button_TScore_Click(object sender, EventArgs e)
        {
            if (GetCollectionTypeDescriptiveStatistics(textBox_CollectionDescriptiveStatistics.Text) == "double")
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
                richTextBox_DescriptiveStatistics.AppendText("TScore of a DATUM with ZScore = " + Convert.ToDouble(textBox_ZScoreIntervalRatio.Text) + " and Mean = " + Convert.ToDouble(textBox_MeanIntervalRatio.Text) + " and Standard Deviation = " + Convert.ToDouble(textBox_StandardDeviationIntervalRatio.Text) + ": " + ClassSpotoMasterRace.TScore(Convert.ToDouble(textBox_ZScoreIntervalRatio.Text), Convert.ToDouble(textBox_MeanIntervalRatio.Text), Convert.ToDouble(textBox_StandardDeviationIntervalRatio.Text)) + "\n\n");
            }
            else
                MessageBox.Show("Need data validity AT LEAST AT THE INTERVAL level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_DescriptiveStatistics.ScrollToCaret();
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
                richTextBox_Combinatorics.AppendText(k + "-Permutations WITHOUT Repetitions of " + n + " elements: " + ClassSpotoMasterRace.FactorialOf(n) / ClassSpotoMasterRace.FactorialOf(Convert.ToInt16(n - k)) + "\n\n");
            else
                MessageBox.Show("K can't be higher than N.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Combinatorics.ScrollToCaret();
        }

        private void button_PermutationsWithRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            richTextBox_Combinatorics.AppendText(k + "-Permutations WITH Repetitions of " + n + " elements: " + Math.Pow(n, k) + "\n\n");
            richTextBox_Combinatorics.ScrollToCaret();
        }

        private void button_CombinationsWithoutRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            if (k <= n)
                richTextBox_Combinatorics.AppendText(k + "-Combinations WITHOUT Repetitions of " + n + " elements: " + ClassSpotoMasterRace.BinomialCoefficient(n, k) + "\n\n");
            else
                MessageBox.Show("K can't be higher than N.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            richTextBox_Combinatorics.ScrollToCaret();
        }

        private void button_CombinationsWithRepetitions_Click(object sender, EventArgs e)
        {
            short n = Convert.ToInt16(numericUpDown_CombinatoricsN.Value), k = Convert.ToInt16(numericUpDown_CombinatoricsK.Value);
            richTextBox_Combinatorics.AppendText(k + "-Combinations WITH Repetitions of " + n + " elements: " + ClassSpotoMasterRace.BinomialCoefficient(Convert.ToInt16(n + k - 1), k) + "\n\n");
            richTextBox_Combinatorics.ScrollToCaret();
        }

        #endregion Combinatorics

        #region Probability Theory

        #region Misc

        private void textBox_OutcomeSpaceProbabilityTheory_TextChanged(object sender, EventArgs e)
        {
            outcomeSpaceProbabilityTheory = new BindingList<StructSet<string>>();
            foreach (string item in textBox_OutcomeSpaceProbabilityTheory.Text.Replace(" ", "").Split(','))
                outcomeSpaceProbabilityTheory.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));
            if (textBox_OutcomeSpaceProbabilityTheory.Text != "")
            {
                label_CardinalityOutcomeSpaceProbabilityTheory.Text = "|Ω| = " + outcomeSpaceProbabilityTheory.Count.ToString();
                label_CardinalitySpaceOfEventsProbabilityTheory.Text = "|ε| = " + Math.Pow(2.0, outcomeSpaceProbabilityTheory.Count).ToString();
            }
            else
            {
                label_CardinalityOutcomeSpaceProbabilityTheory.Text = "|Ω| = 0";
                label_CardinalitySpaceOfEventsProbabilityTheory.Text = "|ε| = 1";
            }
            label_ProbabilityOfX.Text = "Probability of X: ";
            listBox_SpaceOfEvents.DataSource = new StructSet<string>().Elements;
        }

        private void listBox_SpaceOfEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            outcomeSpaceProbabilityTheory = new BindingList<StructSet<string>>();
            foreach (string item in textBox_OutcomeSpaceProbabilityTheory.Text.Replace(" ", "").Split(','))
                outcomeSpaceProbabilityTheory.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));

            if (listBox_SpaceOfEvents.SelectedItem != null)
            {
                int frequency = ClassSpotoMasterRace.GetFrequency(outcomeSpaceProbabilityTheory, ((StructSet<string>)listBox_SpaceOfEvents.SelectedItem));
                if (((StructSet<string>)listBox_SpaceOfEvents.SelectedItem).Elements.Count == 0)
                    frequency = 0;
                label_ProbabilityOfX.Text = "Probability of extracting \"";
                for (int i = 0; i < spaceOfEventsProbabilityTheory.Elements[listBox_SpaceOfEvents.SelectedIndex].Cardinality; i++)
                    label_ProbabilityOfX.Text += spaceOfEventsProbabilityTheory.Elements[listBox_SpaceOfEvents.SelectedIndex].Elements[i] + (i != spaceOfEventsProbabilityTheory.Elements[listBox_SpaceOfEvents.SelectedIndex].Cardinality - 1 ? "\" OR \"" : "");
                label_ProbabilityOfX.Text += "\" = " + frequency + "/" + outcomeSpaceProbabilityTheory.Count;
            }
        }

        #endregion Misc

        private void button_SpaceOfEvents_Click(object sender, EventArgs e)
        {
            if (textBox_OutcomeSpaceProbabilityTheory.Text != "")
            {
                outcomeSpaceProbabilityTheory = new BindingList<StructSet<string>>();
                foreach (string item in textBox_OutcomeSpaceProbabilityTheory.Text.Replace(" ", "").Split(','))
                    outcomeSpaceProbabilityTheory.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));

                bool proceed = true;
                if (Math.Pow(2.0, outcomeSpaceProbabilityTheory.Count) >= 512)
                    proceed = MessageBox.Show("I need to calculate " + Math.Pow(2.0, outcomeSpaceProbabilityTheory.Count) + " (2^" + outcomeSpaceProbabilityTheory.Count + ") elements.\nThis can take a lot, do you really want to proceed?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                if (proceed)
                {
                    spaceOfEventsProbabilityTheory.Elements = ClassSpotoMasterRace.PowerSet<string>(new StructSet<string>('E', new BindingList<string>(textBox_OutcomeSpaceProbabilityTheory.Text.Replace(" ", "").Split(',')), false));
                    spaceOfEventsProbabilityTheory.Sort();
                    listBox_SpaceOfEvents.DataSource = spaceOfEventsProbabilityTheory.Elements;
                }
            }
            else
            {
                outcomeSpaceProbabilityTheory = new BindingList<StructSet<string>>();
                spaceOfEventsProbabilityTheory.Elements = ClassSpotoMasterRace.PowerSet<string>(new StructSet<string>('E', new BindingList<string>(), false));
                listBox_SpaceOfEvents.DataSource = spaceOfEventsProbabilityTheory.Elements;
            }
        }

        #endregion Probability Theory

        #region Probability Distributions

        #region Misc

        private void textBox_OutcomeSpaceProbabilityDistributions_TextChanged(object sender, EventArgs e)
        {
            outcomeSpaceProbabilityDistributions = new BindingList<StructSet<string>>();
            foreach (string item in textBox_OutcomeSpaceProbabilityDistributions.Text.Replace(" ", "").Split(','))
                outcomeSpaceProbabilityDistributions.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));
            if (textBox_OutcomeSpaceProbabilityDistributions.Text != "")
            {
                label_CardinalityOutcomeSpaceProbabilityDistributions.Text = "|Ω| = " + outcomeSpaceProbabilityDistributions.Count.ToString();
                label_CardinalitySpaceOfEventsProbabilityDistributions.Text = "|ε| = " + Math.Pow(2.0, outcomeSpaceProbabilityDistributions.Count).ToString();
            }
            else
            {
                label_CardinalityOutcomeSpaceProbabilityDistributions.Text = "|Ω| = 0";
                label_CardinalitySpaceOfEventsProbabilityDistributions.Text = "|ε| = 1";
            }
        }

        private void button_ResetProbabilityDistributions_Click(object sender, EventArgs e)
        {
            videoProbabilityDistributions = panel_ProbabilityDistributions.CreateGraphics();
            try
            { drawingProbabilityDistributions = new Bitmap(panel_ProbabilityDistributions.Width, panel_ProbabilityDistributions.Height, videoProbabilityDistributions); }
            catch { }
            sheetProbabilityDistributions = Graphics.FromImage(drawingProbabilityDistributions);
            FixView(viewProbabilityDistributions, panel_ProbabilityDistributions, sheetProbabilityDistributions);
            DrawAxes(sheetProbabilityDistributions, viewProbabilityDistributions);
            DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions);
            videoProbabilityDistributions.DrawImageUnscaled(drawingProbabilityDistributions, 0, 0);
            richTextBox_ProbabilityDistributions.Text = "";
        }

        #endregion Misc

        private void button_CumulativeDistributionFunction_Click(object sender, EventArgs e)
        {
            if (textBox_OutcomeSpaceProbabilityDistributions.Text != "")
            {
                outcomeSpaceProbabilityDistributions = new BindingList<StructSet<string>>();
                foreach (string item in textBox_OutcomeSpaceProbabilityDistributions.Text.Replace(" ", "").Split(','))
                    outcomeSpaceProbabilityDistributions.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));

                bool proceed = true;
                if (Math.Pow(2.0, outcomeSpaceProbabilityDistributions.Count) >= 512)
                    proceed = MessageBox.Show("I need to calculate " + Math.Pow(2.0, outcomeSpaceProbabilityDistributions.Count) + " (2^" + outcomeSpaceProbabilityDistributions.Count + ") elements.\nThis can take a lot, do you really want to proceed?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                if (proceed)
                {
                    spaceOfEventsProbabilityDistributions.Elements = ClassSpotoMasterRace.PowerSet<string>(new StructSet<string>('E', new BindingList<string>(textBox_OutcomeSpaceProbabilityDistributions.Text.Replace(" ", "").Split(',')), false));
                    spaceOfEventsProbabilityDistributions.Sort();
                    double[] probabilities = null;
                    StructSet<StructSet<string>> mainEvents = ClassSpotoMasterRace.MainEvents(spaceOfEventsProbabilityDistributions.Elements);
                    string result = "The random variable X assings:\n";
                    for (int i = 0; i < mainEvents.Cardinality; i++)
                    {
                        result += "The extraction of \"";
                        if (mainEvents.Elements[i].Cardinality == 0)
                            result += "∅";
                        else
                            for (int j = 0; j < mainEvents.Elements[i].Cardinality; j++)
                                result += mainEvents.Elements[i].Elements[j] + (j != mainEvents.Elements[i].Cardinality - 1 ? "\" OR \"" : "");
                        result += "\" to " + i + "\n";
                    }
                    richTextBox_ProbabilityDistributions.Text = result;
                    probabilities = new double[mainEvents.Elements.Count];
                    FixView(viewProbabilityDistributions, panel_ProbabilityDistributions, sheetProbabilityDistributions, -mainEvents.Elements.Count - 1, mainEvents.Elements.Count + 1);
                    DrawAxes(sheetProbabilityDistributions, viewProbabilityDistributions);
                    for (int x = 0; x < mainEvents.Elements.Count; x++)
                    {
                        double xBis = x;
                        int frequency = ClassSpotoMasterRace.GetFrequency(outcomeSpaceProbabilityDistributions, mainEvents.Elements[x]);
                        if (mainEvents.Elements[x].Elements.Count == 0)
                            frequency = 0;
                        double probability = Convert.ToDouble(frequency) / Convert.ToDouble(outcomeSpaceProbabilityDistributions.Count);
                        probabilities[x] = probability;
                        Point P1 = new Point(viewProbabilityDistributions.XVideo(x), viewProbabilityDistributions.YVideo(probability));
                        Point P2;

                        if (x == 0)
                        //from -infinite
                        {
                            xBis = -viewProbabilityDistributions.xVideoMax;
                            while (xBis < x + 1)
                            {
                                sheetProbabilityDistributions.DrawEllipse(functionPen, viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability), 1, 1);
                                xBis += 0.01;
                                P2 = new Point(viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability));
                                sheetProbabilityDistributions.DrawLine(functionPen, P1, P2);
                                P1 = P2;
                            }
                        }
                        while ((xBis < x + 1) && xBis <= viewProbabilityDistributions.xFoglioMax)
                        {
                            sheetProbabilityDistributions.DrawEllipse(functionPen, viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability), 1, 1);
                            xBis += 0.01;
                            P2 = new Point(viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability));
                            sheetProbabilityDistributions.DrawLine(functionPen, P1, P2);
                            P1 = P2;
                        }
                        if (x == mainEvents.Elements.Count - 1)
                        {
                            //to +infinite
                            while (xBis <= viewProbabilityDistributions.xFoglioMax)
                            {
                                sheetProbabilityDistributions.DrawEllipse(functionPen, viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability), 1, 1);
                                xBis += 0.01;
                                P2 = new Point(viewProbabilityDistributions.XVideo(xBis), viewProbabilityDistributions.YVideo(probability));
                                sheetProbabilityDistributions.DrawLine(functionPen, P1, P2);
                                P1 = P2;
                            }
                        }
                    }
                    videoProbabilityDistributions.DrawImageUnscaled(drawingProbabilityDistributions, 0, 0);
                    DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions, probabilities);
                }
            }
            else
                MessageBox.Show("It is pointless to use the empty set in this case!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_MassFunction_Click(object sender, EventArgs e)
        {
            if (textBox_OutcomeSpaceProbabilityDistributions.Text != "")
            {
                outcomeSpaceProbabilityDistributions = new BindingList<StructSet<string>>();
                foreach (string item in textBox_OutcomeSpaceProbabilityDistributions.Text.Replace(" ", "").Split(','))
                    outcomeSpaceProbabilityDistributions.Add(new StructSet<string>('X', new BindingList<string>(new string[] { item })));

                BindingList<StructSet<string>> temp = ClassSpotoMasterRace.RemoveDuplicates(outcomeSpaceProbabilityDistributions);
                string result = "The random variable X assings:\n";
                for (int i = 0; i < temp.Count; i++)
                    result += "The element \"" + temp[i].Elements[0] + "\" to " + (i + 1) + "\n";
                richTextBox_ProbabilityDistributions.Text = result;
                double[] probabilities = null;
                probabilities = new double[temp.Count];
                FixView(viewProbabilityDistributions, panel_ProbabilityDistributions, sheetProbabilityDistributions, -temp.Count - 1, temp.Count + 1);
                DrawAxes(sheetProbabilityDistributions, viewProbabilityDistributions);
                for (int x = 0; x < temp.Count; x++)
                {
                    int frequency = ClassSpotoMasterRace.GetFrequency(outcomeSpaceProbabilityDistributions, temp[x]);
                    if (temp[x].Elements.Count == 0)
                        frequency = 0;
                    double probability = Convert.ToDouble(frequency) / Convert.ToDouble(outcomeSpaceProbabilityDistributions.Count);
                    probabilities[x] = probability;
                    Point P1 = new Point(viewProbabilityDistributions.XVideo(x + 1), viewProbabilityDistributions.YVideo(probability));
                    Point P2;

                    double y = 0;
                    while ((y < probability) && y <= viewProbabilityDistributions.yFoglioMax)
                    {
                        sheetProbabilityDistributions.DrawEllipse(functionPen, viewProbabilityDistributions.XVideo(x + 1), viewProbabilityDistributions.YVideo(y), 1, 1);
                        y += 0.01;
                        P2 = new Point(viewProbabilityDistributions.XVideo(x + 1), viewProbabilityDistributions.YVideo(y));
                        sheetProbabilityDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
                videoProbabilityDistributions.DrawImageUnscaled(drawingProbabilityDistributions, 0, 0);
                DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions, probabilities);
            }
        }

        #endregion Probability Distributions

        #region Parametric Distribution

        #region Misc

        private void tabControl_ParametricDistributions_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_ResetDiscreteParametricDistributions_Click(sender, e);
            button_ResetContinuousParametricDistributions_Click(sender, e);
        }

        #endregion Misc

        #region Discrete

        #region Misc

        private void button_ResetDiscreteParametricDistributions_Click(object sender, EventArgs e)
        {
            videoDiscreteParametricDistributions = panel_DiscreteParametricDistributions.CreateGraphics();
            try
            { drawingDiscreteParametricDistributions = new Bitmap(panel_DiscreteParametricDistributions.Width, panel_DiscreteParametricDistributions.Height, videoDiscreteParametricDistributions); }
            catch { }
            sheetDiscreteParametricDistributions = Graphics.FromImage(drawingDiscreteParametricDistributions);
            FixView(viewDiscreteParametricDistributions, panel_DiscreteParametricDistributions, sheetDiscreteParametricDistributions);
            DrawAxes(sheetDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            richTextBox_DiscreteParametricDistributions.Text = "";
        }

        private void textBox_nBinomialDistribution_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_nBinomialDistribution.Text != "")
                    Convert.ToInt16(textBox_nBinomialDistribution.Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nn must be a Natural number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_nBinomialDistribution.Text = "0";
            }
        }

        private void textBox_pBinomialDistribution_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_pBinomialDistribution.Text != "")
                {
                    double p = Convert.ToDouble(textBox_pBinomialDistribution.Text);
                    if (p < 0 || p > 1)
                        throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input.\np must be a number included in the interval [0, 1]", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_pBinomialDistribution.Text = "0.0";
            }
        }

        private List<double> BinomialDistributionIntro()
        {
            short n = 0;
            double p = 0;
            try
            {
                if (textBox_nBinomialDistribution.Text != "")
                    n = Convert.ToInt16(textBox_nBinomialDistribution.Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nn must be a Natural number.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                if (textBox_pBinomialDistribution.Text != "")
                {
                    p = Convert.ToDouble(textBox_pBinomialDistribution.Text);
                    if (p < 0 || p > 1)
                        throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input.\np must be a number included in the interval [0, 1].", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            List<double> probabilities = new List<double>(ClassSpotoMasterRace.BinomialDistribution(n, p));
            return probabilities;
        }

        private List<double> HypergeometricDistributionIntro()
        {
            short Q = 0, q = 0, n = 0;
            try
            {
                if (textBox_qUpHypergeometricDistribution.Text != "")
                    Q = Convert.ToInt16(textBox_qUpHypergeometricDistribution.Text);
                if (textBox_qDownHypergeometricDistribution.Text != "")
                    q = Convert.ToInt16(textBox_qDownHypergeometricDistribution.Text);
                if (textBox_nHypergeometricDistribution.Text != "")
                    n = Convert.ToInt16(textBox_nHypergeometricDistribution.Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nQ, q, n must be Natural numbers.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            List<double> probabilities = new List<double>(ClassSpotoMasterRace.HypergeometricDistribution(Q, q, n));
            return probabilities;
        }

        #endregion Misc

        private void button_CDFOfBinomialDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(BinomialDistributionIntro());
            probabilities.Sort();
            double previous = 0;
            probabilities.Insert(0, 0);
            for (int i = 0; i < probabilities.Count; i++)
            {
                probabilities[i] += previous;
                previous = probabilities[i];
            }
            probabilities.Add(1);
            richTextBox_DiscreteParametricDistributions.Text = "These are the values of the Binomial Distribution with n = " + textBox_nBinomialDistribution.Text + " and p = " + textBox_pBinomialDistribution.Text + "\n";
            for (int i = 0; i < probabilities.Count; i++)
            {
                richTextBox_DiscreteParametricDistributions.Text += "The extraction of the element with a probability of\"";
                if (probabilities[i] == 0)
                    richTextBox_DiscreteParametricDistributions.Text += "∅";
                else
                    for (int j = 0; j < i; j++)
                        richTextBox_DiscreteParametricDistributions.Text += probabilities[j + 1] + (probabilities[j + 1] != probabilities[i] ? "\" OR \"" : "");
                richTextBox_DiscreteParametricDistributions.Text += "\" to " + i + "\n";
            }
            FixView(viewDiscreteParametricDistributions, panel_DiscreteParametricDistributions, sheetDiscreteParametricDistributions, -probabilities.Count - 1, probabilities.Count + 1);
            DrawAxes(sheetDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            for (int x = 0; x < probabilities.Count; x++)
            {
                double xBis = x;
                double probability = probabilities[x];
                Point P1 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(probability));
                Point P2;

                if (x == 0)
                //from -infinite
                {
                    xBis = -viewDiscreteParametricDistributions.xVideoMax;
                    while (xBis < x + 1)
                    {
                        sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                        xBis += 0.01;
                        P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                        sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
                while ((xBis < x + 1) && xBis <= viewDiscreteParametricDistributions.xFoglioMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                    xBis += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
                if (x == probabilities.Count - 1)
                {
                    //to +infinite
                    while (xBis <= viewDiscreteParametricDistributions.xFoglioMax)
                    {
                        sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                        xBis += 0.01;
                        P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                        sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, probabilities.ToArray());
        }

        private void button_MFOfBinomialDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(BinomialDistributionIntro());
            probabilities.Add(1 - ClassSpotoMasterRace.Sum(probabilities));
            richTextBox_DiscreteParametricDistributions.Text = "These are the values of the Binomial Distribution with n = " + textBox_nBinomialDistribution.Text + " and p = " + textBox_pBinomialDistribution.Text + "\n";
            for (int i = 0; i < probabilities.Count; i++)
                richTextBox_DiscreteParametricDistributions.Text += "The element with a probability of \"" + probabilities[i] + "\" to " + i + "\n";
            FixView(viewDiscreteParametricDistributions, panel_DiscreteParametricDistributions, sheetDiscreteParametricDistributions, -probabilities.Count - 1, probabilities.Count + 1);
            DrawAxes(sheetDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            for (int x = 0; x < probabilities.Count; x++)
            {
                double probability = probabilities[x];
                Point P1 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(probability));
                Point P2;

                double y = 0;
                while ((y < probability) && y <= viewDiscreteParametricDistributions.yFoglioMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y), 1, 1);
                    y += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, probabilities.ToArray());
        }

        private void button_CDFOfHypergeometricDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(HypergeometricDistributionIntro());
            probabilities.Sort();
            double previous = 0;
            probabilities.Insert(0, 0);
            for (int i = 0; i < probabilities.Count; i++)
            {
                probabilities[i] += previous;
                previous = probabilities[i];
            }
            probabilities.Add(1);
            richTextBox_DiscreteParametricDistributions.Text = "These are the values of the Hypergeometric Distribution with Q = " + textBox_qUpHypergeometricDistribution.Text + " and q = " + textBox_qDownHypergeometricDistribution.Text + " and n = " + textBox_nHypergeometricDistribution.Text + "\n";
            for (int i = 0; i < probabilities.Count; i++)
            {
                richTextBox_DiscreteParametricDistributions.Text += "The extraction of the element with a probability of\"";
                if (probabilities[i] == 0)
                    richTextBox_DiscreteParametricDistributions.Text += "∅";
                else
                    for (int j = 0; j < i; j++)
                        richTextBox_DiscreteParametricDistributions.Text += probabilities[j + 1] + (probabilities[j + 1] != probabilities[i] ? "\" OR \"" : "");
                richTextBox_DiscreteParametricDistributions.Text += "\" to " + i + "\n";
            }
            FixView(viewDiscreteParametricDistributions, panel_DiscreteParametricDistributions, sheetDiscreteParametricDistributions, -probabilities.Count - 1, probabilities.Count + 1);
            DrawAxes(sheetDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            for (int x = 0; x < probabilities.Count; x++)
            {
                double xBis = x;
                double probability = probabilities[x];
                Point P1 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(probability));
                Point P2;

                if (x == 0)
                //from -infinite
                {
                    xBis = -viewDiscreteParametricDistributions.xVideoMax;
                    while (xBis < x + 1)
                    {
                        sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                        xBis += 0.01;
                        P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                        sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
                while ((xBis < x + 1) && xBis <= viewDiscreteParametricDistributions.xFoglioMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                    xBis += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
                if (x == probabilities.Count - 1)
                {
                    //to +infinite
                    while (xBis <= viewDiscreteParametricDistributions.xFoglioMax)
                    {
                        sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability), 1, 1);
                        xBis += 0.01;
                        P2 = new Point(viewDiscreteParametricDistributions.XVideo(xBis), viewDiscreteParametricDistributions.YVideo(probability));
                        sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, probabilities.ToArray());
        }

        private void button_MFOfHypergeometricDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(HypergeometricDistributionIntro());
            probabilities.Add(1 - ClassSpotoMasterRace.Sum(probabilities));
            richTextBox_DiscreteParametricDistributions.Text = "These are the values of the Hypergeometric Distribution with Q = " + textBox_qUpHypergeometricDistribution.Text + " and q = " + textBox_qDownHypergeometricDistribution.Text + " and n = " + textBox_nHypergeometricDistribution.Text + "\n";
            for (int i = 0; i < probabilities.Count; i++)
                richTextBox_DiscreteParametricDistributions.Text += "The element with a probability of \"" + probabilities[i] + "\" to " + i + "\n";
            FixView(viewDiscreteParametricDistributions, panel_DiscreteParametricDistributions, sheetDiscreteParametricDistributions, -probabilities.Count - 1, probabilities.Count + 1);
            DrawAxes(sheetDiscreteParametricDistributions, viewDiscreteParametricDistributions);
            for (int x = 0; x < probabilities.Count; x++)
            {
                double probability = probabilities[x];
                Point P1 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(probability));
                Point P2;

                double y = 0;
                while ((y < probability) && y <= viewDiscreteParametricDistributions.yFoglioMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y), 1, 1);
                    y += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, probabilities.ToArray());
        }

        #endregion Discrete

        #region Continuous

        private void button_ResetContinuousParametricDistributions_Click(object sender, EventArgs e)
        {
            videoContinuousParametricDistributions = panel_ContinuousParametricDistributions.CreateGraphics();
            try
            { drawingContinuousParametricDistributions = new Bitmap(panel_ContinuousParametricDistributions.Width, panel_ContinuousParametricDistributions.Height, videoContinuousParametricDistributions); }
            catch { }
            sheetContinuousParametricDistributions = Graphics.FromImage(drawingContinuousParametricDistributions);
            FixView(viewContinuousParametricDistributions, panel_ContinuousParametricDistributions, sheetContinuousParametricDistributions);
            DrawAxes(sheetContinuousParametricDistributions, viewContinuousParametricDistributions);
            DrawCoordinates(videoContinuousParametricDistributions, viewContinuousParametricDistributions);
            videoContinuousParametricDistributions.DrawImageUnscaled(drawingContinuousParametricDistributions, 0, 0);
            richTextBox_ContinuousParametricDistributions.Text = "";
        }

        #endregion Continuous

        #endregion Parametric Distribution
    }
}