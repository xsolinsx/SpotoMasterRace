using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpotoMasterRace
{
    public partial class FormSpotoMasterRace : Form
    {
        #region Common

        private Pen functionPen;
        private Pen axisPen;
        private double XSMIN = -1;
        private double XSMAX = 1;
        private double YSMIN = -1;
        private double YSMAX = 1;

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

        #region Covariance and Correlation

        private Pen covarianceAndCorrelationPen;
        private ClassDraw viewCovarianceAndCorrelation;
        private Graphics videoCovarianceAndCorrelation;
        private Bitmap drawingCovarianceAndCorrelation;
        private Graphics sheetCovarianceAndCorrelation;

        #endregion Covariance and Correlation
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

            #region Covariance and Correlation

            covarianceAndCorrelationPen = new Pen(Color.Black, 4);
            viewCovarianceAndCorrelation = new ClassDraw();
            videoCovarianceAndCorrelation = panel_CovarianceAndCorrelation.CreateGraphics();
            drawingCovarianceAndCorrelation = new Bitmap(panel_CovarianceAndCorrelation.Width, panel_CovarianceAndCorrelation.Height, videoCovarianceAndCorrelation);
            sheetCovarianceAndCorrelation = Graphics.FromImage(drawingCovarianceAndCorrelation);

            #endregion Covariance and Correlation

            MessageBox.Show("THINK and REASON about what you're doing.\nThis is just meant to help, not to do the exam for you.\nI'm not responsible for your grade, it doesn't matter if it is good or bad.", "DISCLAIMER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #region Global Misc

        private void tabControl_SpotoMasterRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Name)
            {
                case "tabPage_SetTheory":
                    {
                        this.MinimumSize = new Size(800, 600);
                        break;
                    }
                case "tabPage_DescriptiveStatistics":
                    {
                        this.MinimumSize = new Size(600, 600);
                        break;
                    }
                case "tabPage_Combinatorics":
                    {
                        this.MinimumSize = new Size(600, 400);
                        break;
                    }
                case "tabPage_ProbabilityTheory":
                    {
                        this.MinimumSize = new Size(700, 300);
                        break;
                    }
                case "tabPage_ProbabilityDistributions":
                    {
                        this.MinimumSize = new Size(600, 600);
                        button_ResetProbabilityDistributions_Click(sender, e);
                        break;
                    }
                case "tabPage_ParametricDistributions":
                    {
                        this.MinimumSize = new Size(800, 600);
                        switch (tabControl_ParametricDistributions.SelectedTab.Name)
                        {
                            case "tabPage_DiscreteParametricDistributions":
                                {
                                    button_ResetDiscreteParametricDistributions_Click(sender, e);
                                    break;
                                }
                            case "tabPage_ContinuousParametricDistributions":
                                {
                                    button_ResetContinuousParametricDistributions_Click(sender, e);
                                    break;
                                }
                            default:
                                {
                                    button_ResetDiscreteParametricDistributions_Click(sender, e);
                                    button_ResetContinuousParametricDistributions_Click(sender, e);
                                    break;
                                }
                        }
                        break;
                    }
                case "tabPage_CovarianceAndCorrelation":
                    {
                        this.MinimumSize = new Size(750, 600);
                        button_ResetCovarianceAndCorrelation_Click(sender, e);
                        break;
                    }
                case "tabPage_Tables":
                    {
                        this.MinimumSize = new Size(650, 500);
                        break;
                    }
                case "tabPage_Utilities":
                    {
                        this.MinimumSize = new Size(500, 600);
                        break;
                    }
                default:
                    {
                        button_ResetProbabilityDistributions_Click(sender, e);
                        button_ResetDiscreteParametricDistributions_Click(sender, e);
                        button_ResetContinuousParametricDistributions_Click(sender, e);
                        button_ResetCovarianceAndCorrelation_Click(sender, e);
                        break;
                    }
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

        private void FixView(ClassDraw view, Panel panel, Graphics sheet, double xsmin = -1, double xsmax = 1, double ysmin = -1, double ysmax = 1)
        {
            XSMIN = xsmin;
            XSMAX = xsmax;
            YSMIN = ysmin;
            YSMAX = ysmax;
            view.xSheetMin = XSMIN;
            view.xSheetMax = XSMAX;
            view.ySheetMin = YSMIN;
            view.ySheetMax = YSMAX;
            view.xVideoMin = 0;
            view.xVideoMax = panel.Width;
            view.yVideoMin = panel.Height;
            view.yVideoMax = 0;
            sheet.Clear(Form.DefaultBackColor);
        }

        private void DrawAxes(Graphics sheet, ClassDraw view)
        {
            int xVideoZero = view.XVideo(0);
            int yVideoZero = view.YVideo(0);
            sheet.DrawLine(axisPen, view.XVideo(view.xSheetMin), yVideoZero, view.XVideo(view.xSheetMax), yVideoZero);
            sheet.DrawLine(axisPen, xVideoZero, view.YVideo(view.ySheetMin), xVideoZero, view.YVideo(view.ySheetMax));
        }

        private void DrawCoordinates(Graphics video, ClassDraw view, double[] xValues = null, double[] yValues = null)
        {
            double x = 0;
            double y = 0;
            double weirdXValue = 0;
            double weirdYValue = 0;
            do
                weirdXValue += 0.1;
            while (weirdXValue * 10 <= view.xSheetMax || view.xSheetMax >= weirdXValue * 15);
            do
                weirdYValue += 0.1;
            while (weirdYValue * 10 <= view.ySheetMax || view.ySheetMax >= weirdYValue * 15);

            if (xValues != null)
                for (int i = 0; i < xValues.Length; i++)
                {
                    x = xValues[i];
                    //if (x != 0)
                    //video.DrawString("-" + string.Format("{0:0.00}", x), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo(-x), view.YVideo((view.ySheetMin + view.ySheetMax) / 2));
                    video.DrawString(string.Format("{0:0.00}", x), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo(+x), view.YVideo((view.ySheetMin + view.ySheetMax) / 2));
                }
            else
                do
                {
                    if (x != 0)
                        video.DrawString("-" + string.Format("{0:0.00}", x), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo(-x), view.YVideo((view.ySheetMin + view.ySheetMax) / 2));
                    video.DrawString(string.Format("{0:0.00}", x), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo(+x), view.YVideo((view.ySheetMin + view.ySheetMax) / 2));
                    x += weirdXValue;
                }
                while (x <= view.yVideoMin);

            if (yValues != null)
                for (int i = 0; i < yValues.Length; i++)
                {
                    y = yValues[i];
                    if (y != 0)
                        video.DrawString("-" + string.Format("{0:0.00}", y), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo((view.xSheetMin + view.xSheetMax) / 2), view.YVideo(-y));
                    video.DrawString(string.Format("{0:0.00}", y), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo((view.xSheetMin + view.xSheetMax) / 2), view.YVideo(+y));
                }
            else
                do
                {
                    if (y != 0)
                        video.DrawString("-" + string.Format("{0:0.00}", y), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo((view.xSheetMin + view.xSheetMax) / 2), view.YVideo(-y));
                    video.DrawString(string.Format("{0:0.00}", y), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), view.XVideo((view.xSheetMin + view.xSheetMax) / 2), view.YVideo(+y));
                    y += weirdYValue;
                }
                while (y <= view.xVideoMax);
        }

        private void FormSpotoMasterRace_SizeChanged(object sender, EventArgs e)
        {
            switch (tabControl_SpotoMasterRace.SelectedTab.Name)
            {
                case "tabPage_ProbabilityDistributions":
                    {
                        button_ResetProbabilityDistributions_Click(sender, e);
                        break;
                    }
                case "tabPage_ParametricDistributions":
                    {
                        switch (tabControl_ParametricDistributions.SelectedTab.Name)
                        {
                            case "tabPage_DiscreteParametricDistributions":
                                {
                                    button_ResetDiscreteParametricDistributions_Click(sender, e);
                                    break;
                                }
                            case "tabPage_ContinuousParametricDistributions":
                                {
                                    button_ResetContinuousParametricDistributions_Click(sender, e);
                                    break;
                                }
                            default:
                                {
                                    button_ResetDiscreteParametricDistributions_Click(sender, e);
                                    button_ResetContinuousParametricDistributions_Click(sender, e);
                                    break;
                                }
                        }
                        break;
                    }
                case "tabPage_CovarianceAndCorrelation":
                    {
                        button_ResetCovarianceAndCorrelation_Click(sender, e);
                        break;
                    }
                default:
                    {
                        button_ResetProbabilityDistributions_Click(sender, e);
                        button_ResetDiscreteParametricDistributions_Click(sender, e);
                        button_ResetContinuousParametricDistributions_Click(sender, e);
                        button_ResetCovarianceAndCorrelation_Click(sender, e);
                        break;
                    }
            }
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
                label_Cardinality.Text = "Cardinality = " + tempSetSetTheory.Cardinality;
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
                    textBox_CurrentSet.Text = set1.Name + " = " + set2.Name + ": " + (set1 == set2).ToString();
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
        {
            button_XPercentile.Text = numericUpDown_XPercentile.Value + "° Percentage";
            label_XPercentile.Text = numericUpDown_XPercentile.Value + "° Percentage";
        }

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
                    Convert.ToDouble(textBox_UtilitiesZScoreForTScore.Text);
                    Convert.ToDouble(textBox_UtilitiesMeanForTScore.Text);
                    Convert.ToDouble(textBox_UtilitiesStandardDeviationForTScore.Text);
                }
                catch
                {
                    MessageBox.Show("Need ZScore, Mean and Standard Deviation with this format: IntegerPart.DecimalPartIfPresent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                richTextBox_DescriptiveStatistics.AppendText("TScore of a DATUM with ZScore = " + Convert.ToDouble(textBox_UtilitiesZScoreForTScore.Text) + " and Mean = " + Convert.ToDouble(textBox_UtilitiesMeanForTScore.Text) + " and Standard Deviation = " + Convert.ToDouble(textBox_UtilitiesStandardDeviationForTScore.Text) + ": " + ClassSpotoMasterRace.TScore(Convert.ToDouble(textBox_UtilitiesZScoreForTScore.Text), Convert.ToDouble(textBox_UtilitiesMeanForTScore.Text), Convert.ToDouble(textBox_UtilitiesStandardDeviationForTScore.Text)) + "\n\n");
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
                MessageBox.Show("k can't be higher than n.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("k can't be higher than n.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            videoProbabilityDistributions.DrawImageUnscaled(drawingProbabilityDistributions, 0, 0);
            DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions);
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
                    StructSet<StructSet<string>> mainEvents = ClassSpotoMasterRace.MainEvents(spaceOfEventsProbabilityDistributions.Elements);
                    richTextBox_ProbabilityDistributions.AppendText("The random variable X assings:\n");
                    for (int i = 0; i < mainEvents.Cardinality; i++)
                    {
                        richTextBox_ProbabilityDistributions.AppendText("The extraction of \"");
                        if (mainEvents.Elements[i].Cardinality == 0)
                            richTextBox_ProbabilityDistributions.AppendText("∅");
                        else
                            for (int j = 0; j < mainEvents.Elements[i].Cardinality; j++)
                                richTextBox_ProbabilityDistributions.AppendText(mainEvents.Elements[i].Elements[j] + (j != mainEvents.Elements[i].Cardinality - 1 ? "\" OR \"" : ""));
                        richTextBox_ProbabilityDistributions.AppendText("\" to " + i + "\n");
                    }
                    double[] probabilities = new double[mainEvents.Elements.Count];
                    double[] xValues = new double[mainEvents.Elements.Count + 1];
                    for (int i = 0; i < xValues.Length; i++)
                        xValues[i] = i;
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
                        while ((xBis < x + 1) && xBis <= viewProbabilityDistributions.xSheetMax)
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
                            while (xBis <= viewProbabilityDistributions.xSheetMax)
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
                    DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions, xValues, probabilities);
                }
                richTextBox_ProbabilityDistributions.ScrollToCaret();
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
                richTextBox_ProbabilityDistributions.AppendText("The random variable X assings:\n");
                for (int i = 0; i < temp.Count; i++)
                    richTextBox_ProbabilityDistributions.AppendText("The element \"" + temp[i].Elements[0] + "\" to " + (i + 1) + "\n");
                double[] probabilities = new double[temp.Count];
                double[] xValues = new double[temp.Count + 1];
                for (int i = 0; i < xValues.Length; i++)
                    xValues[i] = i;
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
                    while ((y < probability) && y <= viewProbabilityDistributions.ySheetMax)
                    {
                        sheetProbabilityDistributions.DrawEllipse(functionPen, viewProbabilityDistributions.XVideo(x + 1), viewProbabilityDistributions.YVideo(y), 1, 1);
                        y += 0.01;
                        P2 = new Point(viewProbabilityDistributions.XVideo(x + 1), viewProbabilityDistributions.YVideo(y));
                        sheetProbabilityDistributions.DrawLine(functionPen, P1, P2);
                        P1 = P2;
                    }
                }
                videoProbabilityDistributions.DrawImageUnscaled(drawingProbabilityDistributions, 0, 0);
                DrawCoordinates(videoProbabilityDistributions, viewProbabilityDistributions, xValues, probabilities);
                richTextBox_ProbabilityDistributions.ScrollToCaret();
            }
        }

        #endregion Probability Distributions

        #region Parametric Distribution

        #region Misc

        private void tabControl_ParametricDistributions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Name)
            {
                case "tabPage_DiscreteParametricDistributions":
                    {
                        button_ResetDiscreteParametricDistributions_Click(sender, e);
                        break;
                    }
                case "tabPage_ContinuousParametricDistributions":
                    {
                        button_ResetContinuousParametricDistributions_Click(sender, e);
                        break;
                    }
                default:
                    {
                        button_ResetDiscreteParametricDistributions_Click(sender, e);
                        button_ResetContinuousParametricDistributions_Click(sender, e);
                        break;
                    }
            }
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
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions);
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
                MessageBox.Show("Incorrect input.\nn must be a Natural number.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Incorrect input.\np must be a Real number included in the interval [0, 1].", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_pBinomialDistribution.Text = "0.0";
            }
        }

        private List<double> BinomialDistributionIntro()
        {
            short n = 0;
            double p = 0;
            try
            { n = Convert.ToInt16(textBox_nBinomialDistribution.Text); }
            catch
            {
                MessageBox.Show("Incorrect input.\nn must be a Natural number.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                p = Convert.ToDouble(textBox_pBinomialDistribution.Text);
                if (p < 0 || p > 1)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Incorrect input.\np must be a Real number included in the interval [0, 1].", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            List<double> probabilities = new List<double>(ClassSpotoMasterRace.BinomialDistribution(n, p));
            return probabilities;
        }

        private void textBoxes_HypergeometricDistribution_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != "")
                    Convert.ToInt16(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nQ, q, n must be Natural numbers.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = "0";
            }
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
            double[] xValues = new double[probabilities.Count + 1];
            for (int i = 0; i < xValues.Length; i++)
                xValues[i] = i;
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
                while ((xBis < x + 1) && xBis <= viewDiscreteParametricDistributions.xSheetMax)
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
                    while (xBis <= viewDiscreteParametricDistributions.xSheetMax)
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
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, xValues, probabilities.ToArray());
        }

        private void button_MFOfBinomialDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(BinomialDistributionIntro());
            probabilities.Add(1 - ClassSpotoMasterRace.Sum(probabilities));
            double[] xValues = new double[probabilities.Count + 1];
            for (int i = 0; i < xValues.Length; i++)
                xValues[i] = i;
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
                while ((y < probability) && y <= viewDiscreteParametricDistributions.ySheetMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y), 1, 1);
                    y += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, xValues, probabilities.ToArray());
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
            double[] xValues = new double[probabilities.Count + 1];
            for (int i = 0; i < xValues.Length; i++)
                xValues[i] = i;
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
                while ((xBis < x + 1) && xBis <= viewDiscreteParametricDistributions.xSheetMax)
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
                    while (xBis <= viewDiscreteParametricDistributions.xSheetMax)
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
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, xValues, probabilities.ToArray());
        }

        private void button_MFOfHypergeometricDistribution_Click(object sender, EventArgs e)
        {
            List<double> probabilities = new List<double>(HypergeometricDistributionIntro());
            probabilities.Add(1 - ClassSpotoMasterRace.Sum(probabilities));
            double[] xValues = new double[probabilities.Count + 1];
            for (int i = 0; i < xValues.Length; i++)
                xValues[i] = i;
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
                while ((y < probability) && y <= viewDiscreteParametricDistributions.ySheetMax)
                {
                    sheetDiscreteParametricDistributions.DrawEllipse(functionPen, viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y), 1, 1);
                    y += 0.01;
                    P2 = new Point(viewDiscreteParametricDistributions.XVideo(x), viewDiscreteParametricDistributions.YVideo(y));
                    sheetDiscreteParametricDistributions.DrawLine(functionPen, P1, P2);
                    P1 = P2;
                }
            }
            videoDiscreteParametricDistributions.DrawImageUnscaled(drawingDiscreteParametricDistributions, 0, 0);
            DrawCoordinates(videoDiscreteParametricDistributions, viewDiscreteParametricDistributions, xValues, probabilities.ToArray());
        }

        #endregion Discrete

        #region Continuous

        #region Misc

        private void button_ResetContinuousParametricDistributions_Click(object sender, EventArgs e)
        {
            videoContinuousParametricDistributions = panel_ContinuousParametricDistributions.CreateGraphics();
            try
            { drawingContinuousParametricDistributions = new Bitmap(panel_ContinuousParametricDistributions.Width, panel_ContinuousParametricDistributions.Height, videoContinuousParametricDistributions); }
            catch { }
            sheetContinuousParametricDistributions = Graphics.FromImage(drawingContinuousParametricDistributions);
            FixView(viewContinuousParametricDistributions, panel_ContinuousParametricDistributions, sheetContinuousParametricDistributions);
            DrawAxes(sheetContinuousParametricDistributions, viewContinuousParametricDistributions);
            videoContinuousParametricDistributions.DrawImageUnscaled(drawingContinuousParametricDistributions, 0, 0);
            DrawCoordinates(videoContinuousParametricDistributions, viewContinuousParametricDistributions);
            richTextBox_ContinuousParametricDistributions.Text = "";
        }

        private void textBoxes_NormalDistribution_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != "")
                    Convert.ToDouble(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nMean and Variance must be Real numbers.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = "0.0";
            }
        }

        #endregion Misc

        private void button_NormalDistribution_Click(object sender, EventArgs e)
        {
            if (textBox_MeanNormalDistribution.Text == "" || textBox_VarianceNormalDistribution.Text == "")
            {
                MessageBox.Show("Incorrect input.\nMean must be a Real number and Variance must be > 0.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double mean = Convert.ToDouble(textBox_MeanNormalDistribution.Text);
            double variance = Convert.ToDouble(textBox_VarianceNormalDistribution.Text);
            if (variance <= 0)
            {
                MessageBox.Show("Incorrect input.\nMean must be a Real number and Variance must be > 0.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            richTextBox_ContinuousParametricDistributions.Text = "This is the graph of the Normal Distribution with Mean = " + mean + " and Variance = " + variance + "\n";
            FixView(viewContinuousParametricDistributions, panel_ContinuousParametricDistributions, sheetContinuousParametricDistributions, mean - (variance < 10 ? 9 : variance), mean + (variance < 10 ? 9 : variance), -ClassSpotoMasterRace.NormalDistributionValue(mean, mean, variance), ClassSpotoMasterRace.NormalDistributionValue(mean, mean, variance));
            DrawAxes(sheetContinuousParametricDistributions, viewContinuousParametricDistributions);
            Point P1 = new Point(viewContinuousParametricDistributions.XVideo(viewContinuousParametricDistributions.xSheetMin), viewContinuousParametricDistributions.YVideo(ClassSpotoMasterRace.NormalDistributionValue(viewContinuousParametricDistributions.xSheetMin, mean, variance)));
            Point P2;

            double drawEvery = (variance < 10 ? 7 : variance) / 10;
            List<double> xValues = new List<double>();
            double tempLeft = viewContinuousParametricDistributions.xSheetMin;
            while (tempLeft < mean)
            {
                xValues.Add(tempLeft);
                tempLeft += drawEvery;
            }
            xValues.Add(mean);
            double tempRight = viewContinuousParametricDistributions.xSheetMax;
            while (tempRight > mean)
            {
                xValues.Add(tempRight);
                tempRight -= drawEvery;
            }
            double x = viewContinuousParametricDistributions.xSheetMin;
            while (x <= viewContinuousParametricDistributions.xSheetMax)
            {
                sheetContinuousParametricDistributions.DrawEllipse(functionPen, viewContinuousParametricDistributions.XVideo(x), viewContinuousParametricDistributions.YVideo(ClassSpotoMasterRace.NormalDistributionValue(x, mean, variance)), 1, 1);
                x += 0.01;
                P2 = new Point(viewContinuousParametricDistributions.XVideo(x), viewContinuousParametricDistributions.YVideo(ClassSpotoMasterRace.NormalDistributionValue(x, mean, variance)));
                sheetContinuousParametricDistributions.DrawLine(functionPen, P1, P2);
                P1 = P2;
            }
            //draw line in the middle of the distribution
            videoContinuousParametricDistributions.DrawImageUnscaled(drawingContinuousParametricDistributions, 0, 0);
            videoContinuousParametricDistributions.DrawString(string.Format("{0:0.00}", mean), FormSpotoMasterRace.DefaultFont, new SolidBrush(Color.Black), viewContinuousParametricDistributions.XVideo(+mean), viewContinuousParametricDistributions.YVideo((viewContinuousParametricDistributions.ySheetMin + viewContinuousParametricDistributions.ySheetMax) / 2));
            videoContinuousParametricDistributions.DrawLine(axisPen, viewContinuousParametricDistributions.XVideo(mean), viewContinuousParametricDistributions.YVideo(viewContinuousParametricDistributions.ySheetMin), viewContinuousParametricDistributions.XVideo(mean), viewContinuousParametricDistributions.YVideo(viewContinuousParametricDistributions.ySheetMax));
            DrawCoordinates(videoContinuousParametricDistributions, viewContinuousParametricDistributions, xValues.ToArray(), null);
        }

        #endregion Continuous

        #endregion Parametric Distribution

        #region Covariance and Correlation

        #region Misc

        private void button_ResetCovarianceAndCorrelation_Click(object sender, EventArgs e)
        {
            videoCovarianceAndCorrelation = panel_CovarianceAndCorrelation.CreateGraphics();
            try
            { drawingCovarianceAndCorrelation = new Bitmap(panel_CovarianceAndCorrelation.Width, panel_CovarianceAndCorrelation.Height, videoCovarianceAndCorrelation); }
            catch { }
            sheetCovarianceAndCorrelation = Graphics.FromImage(drawingCovarianceAndCorrelation);
            FixView(viewCovarianceAndCorrelation, panel_CovarianceAndCorrelation, sheetCovarianceAndCorrelation);
            DrawAxes(sheetCovarianceAndCorrelation, viewCovarianceAndCorrelation);
            videoCovarianceAndCorrelation.DrawImageUnscaled(drawingCovarianceAndCorrelation, 0, 0);
            DrawCoordinates(videoCovarianceAndCorrelation, viewCovarianceAndCorrelation);
            richTextBox_CovarianceAndCorrelation.Text = "";
        }

        private void CovarianceAndCorrelationGraph()
        {
            if (textBox_FirstVariableValues.Text == "" || textBox_SecondVariableValues.Text == "")
            {
                MessageBox.Show("Incorrect input.\nThe two boxes must be filled with values.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<double> firstVariable = InitializeDoubleCollection(InitializeStringCollection(textBox_FirstVariableValues.Text));
            List<double> secondVariable = InitializeDoubleCollection(InitializeStringCollection(textBox_SecondVariableValues.Text));
            if (firstVariable != null && secondVariable != null && firstVariable.Count == secondVariable.Count)
            {
                double minX = double.MaxValue;
                double minY = double.MaxValue;
                double maxX = double.MinValue;
                double maxY = double.MinValue;
                for (int i = 0; i < firstVariable.Count; i++)
                {
                    if (minX > firstVariable[i])
                        minX = firstVariable[i];
                    if (minY > secondVariable[i])
                        minY = secondVariable[i];
                    if (maxX < firstVariable[i])
                        maxX = firstVariable[i];
                    if (maxY < secondVariable[i])
                        maxY = secondVariable[i];
                }
                if (Math.Abs(minX) >= Math.Abs(maxX))
                    maxX = Math.Abs(minX);
                else
                    minX = -Math.Abs(maxX);
                if (Math.Abs(minY) >= Math.Abs(maxY))
                    maxY = Math.Abs(minY);
                else
                    minY = -Math.Abs(maxY);
                minX--;
                minY--;
                maxX++;
                maxY++;
                FixView(viewCovarianceAndCorrelation, panel_CovarianceAndCorrelation, sheetCovarianceAndCorrelation, minX, maxX, minY, maxY);
                DrawAxes(sheetCovarianceAndCorrelation, viewCovarianceAndCorrelation);

                for (int i = 0; i < firstVariable.Count; i++)
                    sheetCovarianceAndCorrelation.DrawEllipse(covarianceAndCorrelationPen, viewCovarianceAndCorrelation.XVideo(firstVariable[i]), viewCovarianceAndCorrelation.YVideo(secondVariable[i]), 1, 1);
                //draw line in the middle of the distribution
                videoCovarianceAndCorrelation.DrawImageUnscaled(drawingCovarianceAndCorrelation, 0, 0);
                DrawCoordinates(videoCovarianceAndCorrelation, viewCovarianceAndCorrelation);
                richTextBox_CovarianceAndCorrelation.Text = "The graph is plotted using the two variables.\n1st: " + textBox_FirstVariableValues.Text + "\n2nd: " + textBox_SecondVariableValues.Text + "\n";
            }
        }

        #endregion Misc

        private void button_Covariance_Click(object sender, EventArgs e)
        {
            CovarianceAndCorrelationGraph();
            richTextBox_CovarianceAndCorrelation.Text += "The covariance between the two variables is " + ClassSpotoMasterRace.Covariance(InitializeDoubleCollection(InitializeStringCollection(textBox_FirstVariableValues.Text)), InitializeDoubleCollection(InitializeStringCollection(textBox_SecondVariableValues.Text)));
        }

        private void button_Correlation_Click(object sender, EventArgs e)
        {
            CovarianceAndCorrelationGraph();
            richTextBox_CovarianceAndCorrelation.Text += "The correlation between the two variables is " + ClassSpotoMasterRace.Correlation(InitializeDoubleCollection(InitializeStringCollection(textBox_FirstVariableValues.Text)), InitializeDoubleCollection(InitializeStringCollection(textBox_SecondVariableValues.Text)));
        }

        #endregion Covariance and Correlation

        #region Tables

        #region Misc

        private void textBox_SNDProbability_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SNDProbability.Text != "")
                {
                    double probability = Convert.ToDouble(textBox_SNDProbability.Text);
                    if (probability < 0 || probability > 1)
                        throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nThe probability must be a Real number, with 4 decimals at most, included in the interval [0, 1].", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_SNDProbability.Text = "0.0000";
            }
        }

        private void textBox_SNDZPoint_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SNDZPoint.Text != "")
                {
                    double z = Convert.ToDouble(textBox_SNDZPoint.Text);
                    if (z < -3.49 || z > 3.49)
                        throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nz must be a Real number, with 2 decimals at most, included in the interval [-3.49, 3.49] (the given table have those values).", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_SNDZPoint.Text = "0.00";
            }
        }

        #endregion Misc

        private void button_SNDProbability_Click(object sender, EventArgs e)
        {
            richTextBox_Tables.Text += "The Probability of having a value from -∞ to " + textBox_SNDProbability.Text.Replace(',', '.') + " is " +
              string.Format("{0:0.0000}", ClassSpotoMasterRace.GetZTableProbability(textBox_SNDZPoint.Text.Replace(',', '.')).ToString()) + "\n\n";
        }

        private void button_SNDZPoint_Click(object sender, EventArgs e)
        {
            richTextBox_Tables.Text += "The zPoint that gives a probability of " + textBox_SNDProbability.Text.Replace(',', '.') + " is " +
              string.Format("{0:0.00}", ClassSpotoMasterRace.GetZTableZPoint(Convert.ToDouble(textBox_SNDProbability.Text.Replace(',', '.'))).ToString()) + "\n\n";
        }

        private void button_CSDCriticalValue_Click(object sender, EventArgs e)
        {
            double alpha;
            int degreesOfFreedom;
            if (radioButton_CSD995.Checked)
                alpha = 0.995;
            else if (radioButton_CSD990.Checked)
                alpha = 0.990;
            else if (radioButton_CSD975.Checked)
                alpha = 0.975;
            else if (radioButton_CSD950.Checked)
                alpha = 0.950;
            else if (radioButton_CSD900.Checked)
                alpha = 0.900;
            else if (radioButton_CSD100.Checked)
                alpha = 0.100;
            else if (radioButton_CSD50.Checked)
                alpha = 0.050;
            else if (radioButton_CSD25.Checked)
                alpha = 0.025;
            else if (radioButton_CSD10.Checked)
                alpha = 0.010;
            else if (radioButton_CSD5.Checked)
                alpha = 0.005;
            else
            {
                MessageBox.Show("You must specify α.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_CSDDegreesOfFreedom.Value > 30 && numericUpDown_CSDDegreesOfFreedom.Value <= 40)
                degreesOfFreedom = 40;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 40 && numericUpDown_CSDDegreesOfFreedom.Value <= 50)
                degreesOfFreedom = 50;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 50 && numericUpDown_CSDDegreesOfFreedom.Value <= 60)
                degreesOfFreedom = 60;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 60 && numericUpDown_CSDDegreesOfFreedom.Value <= 70)
                degreesOfFreedom = 70;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 70 && numericUpDown_CSDDegreesOfFreedom.Value <= 80)
                degreesOfFreedom = 80;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 80 && numericUpDown_CSDDegreesOfFreedom.Value <= 90)
                degreesOfFreedom = 90;
            else if (numericUpDown_CSDDegreesOfFreedom.Value > 90 && numericUpDown_CSDDegreesOfFreedom.Value <= 100)
                degreesOfFreedom = 100;
            else
                degreesOfFreedom = Convert.ToInt32(numericUpDown_CSDDegreesOfFreedom.Value);
            richTextBox_Tables.Text += "The Critical X^2 with an α of " + alpha + " and " + numericUpDown_CSDDegreesOfFreedom.Value + " deegrees of freedom is " +
                string.Format("{0:0.000}", ClassSpotoMasterRace.GetChiSquareTableValue(degreesOfFreedom, alpha)) + "\n\n";
        }

        private void button_TDCriticalT_Click(object sender, EventArgs e)
        {
            double alpha;
            string degreesOfFreedom;
            if (radioButton_TD100.Checked)
                alpha = 0.100;
            else if (radioButton_TD50.Checked)
                alpha = 0.050;
            else if (radioButton_TD25.Checked)
                alpha = 0.025;
            else if (radioButton_TD10.Checked)
                alpha = 0.010;
            else if (radioButton_TD5.Checked)
                alpha = 0.005;
            else
            {
                MessageBox.Show("You must specify α.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_TDDegreesOfFreedom.Value > 30 && numericUpDown_TDDegreesOfFreedom.Value <= 32)
                degreesOfFreedom = "32";
            else if (numericUpDown_TDDegreesOfFreedom.Value > 40 && numericUpDown_TDDegreesOfFreedom.Value <= 34)
                degreesOfFreedom = "34";
            else if (numericUpDown_TDDegreesOfFreedom.Value > 34 && numericUpDown_TDDegreesOfFreedom.Value <= 36)
                degreesOfFreedom = "36";
            else if (numericUpDown_TDDegreesOfFreedom.Value > 36 && numericUpDown_TDDegreesOfFreedom.Value <= 38)
                degreesOfFreedom = "38";
            else if (numericUpDown_TDDegreesOfFreedom.Value > 38)
                degreesOfFreedom = "∞";
            else
                degreesOfFreedom = numericUpDown_TDDegreesOfFreedom.Text;
            richTextBox_Tables.Text += "The Critical t with an α of " + alpha + " and " + numericUpDown_CSDDegreesOfFreedom.Value + " deegrees of freedom is " +
                string.Format("{0:0.000}", ClassSpotoMasterRace.GetTTableValue(degreesOfFreedom, alpha)) + "\n\n";
        }

        #endregion Tables

        #region Utilities

        #region Misc

        private void textBoxes_Utilities_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != "")
                    Convert.ToDouble(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input.\nThe values in this page must be Numbers.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = "0";
            }
        }

        #endregion Misc

        private void button_UtilitiesVariancePopulation_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The Variance of the Population composed of " + textBox_UtilitiesN.Text + " individuals with Deviance = " + textBox_UtilitiesDeviance.Text + " is " +
                ClassSpotoMasterRace.VariancePopulation(Convert.ToDouble(textBox_UtilitiesDeviance.Text), Convert.ToInt32(textBox_UtilitiesN.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesVarianceSample_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The Variance of the Sample composed of " + textBox_UtilitiesN.Text + " individuals with Deviance = " + textBox_UtilitiesDeviance.Text + " is " +
                ClassSpotoMasterRace.VarianceSample(Convert.ToDouble(textBox_UtilitiesDeviance.Text), Convert.ToInt32(textBox_UtilitiesN.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesCoefficientOfVariationPopulation_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The coefficient of Variation of the Population with Standard Deviation = " + textBox_UtilitiesStandardDeviationForCoefficientOfVariation.Text + " and Mean = " + textBox_UtilitiesMeanForCoefficientOfVariation.Text + " is " +
                ClassSpotoMasterRace.CoefficientOfVariationPopulation(Convert.ToDouble(textBox_UtilitiesStandardDeviationForCoefficientOfVariation.Text), Convert.ToDouble(textBox_UtilitiesMeanForCoefficientOfVariation.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesCoefficientOfVariationSample_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The coefficient of Variation of the Sample with Standard Deviation = " + textBox_UtilitiesStandardDeviationForCoefficientOfVariation.Text + " and Mean = " + textBox_UtilitiesMeanForCoefficientOfVariation.Text + " is " +
                ClassSpotoMasterRace.CoefficientOfVariationSample(Convert.ToDouble(textBox_UtilitiesStandardDeviationForCoefficientOfVariation.Text), Convert.ToDouble(textBox_UtilitiesMeanForCoefficientOfVariation.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesZScore_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The ZScore of " + textBox_UtilitiesItemForZScore.Text + " with Standard Deviation = " + textBox_UtilitiesStandardDeviationForZScore.Text + " and Mean = " + textBox_UtilitiesMeanForZScore.Text + " is " +
                ClassSpotoMasterRace.ZScore(Convert.ToDouble(textBox_UtilitiesMeanForZScore.Text), Convert.ToDouble(textBox_UtilitiesStandardDeviationForZScore.Text), Convert.ToDouble(textBox_UtilitiesItemForZScore.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesTScore_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The TScore of a ZScore of " + textBox_UtilitiesZScoreForTScore.Text + " with Standard Deviation = " + textBox_UtilitiesStandardDeviationForTScore.Text + " and Mean = " + textBox_UtilitiesMeanForTScore.Text + " is " +
                ClassSpotoMasterRace.TScore(Convert.ToDouble(textBox_UtilitiesZScoreForTScore.Text), Convert.ToDouble(textBox_UtilitiesMeanForTScore.Text), Convert.ToDouble(textBox_UtilitiesStandardDeviationForTScore.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        private void button_UtilitiesStandardDeviation_Click(object sender, EventArgs e)
        {
            richTextBox_Utilities.AppendText("The Standard Deviation of a population/sample with Variance = " + textBox_UtilitiesVariance.Text + " is " +
                ClassSpotoMasterRace.StandardDeviation(Convert.ToDouble(textBox_UtilitiesVariance.Text)) + "\n\n");
            richTextBox_Utilities.ScrollToCaret();
        }

        #endregion Utilities
    }
}