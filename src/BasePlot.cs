/*
 * NPlot - A charting library for .NET
 * 
 * BasePlot.cs
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

namespace NPlot
{
    /// <summary>
    /// Supplies implementation of basic legend handling properties, and
    /// basic data specifying properties which are used by all plots.
    /// </summary>
    /// <remarks>If C# had multiple inheritance, the heirachy would be different.</remarks>
    public abstract class BasePlot
    {
        private string label_ = "";

        private bool showInLegend_ = true;

        /// <summary>
        /// A label to associate with the plot - used in the legend.
        /// </summary>
        public string Label
        {
            get { return label_; }
            set { label_ = value; }
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
        /// Gets or sets the source containing a list of values used to populate the plot object.
        /// </summary>
        public object DataSource { get; set; }

        /// <summary>
        /// Gets or sets the specific data member in a multimember data source to get data from.
        /// </summary>
        public string DataMember { get; set; }
    }
}