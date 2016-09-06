/*
 * NPlot - A charting library for .NET
 * 
 * FinancialDemo.cs
 * Copyright (C) 2003-2006 Matt Howlett and others.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
 * OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */



using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

using NPlot;


namespace NPlotDemo
{
	/// <summary>
	/// Summary description for BasicDemo.
	/// </summary>
	public class FinancialDemo : System.Windows.Forms.Form
	{
        private NPlot.Windows.PlotSurface2D volumePS;
        private NPlot.Windows.PlotSurface2D costPS;
        private System.Windows.Forms.Button closeButton;


		/// <summary>
		/// Right context menu with non-default functionality. Just take out some functionality. Could also have added some.
		/// </summary>
		public class ReducedContextMenu : NPlot.Windows.PlotSurface2D.PlotContextMenu
		{

			/// <summary>
			/// Constructor
			/// </summary>
			public ReducedContextMenu()
				: base()
			{
				ArrayList menuItems = this.MenuItems;

				// remove show coordinates, and print functionality
				menuItems.RemoveAt(4);
				menuItems.RemoveAt(3);
				menuItems.RemoveAt(1);

                this.SetMenuItems(menuItems);

			}

		}


        public FinancialDemo()
        {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            costPS.Clear();
            costPS.DateTimeToolTip = true;

            // obtain stock information from xml file
            DataSet ds = new DataSet();
            System.IO.Stream file =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("NPlotDemo.resources.asx_jbh.xml");
            ds.ReadXml(file, System.Data.XmlReadMode.ReadSchema);
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);

            // create CandlePlot.
            CandlePlot cp = new CandlePlot();
            cp.DataSource = dt;
            cp.AbscissaData = "Date";
            cp.OpenData = "Open";
            cp.LowData = "Low";
            cp.HighData = "High";
            cp.CloseData = "Close";
            cp.BearishColor = Color.Red;
            cp.BullishColor = Color.Green;
            cp.Style = CandlePlot.Styles.Filled;
            costPS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            costPS.Add(new Grid());
            costPS.Add(cp);
            costPS.Title = "AU:JBH";
            costPS.YAxis1.Label = "Price [$]";
            costPS.YAxis1.LabelOffset = 40;
            costPS.YAxis1.LabelOffsetAbsolute = true;
            costPS.XAxis1.HideTickText = true;
            costPS.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            costPS.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            costPS.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(false));
            costPS.InteractionOccured += new NPlot.Windows.PlotSurface2D.InteractionHandler(costPS_InteractionOccured);
            costPS.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));

            PointPlot pp = new PointPlot();
            pp.Marker = new Marker(Marker.MarkerType.Square, 0);
            pp.Marker.Pen = new Pen(Color.Red, 5.0f);
            pp.Marker.DropLine = true;
            pp.DataSource = dt;
            pp.AbscissaData = "Date";
            pp.OrdinateData = "Volume";  
            volumePS.Add(pp);
            volumePS.YAxis1.Label = "Volume";
            volumePS.YAxis1.LabelOffsetAbsolute = true;
            volumePS.YAxis1.LabelOffset = 40;
            volumePS.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.YAxisPosition.Left, 60));
            volumePS.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(false));
            volumePS.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            volumePS.InteractionOccured += new NPlot.Windows.PlotSurface2D.InteractionHandler(volumePS_InteractionOccured);
            volumePS.PreRefresh += new NPlot.Windows.PlotSurface2D.PreRefreshHandler(volumePS_PreRefresh);

            this.costPS.RightMenu = new ReducedContextMenu();
			
        }

        protected override void OnResize(EventArgs e)
        {
            this.costPS.Height = (int)(0.5 * (this.Height));
            this.costPS.Width = (int)(this.Width - 35);

            this.volumePS.Top = costPS.Height + 12;
            this.volumePS.Height = this.Height - (costPS.Height + 25) - 80;
            this.volumePS.Width = (int)(this.Width - 35);

            base.OnResize(e);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.closeButton = new System.Windows.Forms.Button();
            this.volumePS = new NPlot.Windows.PlotSurface2D();
            this.costPS = new NPlot.Windows.PlotSurface2D();
            this.SuspendLayout();
// 
// closeButton
// 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.Location = new System.Drawing.Point(8, 421);
            this.closeButton.Name = "closeButton";
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
// 
// volumePS
// 
            this.volumePS.AutoScaleAutoGeneratedAxes = false;
            this.volumePS.AutoScaleTitle = false;
            this.volumePS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.volumePS.Legend = null;
            this.volumePS.Location = new System.Drawing.Point(13, 305);
            this.volumePS.Name = "volumePS";
            this.volumePS.RightMenu = null;
            this.volumePS.ShowCoordinates = false;
            this.volumePS.Size = new System.Drawing.Size(606, 109);
            this.volumePS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.volumePS.TabIndex = 3;
            this.volumePS.Title = "";
            this.volumePS.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.volumePS.XAxis1 = null;
            this.volumePS.XAxis2 = null;
            this.volumePS.YAxis1 = null;
            this.volumePS.YAxis2 = null;
// 
// costPS
// 
            this.costPS.AutoScaleAutoGeneratedAxes = false;
            this.costPS.AutoScaleTitle = false;
            this.costPS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.costPS.Legend = null;
            this.costPS.Location = new System.Drawing.Point(13, 13);
            this.costPS.Name = "costPS";
            this.costPS.RightMenu = null;
            this.costPS.ShowCoordinates = false;
            this.costPS.Size = new System.Drawing.Size(606, 285);
            this.costPS.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.costPS.TabIndex = 2;
            this.costPS.Title = "";
            this.costPS.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costPS.XAxis1 = null;
            this.costPS.XAxis2 = null;
            this.costPS.YAxis1 = null;
            this.costPS.YAxis2 = null;
// 
// FinancialDemo
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(631, 450);
            this.Controls.Add(this.volumePS);
            this.Controls.Add(this.costPS);
            this.Controls.Add(this.closeButton);
            this.Name = "FinancialDemo";
            this.Text = "BasicDemo";
            this.ResumeLayout(false);

        }
		#endregion


        /// <summary>
        /// Callback for close button.
        /// </summary>
		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


        /// <summary>
        /// When the costPS chart has changed, this is called which updates the volumePS chart.
        /// </summary>
        /// <param name="sender"></param>
        private void costPS_InteractionOccured(object sender)
        {
            DateTimeAxis axis = new DateTimeAxis(costPS.XAxis1);
            axis.Label = "Date / Time";
            axis.HideTickText = false;
            this.volumePS.XAxis1 = axis;
            this.volumePS.Refresh();
        }


        /// <summary>
        /// When the volumePS chart has changed, this is called which updates hte costPS chart.
        /// </summary>
        private void volumePS_InteractionOccured(object sender)
        {
            DateTimeAxis axis = new DateTimeAxis(volumePS.XAxis1);
            axis.Label = "";
            axis.HideTickText = true;
            this.costPS.XAxis1 = axis;
            this.costPS.Refresh();
        }


        /// <summary>
        /// This is called prior to volumePS refresh to enforce the WorldMin is 0. 
        /// This may have been changed by the axisdrag interaction.
        /// </summary>
        /// <param name="sender"></param>
        private void volumePS_PreRefresh(object sender)
        {
            volumePS.YAxis1.WorldMin = 0.0;
        }

    }
}
