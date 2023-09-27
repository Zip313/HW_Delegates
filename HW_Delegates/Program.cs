namespace HW_Delegates
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region 1 Метод принимающий делегат

            IEnumerable<string> arrayString = new string[2] { "1", "2" };

            var maxElement = arrayString.GetMax(x=>float.Parse(x));

            Console.WriteLine($"1) Max element of array is {maxElement}");
            #endregion

            #region 2 Обходим файлы директории, с делегатом останавливающим рекурсивный поиск при соблюдении условия

            

            FileReader fileReader = new FileReader("c:\\temp");
            fileReader.FileFound += HandleFileReaderEvent;
            fileReader.CheckFiles((x)=>x== @"c:\temp\rules.conf");
            #endregion
        }

        static void HandleFileReaderEvent(object sender, EventArgs args)
        {
            Console.WriteLine($"Найден файл {((FileArgs)args).FileName}");
        }


    }
}