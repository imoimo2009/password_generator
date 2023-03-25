using System.Text.Json;

namespace password_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // タイトルを設定する
            SetTitle();

            // パスワード表示用ラベル（手前側）を奥側の子に設定し、相対位置を指定
            lbl_passfore.Parent = lbl_passback;
            lbl_passfore.Location = new System.Drawing.Point(-3, -3);

            // パラメータを初期値にセット
            if (!LoadINIFile()){ ResetParam(); }

            // パスワードを作成する
            _ = GenPassword();
        }

        private void SetTitle()
        {
            this.Text = APP_NAME + " Ver." + APP_VERSION;
        }

        /// <summary>
        /// パラメータを初期値にセットする
        /// </summary>
        private void ResetParam()
        {
            sb_length.Maximum = MAX_LENGTH;
            sb_length.Minimum = MIN_LENGTH;
            sb_length.Value = DEFAULT_LENGTH;

            sb_times.Maximum = sb_length.Value;
            sb_times.Minimum = 1;
            sb_times.Value = DEFAULT_TIMES;

            cb_numeric.Checked = true;
            tb_numeric.Text = NUMERIC_CHRS;

            cb_ucase.Checked = true;
            tb_ucase.Text = UCASE_CHRS;

            cb_lcase.Checked = true;
            tb_lcase.Text = LCASE_CHRS;

            cb_symbol.Checked = true;
            tb_symbol.Text = SYMBOL_CHRS;
        }

        /// <summary>
        /// INIファイルを読み込み、パラメータを復元する
        /// </summary>
        /// <returns></returns>
        private bool LoadINIFile()
        {
            INIClass ini = new(INI_FILE_NAME);

            if(ini.GetInt(INI_DEFAULT, INI_LENGTH) > 0)
            {
                sb_length.Value = ini.GetInt(INI_DEFAULT, INI_LENGTH);

                sb_times.Value = ini.GetInt(INI_DEFAULT, INI_TIMES);
                
                cb_numeric.Checked = ini.GetBool(INI_DEFAULT, INI_NUMERIC_CHK);
                tb_numeric.Text = ini.GetString(INI_DEFAULT, INI_NUMERIC_TXT);
                
                cb_ucase.Checked = ini.GetBool(INI_DEFAULT, INI_UCASE_CHK);
                tb_ucase.Text = ini.GetString(INI_DEFAULT, INI_UCASE_TXT);
                
                cb_lcase.Checked = ini.GetBool(INI_DEFAULT, INI_LCASE_CHK);
                tb_lcase.Text = ini.GetString(INI_DEFAULT, INI_LCASE_TXT);
                
                cb_symbol.Checked = ini.GetBool(INI_DEFAULT, INI_SYMBOL_CHK);
                tb_symbol.Text = ini.GetString(INI_DEFAULT, INI_SYMBOL_TXT);

                return true;
            }
            return false;
        }

        /// <summary>
        /// INIファイルにパラメータを保存する
        /// </summary>
        private bool SaveINIFile()
        {
            bool ret = true;
            INIClass ini = new(INI_FILE_NAME);

            ret &= ini.Write(INI_DEFAULT, INI_LENGTH, sb_length.Value.ToString());
            
            ret &= ini.Write(INI_DEFAULT, INI_TIMES, sb_times.Value.ToString());
            
            ret &= ini.Write(INI_DEFAULT, INI_NUMERIC_CHK, cb_numeric.Checked ? "1" : "0");
            ret &= ini.Write(INI_DEFAULT, INI_NUMERIC_TXT, tb_numeric.Text);

            ret &= ini.Write(INI_DEFAULT, INI_UCASE_CHK, cb_ucase.Checked ? "1" : "0");
            ret &= ini.Write(INI_DEFAULT, INI_UCASE_TXT, tb_ucase.Text);

            ret &= ini.Write(INI_DEFAULT, INI_LCASE_CHK, cb_lcase.Checked ? "1" : "0");
            ret &= ini.Write(INI_DEFAULT, INI_LCASE_TXT, tb_lcase.Text);

            ret &= ini.Write(INI_DEFAULT, INI_SYMBOL_CHK, cb_symbol.Checked ? "1" : "0");
            ret &= ini.Write(INI_DEFAULT, INI_SYMBOL_TXT, tb_symbol.Text);

            return ret;
        }

        /// <summary>
        /// パスワードを作成し、ラベルコントロールに表示する
        /// </summary>
        private bool GenPassword()
        {
            // コントロールから値を取得しリストに格納
            List<Dictionary<string, object>> ctrl = new()
            {
                new(){ {"name","numeric"},{"checked",cb_numeric.Checked},{"text",tb_numeric.Text} },
                new(){ {"name","ucase"},{"checked",cb_ucase.Checked},{"text",tb_ucase.Text} },
                new(){ {"name","lcase"},{"checked",cb_lcase.Checked},{"text",tb_lcase.Text} },
                new(){ {"name","symbol"},{"checked",cb_symbol.Checked},{"text",tb_symbol.Text} }
            };

            // チェックされた文字種をトークンリストに登録
            Dictionary<string, List<Dictionary<string, object>>> tokens = new();
            foreach (var c in ctrl)
            {
                string name = (string)c["name"];
                string text = (string)c["text"];

                if ((bool)c["checked"])
                {
                    tokens.Add(name, new());
                    foreach (char cc in text.ToCharArray())
                    {
                        tokens[name].Add(new() { { "char", cc }, { "times", (int)sb_times.Value } });
                    }
                }
            }

            // 文字種がいっこも選択されていないときは処理を終了する
            if (tokens.Count == 0) { return false; }

            // 各文字種の初期挿入位置を決める（各文字種を必ず1回以上使うようにするため）
            Random rnd = new();
            string[] place = new string[(int)sb_length.Value];
            List<int> idxs = new(Enumerable.Range(0, (int)sb_length.Value).ToArray<int>());
            foreach (string s in tokens.Keys)
            {
                int r = rnd.Next(0, idxs.Count);
                place[idxs[r]] = s;
                idxs.RemoveAt(r);
            }

            // パスワード作成処理
            string passwd = "";
            for (int i = 0; i < sb_length.Value; i++)
            {
                string k;
                if (place[i] == null)
                {
                    k = tokens.Keys.ToArray()[rnd.Next(0, tokens.Count)];
                }
                else
                {
                    k = place[i];
                }
                if (tokens[k].Count > 0)
                {
                    int r = rnd.Next(0, tokens[k].Count);
                    passwd += tokens[k][r]["char"];
                    int c = (int)tokens[k][r]["times"];
                    tokens[k][r]["times"] = --c;
                    if (c <= 0)
                    {
                        tokens[k].RemoveAt(r);
                    }
                }
            }

            // ラベルコントロールにパスワードを表示する
            lbl_passfore.Text = passwd;
            lbl_passback.Text = passwd;
            return true;
        }

        /// <summary>
        /// パスワードをクリップボードにコピーする
        /// </summary>
        /// <returns>実行結果(bool)</returns>
        private bool CopyClipboard()
        {
            if (lbl_passfore.Text.Length > 0)
            {
                Clipboard.SetText(lbl_passfore.Text);
                return true;
            }
            return false;
        }

        /// <summary>
        /// NumericUpDownコントロールのMaximum値をValueの値と同じにする
        /// </summary>
        /// <param name="src">参照するコントロールオブジェクト</param>
        /// <param name="dst">設定先のコントロールオブジェクト</param>
        private void SyncMaxValue(NumericUpDown src, NumericUpDown dst)
        {
            dst.Maximum = src.Value;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            if (!GenPassword())
            {
                MessageBox.Show(MSG_STR_NOTHING, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetParam();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            if (CopyClipboard())
            {
                MessageBox.Show(MSG_STR_COPY, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sb_length_ValueChanged(object sender, EventArgs e)
        {
            SyncMaxValue(sb_length, sb_times);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ = SaveINIFile();
        }
    }
}