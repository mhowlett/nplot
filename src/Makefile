all:
	xbuild /p:Configuration=Release NPlot.csproj

install: all
	gacutil -i bin/NPlot.dll

deinstall:
	gacutil -u NPlot

clean:
	xbuild /p:Configuration=Release /t:clean NPlot.csproj
