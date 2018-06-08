namespace MLP_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.bToggleController = new System.Windows.Forms.Button();
            this.bControllerStep = new System.Windows.Forms.Button();
            this.bControllerReset = new System.Windows.Forms.Button();
            this.bClearLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbValueTest = new System.Windows.Forms.TextBox();
            this.bTestValues = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbNumericResult = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbErrorResult = new System.Windows.Forms.Label();
            this.lbTestResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.tbLearningRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnbatch = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbmnist3 = new System.Windows.Forms.Label();
            this.lbmnist2 = new System.Windows.Forms.Label();
            this.lbmnist1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbiris3 = new System.Windows.Forms.Label();
            this.lbiris2 = new System.Windows.Forms.Label();
            this.lbiris1 = new System.Windows.Forms.Label();
            this.lbIterationNumber = new System.Windows.Forms.Label();
            this.lbElapsed = new System.Windows.Forms.Label();
            this.lbBestError = new System.Windows.Forms.Label();
            this.btnWeightCharts = new System.Windows.Forms.Button();
            this.IMG_NetworkTopography = new System.Windows.Forms.PictureBox();
            this.tbStructure = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bConstruct = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbMNIST = new System.Windows.Forms.RadioButton();
            this.rbIris = new System.Windows.Forms.RadioButton();
            this.consoleUpdater = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cartesianChart3 = new LiveCharts.WinForms.CartesianChart();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbDisableCharts = new System.Windows.Forms.CheckBox();
            this.cbdisabledrawing = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMG_NetworkTopography)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cartesianChart1.Location = new System.Drawing.Point(8, 16);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(368, 168);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cartesianChart2.Location = new System.Drawing.Point(8, 408);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(368, 168);
            this.cartesianChart2.TabIndex = 1;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.cbDisableCharts);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cartesianChart3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cartesianChart1);
            this.groupBox1.Controls.Add(this.cartesianChart2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 616);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Process Time over iterations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Error over Iterations";
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.Color.Ivory;
            this.rtbConsole.Location = new System.Drawing.Point(408, 8);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(320, 432);
            this.rtbConsole.TabIndex = 3;
            this.rtbConsole.Text = "";
            // 
            // bToggleController
            // 
            this.bToggleController.BackColor = System.Drawing.SystemColors.Control;
            this.bToggleController.Location = new System.Drawing.Point(8, 16);
            this.bToggleController.Name = "bToggleController";
            this.bToggleController.Size = new System.Drawing.Size(64, 32);
            this.bToggleController.TabIndex = 4;
            this.bToggleController.Text = "Train";
            this.bToggleController.UseVisualStyleBackColor = false;
            this.bToggleController.Click += new System.EventHandler(this.bToggleController_Click);
            // 
            // bControllerStep
            // 
            this.bControllerStep.BackColor = System.Drawing.SystemColors.Control;
            this.bControllerStep.Location = new System.Drawing.Point(200, 16);
            this.bControllerStep.Name = "bControllerStep";
            this.bControllerStep.Size = new System.Drawing.Size(40, 32);
            this.bControllerStep.TabIndex = 5;
            this.bControllerStep.Text = "Step";
            this.bControllerStep.UseVisualStyleBackColor = false;
            this.bControllerStep.Click += new System.EventHandler(this.bControllerStep_Click);
            // 
            // bControllerReset
            // 
            this.bControllerReset.BackColor = System.Drawing.SystemColors.Control;
            this.bControllerReset.Location = new System.Drawing.Point(240, 16);
            this.bControllerReset.Name = "bControllerReset";
            this.bControllerReset.Size = new System.Drawing.Size(48, 32);
            this.bControllerReset.TabIndex = 6;
            this.bControllerReset.Text = "Reset";
            this.bControllerReset.UseVisualStyleBackColor = false;
            this.bControllerReset.Click += new System.EventHandler(this.bControllerReset_Click);
            // 
            // bClearLog
            // 
            this.bClearLog.BackColor = System.Drawing.SystemColors.Control;
            this.bClearLog.Location = new System.Drawing.Point(288, 16);
            this.bClearLog.Name = "bClearLog";
            this.bClearLog.Size = new System.Drawing.Size(64, 32);
            this.bClearLog.TabIndex = 7;
            this.bClearLog.Text = "Clear Log";
            this.bClearLog.UseVisualStyleBackColor = false;
            this.bClearLog.Click += new System.EventHandler(this.bClearLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Best Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time Elapsed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Iteration Number";
            // 
            // tbValueTest
            // 
            this.tbValueTest.Location = new System.Drawing.Point(8, 16);
            this.tbValueTest.Name = "tbValueTest";
            this.tbValueTest.Size = new System.Drawing.Size(208, 20);
            this.tbValueTest.TabIndex = 12;
            this.tbValueTest.Text = "5.1 3.5 1.4 0.2 0";
            // 
            // bTestValues
            // 
            this.bTestValues.BackColor = System.Drawing.SystemColors.Control;
            this.bTestValues.Location = new System.Drawing.Point(8, 48);
            this.bTestValues.Name = "bTestValues";
            this.bTestValues.Size = new System.Drawing.Size(88, 48);
            this.bTestValues.TabIndex = 13;
            this.bTestValues.Text = "Test Values";
            this.bTestValues.UseVisualStyleBackColor = false;
            this.bTestValues.Click += new System.EventHandler(this.bTestValues_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Result:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.lbNumericResult);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbErrorResult);
            this.groupBox2.Controls.Add(this.lbTestResult);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bTestValues);
            this.groupBox2.Controls.Add(this.tbValueTest);
            this.groupBox2.Location = new System.Drawing.Point(408, 512);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 112);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Value Test";
            // 
            // lbNumericResult
            // 
            this.lbNumericResult.AutoSize = true;
            this.lbNumericResult.Location = new System.Drawing.Point(176, 64);
            this.lbNumericResult.Name = "lbNumericResult";
            this.lbNumericResult.Size = new System.Drawing.Size(10, 13);
            this.lbNumericResult.TabIndex = 19;
            this.lbNumericResult.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(96, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Numeric Result:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // lbErrorResult
            // 
            this.lbErrorResult.AutoSize = true;
            this.lbErrorResult.Location = new System.Drawing.Point(176, 80);
            this.lbErrorResult.Name = "lbErrorResult";
            this.lbErrorResult.Size = new System.Drawing.Size(10, 13);
            this.lbErrorResult.TabIndex = 17;
            this.lbErrorResult.Text = ".";
            // 
            // lbTestResult
            // 
            this.lbTestResult.AutoSize = true;
            this.lbTestResult.Location = new System.Drawing.Point(176, 48);
            this.lbTestResult.Name = "lbTestResult";
            this.lbTestResult.Size = new System.Drawing.Size(10, 13);
            this.lbTestResult.TabIndex = 16;
            this.lbTestResult.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Error:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.nudIterations);
            this.groupBox3.Controls.Add(this.bClearLog);
            this.groupBox3.Controls.Add(this.bControllerReset);
            this.groupBox3.Controls.Add(this.bControllerStep);
            this.groupBox3.Controls.Add(this.bToggleController);
            this.groupBox3.Controls.Add(this.tbLearningRate);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(408, 448);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 56);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Iterations:";
            // 
            // nudIterations
            // 
            this.nudIterations.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudIterations.Location = new System.Drawing.Point(128, 24);
            this.nudIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(64, 20);
            this.nudIterations.TabIndex = 16;
            this.nudIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tbLearningRate
            // 
            this.tbLearningRate.Location = new System.Drawing.Point(424, 24);
            this.tbLearningRate.Name = "tbLearningRate";
            this.tbLearningRate.Size = new System.Drawing.Size(64, 20);
            this.tbLearningRate.TabIndex = 23;
            this.tbLearningRate.Text = "0.02";
            this.tbLearningRate.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "LearningRate";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.lbIterationNumber);
            this.groupBox4.Controls.Add(this.lbElapsed);
            this.groupBox4.Controls.Add(this.lbBestError);
            this.groupBox4.Controls.Add(this.btnWeightCharts);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(736, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 432);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Results";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnbatch);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Location = new System.Drawing.Point(8, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(152, 240);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Test Values";
            // 
            // btnbatch
            // 
            this.btnbatch.BackColor = System.Drawing.SystemColors.Control;
            this.btnbatch.Location = new System.Drawing.Point(8, 208);
            this.btnbatch.Name = "btnbatch";
            this.btnbatch.Size = new System.Drawing.Size(144, 31);
            this.btnbatch.TabIndex = 3;
            this.btnbatch.Text = "Batch Validate";
            this.btnbatch.UseVisualStyleBackColor = false;
            this.btnbatch.Click += new System.EventHandler(this.btnbatch_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.LightGray;
            this.groupBox8.Controls.Add(this.lbmnist3);
            this.groupBox8.Controls.Add(this.lbmnist2);
            this.groupBox8.Controls.Add(this.lbmnist1);
            this.groupBox8.Location = new System.Drawing.Point(8, 120);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(136, 80);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "MNIST";
            // 
            // lbmnist3
            // 
            this.lbmnist3.AutoSize = true;
            this.lbmnist3.BackColor = System.Drawing.Color.DarkGray;
            this.lbmnist3.Location = new System.Drawing.Point(16, 56);
            this.lbmnist3.Name = "lbmnist3";
            this.lbmnist3.Size = new System.Drawing.Size(56, 13);
            this.lbmnist3.TabIndex = 2;
            this.lbmnist3.Text = "Example 3";
            this.lbmnist3.Click += new System.EventHandler(this.lbmnist3_Click);
            // 
            // lbmnist2
            // 
            this.lbmnist2.AutoSize = true;
            this.lbmnist2.BackColor = System.Drawing.Color.DarkGray;
            this.lbmnist2.Location = new System.Drawing.Point(16, 40);
            this.lbmnist2.Name = "lbmnist2";
            this.lbmnist2.Size = new System.Drawing.Size(56, 13);
            this.lbmnist2.TabIndex = 1;
            this.lbmnist2.Text = "Example 2";
            this.lbmnist2.Click += new System.EventHandler(this.lbmnist2_Click);
            // 
            // lbmnist1
            // 
            this.lbmnist1.AutoSize = true;
            this.lbmnist1.BackColor = System.Drawing.Color.DarkGray;
            this.lbmnist1.Location = new System.Drawing.Point(16, 24);
            this.lbmnist1.Name = "lbmnist1";
            this.lbmnist1.Size = new System.Drawing.Size(56, 13);
            this.lbmnist1.TabIndex = 0;
            this.lbmnist1.Text = "Example 1";
            this.lbmnist1.Click += new System.EventHandler(this.lbmnist1_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.LightGray;
            this.groupBox7.Controls.Add(this.lbiris3);
            this.groupBox7.Controls.Add(this.lbiris2);
            this.groupBox7.Controls.Add(this.lbiris1);
            this.groupBox7.Location = new System.Drawing.Point(8, 32);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(136, 80);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "IRIS";
            // 
            // lbiris3
            // 
            this.lbiris3.AutoSize = true;
            this.lbiris3.BackColor = System.Drawing.Color.DarkGray;
            this.lbiris3.Location = new System.Drawing.Point(16, 56);
            this.lbiris3.Name = "lbiris3";
            this.lbiris3.Size = new System.Drawing.Size(85, 13);
            this.lbiris3.TabIndex = 2;
            this.lbiris3.Text = "6.2 3.4 5.4 2.3 2";
            this.lbiris3.Click += new System.EventHandler(this.lbiris3_Click);
            // 
            // lbiris2
            // 
            this.lbiris2.AutoSize = true;
            this.lbiris2.BackColor = System.Drawing.Color.DarkGray;
            this.lbiris2.Location = new System.Drawing.Point(16, 40);
            this.lbiris2.Name = "lbiris2";
            this.lbiris2.Size = new System.Drawing.Size(85, 13);
            this.lbiris2.TabIndex = 1;
            this.lbiris2.Text = "5.7 2.6 3.5 1.0 1";
            this.lbiris2.Click += new System.EventHandler(this.lbiris2_Click);
            // 
            // lbiris1
            // 
            this.lbiris1.AutoSize = true;
            this.lbiris1.BackColor = System.Drawing.Color.DarkGray;
            this.lbiris1.Location = new System.Drawing.Point(16, 24);
            this.lbiris1.Name = "lbiris1";
            this.lbiris1.Size = new System.Drawing.Size(85, 13);
            this.lbiris1.TabIndex = 0;
            this.lbiris1.Text = "5.1 3.5 1.4 0.2 0";
            this.lbiris1.Click += new System.EventHandler(this.lbiris1_Click);
            // 
            // lbIterationNumber
            // 
            this.lbIterationNumber.AutoSize = true;
            this.lbIterationNumber.Location = new System.Drawing.Point(96, 72);
            this.lbIterationNumber.Name = "lbIterationNumber";
            this.lbIterationNumber.Size = new System.Drawing.Size(10, 13);
            this.lbIterationNumber.TabIndex = 19;
            this.lbIterationNumber.Text = ".";
            // 
            // lbElapsed
            // 
            this.lbElapsed.AutoSize = true;
            this.lbElapsed.Location = new System.Drawing.Point(96, 48);
            this.lbElapsed.Name = "lbElapsed";
            this.lbElapsed.Size = new System.Drawing.Size(10, 13);
            this.lbElapsed.TabIndex = 18;
            this.lbElapsed.Text = ".";
            // 
            // lbBestError
            // 
            this.lbBestError.AutoSize = true;
            this.lbBestError.Location = new System.Drawing.Point(96, 24);
            this.lbBestError.Name = "lbBestError";
            this.lbBestError.Size = new System.Drawing.Size(10, 13);
            this.lbBestError.TabIndex = 17;
            this.lbBestError.Text = ".";
            // 
            // btnWeightCharts
            // 
            this.btnWeightCharts.BackColor = System.Drawing.SystemColors.Control;
            this.btnWeightCharts.Location = new System.Drawing.Point(16, 376);
            this.btnWeightCharts.Name = "btnWeightCharts";
            this.btnWeightCharts.Size = new System.Drawing.Size(144, 47);
            this.btnWeightCharts.TabIndex = 16;
            this.btnWeightCharts.Text = "Show Weight Changes(Last 50)";
            this.btnWeightCharts.UseVisualStyleBackColor = false;
            this.btnWeightCharts.Click += new System.EventHandler(this.btnWeightCharts_Click);
            // 
            // IMG_NetworkTopography
            // 
            this.IMG_NetworkTopography.BackColor = System.Drawing.Color.Gainsboro;
            this.IMG_NetworkTopography.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.IMG_NetworkTopography.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IMG_NetworkTopography.Location = new System.Drawing.Point(912, 8);
            this.IMG_NetworkTopography.Name = "IMG_NetworkTopography";
            this.IMG_NetworkTopography.Size = new System.Drawing.Size(488, 616);
            this.IMG_NetworkTopography.TabIndex = 18;
            this.IMG_NetworkTopography.TabStop = false;
            // 
            // tbStructure
            // 
            this.tbStructure.Location = new System.Drawing.Point(80, 24);
            this.tbStructure.Name = "tbStructure";
            this.tbStructure.Size = new System.Drawing.Size(176, 20);
            this.tbStructure.TabIndex = 21;
            this.tbStructure.Text = "4 5 5 1";
            this.tbStructure.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "MLP Structure";
            // 
            // bConstruct
            // 
            this.bConstruct.BackColor = System.Drawing.SystemColors.Control;
            this.bConstruct.Location = new System.Drawing.Point(8, 64);
            this.bConstruct.Name = "bConstruct";
            this.bConstruct.Size = new System.Drawing.Size(104, 32);
            this.bConstruct.TabIndex = 27;
            this.bConstruct.Text = "Construct Network";
            this.bConstruct.UseVisualStyleBackColor = false;
            this.bConstruct.Click += new System.EventHandler(this.bConstruct_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.rbMNIST);
            this.groupBox5.Controls.Add(this.rbIris);
            this.groupBox5.Controls.Add(this.bConstruct);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.tbStructure);
            this.groupBox5.Location = new System.Drawing.Point(640, 512);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(264, 112);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MLP Builder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Change set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbMNIST
            // 
            this.rbMNIST.AutoSize = true;
            this.rbMNIST.Location = new System.Drawing.Point(120, 80);
            this.rbMNIST.Name = "rbMNIST";
            this.rbMNIST.Size = new System.Drawing.Size(59, 17);
            this.rbMNIST.TabIndex = 29;
            this.rbMNIST.Text = "MNIST";
            this.rbMNIST.UseVisualStyleBackColor = true;
            this.rbMNIST.CheckedChanged += new System.EventHandler(this.rbMNIST_CheckedChanged);
            // 
            // rbIris
            // 
            this.rbIris.AutoSize = true;
            this.rbIris.Checked = true;
            this.rbIris.Location = new System.Drawing.Point(120, 64);
            this.rbIris.Name = "rbIris";
            this.rbIris.Size = new System.Drawing.Size(46, 17);
            this.rbIris.TabIndex = 28;
            this.rbIris.TabStop = true;
            this.rbIris.Text = "IRIS";
            this.rbIris.UseVisualStyleBackColor = true;
            this.rbIris.CheckedChanged += new System.EventHandler(this.rbIris_CheckedChanged);
            // 
            // consoleUpdater
            // 
            this.consoleUpdater.Interval = 1;
            this.consoleUpdater.Tick += new System.EventHandler(this.consoleUpdater_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cartesianChart3
            // 
            this.cartesianChart3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cartesianChart3.Location = new System.Drawing.Point(8, 208);
            this.cartesianChart3.Name = "cartesianChart3";
            this.cartesianChart3.Size = new System.Drawing.Size(368, 168);
            this.cartesianChart3.TabIndex = 4;
            this.cartesianChart3.Text = "vv";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Error Change Over Iterations";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(8, 584);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 29;
            this.button2.Text = "Clear Charts";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbDisableCharts
            // 
            this.cbDisableCharts.AutoSize = true;
            this.cbDisableCharts.Location = new System.Drawing.Point(288, 584);
            this.cbDisableCharts.Name = "cbDisableCharts";
            this.cbDisableCharts.Size = new System.Drawing.Size(94, 17);
            this.cbDisableCharts.TabIndex = 30;
            this.cbDisableCharts.Text = "Disable Charts";
            this.cbDisableCharts.UseVisualStyleBackColor = true;
            this.cbDisableCharts.CheckedChanged += new System.EventHandler(this.cbDisableCharts_CheckedChanged);
            // 
            // cbdisabledrawing
            // 
            this.cbdisabledrawing.AutoSize = true;
            this.cbdisabledrawing.Location = new System.Drawing.Point(920, 600);
            this.cbdisabledrawing.Name = "cbdisabledrawing";
            this.cbdisabledrawing.Size = new System.Drawing.Size(103, 17);
            this.cbdisabledrawing.TabIndex = 20;
            this.cbdisabledrawing.Text = "Disable Drawing";
            this.cbdisabledrawing.UseVisualStyleBackColor = true;
            this.cbdisabledrawing.CheckedChanged += new System.EventHandler(this.cbdisabledrawing_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1410, 628);
            this.Controls.Add(this.cbdisabledrawing);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.IMG_NetworkTopography);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MLP Controller GUI";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMG_NetworkTopography)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bToggleController;
        private System.Windows.Forms.Button bControllerStep;
        private System.Windows.Forms.Button bControllerReset;
        private System.Windows.Forms.Button bClearLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbValueTest;
        private System.Windows.Forms.Button bTestValues;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox IMG_NetworkTopography;
        private System.Windows.Forms.TextBox tbStructure;
        private System.Windows.Forms.TextBox tbLearningRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bConstruct;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer consoleUpdater;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Button btnWeightCharts;
        private System.Windows.Forms.Label lbErrorResult;
        private System.Windows.Forms.Label lbTestResult;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbNumericResult;
        private System.Windows.Forms.Label lbIterationNumber;
        private System.Windows.Forms.Label lbElapsed;
        private System.Windows.Forms.Label lbBestError;
        private System.Windows.Forms.RadioButton rbMNIST;
        private System.Windows.Forms.RadioButton rbIris;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lbiris3;
        private System.Windows.Forms.Label lbiris2;
        private System.Windows.Forms.Label lbiris1;
        private System.Windows.Forms.Label lbmnist3;
        private System.Windows.Forms.Label lbmnist2;
        private System.Windows.Forms.Label lbmnist1;
        private System.Windows.Forms.Button btnbatch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private LiveCharts.WinForms.CartesianChart cartesianChart3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbDisableCharts;
        private System.Windows.Forms.CheckBox cbdisabledrawing;
    }
}

