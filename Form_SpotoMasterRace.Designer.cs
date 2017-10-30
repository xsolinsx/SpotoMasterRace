namespace SpotoMasterRace
{
    partial class Form_SpotoMasterRace
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_SpotoMasterRace = new System.Windows.Forms.TabControl();
            this.tabPage_DescriptiveStatistics = new System.Windows.Forms.TabPage();
            this.groupBox_IntervalRatio = new System.Windows.Forms.GroupBox();
            this.textBox_DatumIntervalRatio = new System.Windows.Forms.TextBox();
            this.button_TScoreSample = new System.Windows.Forms.Button();
            this.button_TScorePopulation = new System.Windows.Forms.Button();
            this.button_ZScorePopulation = new System.Windows.Forms.Button();
            this.button_ZScoreSample = new System.Windows.Forms.Button();
            this.button_CoefficientOfVariationSample = new System.Windows.Forms.Button();
            this.button_CoefficientOfVariationPopulation = new System.Windows.Forms.Button();
            this.button_StandardDeviationSample = new System.Windows.Forms.Button();
            this.button_VariancePopulation = new System.Windows.Forms.Button();
            this.button_VarianceSample = new System.Windows.Forms.Button();
            this.button_Deviance = new System.Windows.Forms.Button();
            this.button_InterquartileDifference = new System.Windows.Forms.Button();
            this.button_Range = new System.Windows.Forms.Button();
            this.button_MedianInterval = new System.Windows.Forms.Button();
            this.button_StandardDeviationPopulation = new System.Windows.Forms.Button();
            this.button_Mean = new System.Windows.Forms.Button();
            this.groupBox_Ordinal = new System.Windows.Forms.GroupBox();
            this.button_PercentileRank = new System.Windows.Forms.Button();
            this.textBox_DatumOrdinal = new System.Windows.Forms.TextBox();
            this.numericUpDown_XPercentage = new System.Windows.Forms.NumericUpDown();
            this.button_XPercentage = new System.Windows.Forms.Button();
            this.button_SortData = new System.Windows.Forms.Button();
            this.button_Quartiles = new System.Windows.Forms.Button();
            this.button_MedianOrdinal = new System.Windows.Forms.Button();
            this.button_CumulativeFrequenciesPercentage = new System.Windows.Forms.Button();
            this.button_CumulativeFrequencies = new System.Windows.Forms.Button();
            this.button_ProportionsPercentage = new System.Windows.Forms.Button();
            this.button_Proportions = new System.Windows.Forms.Button();
            this.button_CheckData = new System.Windows.Forms.Button();
            this.richTextBox_Results = new System.Windows.Forms.RichTextBox();
            this.groupBox_Nominal = new System.Windows.Forms.GroupBox();
            this.button_NumberOfEquivalentClasses = new System.Windows.Forms.Button();
            this.button_Mode = new System.Windows.Forms.Button();
            this.textBox_Collection = new System.Windows.Forms.TextBox();
            this.tabControl_SpotoMasterRace.SuspendLayout();
            this.tabPage_DescriptiveStatistics.SuspendLayout();
            this.groupBox_IntervalRatio.SuspendLayout();
            this.groupBox_Ordinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_XPercentage)).BeginInit();
            this.groupBox_Nominal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_SpotoMasterRace
            // 
            this.tabControl_SpotoMasterRace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_SpotoMasterRace.Controls.Add(this.tabPage_DescriptiveStatistics);
            this.tabControl_SpotoMasterRace.Location = new System.Drawing.Point(12, 12);
            this.tabControl_SpotoMasterRace.Name = "tabControl_SpotoMasterRace";
            this.tabControl_SpotoMasterRace.SelectedIndex = 0;
            this.tabControl_SpotoMasterRace.Size = new System.Drawing.Size(554, 468);
            this.tabControl_SpotoMasterRace.TabIndex = 0;
            // 
            // tabPage_DescriptiveStatistics
            // 
            this.tabPage_DescriptiveStatistics.Controls.Add(this.groupBox_IntervalRatio);
            this.tabPage_DescriptiveStatistics.Controls.Add(this.groupBox_Ordinal);
            this.tabPage_DescriptiveStatistics.Controls.Add(this.button_CheckData);
            this.tabPage_DescriptiveStatistics.Controls.Add(this.richTextBox_Results);
            this.tabPage_DescriptiveStatistics.Controls.Add(this.groupBox_Nominal);
            this.tabPage_DescriptiveStatistics.Controls.Add(this.textBox_Collection);
            this.tabPage_DescriptiveStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DescriptiveStatistics.Name = "tabPage_DescriptiveStatistics";
            this.tabPage_DescriptiveStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DescriptiveStatistics.Size = new System.Drawing.Size(546, 442);
            this.tabPage_DescriptiveStatistics.TabIndex = 0;
            this.tabPage_DescriptiveStatistics.Text = "Descriptive Statistics";
            this.tabPage_DescriptiveStatistics.UseVisualStyleBackColor = true;
            // 
            // groupBox_IntervalRatio
            // 
            this.groupBox_IntervalRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_IntervalRatio.Controls.Add(this.textBox_DatumIntervalRatio);
            this.groupBox_IntervalRatio.Controls.Add(this.button_TScoreSample);
            this.groupBox_IntervalRatio.Controls.Add(this.button_TScorePopulation);
            this.groupBox_IntervalRatio.Controls.Add(this.button_ZScorePopulation);
            this.groupBox_IntervalRatio.Controls.Add(this.button_ZScoreSample);
            this.groupBox_IntervalRatio.Controls.Add(this.button_CoefficientOfVariationSample);
            this.groupBox_IntervalRatio.Controls.Add(this.button_CoefficientOfVariationPopulation);
            this.groupBox_IntervalRatio.Controls.Add(this.button_StandardDeviationSample);
            this.groupBox_IntervalRatio.Controls.Add(this.button_VariancePopulation);
            this.groupBox_IntervalRatio.Controls.Add(this.button_VarianceSample);
            this.groupBox_IntervalRatio.Controls.Add(this.button_Deviance);
            this.groupBox_IntervalRatio.Controls.Add(this.button_InterquartileDifference);
            this.groupBox_IntervalRatio.Controls.Add(this.button_Range);
            this.groupBox_IntervalRatio.Controls.Add(this.button_MedianInterval);
            this.groupBox_IntervalRatio.Controls.Add(this.button_StandardDeviationPopulation);
            this.groupBox_IntervalRatio.Controls.Add(this.button_Mean);
            this.groupBox_IntervalRatio.Location = new System.Drawing.Point(282, 32);
            this.groupBox_IntervalRatio.Name = "groupBox_IntervalRatio";
            this.groupBox_IntervalRatio.Size = new System.Drawing.Size(258, 298);
            this.groupBox_IntervalRatio.TabIndex = 6;
            this.groupBox_IntervalRatio.TabStop = false;
            this.groupBox_IntervalRatio.Text = "Interval/Ratio";
            // 
            // textBox_DatumIntervalRatio
            // 
            this.textBox_DatumIntervalRatio.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DatumIntervalRatio.Location = new System.Drawing.Point(6, 244);
            this.textBox_DatumIntervalRatio.Name = "textBox_DatumIntervalRatio";
            this.textBox_DatumIntervalRatio.Size = new System.Drawing.Size(78, 20);
            this.textBox_DatumIntervalRatio.TabIndex = 20;
            this.textBox_DatumIntervalRatio.Text = "Datum";
            this.textBox_DatumIntervalRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_TScoreSample
            // 
            this.button_TScoreSample.Location = new System.Drawing.Point(90, 258);
            this.button_TScoreSample.Name = "button_TScoreSample";
            this.button_TScoreSample.Size = new System.Drawing.Size(78, 34);
            this.button_TScoreSample.TabIndex = 19;
            this.button_TScoreSample.Text = "TScore Sample";
            this.button_TScoreSample.UseVisualStyleBackColor = true;
            this.button_TScoreSample.Visible = false;
            this.button_TScoreSample.Click += new System.EventHandler(this.button_TScoreSample_Click);
            // 
            // button_TScorePopulation
            // 
            this.button_TScorePopulation.Location = new System.Drawing.Point(90, 218);
            this.button_TScorePopulation.Name = "button_TScorePopulation";
            this.button_TScorePopulation.Size = new System.Drawing.Size(78, 34);
            this.button_TScorePopulation.TabIndex = 18;
            this.button_TScorePopulation.Text = "TScore Population";
            this.button_TScorePopulation.UseVisualStyleBackColor = true;
            this.button_TScorePopulation.Visible = false;
            this.button_TScorePopulation.Click += new System.EventHandler(this.button_TScorePopulation_Click);
            // 
            // button_ZScorePopulation
            // 
            this.button_ZScorePopulation.Location = new System.Drawing.Point(174, 218);
            this.button_ZScorePopulation.Name = "button_ZScorePopulation";
            this.button_ZScorePopulation.Size = new System.Drawing.Size(78, 34);
            this.button_ZScorePopulation.TabIndex = 17;
            this.button_ZScorePopulation.Text = "ZScore Population";
            this.button_ZScorePopulation.UseVisualStyleBackColor = true;
            this.button_ZScorePopulation.Click += new System.EventHandler(this.button_ZScorePopulation_Click);
            // 
            // button_ZScoreSample
            // 
            this.button_ZScoreSample.Location = new System.Drawing.Point(174, 258);
            this.button_ZScoreSample.Name = "button_ZScoreSample";
            this.button_ZScoreSample.Size = new System.Drawing.Size(78, 34);
            this.button_ZScoreSample.TabIndex = 16;
            this.button_ZScoreSample.Text = "ZScore Sample";
            this.button_ZScoreSample.UseVisualStyleBackColor = true;
            this.button_ZScoreSample.Click += new System.EventHandler(this.button_ZScoreSample_Click);
            // 
            // button_CoefficientOfVariationSample
            // 
            this.button_CoefficientOfVariationSample.Location = new System.Drawing.Point(90, 152);
            this.button_CoefficientOfVariationSample.Name = "button_CoefficientOfVariationSample";
            this.button_CoefficientOfVariationSample.Size = new System.Drawing.Size(78, 47);
            this.button_CoefficientOfVariationSample.TabIndex = 15;
            this.button_CoefficientOfVariationSample.Text = "Coefficient of Variation Sample";
            this.button_CoefficientOfVariationSample.UseVisualStyleBackColor = true;
            this.button_CoefficientOfVariationSample.Click += new System.EventHandler(this.button_CoefficientOfVariationSample_Click);
            // 
            // button_CoefficientOfVariationPopulation
            // 
            this.button_CoefficientOfVariationPopulation.Location = new System.Drawing.Point(6, 152);
            this.button_CoefficientOfVariationPopulation.Name = "button_CoefficientOfVariationPopulation";
            this.button_CoefficientOfVariationPopulation.Size = new System.Drawing.Size(78, 47);
            this.button_CoefficientOfVariationPopulation.TabIndex = 14;
            this.button_CoefficientOfVariationPopulation.Text = "Coefficient of Variation Population";
            this.button_CoefficientOfVariationPopulation.UseVisualStyleBackColor = true;
            this.button_CoefficientOfVariationPopulation.Click += new System.EventHandler(this.button_CoefficientOfVariationPopulation_Click);
            // 
            // button_StandardDeviationSample
            // 
            this.button_StandardDeviationSample.Location = new System.Drawing.Point(174, 99);
            this.button_StandardDeviationSample.Name = "button_StandardDeviationSample";
            this.button_StandardDeviationSample.Size = new System.Drawing.Size(78, 47);
            this.button_StandardDeviationSample.TabIndex = 13;
            this.button_StandardDeviationSample.Text = "Standard Deviation Sample";
            this.button_StandardDeviationSample.UseVisualStyleBackColor = true;
            this.button_StandardDeviationSample.Click += new System.EventHandler(this.button_StandardDeviationSample_Click);
            // 
            // button_VariancePopulation
            // 
            this.button_VariancePopulation.Location = new System.Drawing.Point(174, 59);
            this.button_VariancePopulation.Name = "button_VariancePopulation";
            this.button_VariancePopulation.Size = new System.Drawing.Size(78, 34);
            this.button_VariancePopulation.TabIndex = 12;
            this.button_VariancePopulation.Text = "Variance Population";
            this.button_VariancePopulation.UseVisualStyleBackColor = true;
            this.button_VariancePopulation.Click += new System.EventHandler(this.button_VariancePopulation_Click);
            // 
            // button_VarianceSample
            // 
            this.button_VarianceSample.Location = new System.Drawing.Point(6, 101);
            this.button_VarianceSample.Name = "button_VarianceSample";
            this.button_VarianceSample.Size = new System.Drawing.Size(78, 34);
            this.button_VarianceSample.TabIndex = 11;
            this.button_VarianceSample.Text = "Variance Sample";
            this.button_VarianceSample.UseVisualStyleBackColor = true;
            this.button_VarianceSample.Click += new System.EventHandler(this.button_VarianceSample_Click);
            // 
            // button_Deviance
            // 
            this.button_Deviance.Location = new System.Drawing.Point(90, 59);
            this.button_Deviance.Name = "button_Deviance";
            this.button_Deviance.Size = new System.Drawing.Size(78, 23);
            this.button_Deviance.TabIndex = 10;
            this.button_Deviance.Text = "Deviance";
            this.button_Deviance.UseVisualStyleBackColor = true;
            this.button_Deviance.Click += new System.EventHandler(this.button_Deviance_Click);
            // 
            // button_InterquartileDifference
            // 
            this.button_InterquartileDifference.Location = new System.Drawing.Point(174, 19);
            this.button_InterquartileDifference.Name = "button_InterquartileDifference";
            this.button_InterquartileDifference.Size = new System.Drawing.Size(78, 34);
            this.button_InterquartileDifference.TabIndex = 9;
            this.button_InterquartileDifference.Text = "Interquartile Difference";
            this.button_InterquartileDifference.UseVisualStyleBackColor = true;
            this.button_InterquartileDifference.Click += new System.EventHandler(this.button_InterquartileDifference_Click);
            // 
            // button_Range
            // 
            this.button_Range.Location = new System.Drawing.Point(6, 59);
            this.button_Range.Name = "button_Range";
            this.button_Range.Size = new System.Drawing.Size(78, 23);
            this.button_Range.TabIndex = 5;
            this.button_Range.Text = "Range";
            this.button_Range.UseVisualStyleBackColor = true;
            this.button_Range.Click += new System.EventHandler(this.button_Range_Click);
            // 
            // button_MedianInterval
            // 
            this.button_MedianInterval.Location = new System.Drawing.Point(90, 19);
            this.button_MedianInterval.Name = "button_MedianInterval";
            this.button_MedianInterval.Size = new System.Drawing.Size(78, 23);
            this.button_MedianInterval.TabIndex = 4;
            this.button_MedianInterval.Text = "Median";
            this.button_MedianInterval.UseVisualStyleBackColor = true;
            this.button_MedianInterval.Click += new System.EventHandler(this.button_MedianInterval_Click);
            // 
            // button_StandardDeviationPopulation
            // 
            this.button_StandardDeviationPopulation.Location = new System.Drawing.Point(90, 99);
            this.button_StandardDeviationPopulation.Name = "button_StandardDeviationPopulation";
            this.button_StandardDeviationPopulation.Size = new System.Drawing.Size(78, 47);
            this.button_StandardDeviationPopulation.TabIndex = 3;
            this.button_StandardDeviationPopulation.Text = "Standard Deviation Population";
            this.button_StandardDeviationPopulation.UseVisualStyleBackColor = true;
            this.button_StandardDeviationPopulation.Click += new System.EventHandler(this.button_StandardDeviationPopulation_Click);
            // 
            // button_Mean
            // 
            this.button_Mean.Location = new System.Drawing.Point(6, 19);
            this.button_Mean.Name = "button_Mean";
            this.button_Mean.Size = new System.Drawing.Size(78, 23);
            this.button_Mean.TabIndex = 0;
            this.button_Mean.Text = "Mean";
            this.button_Mean.UseVisualStyleBackColor = true;
            this.button_Mean.Click += new System.EventHandler(this.button_Mean_Click);
            // 
            // groupBox_Ordinal
            // 
            this.groupBox_Ordinal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_Ordinal.Controls.Add(this.button_PercentileRank);
            this.groupBox_Ordinal.Controls.Add(this.textBox_DatumOrdinal);
            this.groupBox_Ordinal.Controls.Add(this.numericUpDown_XPercentage);
            this.groupBox_Ordinal.Controls.Add(this.button_XPercentage);
            this.groupBox_Ordinal.Controls.Add(this.button_SortData);
            this.groupBox_Ordinal.Controls.Add(this.button_Quartiles);
            this.groupBox_Ordinal.Controls.Add(this.button_MedianOrdinal);
            this.groupBox_Ordinal.Controls.Add(this.button_CumulativeFrequenciesPercentage);
            this.groupBox_Ordinal.Controls.Add(this.button_CumulativeFrequencies);
            this.groupBox_Ordinal.Controls.Add(this.button_ProportionsPercentage);
            this.groupBox_Ordinal.Controls.Add(this.button_Proportions);
            this.groupBox_Ordinal.Location = new System.Drawing.Point(102, 32);
            this.groupBox_Ordinal.Name = "groupBox_Ordinal";
            this.groupBox_Ordinal.Size = new System.Drawing.Size(174, 298);
            this.groupBox_Ordinal.TabIndex = 4;
            this.groupBox_Ordinal.TabStop = false;
            this.groupBox_Ordinal.Text = "Ordinal";
            // 
            // button_PercentileRank
            // 
            this.button_PercentileRank.Location = new System.Drawing.Point(90, 218);
            this.button_PercentileRank.Name = "button_PercentileRank";
            this.button_PercentileRank.Size = new System.Drawing.Size(78, 34);
            this.button_PercentileRank.TabIndex = 9;
            this.button_PercentileRank.Text = "Percentile Rank";
            this.button_PercentileRank.UseVisualStyleBackColor = true;
            this.button_PercentileRank.Click += new System.EventHandler(this.button_PercentileRank_Click);
            // 
            // textBox_DatumOrdinal
            // 
            this.textBox_DatumOrdinal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DatumOrdinal.Location = new System.Drawing.Point(6, 227);
            this.textBox_DatumOrdinal.Name = "textBox_DatumOrdinal";
            this.textBox_DatumOrdinal.Size = new System.Drawing.Size(78, 20);
            this.textBox_DatumOrdinal.TabIndex = 5;
            this.textBox_DatumOrdinal.Text = "Datum";
            this.textBox_DatumOrdinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_XPercentage
            // 
            this.numericUpDown_XPercentage.Location = new System.Drawing.Point(6, 267);
            this.numericUpDown_XPercentage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown_XPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_XPercentage.Name = "numericUpDown_XPercentage";
            this.numericUpDown_XPercentage.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown_XPercentage.TabIndex = 8;
            this.numericUpDown_XPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_XPercentage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_XPercentage.ValueChanged += new System.EventHandler(this.numericUpDown_XPercentage_ValueChanged);
            // 
            // button_XPercentage
            // 
            this.button_XPercentage.Location = new System.Drawing.Point(90, 258);
            this.button_XPercentage.Name = "button_XPercentage";
            this.button_XPercentage.Size = new System.Drawing.Size(78, 34);
            this.button_XPercentage.TabIndex = 7;
            this.button_XPercentage.Text = "XPercentage";
            this.button_XPercentage.UseVisualStyleBackColor = true;
            this.button_XPercentage.Click += new System.EventHandler(this.button_XPercentage_Click);
            // 
            // button_SortData
            // 
            this.button_SortData.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_SortData.Location = new System.Drawing.Point(3, 16);
            this.button_SortData.Name = "button_SortData";
            this.button_SortData.Size = new System.Drawing.Size(168, 23);
            this.button_SortData.TabIndex = 6;
            this.button_SortData.Text = "Sort Data";
            this.button_SortData.UseVisualStyleBackColor = true;
            this.button_SortData.Click += new System.EventHandler(this.button_SortData_Click);
            // 
            // button_Quartiles
            // 
            this.button_Quartiles.Location = new System.Drawing.Point(90, 141);
            this.button_Quartiles.Name = "button_Quartiles";
            this.button_Quartiles.Size = new System.Drawing.Size(78, 23);
            this.button_Quartiles.TabIndex = 5;
            this.button_Quartiles.Text = "Quartiles";
            this.button_Quartiles.UseVisualStyleBackColor = true;
            this.button_Quartiles.Click += new System.EventHandler(this.button_Quartiles_Click);
            // 
            // button_MedianOrdinal
            // 
            this.button_MedianOrdinal.Location = new System.Drawing.Point(6, 141);
            this.button_MedianOrdinal.Name = "button_MedianOrdinal";
            this.button_MedianOrdinal.Size = new System.Drawing.Size(78, 23);
            this.button_MedianOrdinal.TabIndex = 4;
            this.button_MedianOrdinal.Text = "Median";
            this.button_MedianOrdinal.UseVisualStyleBackColor = true;
            this.button_MedianOrdinal.Click += new System.EventHandler(this.button_MedianOrdinal_Click);
            // 
            // button_CumulativeFrequenciesPercentage
            // 
            this.button_CumulativeFrequenciesPercentage.Location = new System.Drawing.Point(90, 88);
            this.button_CumulativeFrequenciesPercentage.Name = "button_CumulativeFrequenciesPercentage";
            this.button_CumulativeFrequenciesPercentage.Size = new System.Drawing.Size(78, 47);
            this.button_CumulativeFrequenciesPercentage.TabIndex = 3;
            this.button_CumulativeFrequenciesPercentage.Text = "Cumulative Frequencies%";
            this.button_CumulativeFrequenciesPercentage.UseVisualStyleBackColor = true;
            this.button_CumulativeFrequenciesPercentage.Click += new System.EventHandler(this.button_CumulativeFrequenciesPercentage_Click);
            // 
            // button_CumulativeFrequencies
            // 
            this.button_CumulativeFrequencies.Location = new System.Drawing.Point(6, 88);
            this.button_CumulativeFrequencies.Name = "button_CumulativeFrequencies";
            this.button_CumulativeFrequencies.Size = new System.Drawing.Size(78, 34);
            this.button_CumulativeFrequencies.TabIndex = 2;
            this.button_CumulativeFrequencies.Text = "Cumulative Frequencies";
            this.button_CumulativeFrequencies.UseVisualStyleBackColor = true;
            this.button_CumulativeFrequencies.Click += new System.EventHandler(this.button_CumulativeFrequencies_Click);
            // 
            // button_ProportionsPercentage
            // 
            this.button_ProportionsPercentage.Location = new System.Drawing.Point(90, 48);
            this.button_ProportionsPercentage.Name = "button_ProportionsPercentage";
            this.button_ProportionsPercentage.Size = new System.Drawing.Size(78, 34);
            this.button_ProportionsPercentage.TabIndex = 1;
            this.button_ProportionsPercentage.Text = "Proportions %";
            this.button_ProportionsPercentage.UseVisualStyleBackColor = true;
            this.button_ProportionsPercentage.Click += new System.EventHandler(this.button_ProportionsPercentage_Click);
            // 
            // button_Proportions
            // 
            this.button_Proportions.Location = new System.Drawing.Point(6, 48);
            this.button_Proportions.Name = "button_Proportions";
            this.button_Proportions.Size = new System.Drawing.Size(78, 23);
            this.button_Proportions.TabIndex = 0;
            this.button_Proportions.Text = "Proportions";
            this.button_Proportions.UseVisualStyleBackColor = true;
            this.button_Proportions.Click += new System.EventHandler(this.button_Proportions_Click);
            // 
            // button_CheckData
            // 
            this.button_CheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CheckData.Location = new System.Drawing.Point(465, 6);
            this.button_CheckData.Name = "button_CheckData";
            this.button_CheckData.Size = new System.Drawing.Size(75, 20);
            this.button_CheckData.TabIndex = 3;
            this.button_CheckData.Text = "Check Data";
            this.button_CheckData.UseVisualStyleBackColor = true;
            this.button_CheckData.Click += new System.EventHandler(this.button_CheckData_Click);
            // 
            // richTextBox_Results
            // 
            this.richTextBox_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Results.Location = new System.Drawing.Point(6, 336);
            this.richTextBox_Results.Name = "richTextBox_Results";
            this.richTextBox_Results.ReadOnly = true;
            this.richTextBox_Results.Size = new System.Drawing.Size(534, 100);
            this.richTextBox_Results.TabIndex = 2;
            this.richTextBox_Results.Text = "";
            // 
            // groupBox_Nominal
            // 
            this.groupBox_Nominal.Controls.Add(this.button_NumberOfEquivalentClasses);
            this.groupBox_Nominal.Controls.Add(this.button_Mode);
            this.groupBox_Nominal.Location = new System.Drawing.Point(6, 32);
            this.groupBox_Nominal.Name = "groupBox_Nominal";
            this.groupBox_Nominal.Size = new System.Drawing.Size(90, 77);
            this.groupBox_Nominal.TabIndex = 2;
            this.groupBox_Nominal.TabStop = false;
            this.groupBox_Nominal.Text = "Nominal";
            // 
            // button_NumberOfEquivalentClasses
            // 
            this.button_NumberOfEquivalentClasses.Location = new System.Drawing.Point(6, 48);
            this.button_NumberOfEquivalentClasses.Name = "button_NumberOfEquivalentClasses";
            this.button_NumberOfEquivalentClasses.Size = new System.Drawing.Size(78, 23);
            this.button_NumberOfEquivalentClasses.TabIndex = 1;
            this.button_NumberOfEquivalentClasses.Text = "NEC";
            this.button_NumberOfEquivalentClasses.UseVisualStyleBackColor = true;
            this.button_NumberOfEquivalentClasses.Click += new System.EventHandler(this.button_NumberOfEquivalentClasses_Click);
            // 
            // button_Mode
            // 
            this.button_Mode.Location = new System.Drawing.Point(6, 19);
            this.button_Mode.Name = "button_Mode";
            this.button_Mode.Size = new System.Drawing.Size(78, 23);
            this.button_Mode.TabIndex = 0;
            this.button_Mode.Text = "Mode";
            this.button_Mode.UseVisualStyleBackColor = true;
            this.button_Mode.Click += new System.EventHandler(this.button_Mode_Click);
            // 
            // textBox_Collection
            // 
            this.textBox_Collection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Collection.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Collection.Location = new System.Drawing.Point(6, 6);
            this.textBox_Collection.Name = "textBox_Collection";
            this.textBox_Collection.Size = new System.Drawing.Size(453, 20);
            this.textBox_Collection.TabIndex = 1;
            this.textBox_Collection.Text = "Comma Separated Values like 3,4,4,4,5,7,9,8,52444.100,49.5555555 or Bryan, Ryan, " +
    "Liam";
            this.textBox_Collection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form_SpotoMasterRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 492);
            this.Controls.Add(this.tabControl_SpotoMasterRace);
            this.MinimumSize = new System.Drawing.Size(594, 531);
            this.Name = "Form_SpotoMasterRace";
            this.Text = "SpotoMasterRace";
            this.tabControl_SpotoMasterRace.ResumeLayout(false);
            this.tabPage_DescriptiveStatistics.ResumeLayout(false);
            this.tabPage_DescriptiveStatistics.PerformLayout();
            this.groupBox_IntervalRatio.ResumeLayout(false);
            this.groupBox_IntervalRatio.PerformLayout();
            this.groupBox_Ordinal.ResumeLayout(false);
            this.groupBox_Ordinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_XPercentage)).EndInit();
            this.groupBox_Nominal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_SpotoMasterRace;
        private System.Windows.Forms.TabPage tabPage_DescriptiveStatistics;
        private System.Windows.Forms.TextBox textBox_Collection;
        private System.Windows.Forms.GroupBox groupBox_Nominal;
        private System.Windows.Forms.Button button_NumberOfEquivalentClasses;
        private System.Windows.Forms.Button button_Mode;
        private System.Windows.Forms.RichTextBox richTextBox_Results;
        private System.Windows.Forms.Button button_CheckData;
        private System.Windows.Forms.GroupBox groupBox_Ordinal;
        private System.Windows.Forms.Button button_ProportionsPercentage;
        private System.Windows.Forms.Button button_Proportions;
        private System.Windows.Forms.Button button_CumulativeFrequenciesPercentage;
        private System.Windows.Forms.Button button_CumulativeFrequencies;
        private System.Windows.Forms.Button button_MedianOrdinal;
        private System.Windows.Forms.Button button_Quartiles;
        private System.Windows.Forms.Button button_SortData;
        private System.Windows.Forms.Button button_XPercentage;
        private System.Windows.Forms.NumericUpDown numericUpDown_XPercentage;
        private System.Windows.Forms.Button button_PercentileRank;
        private System.Windows.Forms.TextBox textBox_DatumOrdinal;
        private System.Windows.Forms.GroupBox groupBox_IntervalRatio;
        private System.Windows.Forms.Button button_InterquartileDifference;
        private System.Windows.Forms.Button button_Range;
        private System.Windows.Forms.Button button_MedianInterval;
        private System.Windows.Forms.Button button_StandardDeviationPopulation;
        private System.Windows.Forms.Button button_Mean;
        private System.Windows.Forms.Button button_Deviance;
        private System.Windows.Forms.Button button_VariancePopulation;
        private System.Windows.Forms.Button button_VarianceSample;
        private System.Windows.Forms.Button button_StandardDeviationSample;
        private System.Windows.Forms.Button button_CoefficientOfVariationSample;
        private System.Windows.Forms.Button button_CoefficientOfVariationPopulation;
        private System.Windows.Forms.Button button_TScoreSample;
        private System.Windows.Forms.Button button_TScorePopulation;
        private System.Windows.Forms.Button button_ZScorePopulation;
        private System.Windows.Forms.Button button_ZScoreSample;
        private System.Windows.Forms.TextBox textBox_DatumIntervalRatio;

    }
}

