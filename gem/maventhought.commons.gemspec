version = File.read(File.expand_path("../VERSION",__FILE__)).strip  
  
Gem::Specification.new do |spec|  
  spec.name  = 'maventhought.commons'  
  spec.files = Dir['lib/**/*'] + Dir['doc/**/*']
  
  spec.summary     = 'Utility classes, patterns and extension methods used by MavenThought in several projects'  
  
  spec.description = 'Useful patterns and extensions classes for enumerable, pair, etc'
    
  spec.authors           = ['Amir Barylko']  
  spec.email             = 'amir@maventhought.com'  
  spec.homepage          = 'http://maventhought.com/Commons'  
  spec.rubyforge_project = 'maventhought.commons'  
end  