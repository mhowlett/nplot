CSC=mcs
# CSC=gmcs
CSCFLAGS+= /define:MONO /warn:4 /nologo /target:library

# Mono version (used only for subdirs)
MONO_VERION = 1.0
# MONO_VERION = 2.0

# Symbols that identify build target
CSCFLAGS+= /define:MONO_1_0 /define:API_1_1
# CSCFLAGS+= /define:MONO_2_0 /define:API_2_0

# Target subdir
TARGET_BUILD = debug
# TARGET_BUILD = release

# Debug compile options
CSCFLAGS+= /debug+ /debug:full /define:DEBUG

# Base source dir
BASE = .

# Base dir for references
BASE_REF = $(BASE)/bin/mono
BASE_REF_VERSION = $(BASE)/bin/mono/$(MONO_VERION)

BIN = $(BASE)/bin/mono/$(MONO_VERION)/$(TARGET_BUILD)

SOURCES = $(BASE)/src/*.cs

REFERENCES= System.Data System.Design System.Drawing System.Web System.Windows.Forms
REFS= $(addsuffix .dll, $(addprefix /r:, $(REFERENCES)))

all: NPlot

NPlot: builddir $(BIN)/NPlot.dll

builddir:
	if [ ! -d $(BIN) ]; then \
                mkdir -p $(BIN); \
        fi; \

$(BIN)/NPlot.dll: $(SOURCES)
	$(CSC) $(CSCFLAGS) $(REFS) /out:$@ $^

clean:
	rm -f $(BIN)/NPlot.dll

distclean:
	rm -Rf $(BASE)/bin/
