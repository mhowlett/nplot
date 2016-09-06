/*
 * NPlot - A charting library for .NET
 * 
 * ImagePlot.cs
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
using System.Text;

namespace NPlot
{
    /// <summary>
    /// Encapsulates functionality for plotting data as a 2D image chart.
    /// </summary>
    public class ImagePlot : IPlot
    {
        private readonly double[,] data_;
        private readonly double xStart_;
        private readonly double xStep_ = 1.0;
        private readonly double yStart_;
        private readonly double yStep_ = 1.0;
        private bool center_ = true;

        private double dataMax_;
        private double dataMin_;
        private IGradient gradient_;
        private string label_ = "";
        private bool showInLegend_ = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">the 2D array to plot</param>
        /// <param name="xStart">the world value corresponding to the 1st position in the x-direction</param>
        /// <param name="xStep">the world step size between pixels in the x-direction.</param>
        /// <param name="yStart">the world value corresponding to the 1st position in the y-direction</param>
        /// <param name="yStep">the world step size between pixels in the y-direction.</param>
        /// <remarks>
        /// no adapters for this yet - when we get some more 2d
        /// plotting functionality, then perhaps create some.
        /// </remarks>
        public ImagePlot(double[,] data, double xStart, double xStep, double yStart, double yStep)
        {
#if CHECK_ERRORS
			if (data == null || data.GetLength(0) == 0 || data.GetLength(1) == 0)
			{
				throw new NPlotException( "ERROR: ImagePlot.ImagePlot: Data null, or zero length" );
			}
#endif

            data_ = data;
            xStart_ = xStart;
            xStep_ = xStep;
            yStart_ = yStart;
            yStep_ = yStep;
            calculateMinMax();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">The 2D array to plot.</param>
        public ImagePlot(double[,] data)
        {
            data_ = data;
            calculateMinMax();
        }

        /// <summary>
        /// At or below which value a minimum gradient color should be used.
        /// </summary>
        public double DataMin
        {
            get { return dataMin_; }
            set { dataMin_ = value; }
        }

        /// <summary>
        /// At or above which value a maximum gradient color should be used.
        /// </summary>
        public double DataMax
        {
            get { return dataMax_; }
            set { dataMax_ = value; }
        }

        /// <summary>
        /// The gradient that specifies the mapping between value and color.
        /// </summary>
        /// <remarks>memory allocation in get may be inefficient.</remarks>
        public IGradient Gradient
        {
            get
            {
                if (gradient_ == null)
                {
                    // TODO: suboptimal.
                    gradient_ = new LinearGradient(Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0));
                }
                return gradient_;
            }
            set { gradient_ = value; }
        }

        /// <summary>
        /// If true, pixels are centered on their respective coordinates. If false, they are drawn
        /// between their coordinates and the coordinates of the the next point in each direction.
        /// </summary>
        public bool Center
        {
            set { center_ = value; }
            get { return center_; }
        }

        /// <summary>
        /// Draw on to the supplied graphics surface against the supplied axes.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw.</param>
        /// <param name="xAxis">The X-Axis to draw against.</param>
        /// <param name="yAxis">The Y-Axis to draw against.</param>
        /// <remarks>TODO: block positions may be off by a pixel or so. maybe. Re-think calculations</remarks>
        public void Draw(Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis)
        {
            if (data_ == null || data_.GetLength(0) == 0 || data_.GetLength(1) == 0)
            {
                return;
            }

            double worldWidth = xAxis.Axis.WorldMax - xAxis.Axis.WorldMin;
            double numBlocksHorizontal = worldWidth/xStep_;
            double worldHeight = yAxis.Axis.WorldMax - yAxis.Axis.WorldMin;
            double numBlocksVertical = worldHeight/yStep_;

            double physicalWidth = xAxis.PhysicalMax.X - xAxis.PhysicalMin.X;
            double blockWidth = physicalWidth/numBlocksHorizontal;
            bool wPositive = true;
            if (blockWidth < 0.0)
            {
                wPositive = false;
            }
            blockWidth = Math.Abs(blockWidth) + 1;

            double physicalHeight = yAxis.PhysicalMax.Y - yAxis.PhysicalMin.Y;
            double blockHeight = physicalHeight/numBlocksVertical;
            bool hPositive = true;
            if (blockHeight < 0.0)
            {
                hPositive = false;
            }
            blockHeight = Math.Abs(blockHeight) + 1;

            for (int i = 0; i < data_.GetLength(0); ++i)
            {
                for (int j = 0; j < data_.GetLength(1); ++j)
                {
                    double wX = j*xStep_ + xStart_;
                    double wY = i*yStep_ + yStart_;
                    if (!hPositive)
                    {
                        wY += yStep_;
                    }
                    if (!wPositive)
                    {
                        wX += xStep_;
                    }

                    if (center_)
                    {
                        wX -= xStep_/2.0;
                        wY -= yStep_/2.0;
                    }
                    Pen p = new Pen(Gradient.GetColor((data_[i, j] - dataMin_)/(dataMax_ - dataMin_)));
                    int x = (int) xAxis.WorldToPhysical(wX, false).X;
                    int y = (int) yAxis.WorldToPhysical(wY, false).Y;
                    g.FillRectangle(p.Brush,
                                    x,
                                    y,
                                    (int) blockWidth,
                                    (int) blockHeight);
                    //g.DrawRectangle(Pens.White,x,y,(int)blockWidth,(int)blockHeight);
                }
            }
        }

        /// <summary>
        /// Draws a representation of this plot in the legend.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw.</param>
        /// <param name="startEnd">A rectangle specifying the bounds of the area in the legend set aside for drawing.</param>
        public void DrawInLegend(Graphics g, Rectangle startEnd)
        {
            // not implemented yet.
        }

        /// <summary>
        /// A label to associate with the plot - used in the legend.
        /// </summary>
        public string Label
        {
            get { return label_; }
            set { label_ = value; }
        }

        /// <summary>
        /// Returns an x-axis that is suitable for drawing this plot.
        /// </summary>
        /// <returns>A suitable x-axis.</returns>
        public Axis SuggestXAxis()
        {
            if (center_)
            {
                return new LinearAxis(xStart_ - xStep_/2.0, xStart_ + xStep_*data_.GetLength(1) - xStep_/2.0);
            }

            return new LinearAxis(xStart_, xStart_ + xStep_*data_.GetLength(1));
        }

        /// <summary>
        /// Returns a y-axis that is suitable for drawing this plot.
        /// </summary>
        /// <returns>A suitable y-axis.</returns>
        public Axis SuggestYAxis()
        {
            if (center_)
            {
                return new LinearAxis(yStart_ - yStep_/2.0, yStart_ + yStep_*data_.GetLength(0) - yStep_/2.0);
            }

            return new LinearAxis(yStart_, yStart_ + yStep_*data_.GetLength(0));
        }

        /// <summary>
        /// Whether or not to include an entry for this plot in the legend if it exists.
        /// </summary>
        public bool ShowInLegend
        {
            get { return showInLegend_; }
            set { showInLegend_ = value; }
        }

        /// <summary>
        /// Write data associated with the plot as text.
        /// </summary>
        /// <param name="sb">the string builder to write to.</param>
        /// <param name="region">Only write out data in this region if onlyInRegion is true.</param>
        /// <param name="onlyInRegion">If true, only data in region is written, else all data is written.</param>
        /// <remarks>TODO: not implemented.</remarks>
        public void WriteData(StringBuilder sb, RectangleD region, bool onlyInRegion)
        {
        }

        /// <summary>
        /// Calculates the minimum and maximum values of the data array.
        /// </summary>
        private void calculateMinMax()
        {
            dataMin_ = data_[0, 0];
            dataMax_ = data_[0, 0];
            for (int i = 0; i < data_.GetLength(0); ++i)
            {
                for (int j = 0; j < data_.GetLength(1); ++j)
                {
                    if (data_[i, j] < dataMin_)
                    {
                        dataMin_ = data_[i, j];
                    }
                    if (data_[i, j] > dataMax_)
                    {
                        dataMax_ = data_[i, j];
                    }
                }
            }
        }
    }
}