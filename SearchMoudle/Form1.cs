using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SearchMoudle
{
    public partial class SearchForm : Form
    {
        DBClass dbClas = new DBClass();

        public SearchForm()
        {
            InitializeComponent();
            string pwd = string.Empty;      // DB 비밀번호, 개개인 알아서 넣어야 합니다.
            dbClas.SetConInfo("127.0.0.1", "mysql", "root", pwd);       // localhost : 127.0.0.1
            InitComboBox();                     
            SearchGrid.AutoGenerateColumns = true;
        }

        private void InitComboBox()
        {
            // 데이터를 넣기 전 이전 데이터를 초기화시킵니다.
            SearchCbo.Items.Clear();

            DataSet ds;

            string query = @"SELECT CLASS FROM PRODUCTINFOS";

            if (dbClas.ExecureReader(out ds, query, null) > 0)
            {
                DataTable dT = ds.Tables[0];

                foreach (DataRow dRow in dT.Rows)
                {
                    SearchCbo.Items.Add(dRow["CLASS"].ToString());
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // 데이터를 넣기 전 이전 데이터를 초기화시킵니다.
            SearchGrid.DataSource = null;

            DataSet ds;
            string query = @"SELECT * FROM PRODUCTINFOS
                            WHERE CLASS = @";

            List<object> pList = new List<object>();
            pList.Add(SearchCbo.Text);

            BindingSource source = new BindingSource();

            if (dbClas.ExecureReader(out ds, query, pList.ToArray()) > 0)
            {
                source.DataSource = ds.Tables[0];
                SearchGrid.DataSource = source;
                SearchGrid.Refresh();
            }
        }

        private void SearchGrid_SelectionChanged(object sender, EventArgs e)
        {
            // 그리드 Row가 선택되지 않으면 해당 함수를 타지 않습니다
            if (SearchGrid.SelectedRows.Count < 1) return;

            // SelectedRow가 없으면 SelectedRows 컬렉션에 데이터가 없기 때문에 Index 참조하려고 하면 오류남
            DataGridViewRow vRow = SearchGrid.SelectedRows[0];

            txtClass.Text = vRow.Cells["CLASS"].Value.ToString();
            txtName.Text = vRow.Cells["NAME"].Value.ToString();
            txtPrice.Text = vRow.Cells["PRICE"].Value.ToString();
            txtCount.Text = vRow.Cells["COUNT"].Value.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string query = @"
                                    INSERT INTO PRODUCTINFOS
                                    (
                                        CLASS, NAME, PRICE, COUNT, USEFLAG
                                    )
                                    VALUES
                                    (
                                        @,@,@,@,@
                                    );
                                    ";

            List<Object> plist = new List<object>();

            plist.Add(txtClass.Text);
            plist.Add(txtName.Text);
            plist.Add(txtPrice.Text);
            plist.Add(int.Parse(txtCount.Text));
            plist.Add(1);

            dbClas.ExecuteNonQuery(query, plist.ToArray());

            // 데이터를 수정/저장했으면 Grid, ComboBox 새로고침하기
            BtnRefresh_Click(BtnRefresh, null);
            InitComboBox();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (SearchGrid.SelectedRows.Count < 1)
            {
                MessageBox.Show("Row를 선택해주세요.");
            }

            DataGridViewRow vRow = SearchGrid.SelectedRows[0];

            string query = @"
                                    UPDATE PRODUCTINFOS
                                    SET CLASS = @, NAME = @, PRICE = @, COUNT = @, USEFLAG = 1
                                    WHERE CLASS = @ AND NAME = @
                                    ";

            List<Object> plist = new List<object>();

            plist.Add(txtClass.Text);
            plist.Add(txtName.Text);
            plist.Add(txtPrice.Text);
            plist.Add(int.Parse(txtCount.Text));

            plist.Add(vRow.Cells["CLASS"].Value.ToString());
            plist.Add(vRow.Cells["NAME"].Value.ToString());

            dbClas.ExecuteNonQuery(query, plist.ToArray());

            // 데이터를 수정/저장했으면 Grid, ComboBox 새로고침하기
            BtnRefresh_Click(BtnRefresh, null);
            InitComboBox();
        }

        private void SearchCbo_TextChanged(object sender, EventArgs e)
        {
            BtnRefresh_Click(BtnRefresh, null);
        }
    }

    public class DBClass
    {
        string strConInfo = string.Empty;

        public void SetConInfo(string pServer, string pDBName, string pID, string pPwd)
        {
            StringBuilder strConn = new StringBuilder();
            strConn.AppendFormat("Server = {0}; Database = {1}; Uid = {2}; Pwd = {3};", pServer, pDBName, pID, pPwd);
            strConInfo = strConn.ToString();
        }

        public int ExecuteNonQuery(string pQuery, params Object[] pParameter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConInfo))
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd.CommandText = ConvertString(pQuery, pParameter);
                    int ret = cmd.ExecuteNonQuery();
                    conn.Close();
                    return ret;
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public int ExecureReader(out DataSet ds, string query, params Object[] pParams)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConInfo))
                {
                    ds = new DataSet();
                    conn.Open();

                    MySqlDataAdapter adpt = new MySqlDataAdapter(ConvertString(query, pParams), conn);
                    adpt.Fill(ds);
                    conn.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                ds = null;
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public string ConvertString(string pQuery, params Object[] pParams)
        {
            int idx = 0;
            string newString = string.Empty;

            foreach (char c in pQuery)
            {
                if (c == '@')
                {
                    var param = pParams[idx];

                    if (param is int)
                    {
                        newString += Convert.ToInt32(param);
                        idx++;
                    }

                    if (param is string)
                    {
                        newString += "'" + param.ToString() + "'";
                        idx++;
                    }
                }
                else
                {
                    newString += c;
                }
            }

            return newString;
        }


    }


}
