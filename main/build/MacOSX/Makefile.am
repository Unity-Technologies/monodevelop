BUNDLE_VERSION=$(VERSION)
MAC_APP_DIR=MonoDevelop.app
MACOS=$(MAC_APP_DIR)/Contents/MacOS
MAC_APP_LIB_DIR=$(MACOS)/lib/monodevelop
ADDINS=$(MACOS)/lib/monodevelop/AddIns
BUNDLED_FRAMEWORK_DIR=$(MAC_APP_DIR)/Contents/Frameworks/Mono.framework
FINAL_INSTALL_DIR=/Applications/$(MAC_APP_DIR)
MODERN_GTK_DIR=../../../../gtk
EXTRAS=$(top_srcdir)/../extras
ARTIFACTS=$(top_srcdir)/../../artifacts

CLEANFILES = MonoDevelop.dmg MonoDevelop.app
#DISTCLEANFILES = 
EXTRA_DIST = dmg-bg.png DS_Store Info.plist.in make-dmg-bundle.sh mdtool monodevelop 
CURRENT=$(shell readlink /Library/Frameworks/Mono.framework/Versions/Current)

all: MonoDevelop.app

MonoDevelop.dmg: mono-bundle
	./make-dmg-bundle.sh

clean-local:
	rm -rf MonoDevelop.app
	rm -f MonoDevelop.dmg
	rm -f MonoDevelop.app.zip

MonoDevelop.app:
	mkdir -p $(MAC_APP_DIR)/Contents/{MacOS,Resources}
	mkdir -p $(MAC_APP_DIR)/Contents/MacOS/{lib,share}
	mkdir -p $(MAC_APP_LIB_DIR)
	cp -pR ../AddIns $(MAC_APP_LIB_DIR)
	cp -pR ../data $(MAC_APP_LIB_DIR)
	cp -pR ../bin $(MAC_APP_LIB_DIR)
	cp -pR ../locale $(MAC_APP_DIR)/Contents/MacOS/share
	
	mkdir -p $(MAC_APP_DIR)/Contents/MacOS/share/monodevelop
	cp ../../COPYING $(MAC_APP_DIR)/Contents/MacOS/share/monodevelop/COPYING.LGPL2.1
	
	sed -e "s/@BUNDLE_VERSION@/$(BUNDLE_VERSION)/" -e "s/@ASSEMBLY_VERSION@/$(ASSEMBLY_VERSION)/" Info.plist.in > $(MAC_APP_DIR)/Contents/Info.plist
	cp ../../theme-icons/Mac/*.icns $(MAC_APP_DIR)/Contents/Resources/
	cp monodevelop.orig $(MACOS)/monodevelop
	cp mono-version-check $(MACOS)/mono-version-check
	cp mdtool.orig $(MACOS)/mdtool
	cp MonoDevelopProperties.xml EditingLayout2.xml $(MAC_APP_DIR)/Contents/MacOS/lib/monodevelop/data/options

# copy monodevelop.pc and mono-addins.pc to Contents/MacOS/lib/pkgconfig
	mkdir -p $(MACOS)/lib/pkgconfig
	cp ../../*.pc $(MACOS)/lib/pkgconfig
	
# Copy main/monodevelop.xml to MonoDevelop.app/Contents/MacOS/share/mime/packages
	mkdir -p $(MACOS)/share/{applications,mime,icons,locale,man}
	mkdir -p $(MACOS)/share/mime/packages
	cp ../../monodevelop.xml $(MACOS)/share/mime/packages
	cp ../../monodevelop.desktop $(MACOS)/share/applications
	
# Remove addins that don't work on OSX
	rm -rf  $(ADDINS)/GnomePlatform* \
	  $(ADDINS)/WindowsPlatform* \
	  $(ADDINS)/MonoDevelop.Gettext/*
	
# remove stuff we don't need
	rm -rf $(MACOS)/lib/monodevelop/bin/UnitTests.dll* \
	  $(MACOS)/lib/monodevelop/bin/TestResult.xml \
	  $(MACOS)/lib/monodevelop/bin/addin-db* \
	  $(MACOS)/lib/monodevelop/bin/local \
	  $(MACOS)/lib/monodevelop/bin/repository-cache* \
	  $(MACOS)/lib/monodevelop/AddIns/MonoDevelop.TextTemplating/Mono.TextTemplating.Tests*

# add extras known to work on Mac, if they exist
	for ADDIN in MonoDevelop.IPhone MonoDevelop.MonoMac MonoDevelop.Database MonoDevelop.MonoDroid; do \
		(ls $(EXTRAS)/$${ADDIN}/build/* > /dev/null 2>&1 && \
			echo "Copying $${ADDIN}" && \
			mkdir -p $(MAC_APP_LIB_DIR)/AddIns/$${ADDIN} && \
			cp -pR $(EXTRAS)/$${ADDIN}/build/* $(MAC_APP_LIB_DIR)/AddIns/$${ADDIN}/ ) \
		|| (echo "Skipping $${ADDIN}" && echo "$${ADDIN}" >> missing-stuff)  ; \
	done

# add the binary artifacts if they exist
	mkdir -p $(MACOS)/lib/{moonlight,pkgconfig}
	mkdir -p $(MACOS)/MonoDoc.app/
	test ! -d $(ARTIFACTS)/MoonSDK ||  cp -pR $(ARTIFACTS)/MoonSDK/* $(MACOS)/lib/moonlight/
	test ! -d $(ARTIFACTS)/MonoDoc.app ||  cp -pR $(ARTIFACTS)/MonoDoc.app/* $(MACOS)/MonoDoc.app/

	cp -r MDMonitor.app $(MACOS)

# Mono stubs to make the process name and bundle location correct
	mkdir -p "$(MACOS)/bin"
	ln -s /Library/Frameworks/Mono.framework/Versions/Current/bin/mono "$(MACOS)/bin/monodevelop"
	ln -s /Library/Frameworks/Mono.framework/Versions/Current/bin/mono "$(MACOS)/bin/mdtool"

# update revision in updateinfo
	echo "a3140c14-ef90-4019-ae6c-9d93804d6611 $$(cat release-info)" > "$(MACOS)/updateinfo"

# touch the directory so that update dependencies work
	touch MonoDevelop.app
	
	@echo ""
	@echo "MONODEVELOP RELEASE: $$(cat release-info)"
	@echo "$$(cat ../../vcrevision)"
	@if test -f missing-stuff; then echo ""; echo "Missing stuff:"; cat missing-stuff; fi
	@echo ""
	@rm -f missing-stuff

# touch the directory so that update dependencies work
	touch MonoDevelop.app

mono-bundle: MonoDevelop.app
#########################
# Bundle mono
	echo "Preparing mono bundle..."
	mkdir -p $(MAC_APP_DIR)/Contents/Frameworks

# Copy system mono framework
	echo "Copying system framework ($(CURRENT))"
	rm -rf $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework
	mkdir -p $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Versions
	cp -R /Library/Frameworks/Mono.framework/Versions/$(CURRENT) $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Versions
	ln -s Versions/Current/bin $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Commands
	ln -s Versions/Current/include $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Headers
	ln -s Versions/Current $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Home
	ln -s Versions/Current/lib $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Libraries
	ln -s Libraries/libmono.dylib $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Mono
	ln -s Versions/Current/Resources $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Resources
	ln -s $(CURRENT) $(MAC_APP_DIR)/Contents/Frameworks/Mono.framework/Versions/Current
	./transplant_gtk.sh $(MODERN_GTK_DIR) $(BUNDLED_FRAMEWORK_DIR)/Versions/Current
	mkdir -p $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/etc/pango
	cp pangorc $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/etc/pango
	cp monodevelop $(MACOS)/monodevelop
	cp mdtool $(MACOS)/mdtool
	cp replacePath.sh $(MACOS)/replacePath.sh
	chmod +x $(MACOS)/monodevelop $(MACOS)/mdtool

# Relocate .exe.config, .dll.config, pixbuf loaders, and .pc files
	echo "Relocating config files"
	find $(BUNDLED_FRAMEWORK_DIR) -name '*.config' -exec ./copyToInputFile.sh {} \;
	find $(BUNDLED_FRAMEWORK_DIR) -name '*.pc' -exec ./copyToInputFile.sh {} \;
	find $(BUNDLED_FRAMEWORK_DIR) -name '*.loaders' -exec ./copyToInputFile.sh {} \;
	./copyToInputFile.sh $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/etc/mono/config
	./copyToInputFile.sh $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/etc/pango/pango.modules
	./copyToInputFile.sh $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/etc/pango/pangorc
	rm -f $(MAC_APP_LIB_DIR)/bin/MonoDevelop.exe.config

# Relocate launcher scripts
	echo "Relocating launcher scripts"
	file $(BUNDLED_FRAMEWORK_DIR)/Versions/Current/bin/* | grep 'shell script' | awk -F: '{ print $$1 }' | xargs -n 1 ./copyToInputFile.sh
#
#########################
	
MonoDevelop.app.zip: mono-bundle
	zip -r9uq MonoDevelop.app.zip MonoDevelop.app

.PHONY: MonoDevelop.app
