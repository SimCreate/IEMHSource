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
            string pwd = string.Empty;      // DB 비밀번호
            dbClas.SetConInfo("127.0.0.1", "mysql", "root", pwd);
            InitComboBox();
            SearchGrid.AutoGenerateColumns = true;
        }

        private void InitComboBox()
        {
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
                //SearchGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                SearchGrid.Refresh();
            }
        }

    }

    public class DBClass
    {
        string strConInfo = string.Empty;

        public void SetConInfo(string pServer, string pDBName, string pID, string pPwd)
        {
            StringBuilder strConn = new StringBuilder();
            strConn.AppendFormat("Server = {0}; Database = {1}; Uid = {2}; Pwd = {3};", pServer, pDBName, pID, pPwd);
            //"Server = ?; Database = ?; Uid = ?; Pwd=?;";
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
                    }

                    if (param is string)
                    {
                        newString += "'" + param.ToString() + "'";
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
