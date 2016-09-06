CSC=mcs -debug+
VERSION=0.9.9.2
NPLOT_SOURCES =				\
	AdapterUtils.cs	\
	NPlotException.cs \
	ArrowItem.cs			\
	AssemblyInfo.cs			\
	AxesConstraint.cs		\
	Axis.cs				\
	BasePlot.cs			\
	BaseSequenceLinePlot.cs		\
	BaseSequencePlot.cs		\
	Bitmap.PlotSurface2D.cs		\
	CandlePlot.cs			\
	DateTimeAxis.cs			\
	ErrorHandler.cs			\
	FilledRegion.cs			\
	FontScaler.cs			\
	Grid.cs				\
	HistogramPlot.cs		\
	HorizontalLine.cs		\
	IDrawable.cs			\
	IGradient.cs			\
	ImagePlot.cs			\
	IMeshPlot.cs			\
	IPlot.cs			\
	IPlotSurface2D.cs		\
	ITransform2D.cs			\
	ISequencePlot.cs		\
	LabelAxis.cs			\
	LabelPointPlot.cs		\
	LegendBase.cs			\
	Legend.cs			\
	LinearAxis.cs			\
	LinearGradient.cs		\
	LinePlot.cs			\
	LogAxis.cs			\
	Marker.cs			\
	MarkerItem.cs			\
	PageAlignedPhysicalAxis.cs	\
	PhysicalAxis.cs			\
	PiAxis.cs			\
	PiePlot.cs			\
	PlotSurface2D.cs		\
	PlotSurface3D.cs		\
	PointD.cs			\
	PointPlot.cs			\
	RectangleBrushes.cs		\
	RectangleD.cs			\
	SequenceAdapter.cs		\
	StartStep.cs			\
	StepPlot.cs			\
	Transform2D.cs			\
	Utils.cs			\
	VerticalLine.cs			\
	Web.Design.PlotSurface2D.cs	\
	Web.PlotSurface2D.cs

NPLOT_GTK_SOURCES =			\
	Gtk.PlotSurface2D.cs 		\
	sysdraw.cs

all: NPlot.dll NPlot.Gtk.dll tests

tests: mf.exe test.exe

NPLOT_DLLS= -r:System.Web \
				-r:System.Design \
				-r:System.Drawing \
				-r:System.Data 

NPLOT_GTK_DLLS= -r:System.Web \
		-r:System.Design \
		-r:System.Drawing \
		-r:System.Data \
		-pkg:gtk-sharp-2.0 \
		-r:NPlot.dll


NPlot.dll: $(NPLOT_SOURCES) Makefile
	$(CSC) $(NPLOT_SOURCES) -target:library -out:NPlot.dll $(NPLOT_DLLS) 

NPlot.Gtk.dll: $(NPLOT_SOURCES) $(NPLOT_GTK_SOURCES) NPlot.dll Makefile
	$(CSC) $(NPLOT_GTK_SOURCES) -target:library -out:NPlot.Gtk.dll $(NPLOT_GTK_DLLS)

mf.exe: MainForm.cs NPlot.Gtk.dll
	$(CSC) MainForm.cs -out:mf.exe -r:NPlot.dll -r:NPlot.Gtk.dll -pkg:gtk-sharp-2.0 -r:System.Drawing -r:System.Data -resource:asx_jbh.xml,NPlotDemo.resources.asx_jbh.xml

test.exe: NPlot.dll test.cs
	$(CSC) test.cs -r:NPlot.dll -r:NPlot.Gtk.dll -pkg:gtk-sharp-2.0 -r:System.Drawing

install: NPlot.dll NPlot.Gtk.dll
	-mkdir -p $(prefix)/lib/nplot
	cp NPlot.dll NPlot.Gtk.dll $(prefix)/lib/mono/1.0/
	sed -e "s,@prefix@,$(prefix),g" -e "s/@VERSION@/$(VERSION)/" < nplot.pc.in > $(prefix)/lib/pkgconfig/nplot.pc
	sed -e "s,@prefix@,$(prefix),g" -e "s/@VERSION@/$(VERSION)/" < nplot-gtk.pc.in > $(prefix)/lib/pkgconfig/nplot-gtk.pc

clean:
	rm *exe *dll *mdb
