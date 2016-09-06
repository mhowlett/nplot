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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using System.Collections;
using System.Text;

namespace NPlot
{

	namespace Web
	{

		/// <summary>
		/// A PlotSurface2D web control. Rather than use this control, I generally create bitmaps
		/// using Bitmap.PlotSurface2D, then use the ToBrowser() method in Bitmap.PlotSurface2D to
		/// return them as a page request response (and point the src in an image tag to this page).
		/// 
		/// This is not as nice from a users perspective but is more efficient. 
		/// 
		/// Note: this control can chew up memory until the user session ends if the client cancels
		/// the page load before the image has loaded. 
		/// </summary>
		[
		DefaultProperty("Title"), 
		ToolboxData("<{0}:PlotSurface2D runat=server></{0}:PlotSurface2D>"),
		Designer(typeof(NPlot.Web.Design.PlotSurface2D))
		]
		public class PlotSurface2D : System.Web.UI.WebControls.WebControl, IPlotSurface2D 
		{

			private NPlot.PlotSurface2D ps_ = new NPlot.PlotSurface2D();


			/// <summary>
			/// Default constructor.
			/// </summary>
			public PlotSurface2D() : 
				base()
			{
			}


			/// <summary>
			/// The URL to redirect for the plot.
			/// </summary>
			private string plotUrl;


			/// <summary>
			/// the prefix used for the session variables
			/// </summary>
			private string prefix()
			{
				string toReturn = "__PlotSurface2D_";
				toReturn += this.ClientID;
				toReturn += "_";
				toReturn += this.Page.ToString();
				toReturn += "_";
				return toReturn;
			}


			/// <summary>
			/// Clears the plot.
			/// </summary>
			public void Clear()
			{
				ps_.Clear();
			}


			/// <summary>
			/// Adds a drawable object to the plot surface. If the object is an IPlot, 
			/// the PlotSurface2D axes will also be updated.
			/// </summary>
			/// <param name="p">The IDrawable object to add to the plot surface.</param>
			public void Add( IDrawable p )
			{
				ps_.Add( p );
			}


			/// <summary>
			/// Adds a drawable object to the plot surface against the specified axes. If
			/// the object is an IPlot, the PlotSurface2D axes will also be updated.
			/// </summary>
			/// <param name="p">the IDrawable object to add to the plot surface</param>
			/// <param name="xp">the x-axis to add the plot against.</param>
			/// <param name="yp">the y-axis to add the plot against.</param>
			public void Add( IDrawable p, NPlot.PlotSurface2D.XAxisPosition xp, NPlot.PlotSurface2D.YAxisPosition yp )
			{
				ps_.Add( p, xp, yp );
			}


			/// <summary>
			/// Adds a drawable object to the plot surface. If the object is an IPlot, 
			/// the PlotSurface2D axes will also be updated.
			/// </summary>
			/// <param name="p">The IDrawable object to add to the plot surface.</param>
			/// <param name="zOrder">The z-ordering when drawing (objects with lower numbers are drawn first)</param>
			public void Add( IDrawable p, int zOrder )
			{
				ps_.Add( p, zOrder );
			}


			/// <summary>
			/// Adds a drawable object to the plot surface against the specified axes. If
			/// the object is an IPlot, the PlotSurface2D axes will also be updated.
			/// </summary>
			/// <param name="p">the IDrawable object to add to the plot surface</param>
			/// <param name="xp">the x-axis to add the plot against.</param>
			/// <param name="yp">the y-axis to add the plot against.</param>
			/// <param name="zOrder">The z-ordering when drawing (objects with lower numbers are drawn first)</param>
			public void Add( IDrawable p, NPlot.PlotSurface2D.XAxisPosition xp,
				NPlot.PlotSurface2D.YAxisPosition yp, int zOrder )
			{
				ps_.Add( p, xp, yp , zOrder);
			}

			/// <summary>
			/// The plot surface title.
			/// </summary>
			[
			Browsable(true),
			Bindable(true)
			]
			public string Title
			{
				get 
				{
					return ps_.Title;
				}
				set 
				{
					ps_.Title = value;
				}
			}


			/// <summary>
			/// The plot title font.
			/// </summary>
			[
			Browsable(true)
			]
			public System.Drawing.Font TitleFont 
			{
				get 
				{
					return ps_.TitleFont;
				}
				set 
				{
					ps_.TitleFont = value;
				}
			}


			/// <summary>
			/// The distance in pixels to leave between of the edge of the bounding rectangle
			/// supplied to the Draw method, and the markings that make up the plot.
			/// </summary>
			[
			Browsable(true),
			Category("Data"),
			Bindable(true)
			]
			public int Padding
			{
				get
				{
					return ps_.Padding;
				}
				set
				{
					ps_.Padding = value;
				}
			}


			/// <summary>
			/// The first abscissa axis.
			/// </summary>
			[
			Browsable(false),
			Bindable(false)
			]
			public Axis XAxis1
			{
				get
				{
					return ps_.XAxis1;
				}
				set
				{
					ps_.XAxis1 = value;
				}
			}


			/// <summary>
			/// The first ordinate axis.
			/// </summary>
			[
			Browsable(false),
			Bindable(false)
			]
			public Axis YAxis1
			{
				get
				{
					return ps_.YAxis1;
				}
				set
				{
					ps_.YAxis1 = value;
				}
			}


			/// <summary>
			/// The second abscissa axis.
			/// </summary>
			[
			Browsable(false),
			Bindable(false)
			]
			public Axis XAxis2
			{
				get
				{
					return ps_.XAxis2;
				}
				set
				{
					ps_.XAxis2 = value;
				}
			}


			/// <summary>
			/// The second ordinate axis.
			/// </summary>
			[
			Browsable(false),
			Bindable(false)
			]
			public Axis YAxis2
			{
				get
				{
					return ps_.YAxis2;
				}
				set
				{
					ps_.YAxis2 = value;
				}
			}


			/// <summary>
			/// A color used to paint the plot background. Mutually exclusive with PlotBackImage and PlotBackBrush
			/// </summary>
			[
			Bindable(true),
			Browsable(true)
			]
			public System.Drawing.Color PlotBackColor
			{
				set
				{
					ps_.PlotBackColor = value;
				}
			}


			/// <summary>
			/// An imaged used to paint the plot background. Mutually exclusive with PlotBackColor and PlotBackBrush
			/// </summary>
			public System.Drawing.Bitmap PlotBackImage
			{
				set
				{
					ps_.PlotBackImage = value;
				}
			}


			/// <summary>
			/// A Rectangle brush used to paint the plot background. Mutually exclusive with PlotBackColor and PlotBackBrush
			/// </summary>
			public IRectangleBrush PlotBackBrush
			{
				set
				{
					ps_.PlotBackBrush = value;
				}
			}


			/// <summary>
			/// Gets or Sets the legend to use with this plot surface.
			/// </summary>
			[
			Bindable(false),
			Browsable(false)
			]
			public NPlot.Legend Legend
			{
				get
				{
					return ps_.Legend;
				}
				set
				{
					ps_.Legend = value;
				}
			}


			/// <summary>
			/// Gets or Sets the legend z-order.
			/// </summary>
			[
			Bindable(true),
			Browsable(true)
			]
			public int LegendZOrder
			{
				get
				{
					return ps_.LegendZOrder;
				}
				set
				{
					ps_.LegendZOrder = value;
				}
			}
	

			/// <summary>
			/// Smoothing mode to use when drawing plots.
			/// </summary>
			[
			Bindable(true),
			Browsable(true)
			]
			public System.Drawing.Drawing2D.SmoothingMode SmoothingMode 
			{ 
				get
				{
					return ps_.SmoothingMode;
				}
				set
				{
					ps_.SmoothingMode = value;
				}
			}


			/// <summary>
			/// The bitmap background color outside the bounds of the plot surface.
			/// </summary>
			[
			Bindable(true),
			Browsable(true)
			]
			public override Color BackColor
			{
				set
				{
					backColor_ = value;
				}
			}
			object backColor_ = null;
			

			/// <summary>
			/// Ivan Ivanov wrote this function. From his email:
			/// If the request string contains encoded parameters values [e.g. #  - %23]. 
			/// The call to request.Url.ToString() will decode values [e.g. instead of %23 
			/// it will return #]. On the subsequent request to the page that contains the 
			/// nplot control [when the actual drawing of the image takes place] the request 
			/// url will be cut up to the unformated value [e.g. #] and since the PlotSurface2D_ 
			/// is added at the end of the query string, it will be missing.
			/// </summary>
			/// <returns></returns>
			private String buildPlotURL()
			{
				StringBuilder urlParams = new StringBuilder();

				foreach (string getParamName in Context.Request.QueryString.AllKeys)
				{
					urlParams.Append(getParamName + "=" +
						Context.Server.UrlEncode(Context.Request.QueryString[getParamName]) + "&");
				}

				return Context.Request.Url.AbsolutePath +
					(urlParams.Length > 0  ?
					"?" + urlParams.Append("PlotSurface2D_" + this.ClientID + "=1").ToString() :
					"?PlotSurface2D_" + this.ClientID + "=1");
			}


			/// <summary>
			/// Initialization event.
			/// </summary>
			/// <param name="e"></param>
			protected override void OnInit(EventArgs e)
			{
				System.Web.HttpRequest request = Context.Request;
				System.Web.HttpResponse response = Context.Response;
				if (request.Params["PlotSurface2D_" + this.ClientID] != null) 
				{
					// retrieve the bitmap and display
					response.Clear();
					try
					{
						response.ContentType = "Image/Png"; 
						System.Drawing.Bitmap bmp = (System.Drawing.Bitmap) Context.Session[prefix()+"PNG"];
                        
                        // don't ask why, but if I write directly to the response
						// I have a GDI+ error, if I first write to a MemoryStream and 
						// then to the response.OutputStream I don't get an error.
						System.IO.MemoryStream s = new System.IO.MemoryStream();
						bmp.Save( s, System.Drawing.Imaging.ImageFormat.Png);
						s.WriteTo(response.OutputStream);
						Context.Session.Remove(prefix()+"PNG");
					}
					catch (Exception ex)
					{
						response.ContentType = "Text/HTML";
						response.Write(	ex.Message );
					}
					finally
					{
						response.Flush();
						response.End(); 
					}
				}
				
				this.plotUrl = this.buildPlotURL();
				base.OnInit (e);
			}

	
			/// <summary> 
			/// Render this control as an HTML stream.
			/// </summary>
			/// <param name="output">The HTML writer to write out to.</param>
			protected override void Render(HtmlTextWriter output)
			{

				// first of all render the bitmap;
				System.Drawing.Bitmap b = new System.Drawing.Bitmap( (int)this.Width.Value, (int)this.Height.Value );
				if (backColor_!=null)
				{
					Graphics g = Graphics.FromImage( b );
					g.FillRectangle( (new Pen( (Color)this.backColor_)).Brush,0,0,b.Width,b.Height );
				}
				ps_.Draw( Graphics.FromImage(b), new System.Drawing.Rectangle(0,0,b.Width,b.Height) );

				// then store in context memory. 
				Context.Session[prefix()+"PNG"] = b;

				// now render html.
				if (this.BorderStyle == BorderStyle.None)
				{
					output.AddAttribute("border","0");
				}
				else
				{
					output.AddAttribute("border",this.BorderWidth.ToString());
					output.AddAttribute("borderColor",this.BorderColor.ToKnownColor().ToString());
				}
				output.AddAttribute("cellSpacing","0");
				output.AddAttribute("cellPadding","0");
				output.RenderBeginTag("table");
				output.RenderBeginTag("tr");
				output.AddAttribute("vAlign","center");
				output.AddAttribute("align","middle");
				output.RenderBeginTag("td");
				output.RenderBeginTag("P");
				output.AddAttribute("src",this.plotUrl);
				output.AddAttribute("alt",this.ToolTip);
				output.RenderBeginTag("img");
				output.RenderEndTag();
				output.RenderEndTag();
				output.RenderEndTag();
				output.RenderEndTag();
				output.RenderEndTag();
				output.Flush();
			}

			/// <summary>
			/// Add an axis constraint to the plot surface. Axis constraints can
			/// specify relative world-pixel scalings, absolute axis positions etc.
			/// </summary>
			/// <param name="c">The axis constraint to add.</param>
			public void AddAxesConstraint( AxesConstraint c )
			{
				ps_.AddAxesConstraint( c );
			}


			/// <summary>
			/// Whether or not the title will be scaled according to size of the plot 
			/// surface.
			/// </summary>
			[
			Browsable(true),
			Bindable(true)
			]
			public bool AutoScaleTitle
			{
				get
				{
					return ps_.AutoScaleTitle;
				}
				set
				{
					ps_.AutoScaleTitle = value;
				}
			}


			/// <summary>
			/// When plots are added to the plot surface, the axes they are attached to
			/// are immediately modified to reflect data of the plot. If 
			/// AutoScaleAutoGeneratedAxes is true when a plot is added, the axes will
			/// be turned in to auto scaling ones if they are not already [tick marks,
			/// tick text and label size scaled to size of plot surface]. If false,
			/// axes will not be autoscaling.
			/// </summary>
			[
			Browsable(true),
			Bindable(true),
			]
			public bool AutoScaleAutoGeneratedAxes
			{
				get
				{
					return ps_.AutoScaleAutoGeneratedAxes;
				}
				set
				{
					ps_.AutoScaleAutoGeneratedAxes = value;
				}
			}


			/// <summary>
			/// Sets the title to be drawn using a solid brush of this color.
			/// </summary>
			[
			Browsable(true),
			Bindable(true)
			]
			public Color TitleColor
			{
				set
				{
					ps_.TitleColor = value;
				}
			}


			/// <summary>
			/// The brush used for drawing the title.
			/// </summary>
			[
			Browsable(false)
			]
			public Brush TitleBrush
			{
				get
				{
					return ps_.TitleBrush;
				}
				set
				{
					ps_.TitleBrush = value;
				}
			}

			/// <summary>
			/// Remove a drawable object from the plot surface.
			/// </summary>
			/// <param name="p">the drawable to remove</param>
			/// <param name="updateAxes">whether or not to update the axes after removing the idrawable.</param>
			public void Remove( IDrawable p, bool updateAxes ) 
			{
				ps_.Remove( p, updateAxes );
			}


			/// <summary>
			/// Gets an array list containing all drawables currently added to the PlotSurface2D.
			/// </summary>
			[
			Browsable(false)
			]
			public ArrayList Drawables
			{
				get
				{
					return ps_.Drawables;
				}
			}

		}
	}

}
