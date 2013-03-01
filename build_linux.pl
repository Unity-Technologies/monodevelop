#!/usr/bin/perl
use warnings;
use strict;
use File::Basename qw(dirname basename fileparse);
use File::Spec;
use File::Copy;
use File::Path;
use Cwd;

my $root = "";
my $nant = "mono --runtime=v4.0.30319 /usr/lib/NAnt/NAnt.exe";
my $mdSource = "";
my $mdRoot = "";

main();

sub main {
	get_root();
	prepare_sources();
	build_monodevelop();
	build_debugger();
	build_monodevelop_hg();
	finalize_monodevelop();
	build_boo();
	build_boo_extensions();
	build_unityscript();
	build_boo_md_addins(); 
}

sub get_root {
	$root = File::Spec->rel2abs(dirname($0));
	chdir $root;
	$root = Cwd::realpath (File::Spec->rel2abs(File::Spec->updir()));

	$mdSource = "$root/monodevelop/main/build";
	$mdRoot = "$root/tmp/monodevelop";
}

sub prepare_sources {
	if (!$ENV{UNITY_THISISABUILDMACHINE})
	{	
		printf ("Detected that this is not a build machine.\n");
		printf ("Pulling latest MonoDevelop . . .\n");
		chdir "$root/monodevelop";
		system ("git pull") && die ("failed to update monodevelop");
		printf ("Pulling latest MonoDevelop.Debugger.Soft.Unity . . .\n");
		chdir "$root/MonoDevelop.Debugger.Soft.Unity";
		system ("git pull") && die ("failed to update MonoDevelop.Debugger.Soft.Unity");
		printf ("Pulling latest boo . . .\n");
		chdir "$root/boo";
		system ("git pull") && die ("failed to update boo");
		printf ("Pulling latest unityscript . . .\n");
		chdir "$root/unityscript";
		system ("git pull") && die ("failed to update unityscript");
		printf ("Pulling latest boo-md-addins . . .\n");
		chdir "$root/boo-md-addins";
		system ("git pull") && die ("failed to update boo-md-addins");
		chdir "$root/monodevelop-hg";
		system ("hg pull --update") && die ("failed to update monodevelop-hg");
	}
	chdir $root;

	# Check sources
	die ("Must grab Unity MonoDevelop Soft Debugger source from github first") if !-d "MonoDevelop.Debugger.Soft.Unity";
	die ("Must grab monodevelop-hg source from bitbucket first") if !-d "monodevelop-hg";
	die ("Must grab Boo implementation") if !-d "boo";
	die ("Must grab Boo extensions") if !-d "boo-extensions";
	die ("Must grab Boo MD addins implementation") if !-d "boo-md-addins";
	die ("Must grab Unityscript implementation") if !-d "unityscript";
}

sub build_monodevelop {
	chdir "$root/monodevelop";
	system("./configure", "--prefix=$root/tmp", "--profile=default");
	system("make") && die("Failed building MonoDevelop");
	mkpath("main/build/bin/branding");
	copy("branding/Branding.xml", "main/build/bin/branding/Branding.xml");
}

sub build_debugger {
	chdir "$root/MonoDevelop.Debugger.Soft.Unity";
	system("xbuild /property:Configuration=Release /t:Rebuild") && die("Failed building Unity debugger addin");
}

sub build_monodevelop_hg {
	chdir "$root/monodevelop-hg/monodevelop-hg";
	system("xbuild /property:Configuration=Release /t:Rebuild") && die("Failed building monodevelop-hg");
}

sub finalize_monodevelop {
	chdir $root;
	rmtree "tmp";
	mkpath "tmp";
	chdir "$root/monodevelop";
	system ('make install');
	my $dest = "$root/tmp/lib/monodevelop/AddIns";
	
	# Unity soft debugger
	mkpath "$dest/MonoDevelop.Debugger.Soft.Unity";
	copy "$root/MonoDevelop.Debugger.Soft.Unity/obj/Release/MonoDevelop.Debugger.Soft.Unity.dll", "$dest/MonoDevelop.Debugger.Soft.Unity" or die ("Failed to copy MonoDevelop.Debugger.Soft.Unity");	
	# Unity utilities
	copy "$root/MonoDevelop.Debugger.Soft.Unity/obj/Release/UnityUtilities.dll", "$dest" or die ("Failed to copy UnityUtilities");	
	# monodevelop-hg
	copy "$root/monodevelop-hg/monodevelop-hg/bin/Release/MonoDevelop.VersionControl.Mercurial.dll", "$dest/VersionControl" or die ("Failed to copy monodevelop-hg");	
	copy "$root/monodevelop-hg/monodevelop-hg/bin/Release/Mercurial.dll", "$dest/VersionControl" or die ("Failed to copy monodevelop-hg");	
}

sub build_boo {
	chdir "$root/boo";
	system("$nant rebuild") && die ("Failed to build Boo");
	mkpath "$root/tmp/lib/monodevelop/AddIns/BackendBindings/Boo/boo";
	system("rsync -av --exclude=*.mdb  \"$root/boo/build/\" \"$root/tmp/lib/monodevelop/AddIns/BackendBindings/Boo/boo\"");
}

sub build_boo_extensions {
	chdir "$root/boo-extensions";
	copy "$root/monodevelop/dependencies/build.properties", "$root/boo-extensions/build.properties";
	system("$nant rebuild") && die ("Failed to build Boo");
}

sub build_unityscript {
	chdir "$root/unityscript";
	my $javascriptFiles =  "$root/tmp/lib/monodevelop/AddIns/BackendBindings/UnityScript/bin";
	mkpath $javascriptFiles;
	rmtree "$root/unityscript/bin";
	system("$nant rebuild") && die ("Failed to build UnityScript");
	system("rsync -av --exclude=*.mdb --exclude=*Tests* --exclude=nunit* \"$root/unityscript/bin/\" \"$javascriptFiles\"");
}

sub build_boo_md_addins {
	chdir "$root/boo-md-addins";
	my $dest = "$root/tmp/lib/monodevelop/AddIns/BackendBindings";
	copy "$root/monodevelop/dependencies/build.properties", "$root/boo-md-addins/build.properties";
	system("$nant rebuild") && die ("Failed to build Boo-based addins");
	copy "$root/boo-md-addins/build/Boo.MonoDevelop.dll", "$dest/Boo";
	copy "$root/boo-md-addins/build/Boo.Ide.dll", "$dest/Boo";
	copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$dest/Boo";
	copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$dest/Boo";
	copy "$root/boo-md-addins/build/UnityScript.MonoDevelop.dll", "$dest/UnityScript";
	copy "$root/boo-md-addins/build/UnityScript.Ide.dll", "$dest/UnityScript";
	copy "$root/boo-md-addins/build/Boo.Ide.dll", "$dest/UnityScript";
	copy "$root/boo-md-addins/build/Boo.MonoDevelop.Util.dll", "$dest/UnityScript";
}

