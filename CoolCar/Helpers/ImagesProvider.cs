namespace CoolCar.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImagesProvider(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public List<string> SafeFiles(IFormFile[] files, ImageFolders folder)
        {
            var ImagesPaths = new List<string>();
            foreach (var file in files)
            {
                var imagePath = SafeFile(file, folder);
                ImagesPaths.Add(imagePath);
            }
            return ImagesPaths;
        }

        public string SafeFile(IFormFile file, ImageFolders folder)
        {
            if(file != null)
            {
                var folderPath = Path.Combine(webHostEnvironment.WebRootPath + "/images/" + folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                string path = Path.Combine(folderPath, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return "/images/" + folder + "/" + fileName;
            }

            return null;
        }
    }
}
