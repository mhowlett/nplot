/*
 * NPlot - A charting library for .NET
 * 
 * AxisTestsForm.cs
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

using NPlot;

namespace NPlotDemo
{
	/// <summary>
	/// Summary description for Tests.
	/// </summary>
	public class AxisTestsForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AxisTestsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			this.Paint += new PaintEventHandler(Tests_Paint);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// AxisTestsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 342);
			this.Name = "AxisTestsForm";
			this.Text = "Tests";

		}
		#endregion

		private void Tests_Paint(object sender, PaintEventArgs e)
		{
			System.Drawing.Rectangle boundingBox;

			NPlot.LinearAxis a = new LinearAxis(0, 10);
			a.Draw( e.Graphics, new Point(10,10), new Point(10, 200), out boundingBox );

			a.Reversed = true;
			a.Draw( e.Graphics, new Point(40,10), new Point(40, 200), out boundingBox );

			a.SmallTickSize = 0;
			a.Draw( e.Graphics, new Point(70,10), new Point(70, 200), out boundingBox );

			a.LargeTickStep = 2.5;
			a.Draw( e.Graphics, new Point(100,10), new Point(100,200), out boundingBox );

			a.NumberOfSmallTicks = 5;
			a.SmallTickSize = 2;
			a.Draw( e.Graphics, new Point(130,10), new Point(130,200), out boundingBox );

			a.AxisColor = Color.Cyan;
			a.Draw( e.Graphics, new Point(160,10), new Point(160,200), out boundingBox );

			a.TickTextColor= Color.Cyan;
			a.Draw( e.Graphics, new Point(190,10), new Point(190,200), out boundingBox );

			a.TickTextBrush = Brushes.Black;
			a.AxisPen = Pens.Black;
			a.Draw( e.Graphics, new Point(220,10), new Point(280,200), out boundingBox );

			a.WorldMax = 100000;
			a.WorldMin = -3;
			a.LargeTickStep = double.NaN;
			a.Draw( e.Graphics, new Point(310,10), new Point(310,200), out boundingBox );

			a.NumberFormat = "{0:0.0E+0}";
			a.Draw( e.Graphics, new Point(360,10), new Point(360,200), out boundingBox );
		}
	}
}
