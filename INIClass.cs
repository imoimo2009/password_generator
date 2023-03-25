using System.Runtime.InteropServices;
using System.Text;

namespace password_generator
{
    /// <summary>
    /// INIファイルの入出力を行うクラス
    /// </summary>
    internal class INIClass
    {
        // private section

        private const int SB_CAPACITY = 256;

        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileString(
            string lpAppName,string lpKeyName,string lpDefault,
            StringBuilder lpReturnedString,uint nSize,string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileInt(
            string lpAppName, string lpKeyName,int nDefault,string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(
            string lpAppName, string lpKeyName, string lpString,string lpFileName);

        //public section

        /// <summary>
        /// INIファイルパスの参照と設定
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">INIファイルのパス</param>
        public INIClass(string path)
        {
            FilePath = path;
        }
        /// <summary>
        /// INIファイルから文字列を取り出す
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="defaultValue">値が取得できない場合の初期値</param>
        /// <returns>INIファイルに設定された値</returns>
        public string GetString(string section,string key,string defaultValue = "")
        {
            StringBuilder sb = new();

            sb.Capacity = SB_CAPACITY;
            _ = GetPrivateProfileString(section, key, defaultValue, sb, (uint)sb.Capacity, FilePath);
            return sb.ToString();
        }

        /// <summary>
        /// INIファイルから数値を取り出す
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="defaultValue">値が取得できない場合の初期値</param>
        /// <returns>INIファイルに設定された値</returns>
        public int GetInt(string section,string key,int defaultValue = 0)
        {
            return (int)GetPrivateProfileInt(section,key, defaultValue, FilePath);
        }

        /// <summary>
        /// INIファイルからbool値を取り出す
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <returns>INIファイルの0/1をboolに変換した値</returns>
        public bool GetBool(string section, string key)
        {
            return GetInt(section,key) == 1;
        }

        /// <summary>
        /// INIファイルに文字列を書き込む
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="value">書き込む文字列</param>
        /// <returns>処理結果(bool)</returns>
        public bool Write(string section,string key,string value)
        {
            return WritePrivateProfileString(section,key,value, FilePath);
        }
    }
}
