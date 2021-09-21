using System;
using System.IO;
using Onyx.Crypto;
namespace Onyx.IO
{
    public class IO
    {
        private static readonly string _secret;
        public static string _directoryPath;
        private static string _filePath;
        static IO()
        {
            _secret = "Let the force be with you";
            _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "onyx");
        }

        /// <summary>
        /// Инициализирует класс из файла, возвращает результат выполнения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool GetInstance<T>(ref T instance, string path)
        {
            _filePath = Path.Combine(_directoryPath, path);
            try
            {
                //instance = default;
                //Сперва проверим вообще наличие файла
                if (!File.Exists(_filePath))
                {
                    //И если его нет, то заполняем значениями по умолчанию, создаем файл и пишем в него
                    //instance = default;
                    _writeFile(_filePath, XmlExt.ToXML(instance));
                }
                else
                {
                    //Если он есть, прочитаем, дешифруем, и проинициализируем объект

                    var temp = File.ReadAllText(_filePath);

                    var encrypt = Crypto.Crypto.DecryptStringAES(temp, _secret);

                    instance = XmlExt.FromXml<T>(encrypt);

                }
                return true;
            }
            catch
            {
                try
                {
                    instance = default;
                    _writeFile(_filePath, instance.ToXML());
                }
                catch
                {
                    //Ну это уже нештатный исключительный п..дец
                }
                return false;
            }
        }

        /// <summary>
        /// Запись строки на диск.
        /// </summary>
        /// <param name="path">Относительный путь (!) после ApplicationData/имя проекта(!) </param>
        /// <param name="text"></param>
        public static void WriteFile(string path, string text)
        {
            var tempPath = Path.Combine(_directoryPath, path);
            _writeFile(tempPath, text);
        }

        private static void _writeFile(string path, string text)
        {
            var encryptedStringAES = Crypto.Crypto.EncryptStringAES(text, _secret);
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, encryptedStringAES);
            }
            catch
            {
            }
        }
    }
}
