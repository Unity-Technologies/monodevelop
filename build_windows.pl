#!/usr/bin/perl
use warnings;
use strict;
use File::Basename qw(dirname basename fileparse);
use File::Spec;
use File::Copy;
use File::Path;
use Digest::MD5;

my $GTK_VERSION = "2.12";
my $GTK_INSTALLER = "gtk-sharp-2.12.22.msi";
my $GTK_SHARP_DLL_MD5 = "4ffdcbd3b4f3b602f1599b3c0cad9419";

my $MONO_LIBRARIES_VERSION = "2.6";
my $MONO_LIBRARIES_INSTALLER = "MonoLibraries.msi";
my $SevenZip = '"C:\Program Files (x86)\7-Zip\7z"';

my $root = "";

my $incremental = "/t:Rebuild";

sub get_root {
	$root = File::Spec->rel2abs( dirname($0) );
	chdir $root;
	$root = File::Spec->rel2abs( File::Spec->updir() );
}

get_root ();
system("$SevenZip x -y -o\"$root/monodevelop/dependencies\" \"$root/monodevelop/dependencies/nant-0.91-nightly-2011-05-08.zip\"");
my $nant = "\"$root/monodevelop/dependencies/nant-0.91-nightly-2011-05-08/bin/NAnt.exe\"";
# my $nant = "\"C:/nant-0.91-nightly-2011-05-08/bin/NAnt.exe\"";

my $gtkPath = "$ENV{ProgramFiles}/GtkSharp/$GTK_VERSION";
my $monolibPath = "$ENV{ProgramFiles}/MonoLibraries/$MONO_LIBRARIES_VERSION";
if (defined($ENV{'ProgramFiles(x86)'}))
{
	$gtkPath = "$ENV{'ProgramFiles(x86)'}/GtkSharp/$GTK_VERSION";
	$monolibPath = "$ENV{'ProgramFiles(x86)'}/MonoLibraries/$MONO_LIBRARIES_VERSION";
}

if (!-d $monolibPath)
{
	print "== Installing Mono Libraries $MONO_LIBRARIES_VERSION\n";
	system("msiexec /i $root\\monodevelop\\dependencies\\$MONO_LIBRARIES_INSTALLER /passive") && die("Failed to install mono libraries");
}
else
{
	print "== Mono Libraries $MONO_LIBRARIES_VERSION already installed\n";
}

my $gtkSharpDll = "$gtkPath/lib/gtk-sharp-2.0/gtk-sharp.dll";
my $gtkSharpDllMD5 = "";


if (-e "$gtkSharpDll")
{
	open my $fh, '<', "$gtkSharpDll";
	$gtkSharpDllMD5 = Digest::MD5->new->addfile($fh)->hexdigest;
	close $fh;
}

if (!-e "$gtkSharpDll" or $gtkSharpDllMD5 ne $GTK_SHARP_DLL_MD5)
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
# die ("Must grab monodevelop-hg source from bitbucket first") if !-d "$root/monodevelop-hg";
die ("Must grab Boo implementation") if !-d "$root/boo";
die ("Must grab Boo extensions implementation") if !-d "$root/boo-extensions";
die ("Must grab Unityscript implementation") if !-d "$root/unityscript";
die ("Must grab Boo MD Addins implementation") if !-d "$root/boo-md-addins";

system("\"$ENV{VS100COMNTOOLS}/vsvars32.bat\" && msbuild $root\\monodevelop\\main\\Main.sln /p:Configuration=DebugWin32 /p:Platform=x86 $incremental") && die ("Failed to compile MonoDevelop");

system("\"$ENV{VS100COMNTOOLS}/vsvars32.bat\" && msbuild $root\\MonoDevelop.Debugger.Soft.Unity\\MonoDevelop.Debugger.Soft.Unity.sln /p:Configuration=Release $incremental") && die ("Failed to compile MonoDevelop");

# system("\"$ENV{VS100COMNTOOLS}/vsvars32.bat\" && msbuild $root\\monodevelop-hg\\monodevelop-hg\\monodevelop-hg.sln /p:Configuration=ReleaseWin32 $incremental") && die ("Failed to compile monodevelop-hg");

my $mdRoot = "$root/tmp/MonoDevelop";
my $mdSource = "$root/monodevelop/main/build";

rmtree "$mdRoot";

# MonoDevelop
mkpath "$mdRoot/bin";
mkpath "$mdRoot/Addins";
mkpath "$mdRoot/data/options";
mkpath("$mdRoot/bin/branding");
system("xcopy /s \"$root/monodevelop/branding\" \"$mdRoot/bin/branding\"");
system("xcopy /s \"$mdSource/bin\" \"$mdRoot/bin\"");
system("xcopy /s \"$mdSource/Addins\" \"$mdRoot/Addins\"");
system("xcopy /s \"$mdSource/data\" \"$mdRoot/data\"");

# Layout templates
copy "$mdSource/MacOSX/EditingLayout2.xml", "$mdRoot/data/options/EditingLayout2.xml";
copy "$mdSource/MacOSX/MonoDevelopProperties.xml", "$mdRoot/data/options/MonoDevelopProperties.xml";

# Unity soft debugger
mkpath "$mdRoot/Addins/MonoDevelop.Debugger.Soft.Unity";
copy "$root/MonoDevelop.Debugger.Soft.Unity/obj/Release/MonoDevelop.Debugger.Soft.Unity.dll", "$mdRoot/Addins/MonoDevelop.Debugger.Soft.Unity";
copy "$root/MonoDevelop.Debugger.Soft.Unity/obj/Release/UnityUtilities.dll", "$mdRoot/Addins";

# monodevelop-hg
# mkpath "$mdRoot/Addins/VersionControl";
# copy "$root/monodevelop-hg/monodevelop-hg/bin/Release/MonoDevelop.VersionControl.Mercurial.dll", "$mdRoot/Addins/VersionControl";
# copy "$root/monodevelop-hg/monodevelop-hg/bin/Release/Mercurial.dll", "$mdRoot/Addins/VersionControl";

# GTK Sharp dependency files
mkpath "$mdRoot/lib";
mkpath "$mdRoot/etc";
mkpath "$mdRoot/share";
system("xcopy /s /y \"$gtkPath/bin\" \"$mdRoot/bin\"");
system("xcopy /s /y \"$gtkPath/lib\" \"$mdRoot/lib\"");
system("xcopy /s /y \"$gtkPath/etc\" \"$mdRoot/etc\"");
system("xcopy /s /y \"$gtkPath/share\" \"$mdRoot/share\"");
system("xcopy /s /y \"$gtkPath/lib/Mono.Posix\" \"$mdRoot/bin\"");
system("xcopy /s /y \"$gtkPath/lib/gtk-sharp-2.0\" \"$mdRoot/bin\"");
system("xcopy /s /y \"$gtkPath/lib/Mono.Cairo\" \"$mdRoot/bin\"");
# TODO: An installer should execute "gdk-pixbuf-query-loaders.exe > ../etc/gtk-2.0/gdk-pixbuf.loaders" after installing files to get a proper loader file
copy "$root/monodevelop/dependencies/gdk-pixbuf.loaders", "$mdRoot/etc/gtk-2.0";
copy "$root/monodevelop/dependencies/monodoc.dll", "$mdRoot/bin";

# Mono Libraries dependency files
# system("xcopy /s /y \"$monolibPath\" \"$mdRoot/bin\"");

my $monoLib;
foreach $monoLib (('ICSharpCode.SharpZipLib.dll', 'Mono.GetOptions.dll', 'Mono.Security.dll'))
{
	copy "$monolibPath/$monoLib", "$mdRoot/bin";
}

chdir "$root/boo";
system("$nant -t:net-4.0 rebuild") && die ("Failed to build Boo");
mkpath "$mdRoot/Addins/BackendBindings/Boo/boo";
system("xcopy /s /y \"$root/boo/build\" \"$mdRoot/Addins/BackendBindings/Boo/boo\"");
unlink glob "$mdRoot/Addins/BackendBindings/Boo/boo/*.pdb" or die ("unlink fail");

chdir "$root/boo-extensions";
copy "$root/monodevelop/dependencies/build.properties", "$root/boo-extensions/build.properties";
system("$nant -t:net-4.0 rebuild") && die ("Failed to build Boo extensions monodevelop");

chdir "$root/unityscript";
copy "$root/monodevelop/dependencies/build.properties", "$root/unityscript/build.properties";
my $javascriptFiles =  "$mdRoot/Addins/BackendBindings/UnityScript/bin";
mkpath $javascriptFiles;
system("$nant -t:net-4.0 rebuild") && die ("Failed to build UnityScript");
system("xcopy /s /y \"$root/unityscript/bin\" \"$javascriptFiles\"");
unlink glob "$javascriptFiles/*.pdb" or die ("unlink fail");
# unlink glob "$javascriptFiles/*Tests*" or die ("unlink fail");
unlink "$javascriptFiles/nunit.framework.dll" or die ("unlink fail");

chdir "$root/boo-md-addins";
copy "$root/monodevelop/dependencies/build.properties", "$root/boo-md-addins/build.properties";
system("$nant -t:net-4.0 rebuild") && die ("Failed to build Boo MD Addins");
mkpath "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/Boo.MonoDevelop.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/Boo.Ide.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/UnityScript.dll", "$mdRoot/AddIns/BackendBindings/Boo/boo";
copy "$root/boo-md-addins/build/UnityScript.Lang.dll", "$mdRoot/AddIns/BackendBindings/Boo/boo";
copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$mdRoot/AddIns/BackendBindings/Boo";
copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$mdRoot/AddIns/BackendBindings/Boo";

mkpath "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/UnityScript.MonoDevelop.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/Boo.Ide.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";
copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$mdRoot/AddIns/BackendBindings/UnityScript";

mkpath "$root/tmp";
chdir "$root/tmp";
unlink "$root/MonoDevelop.zip";
system("$SevenZip a -r \"$root/MonoDevelop.zip\" *.*");
chdir "$root";
