#!/usr/bin/perl
use warnings;
use strict;
use File::Basename qw(dirname basename fileparse);
use File::Spec;
use File::Copy;
use File::Path;

my $GTK_VERSION = "2.12";
my $GTK_INSTALLER = "gtk-sharp-2.12.9-2.win32.msi";
my $MONO_LIBRARIES_VERSION = "2.2";
my $MONO_LIBRARIES_INSTALLER = "mono-libraries-r135450.msi";

my $root = "";

my $incremental = "/t:Rebuild";

sub get_root {
	$root = File::Spec->rel2abs( dirname($0) );
	chdir $root;
	$root = File::Spec->rel2abs( File::Spec->updir() );
}

get_root ();
my $nant = "\"C:/nant-0.90/bin/NAnt.exe\"";

my $gtkPath = "$ENV{ProgramFiles}/GtkSharp/$GTK_VERSION";
my $monolibPath = "$ENV{ProgramFiles}/MonoLibraries/$MONO_LIBRARIES_VERSION";
if (defined($ENV{'ProgramFiles(x86)'}))
{
	$gtkPath = "$ENV{'ProgramFiles(x86)'}/GtkSharp/$GTK_VERSION";
	#$gtkPath = "$root/dependencies/GtkSharp/$GTK_VERSION";
	$monolibPath = "$ENV{'ProgramFiles(x86)'}/MonoLibraries/$MONO_LIBRARIES_VERSION";
	#$monolibPath = "$root/dependencies/MonoLibraries/$MONO_LIBRARIES_VERSION";
}

if (!-d $monolibPath)
{
	print "== Installing Mono Libraries $MONO_LIBRARIES_VERSION\n";
	system("msiexec /i $root\\monodevelop\\dependencies\\$MONO_LIBRARIES_INSTALLER /passive") && die("Failed to install GTK");
}
else
{
	print "== Mono Libraries $MONO_LIBRARIES_VERSION already installed\n";
}

if (!-d $gtkPath)
{
	print "== Installing GTK Sharp $GTK_VERSION. The machine must be restarted for it to work properly.\n";
	system("msiexec /i $root\\monodevelop\\dependencies\\$GTK_INSTALLER /passive /promptrestart") && die("Failed to install GTK");
}
else
{
	print "== GTK Sharp $GTK_VERSION already installed\n";
}

# Check sources
die ("Must grab Unity MonoDevelop source from github first") if !-d "$root/monodevelop";
die ("Must grab Unity MonoDevelop Soft Debugger source from github first") if !-d "$root/MonoDevelop.Debugger.Soft.Unity";
die ("Must grab Boo implementation") if !-d "$root/boo";
die ("Must grab Boo extensions implementation") if !-d "$root/boo-extensions";
die ("Must grab Unityscript implementation") if !-d "$root/unityscript";
die ("Must grab Boo MD Addins implementation") if !-d "$root/boo-md-addins";

system("\"$ENV{VS90COMNTOOLS}/vsvars32.bat\" && msbuild $root\\monodevelop\\main\\Main.sln /p:Configuration=DebugWin32 /p:Platform=x86 $incremental") && die ("Failed to compile MonoDevelop");

system("\"$ENV{VS90COMNTOOLS}/vsvars32.bat\" && msbuild $root\\MonoDevelop.Debugger.Soft.Unity\\MonoDevelop.Debugger.Soft.Unity.sln /p:Configuration=Release $incremental") && die ("Failed to compile MonoDevelop");

my $mdRoot = "$root/tmp/MonoDevelop";
my $mdSource = "$root/monodevelop/main/build";

rmtree "$mdRoot";

# MonoDevelop
mkpath "$mdRoot/bin";
mkpath "$mdRoot/Addins";
mkpath "$mdRoot/data/options";
system("xcopy /s \"$mdSource/bin\" \"$mdRoot/bin\"");
system("xcopy /s \"$mdSource/Addins\" \"$mdRoot/Addins\"");
system("xcopy /s \"$mdSource/data\" \"$mdRoot/data\"");

# Layout templates
copy "$mdSource/MacOSX/EditingLayout2.xml", "$mdRoot/data/options/EditingLayout2.xml";
copy "$mdSource/MacOSX/MonoDevelopProperties.xml", "$mdRoot/data/options/MonoDevelopProperties.xml";

# Unity soft debugger
mkpath "$mdRoot/Addins/MonoDevelop.Debugger.Soft.Unity";
copy "$root/MonoDevelop.Debugger.Soft.Unity/obj/Release/MonoDevelop.Debugger.Soft.Unity.dll", "$mdRoot/Addins/MonoDevelop.Debugger.Soft.Unity";

# GTK Sharp dependency files
mkpath "$mdRoot/lib";
mkpath "$mdRoot/etc";
mkpath "$mdRoot/share";
system("xcopy /s \"$gtkPath/bin\" \"$mdRoot/bin\"");
system("xcopy /s \"$gtkPath/lib\" \"$mdRoot/lib\"");
system("xcopy /s \"$gtkPath/etc\" \"$mdRoot/etc\"");
system("xcopy /s \"$gtkPath/share\" \"$mdRoot/share\"");
system("xcopy /s \"$gtkPath/lib/Mono.Posix\" \"$mdRoot/bin\"");
system("xcopy /s \"$gtkPath/lib/gtk-sharp-2.0\" \"$mdRoot/bin\"");
system("xcopy /s \"$gtkPath/lib/Mono.Cairo\" \"$mdRoot/bin\"");
# TODO: An installer should execute "gdk-pixbuf-query-loaders.exe > ../etc/gtk-2.0/gdk-pixbuf.loaders" after installing files to get a proper loader file
copy "$root/dependencies/gdk-pixbuf.loaders", "$mdRoot/etc/gtk-2.0";

# Mono Libraries dependency files
system("xcopy /s \"$monolibPath/lib/mono/2.0\" \"$mdRoot/bin\"");

chdir "$root/boo";
system("$nant rebuild") && die ("Failed to build Boo");
mkpath "$mdRoot/Addins/BackendBindings/Boo/boo";
system("xcopy /s /y \"$root/boo/build\" \"$mdRoot/Addins/BackendBindings/Boo/boo\"");
unlink glob "$mdRoot/Addins/BackendBindings/Boo/boo/*.pdb" or die ("unlink fail");

chdir "$root/boo-extensions";
copy "$root/monodevelop/dependencies/build.properties", "$root/boo-extensions/build.properties";
system("$nant rebuild") && die ("Failed to build Boo extensions monodevelop");

chdir "$root/unityscript";
copy "$root/monodevelop/dependencies/build.properties", "$root/unityscript/build.properties";
my $javascriptFiles =  "$mdRoot/Addins/BackendBindings/UnityScript/bin";
mkpath $javascriptFiles;
system("$nant rebuild") && die ("Failed to build UnityScript");
system("xcopy /s /y \"$root/unityscript/bin\" \"$javascriptFiles\"");
unlink glob "$javascriptFiles/*.pdb" or die ("unlink fail");
unlink glob "$javascriptFiles/*Tests*" or die ("unlink fail");
unlink "$javascriptFiles/nunit.framework.dll" or die ("unlink fail");

chdir "$root/boo-md-addins";
copy "$root/monodevelop/dependencies/build.properties", "$root/boo-md-addins/build.properties";
system("$nant rebuild") && die ("Failed to build Boo MD Addins");
copy "$root/boo-md-addins/build/Boo.MonoDevelop.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/Boo.Ide.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$mdRoot/AddIns/BackendBindings/Boo";

copy "$root/boo-md-addins/build/UnityScript.MonoDevelop.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/Boo.Ide.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";

chdir "$root/tmp";
unlink "$root/MonoDevelop.zip";
system("\"C:\\Program\ Files\ \(x86\)\\7-Zip\7z\" a -r \"$root/MonoDevelop.zip\" *.*");
chdir "$root";
