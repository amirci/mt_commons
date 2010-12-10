require 'rubygems'    

require 'albacore'
require 'rake/clean'
require 'git'
require 'noodle'
require 'set'

include FileUtils

solution_file = FileList["*.sln"].first
build_file = FileList["*.msbuild"].first
project_name = "MavenThought.Commons"
commit = Git.open(".").log.first.sha[0..10] rescue 'na'
version = "0.2.0.0"
deploy_folder = "c:/temp/build/#{project_name}.#{version}_#{commit}"
merged_folder = "#{deploy_folder}/merged"

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("**/_*", "**/.svn", "lib/*", "**/*.user", "**/*.cache", "**/*.suo")

msbuild_path = File.join(ENV['windir'], 'Microsoft.NET','Framework',  'v4.0.30319', 'MSBuild.exe')

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep:download", "setup:dep:local"]

desc "Updates build version, generate zip, merged version and the gem in #{deploy_folder}"
task :deploy => ["deploy:all"]

desc "Run all unit tests"
task :test => ["test:all"]

namespace :setup do
	namespace :dep do
		task :download do 
			system "bundle install --system"
		end	
		Noodle::Rake::NoodleTask.new :local do |n|
			n.groups << :dev
			n.groups << :testing
		end
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, :config do |msb, args|
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = solution_file
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end

namespace :test do
	
	desc 'Run all tests'
	task :all => [:default] do 
		tests = FileList["test/**/bin/debug/**/*.Tests.dll"].join " "
		system "./tools/gallio/bin/gallio.echo.exe #{tests}"
	end
	
end

namespace :deploy do

	task :all  => [:update_version] do
		rm_rf(deploy_folder)
		Dir.mkdir(deploy_folder) unless File.directory? deploy_folder
		Rake::Task["build:all"].invoke(:Release)
		
		["test:all", "deploy:package"].each do |taskName|
			Rake::Task[taskName].invoke
		end
	end 
	
	task :update_version do 
		files = FileList["main/**/Properties/AssemblyInfo.cs"]
		ass = Rake::Task["deploy:assemblyinfo"]
		files.each do |file| 
			ass.invoke(file) 
			ass.reenable
		end
	end
	
	assemblyinfo :assemblyinfo, :file do |asm, args|
		asm.version = version
		asm.company_name = "MavenThought Inc."
		asm.product_name = "MavenThought Commons"
		asm.title = "MavenThought Commons (sha #{commit})"
		asm.description = "Selection of utility classes and extensions used for many MavenThought projects and clients"
		asm.copyright = "MavenThought Inc. 2006 - #{Date.new.year}"
		asm.output_file = args[:file]
	end	
		
	zip :package do |zip|
		Dir.mkdir(deploy_folder) unless File.directory? deploy_folder
		zip_file = "#{project_name}.#{version}_#{commit}.zip"
		puts "Creating zip file #{zip_file}"
		zip.directories_to_zip "main/MavenThought.Commons.WPF/bin/release"
		zip.output_file = zip_file
		zip.output_path = deploy_folder
	end
	
	task :merge do
		puts "Merging #{project_name} assemblies located in bin/release into one"
		# Obtain unique list to be merged
		assemblies = FileList["main/**/bin/release/*.dll"].inject({}) do |hash, f| 
			hash[File.basename(f)] ||= f 
			hash
		end.values
		# Sort to put Maventhought first, so the attr are copied
		assemblies = assemblies.sort { |f1, f2| f1.include?( "#{project_name}.dll" ) ? -1 : 0 }.join ' '
		puts "Merging #{assemblies}"
		system "./tools/ilmerge/ILmerge.exe /out:#{project_name}.dll #{assemblies}"
		Dir.mkdir(merged_folder) unless File.directory? merged_folder
		mv("#{project_name}.dll", merged_folder)
		rm("#{project_name}.pdb")
	end
	  
end

namespace :jeweler do
	require 'jeweler'  
	
	desc 'Build the release and then the gem'
	task :buildit do
		Rake::Task["build:all"].invoke(:Release)
		files = Dir.glob("main/MavenThought.Commons.WPF/bin/release/Maven*.dll")
		copy files, "lib"
		Rake::Task["jeweler:build"].invoke
	end
	
	Jeweler::Tasks.new do |gs|
		gs.name = "maventhought.commons"
		gs.summary = "Utility classes, patterns and extension methods used by MavenThought in several projects"
		gs.description = "Useful patterns and extensions classes for enumerable, pair, etc"
		gs.email = "amir@barylko.com"
		gs.homepage = "http://orthocoders.com"
		gs.authors = ["Amir Barylko"]
		gs.has_rdoc = false  
		gs.rubyforge_project = 'maventhought.commons'  
		gs.files = Dir.glob("lib/Maven*.dll")
		gs.require_path = '.'
	end
end
