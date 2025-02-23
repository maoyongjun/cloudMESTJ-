﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace MESDBHelper
{
    public class ConnectionManager
    {
        /// <summary>
        /// 加密連接字符串的密鈅,如無必要請不要修改
        /// </summary>
        public static string CryptKEY = "JBJ9IyiWR/n4Oj2t82Tx7/GRJeblK3YLtomQrB3mIFo=";
        /// <summary>
        /// 加密算法
        /// </summary>
        public static string CryptName = "Rijndael";
        static Dictionary<string, object> _ConnStrings = new Dictionary<string, object>();
        /// <summary>
        /// 初始化鏈接管理器
        /// </summary>
        public static void Init()
        {
            System.Data.DataSet ConnData;
            _ConnStrings.Clear();
            ConnData = new DataSet("ConnData");
            try
            {
                ConnData.ReadXml( ".\\DataBase.xml");
                //throw new NotImplementedException();
            }
            catch(Exception ee)
            {
                DataTable dt = ConnData.Tables.Add("TConnString");
                dt.Columns.Add("ConnName");
                dt.Columns.Add("ConnString");
                dt.Columns.Add("IsCrypt");
                DataRow dr = dt.NewRow();
                dr["ConnName"] = "APDB";
                dr["IsCrypt"] = false;
                //Allpart Test DB
                //dr["ConnString"] = "Data Source=(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.120.156.91)(PORT = 1903)))(CONNECT_DATA =(SERVICE_NAME = HWDNEWDBTEST))); " +
                //                    "Persist Security Info=True;" +
                //                    "User ID=AP2;" +
                //                    "Password=mbdap2session;" +
                //                    "Unicode=True;Provider=OraOLEDB.Oracle.1";

                //HWD Allpart DB
                dr["ConnString"] = "Data Source=(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.120.176.102)(PORT = 1903)))(CONNECT_DATA =(SERVICE_NAME = HWDNEWDB))); " +
                                    "Persist Security Info=True;" +
                                    "User ID=AP2;" +
                                    "Password=mbdap2session;" +
                                    "Unicode=True;Provider=OraOLEDB.Oracle.1";

                //Vertiv Allpart DB
                //dr["ConnString"] = "Data Source=(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.120.246.130)(PORT = 1527)))(CONNECT_DATA =(SERVICE_NAME = VERTIVAP))); " +
                //                    "Persist Security Info=True;" +
                //                    "User ID=AP2;" +
                //                    "Password=mbdap2session;" +
                //                    "Unicode=True;Provider=OraOLEDB.Oracle.1";


                dt.Rows.Add(dr);
                 
                dr = dt.NewRow();
                dr["ConnName"] = "TESTDB";
                dr["IsCrypt"] = false;

                //SFC Test DB
                //dr["ConnString"] = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.120.147.250)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=SFCTEST)));" +
                //                    "Persist Security Info=True;" +
                //                    "User ID=TEST;" +
                //                    "Password=SFCTEST;" +
                //                    "Unicode=True;Provider=OraOLEDB.Oracle.1";

                //HWD SFC DB
                dr["ConnString"] = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.120.176.75)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=MESDB)));" +
                                    "Persist Security Info=True;" +
                                    "User ID=TEST;" +
                                    "Password=SFCTEST;" +
                                    "Unicode=True;Provider=OraOLEDB.Oracle.1";


                //dr["ConnString"] = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.67.38.39)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=CLOUDMESTEST.CESBG.FOXCONN)));" +
                //                    "Persist Security Info=True;" +
                //                    "User ID=TEST;" +
                //                    "Password=SFCTEST;" +
                //                    "Unicode=True;Provider=OraOLEDB.Oracle.1";

                dr["ConnString"] = "OraOLEDB.Oracle.1; Password =SFCTEST;User ID=TEST;Data Source=TJCLOUDMES;Persist Security Info=True";

                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["ConnName"] = "VERTIVTESTDB";
                dr["IsCrypt"] = false;
                //VERTIV SFC DB
                dr["ConnString"] = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.120.246.140)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=VERTIVODB)));" +
                                    "Persist Security Info=True;" +
                                    "User ID=TEST;" +
                                    "Password=SFCTEST;" +
                                    "Unicode=True;Provider=OraOLEDB.Oracle.1";
                dt.Rows.Add(dr);
            }

           
            foreach (DataRow dr in ConnData.Tables["TConnString"].Rows)
            {
                //_ConnStrings.Add("ConnName", dr["ConnName"].ToString());
                if (Boolean.Parse(dr["IsCrypt"].ToString()))
                {
                   // _ConnStrings.Add(dr["ConnName"].ToString(), CryptMain.Decode(dr["ConnString"].ToString(), ConnectionManager.CryptName, BytesIO.FromBase64String(ConnectionManager.CryptKEY)));
                }
                else
                {
                    _ConnStrings.Add(dr["ConnName"].ToString(), dr["ConnString"].ToString());
                }
            }
        }
        /// <summary>
        /// 通過名稱獲取鏈接字符串
        /// </summary>
        /// <param name="ConnName"></param>
        /// <returns></returns>
        public static string GetConnString(string ConnName)
        {
            return (string)_ConnStrings[ConnName];
        }
    }
}
