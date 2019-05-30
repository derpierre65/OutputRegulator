using System;
using System.Windows.Forms;

namespace OutputRegulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputRegulator.Form1));
            this.inputDevice = new System.Windows.Forms.ComboBox();
            this.progressBarVolume = new System.Windows.Forms.ProgressBar();
            this.outputDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reduceAll = new System.Windows.Forms.CheckBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.reducePercent = new System.Windows.Forms.NumericUpDown();
            this.needInputVolume = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelInputVolume = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ticksBeforeDeactivate = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.reducePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.needInputVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ticksBeforeDeactivate)).BeginInit();
            this.SuspendLayout();
            this.inputDevice.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inputDevice.FormattingEnabled = true;
            this.inputDevice.Location = new System.Drawing.Point(112, 9);
            this.inputDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputDevice.Name = "inputDevice";
            this.inputDevice.Size = new System.Drawing.Size(202, 23);
            this.inputDevice.TabIndex = 1;
            this.progressBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarVolume.Location = new System.Drawing.Point(13, 230);
            this.progressBarVolume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarVolume.Name = "progressBarVolume";
            this.progressBarVolume.Size = new System.Drawing.Size(302, 27);
            this.progressBarVolume.TabIndex = 2;
            this.outputDevice.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outputDevice.FormattingEnabled = true;
            this.outputDevice.Location = new System.Drawing.Point(112, 38);
            this.outputDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.outputDevice.Name = "outputDevice";
            this.outputDevice.Size = new System.Drawing.Size(202, 23);
            this.outputDevice.TabIndex = 3;
            this.outputDevice.SelectedIndexChanged += new System.EventHandler(this.outputDevice_SelectedIndexChanged);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input device";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output device";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reduceAll.Location = new System.Drawing.Point(112, 67);
            this.reduceAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reduceAll.Name = "reduceAll";
            this.reduceAll.Size = new System.Drawing.Size(240, 24);
            this.reduceAll.TabIndex = 6;
            this.reduceAll.Text = "reduce all output devices";
            this.reduceAll.UseVisualStyleBackColor = true;
            this.reduceAll.CheckedChanged += new System.EventHandler(this.reduceAll_CheckedChanged);
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reduce Output (in %)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reducePercent.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reducePercent.Location = new System.Drawing.Point(259, 100);
            this.reducePercent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reducePercent.Name = "reducePercent";
            this.reducePercent.Size = new System.Drawing.Size(55, 23);
            this.reducePercent.TabIndex = 9;
            this.reducePercent.Value = new decimal(new int[] {75, 0, 0, 0});
            this.needInputVolume.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.needInputVolume.Location = new System.Drawing.Point(259, 129);
            this.needInputVolume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.needInputVolume.Name = "needInputVolume";
            this.needInputVolume.Size = new System.Drawing.Size(55, 23);
            this.needInputVolume.TabIndex = 10;
            this.needInputVolume.Value = new decimal(new int[] {10, 0, 0, 0});
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Reduce when microphone reached (%)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(13, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Microphone Volume:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInputVolume.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInputVolume.Location = new System.Drawing.Point(241, 209);
            this.labelInputVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInputVolume.Name = "labelInputVolume";
            this.labelInputVolume.Size = new System.Drawing.Size(74, 20);
            this.labelInputVolume.TabIndex = 13;
            this.labelInputVolume.Text = "100%";
            this.labelInputVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(13, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Deactivate reduce after (1 = 10ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ticksBeforeDeactivate.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ticksBeforeDeactivate.Location = new System.Drawing.Point(259, 158);
            this.ticksBeforeDeactivate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ticksBeforeDeactivate.Maximum = new decimal(new int[] {2147483647, 0, 0, 0});
            this.ticksBeforeDeactivate.Name = "ticksBeforeDeactivate";
            this.ticksBeforeDeactivate.Size = new System.Drawing.Size(55, 23);
            this.ticksBeforeDeactivate.TabIndex = 15;
            this.ticksBeforeDeactivate.Value = new decimal(new int[] {30, 0, 0, 0});
            this.notifyIcon1.Icon = ((System.Drawing.Icon) (resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Output regulator";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(327, 270);
            this.Controls.Add(this.ticksBeforeDeactivate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelInputVolume);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.needInputVolume);
            this.Controls.Add(this.reducePercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reduceAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputDevice);
            this.Controls.Add(this.progressBarVolume);
            this.Controls.Add(this.inputDevice);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Output regulator";
            this.Closed += new System.EventHandler(this.Form_Closed);
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize) (this.reducePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.needInputVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ticksBeforeDeactivate)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox inputDevice;
        private System.Windows.Forms.ComboBox outputDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox reduceAll;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown reducePercent;
        private System.Windows.Forms.NumericUpDown needInputVolume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelInputVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ticksBeforeDeactivate;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ProgressBar progressBarVolume;
    }
}