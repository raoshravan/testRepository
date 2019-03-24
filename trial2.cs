using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Reflection;
namespace JsonExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo AIDirectoryInfo = new DirectoryInfo(@"F:\jsonExtractor\04021-20180905-01\AI");
            FileInfo[] AIfiles = AIDirectoryInfo.GetFiles("*.json");
            //string[] AIfilesList = AIfiles.Select(f => f.Name).ToArray();

            DirectoryInfo OPDirectoryInfo = new DirectoryInfo(@"F:\jsonExtractor\04021-20180905-01\Operations");
            FileInfo[] OPfiles = OPDirectoryInfo.GetFiles("*.json");
            //string[] OPfilesList = OPfiles.Select(f => f.Name).ToArray();
            RootObject objJdata=null;
            foreach (var AIfilesListItem in AIfiles)
            {
                if (OPfiles.Any(file => file.Name == AIfilesListItem.Name.Split('.')[0] + ".TIF.json"))
                {
                    string json = File.ReadAllText(AIfilesListItem.FullName);
                    objJdata = JsonConvert.DeserializeObject<RootObject>(json);
                    // var gettingcolumnname = objJdata.GetType().GetProperties().Select(x => x.Name).ToArray();
                    
                    System.Data.DataTable AIDatatable = new System.Data.DataTable();
                    AIDatatable.TableName = "AI";

                    var properties = objJdata.GetType().GetProperties();

                    foreach (var p in properties)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = p.Name;
                        var value1 = p.GetValue(objJdata, null).GetType().GetProperties();
                        foreach(var val in value1)
                        {
                            var finalvalue = val.Name + ""+val.GetValue(p.GetValue(objJdata, null), null);
                        }
                        
                    }







                    //foreach (var Item in gettingcolumnname)
                    //{
                        
                    //    if (!AIDatatable.Columns.Contains(column.ColumnName))
                    //    {
                    //        AIDatatable.Columns.Add(column);
                    //    }

                    //    AIDatatable.Rows.Add(objJdata.GetType().GetProperty(Item).GetValue(objJdata, null));
                    //}

                }
            }


        }

        public class RecordingDocumentNumber
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class SaleAmount
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class MERSMinNumber
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class TermEndDate
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class SubType
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class CountyTransferTax
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class RecordingPageFrom
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class RecordingBook
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class JudgmentLienAmountTotalAmount
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class MERSPhoneNumber
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class RecordingDocumentDate
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class RecordingCompany
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class PostToIndicator
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class CaseNumber
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class LoanAmount
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class Doctype
        {
            public string confidence { get; set; }
            public string value { get; set; }
        }

        public class RootObject
        {
            public RecordingDocumentNumber Recording_Document_Number { get; set; }
            public SaleAmount SaleAmount { get; set; }
            public MERSMinNumber MERS_Min_number { get; set; }
            public object Transfer_Tax_Full_Partial_code { get; set; }
            public TermEndDate Term_End_Date { get; set; }
            public SubType SubType { get; set; }
            public object Loan_Type { get; set; }
            public CountyTransferTax County_Transfer_Tax { get; set; }
            public RecordingPageFrom Recording_Page_From { get; set; }
            public RecordingBook Recording_Book { get; set; }
            public object Court_Type_Code { get; set; }
            public string imageFile { get; set; }
            public JudgmentLienAmountTotalAmount Judgment_Lien_Amount_Total_Amount { get; set; }
            public MERSPhoneNumber MERS_Phone_number { get; set; }
            public RecordingDocumentDate Recording_Document_Date { get; set; }
            public RecordingCompany RecordingCompany { get; set; }
            public PostToIndicator PostToIndicator { get; set; }
            public CaseNumber Case_Number { get; set; }
            public LoanAmount Loan_Amount { get; set; }
            public Doctype Doctype { get; set; }
        }
    }
}

