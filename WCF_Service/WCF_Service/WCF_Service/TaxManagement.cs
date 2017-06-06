using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace WCF_Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class TaxManagement : ITaxManagement
    {
        private int rows_affected;
        private string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; 
                                         AttachDbFilename = |DataDirectory|\ML_Service_DB.mdf;
                                         Integrated Security=True";

        public List<MunicipalityTaxResponse> UploadDataFromFile(FileTransferRequest inputFile)
        {
            List<MunicipalityTaxResponse> TaxRecordList = new List<MunicipalityTaxResponse>();
            MunicipalityTaxResponse TaxRecord = new MunicipalityTaxResponse();

            if (!CheckFileTransferRequest(inputFile, out string message))
            {
                TaxRecord.Status = false;
                TaxRecord.Message = message;
                TaxRecordList.Add(TaxRecord);
                return TaxRecordList;
            }

            try
            {
                if (SaveFileStream(inputFile.FileName, new MemoryStream(inputFile.Content), out message))
                {
                    DataTable records = GetDataFromCSV(inputFile.FileName);

                    foreach (DataRow rec in records.Rows)
                    {
                        TaxRecord = new MunicipalityTaxResponse();
                        if (!bool.Parse(rec[5].ToString()))
                        {
                            TaxRecord.Status = bool.Parse(rec[5].ToString());
                            TaxRecord.Message = rec[6].ToString();
                        }
                        else
                        { 
                            try
                            {
                                TaxRecord.Municipality = rec[0].ToString();
                                TaxRecord.TaxType = rec[1].ToString();
                                TaxRecord.ValidFrom = DateTime.Parse(rec[2].ToString());
                                TaxRecord.ValidTo = DateTime.Parse(rec[3].ToString());
                                TaxRecord.Tax = Decimal.Parse(rec[4].ToString());
                                GeneralResponse res = AddTaxRecord(TaxRecord);
                                TaxRecord.Status = res.status;
                                TaxRecord.Message = res.message;
                            }
                            catch
                            {
                                TaxRecord.Status = false;
                                TaxRecord.Message = "Unable to convert field data";
                            }
                        }
                        TaxRecordList.Add(TaxRecord);

                    }
                }
                else
                {
                    TaxRecord.Status = false;
                    TaxRecord.Message = message;
                    TaxRecordList.Add(TaxRecord);
                    return TaxRecordList;
                }
            }
            catch
            {
                TaxRecord.Status = false;
                TaxRecord.Message = "Unknown file format";
                TaxRecordList.Add(TaxRecord);
                return TaxRecordList;
            }

            return TaxRecordList;
        }

        private bool SaveFileStream(string filePath, Stream stream, out string message)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    message = "File " + filePath + " allready uploaded";
                    return false;
                }
                var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                fileStream.Dispose();
                message = "File saved";
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckFileTransferRequest(FileTransferRequest fileToPush, out string message)
        {
            if (fileToPush != null)
            {
                if (!string.IsNullOrEmpty(fileToPush.FileName))
                {
                    if (fileToPush.Content != null)
                    {
                        message = "File transfered";
                        return true;
                    }
                    else
                    {
                        message = "File is empty";
                        return false;
                    }
                }
                else
                {
                    message = "File is empty";
                    return false;
                }
            }
            else
            {
                message = "File not found";
                return false;
            };
        }

        //d:\\Dropbox\\Other\\C#\\inp.csv
        private static DataTable GetDataFromCSV(string input_file)
        {
            DataTable csvDataTable = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(input_file))
                {
                    csvReader.SetDelimiters(new string[] { ";" });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        csvDataTable.Columns.Add(datacolumn);
                    }
                    csvDataTable.Columns.Add("Status");
                    csvDataTable.Columns.Add("Message");


                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        if (fieldData.Length == (csvDataTable.Columns.Count - 2))
                        {
                            csvDataTable.Rows.Add(fieldData[0], fieldData[1], fieldData[2], fieldData[3], fieldData[4], true, "OK");
                        }
                        else
                        {
                            csvDataTable.Rows.Add(fieldData[0], fieldData[1], fieldData[2], fieldData[3], fieldData[4], false, "Line member count is incorrect");
                        }
                    }
                }
            }
            catch
            {
                csvDataTable.Rows.Add("", "", "", "", "", false, "Unknown file format");
                return csvDataTable;
            }
            return csvDataTable;
        }

        public MunicipalityTaxResponse GetTaxInfo(MunicipalityTax req)
        {
            MunicipalityTaxResponse tbl = new MunicipalityTaxResponse();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {

                    sqlCommand.CommandText = @"SELECT TOP 1 tax  
                                    FROM municipalities
                                    LEFT JOIN TaxPriorities ON municipalities.tax_type = TaxPriorities.TaxType                                    
                                    where municipality = @parMunicip and valid_from <= @parDate and valid_to >= @parDate
                                    ORDER BY Priority";
                    sqlCommand.Parameters.Add(new SqlParameter("parMunicip", req.Municipality));
                    sqlCommand.Parameters.Add(new SqlParameter("parDate", req.ValidFrom));
                    sqlCommand.Connection = connection;
                    connection.Open();
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tbl.Status = true;
                                tbl.Tax = reader.GetDecimal(0);
                                tbl.Message = "";
                            }
                            else
                            {
                                tbl.Status = false;
                                tbl.Tax = 0;
                                tbl.Message = "No tax records found";
                            }
                        }
                    }
                    catch
                    {
                        tbl.Status = false;
                        tbl.Tax = 0;
                        tbl.Message = "Database error occured";
                    }
                }
            }
            return tbl;
        }

        public GeneralResponse AddTaxRecord(MunicipalityTax tbl)
        {
            GeneralResponse res = new GeneralResponse();

            if (!ValidateTaxDates(tbl.TaxType, tbl.ValidFrom.Date, tbl.ValidTo.Date))
            {
                res.message = "From/To dates do not match tax type";
                res.status = false;
                return res;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText = @"IF NOT EXISTS (SELECT 1 FROM municipalities 
                                                              WHERE municipality = @parMunicip and tax_type = @parTaxType and valid_from = @parFrom)
                                             INSERT INTO municipalities (municipality, tax_type, valid_from, valid_to, tax)
                                             VALUES (@parMunicip, @parTaxType, @parFrom, @parTo, @parTax)";
                    sqlCommand.Parameters.Add(new SqlParameter("parMunicip", tbl.Municipality));
                    sqlCommand.Parameters.Add(new SqlParameter("parTaxType", tbl.TaxType));
                    sqlCommand.Parameters.Add(new SqlParameter("parFrom", tbl.ValidFrom.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("parTo", tbl.ValidTo.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("parTax", tbl.Tax));
                    sqlCommand.Connection = connection;
                    connection.Open();
                    try
                    {
                        rows_affected = sqlCommand.ExecuteNonQuery();
                        if (rows_affected < 1)
                        {
                            res.message = "Duplicate tax record was not added";
                            res.status = false;
                            return res;
                        }
                    }
                    catch
                    {
                        res.status = false;
                        res.message = "Unable to add record";
                        return res;
                    }
                }
            }
            res.message = "Tax record added";
            res.status = true;
            return res;
        }

        public GeneralResponse UpdateTaxRecord(MunicipalityTax tbl)
        {
            GeneralResponse res = new GeneralResponse();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText = @"IF EXISTS (SELECT 1 FROM municipalities 
                                                          WHERE municipality = @parMunicip and tax_type = @parTaxType and valid_from = @parFrom)
                                             UPDATE municipalities 
                                             SET tax = @parTax
                                             WHERE municipality = @parMunicip and tax_type = @parTaxType and valid_from = @parFrom;";
                    sqlCommand.Parameters.Add(new SqlParameter("parMunicip", tbl.Municipality));
                    sqlCommand.Parameters.Add(new SqlParameter("parTaxType", tbl.TaxType));
                    sqlCommand.Parameters.Add(new SqlParameter("parFrom", tbl.ValidFrom.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("parTax", tbl.Tax));
                    sqlCommand.Connection = connection;
                    connection.Open();
                    try
                    {
                        rows_affected = sqlCommand.ExecuteNonQuery();
                        if (rows_affected < 1)
                        {
                            res.message = "Tax record not found";
                            res.status = false;
                            return res;
                        }
                    }
                    catch (Exception e)
                    {
                        res.status = false;
                        res.message = e.Message;
                    }
                }
            }
            res.message = "Record updated";
            res.status = true;
            return res;
        }

        public List<string> GetTaxTypes()
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    connection.Open();
                    sqlCommand.CommandText = @"SELECT * FROM TaxPriorities";
                    sqlCommand.Connection = connection;

                    sqlCommand.ExecuteNonQuery();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return list;
        }

        private bool ValidateTaxDates(string taxType, DateTime dateFrom, DateTime dateTo)
        {
            int month = dateFrom.Month;
            int year = dateFrom.Year;
            DateTime firstDay, lastDay;
            switch (taxType)
            {
                case "WEEK":
                    firstDay = dateFrom.AddDays(DayOfWeek.Monday - dateFrom.DayOfWeek);
                    lastDay = firstDay.AddDays(6);
                    break;
                case "MONTH":
                    firstDay = DateTime.Parse(year.ToString() + "." + month.ToString().PadLeft(2, '0') + ".01");
                    lastDay = DateTime.Parse(year.ToString() + "." + month.ToString().PadLeft(2, '0') + "." + System.DateTime.DaysInMonth(year, month).ToString().PadLeft(2, '0'));
                    break;
                case "YEAR":
                    firstDay = DateTime.Parse(year.ToString() + ".01.01");
                    lastDay = DateTime.Parse(year.ToString() + ".12.31");
                    break;
                default:
                    firstDay = dateFrom;
                    lastDay = dateFrom;
                    break;
            }
            if ((firstDay.Equals(dateFrom)) && (lastDay.Equals(dateTo)))
            {
                return true;
            }
            return false;

        }

    }

}

