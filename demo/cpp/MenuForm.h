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

#pragma once


namespace NPlotDemo {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class CMenuForm : public System::Windows::Forms::Form
	{
	public:
		CMenuForm(void);

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~CMenuForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  quitButton;
	private: System::Windows::Forms::Button^  plotSurface2DDemoButton;
	private: System::Windows::Forms::Button^  multiPlotDemoButton;

	private: ArrayList^ testItems;
	private: System::Windows::Forms::Button^  testAxis;
	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->quitButton = (gcnew System::Windows::Forms::Button());
			this->plotSurface2DDemoButton = (gcnew System::Windows::Forms::Button());
			this->multiPlotDemoButton = (gcnew System::Windows::Forms::Button());
			this->testAxis = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// quitButton
			// 
			this->quitButton->Location = System::Drawing::Point(50, 163);
			this->quitButton->Name = L"quitButton";
			this->quitButton->Size = System::Drawing::Size(75, 23);
			this->quitButton->TabIndex = 0;
			this->quitButton->Text = L"Quit";
			this->quitButton->UseVisualStyleBackColor = true;
			this->quitButton->Click += gcnew System::EventHandler(this, &CMenuForm::quitButton_Click);
			// 
			// plotSurface2DDemoButton
			// 
			this->plotSurface2DDemoButton->Location = System::Drawing::Point(22, 12);
			this->plotSurface2DDemoButton->Name = L"plotSurface2DDemoButton";
			this->plotSurface2DDemoButton->Size = System::Drawing::Size(130, 23);
			this->plotSurface2DDemoButton->TabIndex = 1;
			this->plotSurface2DDemoButton->Text = L"PlotSurface2D Demo";
			this->plotSurface2DDemoButton->UseVisualStyleBackColor = true;
			this->plotSurface2DDemoButton->Click += gcnew System::EventHandler(this, &CMenuForm::plotSurface2DDemoButton_Click);
			// 
			// multiPlotDemoButton
			// 
			this->multiPlotDemoButton->Location = System::Drawing::Point(22, 40);
			this->multiPlotDemoButton->Name = L"multiPlotDemoButton";
			this->multiPlotDemoButton->Size = System::Drawing::Size(130, 23);
			this->multiPlotDemoButton->TabIndex = 2;
			this->multiPlotDemoButton->Text = L"Multi Plot Demo";
			this->multiPlotDemoButton->UseVisualStyleBackColor = true;
			this->multiPlotDemoButton->Click += gcnew System::EventHandler(this, &CMenuForm::multiPlotDemoButton_Click);
			// 
			// testAxis
			// 
			this->testAxis->Location = System::Drawing::Point(22, 68);
			this->testAxis->Name = L"testAxis";
			this->testAxis->Size = System::Drawing::Size(130, 23);
			this->testAxis->TabIndex = 3;
			this->testAxis->Text = L"Axis Test";
			this->testAxis->UseVisualStyleBackColor = true;
			this->testAxis->Click += gcnew System::EventHandler(this, &CMenuForm::testAxis_Click);
			// 
			// CMenuForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(175, 198);
			this->Controls->Add(this->testAxis);
			this->Controls->Add(this->multiPlotDemoButton);
			this->Controls->Add(this->plotSurface2DDemoButton);
			this->Controls->Add(this->quitButton);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Name = L"CMenuForm";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"NPlot Demo";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void quitButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 Application::Exit();
			 }
	
	private: System::Void plotSurface2DDemoButton_Click(System::Object^  sender, System::EventArgs^  e);

	private: System::Windows::Forms::Form^ displayForm_;
	private: System::Void multiPlotDemoButton_Click(System::Object^  sender, System::EventArgs^  e);
	private: System::Void testAxis_Click(System::Object^  sender, System::EventArgs^  e);
};
}


