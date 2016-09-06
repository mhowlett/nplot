/*
 * NPlot - A charting library for .NET
 * 
 * Web.PlotSurface2d.cs
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
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using NPlot;

namespace NPlot
{
	
	namespace Web
	{
		namespace Design
		{

			/// <summary>
			/// The Design Time rendered for the NPlot.web.PlotSurface2D control.
			/// </summary>
			public class PlotSurface2D : System.Web.UI.Design.ControlDesigner
			{

				/// <summary>
				/// The design time generated HTML for the control.
				/// </summary>
				/// <returns>A string containing the HTML rendering.</returns>
				public override string GetDesignTimeHtml()
				{
					
					// Extremely simple design time rendering!
					// will work on something better sooner or later.
					// This acts as a placeholder.
					Web.PlotSurface2D plot = (Web.PlotSurface2D)Component;

					int xs = Convert.ToInt32(plot.Width.Value);
					if ( xs < 1 ) return "";
					int ys = Convert.ToInt32(plot.Height.Value);
					if ( ys < 1 ) return "";

					StringWriter sw = new StringWriter();
					HtmlTextWriter output= new HtmlTextWriter(sw);
					output.AddAttribute("border",plot.BorderWidth.ToString());
					output.AddAttribute("borderColor",plot.BorderColor.ToKnownColor().ToString());
					output.AddAttribute("cellSpacing","0");
					output.AddAttribute("cellPadding","0");
					output.AddAttribute("width",xs.ToString());
					output.RenderBeginTag("table ");
					output.RenderBeginTag("tr");
					output.AddAttribute("vAlign","center");
					output.AddAttribute("align","middle");
					output.AddAttribute("height",ys.ToString());
					output.RenderBeginTag("td");
					output.RenderBeginTag("P");
					output.Write("PlotSurface2D:" + plot.Title);
					output.RenderEndTag();
					output.RenderEndTag();
					output.RenderEndTag();
					output.RenderEndTag();
					output.Flush();
					return sw.ToString();
				
				}

			}

		}

	}
}
