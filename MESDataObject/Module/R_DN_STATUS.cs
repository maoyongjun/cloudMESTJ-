﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MESDBHelper;

namespace MESDataObject.Module
{
    public class T_R_DN_STATUS : DataObjectTable
    {
        public T_R_DN_STATUS(string _TableName, OleExec DB, DB_TYPE_ENUM DBType) : base(_TableName, DB, DBType)
        {

        }
        public T_R_DN_STATUS(OleExec DB, DB_TYPE_ENUM DBType)
        {
            RowType = typeof(Row_R_DN_STATUS);
            TableName = "R_DN_STATUS".ToUpper();
            DataInfo = GetDataObjectInfo(TableName, DB, DBType);
        }
    }
    public class Row_R_DN_STATUS : DataObjectBase
    {
        public Row_R_DN_STATUS(DataObjectInfo info) : base(info)
        {

        }
        public R_DN_STATUS GetDataObject()
        {
            R_DN_STATUS DataObject = new R_DN_STATUS();
            DataObject.GTEVENT = this.GTEVENT;
            DataObject.EDITTIME = this.EDITTIME;
            DataObject.CREATETIME = this.CREATETIME;
            DataObject.DN_PLANT = this.DN_PLANT;
            DataObject.DN_FLAG = this.DN_FLAG;
            DataObject.GTDATE = this.GTDATE;
            DataObject.GT_FLAG = this.GT_FLAG;
            DataObject.GTTYPE = this.GTTYPE;
            DataObject.QTY = this.QTY;
            DataObject.SKUNO = this.SKUNO;
            DataObject.SO_NO = this.SO_NO;
            DataObject.PO_LINE = this.PO_LINE;
            DataObject.PO_NO = this.PO_NO;
            DataObject.DN_LINE = this.DN_LINE;
            DataObject.DN_NO = this.DN_NO;
            return DataObject;
        }
        public string GTEVENT
        {
            get
            {
                return (string)this["GTEVENT"];
            }
            set
            {
                this["GTEVENT"] = value;
            }
        }
        public DateTime? EDITTIME
        {
            get
            {
                return (DateTime?)this["EDITTIME"];
            }
            set
            {
                this["EDITTIME"] = value;
            }
        }
        public DateTime? CREATETIME
        {
            get
            {
                return (DateTime?)this["CREATETIME"];
            }
            set
            {
                this["CREATETIME"] = value;
            }
        }
        public string DN_PLANT
        {
            get
            {
                return (string)this["DN_PLANT"];
            }
            set
            {
                this["DN_PLANT"] = value;
            }
        }
        public string DN_FLAG
        {
            get
            {
                return (string)this["DN_FLAG"];
            }
            set
            {
                this["DN_FLAG"] = value;
            }
        }
        public DateTime? GTDATE
        {
            get
            {
                return (DateTime?)this["GTDATE"];
            }
            set
            {
                this["GTDATE"] = value;
            }
        }
        public string GT_FLAG
        {
            get
            {
                return (string)this["GT_FLAG"];
            }
            set
            {
                this["GT_FLAG"] = value;
            }
        }
        public string GTTYPE
        {
            get
            {
                return (string)this["GTTYPE"];
            }
            set
            {
                this["GTTYPE"] = value;
            }
        }
        public double? QTY
        {
            get
            {
                return (double?)this["QTY"];
            }
            set
            {
                this["QTY"] = value;
            }
        }
        public string SKUNO
        {
            get
            {
                return (string)this["SKUNO"];
            }
            set
            {
                this["SKUNO"] = value;
            }
        }
        public string SO_NO
        {
            get
            {
                return (string)this["SO_NO"];
            }
            set
            {
                this["SO_NO"] = value;
            }
        }
        public string PO_LINE
        {
            get
            {
                return (string)this["PO_LINE"];
            }
            set
            {
                this["PO_LINE"] = value;
            }
        }
        public string PO_NO
        {
            get
            {
                return (string)this["PO_NO"];
            }
            set
            {
                this["PO_NO"] = value;
            }
        }
        public string DN_LINE
        {
            get
            {
                return (string)this["DN_LINE"];
            }
            set
            {
                this["DN_LINE"] = value;
            }
        }
        public string DN_NO
        {
            get
            {
                return (string)this["DN_NO"];
            }
            set
            {
                this["DN_NO"] = value;
            }
        }
    }
    public class R_DN_STATUS
    {
        public string GTEVENT{ get; set; }
        public DateTime? EDITTIME{ get; set; }
        public DateTime? CREATETIME{ get; set; }
        public string DN_PLANT{ get; set; }
        public string DN_FLAG{ get; set; }
        public DateTime? GTDATE{ get; set; }
        public string GT_FLAG{ get; set; }
        public string GTTYPE{ get; set; }
        public double? QTY{ get; set; }
        public string SKUNO{ get; set; }
        public string SO_NO{ get; set; }
        public string PO_LINE{ get; set; }
        public string PO_NO{ get; set; }
        public string DN_LINE{ get; set; }
        public string DN_NO{ get; set; }
    }
}