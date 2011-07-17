RAW_API=gudev-api.raw
API=gudev-api.xml
METADATA=gudev.metadata

ASSEMBLY_NAME= gudev-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

CODEGEN=gapi3-codegen
FIXUP=gapi3-fixup

sources = 

build_sources = $(addprefix $(srcdir)/, $(sources)) AssemblyInfo.cs

customs = 

CLEANFILES = gudev-sharp.dll generated-stamp generated/*.cs $(API) gudev-sharp.snk

DISTCLEANFILES= AssemblyInfo.cs

noinst_DATA = gudev-sharp.dll

moduledir = $(prefix)/lib/mono/gudev-sharp-1.0/
module_SCRIPTS = gudev-sharp.dll.config

all: generated-stamp gudev-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	$(FIXUP) --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 $(CODEGEN) --generate $(srcdir)/$(API) $(GTK_SHARP_CFLAGS) --outdir=generated --customdir=$(srcdir) --assembly-name=gudev-sharp && touch generated-stamp

gudev-sharp.snk: $(top_srcdir)/gudev-sharp.snk
	cp $(top_srcdir)/gudev-sharp.snk .

gudev-sharp.dll: $(build_sources) generated-stamp gudev-sharp.snk
	$(CSC) -out:gudev-sharp.dll -unsafe -target:library $(GTK_SHARP_LIBS) \
	$(build_sources) $(GENERATED_SOURCES)

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f /package gudev-sharp-1.0 /root $(DESTDIR)$(prefix)/lib";  \
        $(GACUTIL) /i $(ASSEMBLY) /f /package gudev-sharp-1.0 /root $(DESTDIR)$(prefix)/lib || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) /package gudev-sharp-1.0 /root $(DESTDIR)$(libdir)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) /package gudev-sharp-1.0 /root $(DESTDIR)$(libdir) || exit 1;

EXTRA_DIST = $(API) $(RAW_API) $(sources) $(customs) $(METADATA) AssemblyInfo.cs.in gudev-sharp.dll.config.in
