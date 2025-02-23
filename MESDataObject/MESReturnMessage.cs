﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using MESDBHelper;
using MESDataObject.Module;



/// <summary>
/// 多語言顯示類
/// </summary>
namespace MESDataObject
{
    
    public class MESReturnMessage:System.Exception
    {
        static OleExecPool _sfcdb;

        public static string Language;
        /// <summary>
        /// 獲取DB資源池信息
        /// </summary>
        /// <param name="sfcdb"></param>
        public static void SetSFCDBPool(OleExecPool sfcdb)
        {
            _sfcdb = sfcdb;
        }

        /// <summary>
        /// 從DB中獲取Message信息,從App.config中讀取語言類型
        /// </summary>
        /// <param name="MessageCode"></param>
        /// <returns></returns>
        public static string GetMESReturnMessage(string MessageCode)
        {
            string MESMessage = "";
            Language = Language == null ? "ENGLISH" : Language;
            OleExec sfcdb = _sfcdb.Borrow();
            try
            {
                T_C_MES_MESSAGE c_mes_message = new T_C_MES_MESSAGE(sfcdb, DB_TYPE_ENUM.Oracle);
                DataObjectBase row = c_mes_message.GetMESMessageByMessageCode(MessageCode, sfcdb, DB_TYPE_ENUM.Oracle);
                MESMessage = row[Language].ToString();
                _sfcdb.Return(sfcdb);
            }
            catch(Exception ex)
            {
                _sfcdb.Return(sfcdb);
                MESMessage = "500.System Error:" + ex.Message.ToString();
            }
            return MESMessage;
        }

        public static string GetMESReturnMessage(string MessageCode,string[] Paras)
        {
            string MESMessage = "";
            Language = Language == null ? "ENGLISH" : Language;
            OleExec sfcdb = _sfcdb.Borrow();

            try
            {
                T_C_MES_MESSAGE c_mes_message = new T_C_MES_MESSAGE(sfcdb, DB_TYPE_ENUM.Oracle);
                DataObjectBase row = c_mes_message.GetMESMessageByMessageCode(MessageCode, sfcdb, DB_TYPE_ENUM.Oracle);
                if (Paras == null)
                {
                    MESMessage = string.Format(row[Language].ToString());
                }
                else
                {
                    MESMessage = string.Format(row[Language].ToString(), Paras);
                }
                _sfcdb.Return(sfcdb);
            }
            catch (Exception ex)
            {
                _sfcdb.Return(sfcdb);
                MESMessage = "500.System Error:" + ex.Message.ToString();
            }
            return MESMessage;
        }

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name="message"></param>
        public MESReturnMessage(string Message) : base(Message)
        {
         
        }

      
    }
}
