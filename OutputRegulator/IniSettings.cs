using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OutputRegulator
{
    public class IniSettings
    {
        private readonly string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iniPath"></param>
        public IniSettings(string iniPath)
        {
            _path = iniPath;
        }

        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string ReadValue(string section, string key)
        {
            var temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, _path);

            return temp.ToString();
        }

        public bool ReadBool(string section, string key, bool defaultValue = false)
        {
            var temp = ReadValue(section, key);

            return string.IsNullOrEmpty(temp) ? defaultValue : int.Parse(temp) == 1;
        }

        public int ReadInt(string section, string key, int defaultValue = 0)
        {
            var temp = ReadValue(section, key);

            return string.IsNullOrEmpty(temp) ? defaultValue : int.Parse(temp);
        }
    }
}