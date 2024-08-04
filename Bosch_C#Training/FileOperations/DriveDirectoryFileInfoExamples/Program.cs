namespace DriveDirectoryFileInfoExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*           foreach (DriveInfo drive in DriveInfo.GetDrives())
                       {
                           Console.WriteLine(drive.Name);
                           Console.WriteLine("");
                           DirectoryInfo directoryInfo = new DirectoryInfo(drive.Name);
                           try
                           {
                               foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                               {
                                   Console.WriteLine(dirInfo.Name);
                                   Console.WriteLine();
                                   Console.WriteLine(dirInfo.FullName);
                                   try
                                   {
                                       foreach (FileInfo file in dirInfo.GetFiles())
                                       {
                                           Console.WriteLine(file.Name);
                                       }
                                   }
                                   catch (UnauthorizedAccessException uae)
                                   {

                                       Console.WriteLine(uae.Message);
                                   }
                               };
                           }
                           catch (UnauthorizedAccessException uae)
                           {

                               Console.WriteLine(uae.Message);
                           }
                       }*/

            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    Console.WriteLine(drive.Name);
                    Console.WriteLine("");
                    DirectoryInfo directoryInfo = new DirectoryInfo(drive.Name);
                    foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                    {

                        try
                        {
                            Console.WriteLine($"\t{directory.Name}");
                            Console.WriteLine("");
                            foreach (FileInfo fileInfo in directory.GetFiles())
                            {
                                try
                                {
                                    Console.WriteLine($"\t\t{fileInfo.Name}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"\t\t{ex.Message}");
                                }
                            }
                        }
                        catch (UnauthorizedAccessException uae)
                        {
                            Console.WriteLine($"\t{uae.Message}"); Console.WriteLine(uae.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\t{ex.Message}");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

       