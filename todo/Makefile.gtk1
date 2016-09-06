all:
	(cd lib; make all)

install:
	@if test x$$prefix = x; then \
		echo -e "\nError, usage is:\n\n\t make install prefix=INSTALLPREFIX\n"; \
		exit 1; \
	fi;
	(cd lib; make install prefix=$$prefix)