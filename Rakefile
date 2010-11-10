require 'rubygems'    

require 'albacore'
require 'rake/clean'
require 'zip/zip'
require 'zip/zipfilesystem'
require 'git'
require 'rake/gempackagetask'
require 'noodle'

include FileUtils

solution_file = FileList["*.sln"].first
build_file = FileList["*.msbuild"].first
project_name = "MavenThought.Commons"
commit = Git.open(".").log.first.sha[0..10]
version = "0.2.0.0"
deploy_folder = "c:/temp/build/#{project_name}.#{version}_#{commit}"
merged_folder = "#{deploy_folder}/merged"
zip_file = "#{deploy_folder}/#{project_name}.#{version}_#{commit}.zip"

CLEAN.include("main/**/bin", "main/**/obj", "test/**/obj", "test/**/bin")

CLOBBER.include("**/_*", "**/.svn", "lib/*", "**/*.user", "**/*.cache", "**/*.suo")

msbuild_path = File.join(ENV['windir'], 'Microsoft.NET','Framework',  'v4.0.30319', 'MSBuild.exe')

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep:download", "setup:dep:store"]

desc "Updates build version, generate zip, merged version and the gem in #{deploy_folder}"
task :deploy => ["deploy:all"]

namespace :setup do
	namespace :dep do
		task :download do 
			`bundle install --system`
		end	
		Noodle::Rake::NoodleTask.new :store
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, :config do |msb, args|
		msb.path_to_command =  msbuild_path
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = solution_file
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end

namespace :test do
	
	desc 'Run all tests'
	msbuild :all do |msb|
		msb.path_to_command =  msbuild_path
		msb.targets :test
		msb.solution = build_file
	end
	
end

namespace :deploy do

	task :all  => [:update_version] do
		Rake::Task["build:all"].invoke(:Release)
		Rake::Task["deploy:package"].invoke
		Rake::Task["deploy:merge"].invoke
		Rake::Task["deploy:gem"].invoke
	end 
	
	task :update_version do 
		files = FileList["main/**/Properties/AssemblyInfo.cs"]
		files.each { |file| Rake::Task["deploy:assemblyinfo"].invoke(file) }
	end
	
	assemblyinfo :assemblyinfo, :file do |asm, args|
		asm.version = version
		asm.company_name = "MavenThought Inc."
		asm.product_name = "MavenThought Commons"
		asm.title = "MavenThought Commons (sha #{commit})"
		asm.description = "Selection of classes and extension used for many MavenThought projects and clients"
		asm.copyright = "MavenThought Inc. 2010"
		asm.output_file = args[:file]
	end	
		
	task :package do
		Dir.mkdir(deploy_folder) unless File.directory? deploy_folder
		curdir = Dir.pwd
		Dir.chdir("main/#{project_name}/bin/release")
		files = FileList["*.dll"]
		puts "Sorry can't find any files in #{Dir.pwd} to add to the zip" unless !files.empty?
		puts "Creating zip file #{zip_file}" unless !files.empty?
		Zip::ZipOutputStream.open(zip_file) do |zos|
			files.each do |file|
				# Create a new entry with some arbitrary name
				zos.put_next_entry(file)
				# Add the contents of the file, don't read the stuff linewise if its binary, instead use direct IO
				content = IO.read(file)
				zos.write(content)
			end
		end
		Dir.chdir(curdir)
	end
	
	task :merge do
		puts "Merging #{project_name} assemblies located in bin/release into one"
		assemblies = FileList["main/#{project_name}/bin/release/*.dll"]
		assemblies = assemblies.sort { |f1, f2| f1.include?( "Testing.dll" ) ? -1 : 0 } .join " "
		`./tools/ilmerge/ILmerge.exe /out:#{project_name}.dll #{assemblies}`
		Dir.mkdir(merged_folder) unless File.directory? merged_folder
		mv("#{project_name}.dll", merged_folder)
		rm("#{project_name}.pdb")
	end

	task :gem do
		rm_rf('gem/lib') if File.directory?('gem/lib')
		mkdir('gem/lib')
		cp("#{merged_folder}/#{project_name}.dll", "gem/lib")
		chdir('gem')
		spec = eval(IO.read("maventhought.testing.gemspec"))
		spec.version = version
		Gem::Builder.new(spec).build
		chdir('..')
		FileList["gem/maventhought.testing-*.gem"].each { |f| mv(f, deploy_folder) }
	end
  
end