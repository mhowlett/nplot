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
#include "FinancialDemo.h"

namespace NPlotDemo {

	CFinancialDemo::CFinancialDemo(void)
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		costPS->Clear();
        costPS->DateTimeToolTip = true;

        // obtain stock information from xml file
        DataSet^ ds = gcnew DataSet();
        System::IO::Stream^ file = (System::IO::Stream^)
			System::Reflection::Assembly::GetExecutingAssembly()->GetManifestResourceStream("asx_jbh.xml");
        ds->ReadXml(file, System::Data::XmlReadMode::ReadSchema);
        DataTable^ dt = ds->Tables[0];
        DataView^ dv = gcnew DataView(dt);

        // create CandlePlot.
		CandlePlot^ cp = gcnew CandlePlot();
        cp->DataSource = dt;
        cp->AbscissaData = "Date";
        cp->OpenData = "Open";
        cp->LowData = "Low";
        cp->HighData = "High";
        cp->CloseData = "Close";
        cp->BearishColor = Color::Red;
        cp->BullishColor = Color::Green;
		cp->Style = CandlePlot::Styles::Filled;
		costPS->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::AntiAlias;
        costPS->Add(gcnew Grid());
        costPS->Add(cp);
        costPS->Title = "AU:JBH";
        costPS->YAxis1->Label = "Price [$]";
        costPS->YAxis1->LabelOffset = 40;
        costPS->YAxis1->LabelOffsetAbsolute = true;
        costPS->XAxis1->HideTickText = true;
        costPS->SurfacePadding = 5;
		costPS->AddInteraction(gcnew NPlot::Windows::PlotSurface2D::Interactions::HorizontalDrag());
		costPS->AddInteraction(gcnew NPlot::Windows::PlotSurface2D::Interactions::VerticalDrag());
        costPS->AddInteraction(gcnew NPlot::Windows::PlotSurface2D::Interactions::AxisDrag(false));
		costPS->InteractionOccured += gcnew NPlot::Windows::PlotSurface2D::InteractionHandler(this,&NPlotDemo::CFinancialDemo::costPS_InteractionOccured);
		costPS->AddAxesConstraint(gcnew AxesConstraint::AxisPosition(PlotSurface2D::YAxisPosition::Left, 60));

        PointPlot^ pp = gcnew PointPlot();
        pp->Marker = gcnew Marker(Marker::MarkerType::Square, 0);
        pp->Marker->Pen = gcnew Pen(Color::Red, 5.0f);
        pp->Marker->DropLine = true;
        pp->DataSource = dt;
        pp->AbscissaData = "Date"; 
        pp->OrdinateData = "Volume";
        volumePS->Add(pp);
        volumePS->YAxis1->Label = "Volume";
        volumePS->YAxis1->LabelOffsetAbsolute = true;
        volumePS->YAxis1->LabelOffset = 40;
        volumePS->SurfacePadding = 5;
		volumePS->AddAxesConstraint(gcnew AxesConstraint::AxisPosition(PlotSurface2D::YAxisPosition::Left, 60));
		volumePS->AddInteraction(gcnew NPlot::Windows::PlotSurface2D::Interactions::AxisDrag(false));
        volumePS->AddInteraction(gcnew NPlot::Windows::PlotSurface2D::Interactions::HorizontalDrag());
        volumePS->InteractionOccured += gcnew NPlot::Windows::PlotSurface2D::InteractionHandler(this,&NPlotDemo::CFinancialDemo::volumePS_InteractionOccured);
        volumePS->PreRefresh += gcnew NPlot::Windows::PlotSurface2D::PreRefreshHandler(this,&NPlotDemo::CFinancialDemo::volumePS_PreRefresh);

        costPS->RightMenu = gcnew ReducedContextMenu();
	}

	/// <summary>
    /// Callback for close button.
    /// </summary>
	System::Void CFinancialDemo::closeButton_Click(System::Object^  sender, System::EventArgs^  e)
	{
		Close();
	}

	/// <summary>
    /// When the costPS chart has changed, this is called which updates the volumePS chart.
    /// </summary>
    /// <param name="sender"></param>
    System::Void CFinancialDemo::costPS_InteractionOccured(System::Object^ sender)
    {
        DateTimeAxis^ axis = gcnew DateTimeAxis(costPS->XAxis1);
        axis->Label = "Date / Time";
        axis->HideTickText = false;
        volumePS->XAxis1 = axis;
        volumePS->Refresh();
    }


    /// <summary>
    /// When the volumePS chart has changed, this is called which updates hte costPS chart.
    /// </summary>
    System::Void CFinancialDemo::volumePS_InteractionOccured(System::Object^ sender)
    {
        DateTimeAxis^ axis = gcnew DateTimeAxis(volumePS->XAxis1);
        axis->Label = "";
        axis->HideTickText = true;
        costPS->XAxis1 = axis;
        costPS->Refresh();
    }

	/// <summary>
    /// This is called prior to volumePS refresh to enforce the WorldMin is 0. 
    /// This may have been changed by the axisdrag interaction.
    /// </summary>
    /// <param name="sender"></param>
    System::Void CFinancialDemo::volumePS_PreRefresh(System::Object^ sender)
    {
        volumePS->YAxis1->WorldMin = 0.0;
    }

	System::Void CFinancialDemo::CFinancialDemo_Resize(System::Object^  sender, System::EventArgs^  e)
	{
		costPS->Height = (int)(0.5 * (this->Height));
        costPS->Width = (int)(this->Width - 35);

        volumePS->Top = costPS->Height + 12;
        volumePS->Height = this->Height - (costPS->Height + 25) - 80;
        volumePS->Width = (int)(this->Width - 35);

        //OnResize(e);
	}
}

