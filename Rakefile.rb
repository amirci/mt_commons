require 'rubygems'    

sh "bundle install --system"
Gem.clear_paths

require 'albacore'
require 'rake/clean'
require 'git'
require 'set'

include FileUtils

solution_file = FileList["*.sln"].first
build_file = FileList["*.msbuild"].first
project_name = "MavenThought.Commons"
commit = Git.open(".").log.first.sha[0..10] rescue 'na'
version = IO.readlines('VERSION')[0] rescue "0.0.0.0"
deploy_folder = "c:/temp/build/#{project_name}.#{version}_#{commit}"
merged_folder = "#{deploy_folder}/merged"

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("**/_*", "**/.svn", "packages/*", "lib/*", "**/*.user", "**/*.cache", "**/*.suo")

msbuild_path = File.join(ENV['windir'], 'Microsoft.NET','Framework',  'v4.0.30319', 'MSBuild.exe')

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep"]

desc "Updates build version, generate zip, merged version and the gem in #{deploy_folder}"
task :deploy => ["deploy:all"]

desc "Run all unit tests"
task :test => ["test:all"]

desc "Builds and publishes the nuget pakage to the server"
task :publish => ["publish:nuget"]

namespace :setup do
	desc "Setup dependencies for nuget packages"
	task :dep do
		FileList["**/packages.config"].each do |file|
			sh "nuget install #{file} /OutputDirectory Packages"
		end
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, :config, :needs => :setup do |msb, args|
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

	task :all  => ["util:update_version"] do
		Rake::Task["util:clean_folder"].invoke(deploy_folder)
		Rake::Task["util:build_release"].invoke
		Rake::Task["deploy:package"].invoke
	end 
	
	zip :package do |zip|
		zip_file = "#{project_name}.#{version}_#{commit}.zip"
		zip.directories_to_zip "main/MavenThought.Commons.WPF/bin/release"
		zip.output_file = zip_file
		zip.output_path = deploy_folder
		puts "Zip file #{zip_file} created under #{deploy_folder}"
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

namespace :publish do
	
	desc "Publish nuget package"
	task :nuget  => ["util:build_release"] do
		nuget_lib = "nuget/lib"
		Rake::Task["util:clean_folder"].invoke("nuget")
		mkdir nuget_lib
		FileList["main/**/bin/release/MavenT*.dll"].each { |f| cp f, nuget_lib }
		nuget_package = "maventhought.commons"
		Rake::Task["publish:package"].invoke(nuget_package)
		sh "nuget push nuget/#{nuget_package}.#{version}.nupkg" 
	end 

	nuspec :spec, :package_id  do |nuspec, args|
	   nuspec.id = args.package_id
	   nuspec.version = version
	   nuspec.authors = "Amir Barylko"
	   nuspec.owners = "Amir Barylko"
	   nuspec.description = "Common utilities and extension classes used by MavenThought projects"
	   nuspec.summary = "Common utilities and extension classes used by MavenThought projects"
	   nuspec.language = "en-US"
	   nuspec.licenseUrl = "https://github.com/amirci/mt_commons/LICENSE"
	   nuspec.projectUrl = "https://github.com/amirci/mt_commons"
	   nuspec.working_directory = "nuget"
	   nuspec.output_file = "#{args.package_id}.#{version}.nuspec"
	   nuspec.tags = "patterns enumerable extensions"
	   nuspec.dependency "castle.core", "2.5.1"
	end
	
	nugetpack :package, :package_id do |p, args|
		spec = Rake::Task["publish:spec"]
		spec.invoke(args.package_id)
		spec.reenable
		p.nuspec = "nuget/#{args.package_id}.#{version}.nuspec"
		p.output = "nuget"
	end
end

namespace :util do
	task :clean_folder, :folder do |t, args|
		rm_rf(args.folder)
		Dir.mkdir(args.folder) unless File.directory? args.folder
	end
		
	assemblyinfo :update_version do |asm|
		asm.version = version
		asm.company_name = "MavenThought Inc."
		asm.product_name = "MavenThought Commons (sha #{commit})"
		asm.copyright = "MavenThought Inc. 2006 - #{DateTime.now.year}"
		asm.output_file = "main/GlobalAssemblyInfo.cs"
	end	

	task :build_release => [:update_version] do 
		Rake::Task["build:all"].invoke(:Release)
		Rake::Task["test"].invoke
	end
end
