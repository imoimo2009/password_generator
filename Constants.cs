namespace password_generator
{
    public partial class Form1 : Form
    {
        private const string APP_NAME = "パスワードジェネレータ";
        private const string APP_VERSION = "1.0.0";

        private const int DEFAULT_LENGTH = 8;
        private const int DEFAULT_TIMES = 3;

        private const string NUMERIC_CHRS = "0123456789";
        private const string UCASE_CHRS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LCASE_CHRS = "abcdefghijklmnopqrstuvwxyz";
        private const string SYMBOL_CHRS = "!#$%&()-=^~\\|[]{};:+*,.<>/?_";

        private const string INI_FILE_NAME = ".\\password_generator.ini";

        private const string MSG_STR_NOTHING = "一つ以上の文字種を選択してください！";
        private const string MSG_STR_COPY = "パスワードをクリップボードにコピーしました。";

        private const string INI_DEFAULT = "DEFAULT";
        private const string INI_LENGTH = "LENGTH";
        private const string INI_TIMES = "TIMES";
        private const string INI_NUMERIC_CHK = "NUMERIC_CHECKED";
        private const string INI_NUMERIC_TXT = "NUMERIC_TEXT";
        private const string INI_UCASE_CHK = "UCASE_CHECKED";
        private const string INI_UCASE_TXT = "UCASE_TEXT";
        private const string INI_LCASE_CHK = "LCASE_CHECKED";
        private const string INI_LCASE_TXT = "LCASE_TEXT";
        private const string INI_SYMBOL_CHK = "SYMBOL_CHECKED";
        private const string INI_SYMBOL_TXT = "SYMBOL_TEXT";
    }
}
