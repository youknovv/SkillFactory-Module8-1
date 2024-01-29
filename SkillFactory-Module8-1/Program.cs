using System;
using System.IO;

namespace SkillFactory_Module8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"\";
            DeleteUnusedFiles(path);
        }

        static void DeleteUnusedFiles(string path)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime lifeSpan = currentTime.AddMinutes(-30);
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    DirectoryInfo[] folders = directory.GetDirectories();
                    foreach (DirectoryInfo folder in folders)
                    {
                        DateTime lastAccess = Directory.GetLastAccessTime(folder.FullName);
                        if (lastAccess <= lifeSpan)
                        {
                            folder.Delete(true);
                            Console.WriteLine("Неиспользуемая папка удалена");
                        }
                    }
                    FileInfo[] files = directory.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        DateTime lastAccess = File.GetLastAccessTime(file.FullName);
                        if (lastAccess <= lifeSpan)
                        {
                            file.Delete();
                            Console.WriteLine("Неиспользуемый файл удалён");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
