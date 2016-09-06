/*
 * NPlot - A charting library for .NET
 * 
 * PlotSurface2DDemo.cs
 * Copyright (C) 2003-2006 Jamie McQuay.
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
#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace NPlot;


namespace NPlotDemo {

	/// <summary>
	/// Summary for PlotSurface2DDemo
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class CPlotSurface2DDemo : public System::Windows::Forms::Form
	{
	public:
		CPlotSurface2DDemo(void);

		System::Void PlotCircular();
		System::Void PlotWavelet();
		System::Void PlotLogAxis();
		System::Void PlotLogLog();
		System::Void PlotSincFunction();
		System::Void PlotGaussian();
		System::Void PlotABC();
		System::Void PlotLabelAxis();
		System::Void PlotParticles();
		System::Void PlotQE();
		System::Void PlotDataSet();
		System::Void PlotImage();
		System::Void PlotMarkers();
		System::Void PlotCandle();
		System::Void PlotTest();
		System::Void PlotWave();
		System::Void PlotMultiHistogram();
		System::Void PlotCandleSimple();
		System::Void PlotMockup();
		System::Void PlotProfitLoss();
		
	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~CPlotSurface2DDemo()
		{
			if (components)
			{
				delete components;
			}
		}
	private: 
		NPlot::Windows::PlotSurface2D^  plotSurface;

		array<float>^ CPlotSurface2DDemo::makeDaub( int len ); 
		System::Void TwissEllipse(float a, float b, float g, float e, array<float>^ x, array<float>^ y);
		System::Void Twiss(array<float>^ x, array<float>^ y, float& a, float& b, float& g, float& e);

	protected: 

	// Note that a NPlot.Windows.PlotSurface2D class
	// is used here. This has exactly the same 
	// functionality as the NPlot.PlotSurface2D 
	// class, except that it is derived from Forms.UserControl
	// and automatically paints itself in a windows.forms
	// application. Windows.PlotSurface2D can also paint itself
	// to other arbitrary Drawing.Graphics drawing surfaces
	// using the Draw method. (see printing later).


	private: System::Windows::Forms::Button^  prevPlotButton;
	private: System::Drawing::Printing::PrintDocument^ printDocument;

	private: System::Windows::Forms::Button^  nextPlotButton;
	private: System::Windows::Forms::Button^  printButton;
	private: System::Windows::Forms::Button^  quitButton;
	private: System::Windows::Forms::Label^  exampleNumberLabel;
	private: System::Windows::Forms::Timer^  qeExampleTimer;

	private: System::Windows::Forms::TextBox^  infoBox;

	
	private: System::Void quitButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::Void printButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::Void nextPlotButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::Void prevPlotButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::ComponentModel::IContainer^  components;

	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


		/// <summary>
		/// used to keep track of the current demo plot being displayed.
		/// </summary>
		int currentPlot;

		/// <summary>
		/// delegate for plot demo functions.
		/// </summary>
		delegate void PlotDemoDelegate();

		/// <summary>
		///  list of the plot demos, initialized in the form constructor.
		/// </summary>
		array<PlotDemoDelegate^>^ PlotRoutines;

		array<double>^ PlotQEExampleValues;
		array<System::String^>^ PlotQEExampleTextValues;

		System::Void pd_PrintPage(System::Object^ sender, Printing::PrintPageEventArgs^ ev);

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->plotSurface = (gcnew NPlot::Windows::PlotSurface2D());
			this->prevPlotButton = (gcnew System::Windows::Forms::Button());
			this->nextPlotButton = (gcnew System::Windows::Forms::Button());
			this->printButton = (gcnew System::Windows::Forms::Button());
			this->quitButton = (gcnew System::Windows::Forms::Button());
			this->infoBox = (gcnew System::Windows::Forms::TextBox());
			this->exampleNumberLabel = (gcnew System::Windows::Forms::Label());
			this->qeExampleTimer = (gcnew System::Windows::Forms::Timer(this->components));
			this->SuspendLayout();
			// 
			// plotSurface
			// 
			this->plotSurface->AutoScaleAutoGeneratedAxes = false;
			this->plotSurface->AutoScaleTitle = false;
			this->plotSurface->BackColor = System::Drawing::SystemColors::ControlLightLight;
			this->plotSurface->DateTimeToolTip = false;
			this->plotSurface->Legend = nullptr;
			this->plotSurface->LegendZOrder = 1;
			this->plotSurface->Location = System::Drawing::Point(8, 8);
			this->plotSurface->Name = L"plotSurface";
			this->plotSurface->RightMenu = nullptr;
			this->plotSurface->ShowCoordinates = true;
			this->plotSurface->Size = System::Drawing::Size(616, 360);
			this->plotSurface->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::None;
			this->plotSurface->TabIndex = 0;
			this->plotSurface->Text = L"plotSurface2D1";
			this->plotSurface->Title = L"";
			this->plotSurface->TitleFont = (gcnew System::Drawing::Font(L"Arial", 14, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Pixel));
			this->plotSurface->XAxis1 = nullptr;
			this->plotSurface->XAxis2 = nullptr;
			this->plotSurface->YAxis1 = nullptr;
			this->plotSurface->YAxis2 = nullptr;
			// 
			// prevPlotButton
			// 
			this->prevPlotButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->prevPlotButton->Location = System::Drawing::Point(8, 374);
			this->prevPlotButton->Name = L"prevPlotButton";
			this->prevPlotButton->Size = System::Drawing::Size(75, 23);
			this->prevPlotButton->TabIndex = 1;
			this->prevPlotButton->Text = L"Prev";
			this->prevPlotButton->UseVisualStyleBackColor = true;
			this->prevPlotButton->Click += gcnew System::EventHandler(this, &CPlotSurface2DDemo::prevPlotButton_Click);
			// 
			// nextPlotButton
			// 
			this->nextPlotButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->nextPlotButton->Location = System::Drawing::Point(90, 374);
			this->nextPlotButton->Name = L"nextPlotButton";
			this->nextPlotButton->Size = System::Drawing::Size(75, 23);
			this->nextPlotButton->TabIndex = 2;
			this->nextPlotButton->Text = L"Next";
			this->nextPlotButton->UseVisualStyleBackColor = true;
			this->nextPlotButton->Click += gcnew System::EventHandler(this, &CPlotSurface2DDemo::nextPlotButton_Click);
			// 
			// printButton
			// 
			this->printButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->printButton->Location = System::Drawing::Point(172, 374);
			this->printButton->Name = L"printButton";
			this->printButton->Size = System::Drawing::Size(75, 23);
			this->printButton->TabIndex = 3;
			this->printButton->Text = L"Print";
			this->printButton->UseVisualStyleBackColor = true;
			this->printButton->Click += gcnew System::EventHandler(this, &CPlotSurface2DDemo::printButton_Click);
			// 
			// quitButton
			// 
			this->quitButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->quitButton->Location = System::Drawing::Point(254, 374);
			this->quitButton->Name = L"quitButton";
			this->quitButton->Size = System::Drawing::Size(75, 23);
			this->quitButton->TabIndex = 4;
			this->quitButton->Text = L"Close";
			this->quitButton->UseVisualStyleBackColor = true;
			this->quitButton->Click += gcnew System::EventHandler(this, &CPlotSurface2DDemo::quitButton_Click);
			// 
			// infoBox
			// 
			this->infoBox->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->infoBox->Location = System::Drawing::Point(8, 416);
			this->infoBox->Multiline = true;
			this->infoBox->Name = L"infoBox";
			this->infoBox->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->infoBox->Size = System::Drawing::Size(611, 92);
			this->infoBox->TabIndex = 5;
			// 
			// exampleNumberLabel
			// 
			this->exampleNumberLabel->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->exampleNumberLabel->Location = System::Drawing::Point(335, 374);
			this->exampleNumberLabel->Name = L"exampleNumberLabel";
			this->exampleNumberLabel->Size = System::Drawing::Size(72, 23);
			this->exampleNumberLabel->TabIndex = 6;
			// 
			// qeExampleTimer
			// 
			this->qeExampleTimer->Interval = 500;
			this->qeExampleTimer->Tick += gcnew System::EventHandler(this, &CPlotSurface2DDemo::qeExampleTimer_Tick);
			// 
			// CPlotSurface2DDemo
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(631, 520);
			this->Controls->Add(this->exampleNumberLabel);
			this->Controls->Add(this->infoBox);
			this->Controls->Add(this->quitButton);
			this->Controls->Add(this->printButton);
			this->Controls->Add(this->nextPlotButton);
			this->Controls->Add(this->prevPlotButton);
			this->Controls->Add(this->plotSurface);
			this->Name = L"CPlotSurface2DDemo";
			this->Text = L"NPlot C++.Net Demo";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion


private: System::Void qeExampleTimer_Tick(System::Object^  sender, System::EventArgs^  e);
};
}





//#pragma once
//
//using namespace System;
//using namespace System::ComponentModel;
//using namespace System::Collections;
//using namespace System::Windows::Forms;
//using namespace System::Data;
//using namespace System::Drawing;
//
//
//namespace cpp {
//
//	/// <summary>
//	/// Summary for PlotSurface2DDemo
//	///
//	/// WARNING: If you change the name of this class, you will need to change the
//	///          'Resource File Name' property for the managed resource compiler tool
//	///          associated with all .resx files this class depends on.  Otherwise,
//	///          the designers will not be able to interact properly with localized
//	///          resources associated with this form.
//	/// </summary>
//	public ref class PlotSurface2DDemo : public System::Windows::Forms::Form
//	{
//	public:
//		PlotSurface2DDemo(void)
//		{
//			InitializeComponent();
//			//
//			//TODO: Add the constructor code here
//			//
//		}
//
//	protected:
//		/// <summary>
//		/// Clean up any resources being used.
//		/// </summary>
//		~PlotSurface2DDemo()
//		{
//			if (components)
//			{
//				delete components;
//			}
//		}
//	private: NPlot::Windows::PlotSurface2D^  plotSurface;
//	private: System::Windows::Forms::Button^  prevPlotButton;
//	private: System::Windows::Forms::Button^  nextPlotButton;
//	private: System::Windows::Forms::Button^  printButton;
//	private: System::Windows::Forms::Button^  quitButton;
//	private: System::Windows::Forms::TextBox^  infoBox;
//	private: System::Windows::Forms::Label^  exampleNumberLabel;
//	private: System::Windows::Forms::Timer^  qeExampleTimer;
//	private: System::ComponentModel::IContainer^  components;
//	protected: 
//
//	protected: 
//
//	private:
//		/// <summary>
//		/// Required designer variable.
//		/// </summary>
//
//
//#pragma region Windows Form Designer generated code
//		/// <summary>
//		/// Required method for Designer support - do not modify
//		/// the contents of this method with the code editor.
//		/// </summary>
//		void InitializeComponent(void)
//		{
//			this->components = (gcnew System::ComponentModel::Container());
//			this->plotSurface = (gcnew NPlot::Windows::PlotSurface2D());
//			this->prevPlotButton = (gcnew System::Windows::Forms::Button());
//			this->nextPlotButton = (gcnew System::Windows::Forms::Button());
//			this->printButton = (gcnew System::Windows::Forms::Button());
//			this->quitButton = (gcnew System::Windows::Forms::Button());
//			this->infoBox = (gcnew System::Windows::Forms::TextBox());
//			this->exampleNumberLabel = (gcnew System::Windows::Forms::Label());
//			this->qeExampleTimer = (gcnew System::Windows::Forms::Timer(this->components));
//			this->SuspendLayout();
//			// 
//			// plotSurface
//			// 
//			this->plotSurface->AutoScaleAutoGeneratedAxes = false;
//			this->plotSurface->AutoScaleTitle = false;
//			this->plotSurface->BackColor = System::Drawing::SystemColors::ControlLightLight;
//			this->plotSurface->DateTimeToolTip = false;
//			this->plotSurface->Legend = nullptr;
//			this->plotSurface->LegendZOrder = -1;
//			this->plotSurface->Location = System::Drawing::Point(71, 23);
//			this->plotSurface->Name = L"plotSurface";
//			this->plotSurface->RightMenu = nullptr;
//			this->plotSurface->ShowCoordinates = true;
//			this->plotSurface->Size = System::Drawing::Size(328, 272);
//			this->plotSurface->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::None;
//			this->plotSurface->TabIndex = 0;
//			this->plotSurface->Text = L"plotSurface2D1";
//			this->plotSurface->Title = L"";
//			this->plotSurface->TitleFont = (gcnew System::Drawing::Font(L"Arial", 14, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Pixel));
//			this->plotSurface->XAxis1 = nullptr;
//			this->plotSurface->XAxis2 = nullptr;
//			this->plotSurface->YAxis1 = nullptr;
//			this->plotSurface->YAxis2 = nullptr;
//			// 
//			// prevPlotButton
//			// 
//			this->prevPlotButton->Location = System::Drawing::Point(23, 329);
//			this->prevPlotButton->Name = L"prevPlotButton";
//			this->prevPlotButton->Size = System::Drawing::Size(75, 23);
//			this->prevPlotButton->TabIndex = 1;
//			this->prevPlotButton->Text = L"Prev";
//			this->prevPlotButton->UseVisualStyleBackColor = true;
//			// 
//			// nextPlotButton
//			// 
//			this->nextPlotButton->Location = System::Drawing::Point(105, 329);
//			this->nextPlotButton->Name = L"nextPlotButton";
//			this->nextPlotButton->Size = System::Drawing::Size(75, 23);
//			this->nextPlotButton->TabIndex = 2;
//			this->nextPlotButton->Text = L"Next";
//			this->nextPlotButton->UseVisualStyleBackColor = true;
//			// 
//			// printButton
//			// 
//			this->printButton->Location = System::Drawing::Point(187, 329);
//			this->printButton->Name = L"printButton";
//			this->printButton->Size = System::Drawing::Size(75, 23);
//			this->printButton->TabIndex = 3;
//			this->printButton->Text = L"Print";
//			this->printButton->UseVisualStyleBackColor = true;
//			this->printButton->Click += gcnew System::EventHandler(this, &PlotSurface2DDemo::printButton_Click);
//			// 
//			// quitButton
//			// 
//			this->quitButton->Location = System::Drawing::Point(268, 329);
//			this->quitButton->Name = L"quitButton";
//			this->quitButton->Size = System::Drawing::Size(75, 23);
//			this->quitButton->TabIndex = 4;
//			this->quitButton->Text = L"Close";
//			this->quitButton->UseVisualStyleBackColor = true;
//			// 
//			// infoBox
//			// 
//			this->infoBox->Location = System::Drawing::Point(32, 383);
//			this->infoBox->Multiline = true;
//			this->infoBox->Name = L"infoBox";
//			this->infoBox->Size = System::Drawing::Size(100, 20);
//			this->infoBox->TabIndex = 5;
//			// 
//			// exampleNumberLabel
//			// 
//			this->exampleNumberLabel->AutoSize = true;
//			this->exampleNumberLabel->Location = System::Drawing::Point(373, 329);
//			this->exampleNumberLabel->Name = L"exampleNumberLabel";
//			this->exampleNumberLabel->Size = System::Drawing::Size(35, 13);
//			this->exampleNumberLabel->TabIndex = 6;
//			this->exampleNumberLabel->Text = L"label1";
//			// 
//			// qeExampleTimer
//			// 
//			this->qeExampleTimer->Interval = 500;
//			// 
//			// PlotSurface2DDemo
//			// 
//			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
//			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
//			this->ClientSize = System::Drawing::Size(561, 489);
//			this->Controls->Add(this->exampleNumberLabel);
//			this->Controls->Add(this->infoBox);
//			this->Controls->Add(this->quitButton);
//			this->Controls->Add(this->printButton);
//			this->Controls->Add(this->nextPlotButton);
//			this->Controls->Add(this->prevPlotButton);
//			this->Controls->Add(this->plotSurface);
//			this->Name = L"PlotSurface2DDemo";
//			this->Text = L"PlotSurface2DDemo";
//			this->ResumeLayout(false);
//			this->PerformLayout();
//
//		}
//#pragma endregion
//	private: System::Void printButton_Click(System::Object^  sender, System::EventArgs^  e) {
//			 }
//};
//}
