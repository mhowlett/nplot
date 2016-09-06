/*
 * NPlot - A charting library for .NET
 * 
 * PlotSurface2DDemo.cs
 * Copyright (C) 2003-2006 Matt Howlett, Jamie McQuay.
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
 * 3. Neither the name of NPlot nor the names of its contributors may
 *    be used to endorse or promote products derived from this software without
 *    specific prior written permission.
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

#include "StdAfx.h"
#include "AxisTestsForm.h"

namespace NPlotDemo {

	CAxisTestsForm::CAxisTestsForm(void)
	{
		InitializeComponent();
		
		this->Paint += gcnew PaintEventHandler(this,&NPlotDemo::CAxisTestsForm::Tests_Paint);
	}

	System::Void CAxisTestsForm::Tests_Paint(System::Object^ sender, PaintEventArgs^ e)
	{
		System::Drawing::Rectangle boundingBox;

		NPlot::LinearAxis^ a = gcnew NPlot::LinearAxis(0, 10);
		a->Draw( e->Graphics, (Point)gcnew Point(10,10), (Point)gcnew Point(10, 200), boundingBox );

		a->Reversed = true;
		a->Draw( e->Graphics, (Point)gcnew Point(40,10), (Point)gcnew Point(40, 200), boundingBox );

		a->SmallTickSize = 0;
		a->Draw( e->Graphics, (Point)gcnew Point(70,10), (Point)gcnew Point(70, 200), boundingBox );

		a->LargeTickStep = 2.5;
		a->Draw( e->Graphics, (Point)gcnew Point(100,10), (Point)gcnew Point(100,200), boundingBox );

		a->NumberOfSmallTicks = 5;
		a->SmallTickSize = 2;
		a->Draw( e->Graphics, (Point)gcnew Point(130,10), (Point)gcnew Point(130,200), boundingBox );

		a->AxisColor = Color::Cyan;
		a->Draw( e->Graphics, (Point)gcnew Point(160,10), (Point)gcnew Point(160,200), boundingBox );

		a->TickTextColor= Color::Cyan;
		a->Draw( e->Graphics, (Point)gcnew Point(190,10), (Point)gcnew Point(190,200), boundingBox );

		a->TickTextBrush = Brushes::Black;
		a->AxisPen = Pens::Black;
		a->Draw( e->Graphics, (Point)gcnew Point(220,10), (Point)gcnew Point(280,200), boundingBox );

		a->WorldMax = 100000;
		a->WorldMin = -3;
		a->LargeTickStep = System::Double::NaN;
		a->Draw( e->Graphics, (Point)gcnew Point(310,10), (Point)gcnew Point(310,200), boundingBox );

		a->NumberFormat = "{0:0.0E+0}";
		a->Draw( e->Graphics, (Point)gcnew Point(360,10), (Point)gcnew Point(360,200), boundingBox );
	}
}

