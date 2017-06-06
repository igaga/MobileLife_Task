using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCF_Service
{
    [ServiceContract]
    public interface ITaxManagement
    {
        [OperationContract]
        List<MunicipalityTaxResponse> UploadDataFromFile(FileTransferRequest req);

        [OperationContract]
        List<string> GetTaxTypes();

        [OperationContract]
        MunicipalityTaxResponse GetTaxInfo(MunicipalityTax req);

        [OperationContract]
        GeneralResponse AddTaxRecord(MunicipalityTax tbl);

        [OperationContract]
        GeneralResponse UpdateTaxRecord(MunicipalityTax tbl);
    }

    [DataContract]
    public class FileTransferRequest
    {
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }

    [DataContract]
    public class GeneralResponse
    {
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public string message { get; set; }
    }

   
    [DataContract]
    [Serializable]
    public class MunicipalityTax
    {
        private string municipality;
        private string taxType;
        private DateTime validFrom;
        private DateTime validTo;
        private decimal tax;

        [DataMember]
        public string Municipality
        {
            get { return municipality; }
            set { municipality = value; }
        }

        [DataMember]
        public string TaxType
        {
            get { return taxType; }
            set { taxType = value; }
        }

        [DataMember]
        public DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }

        [DataMember]
        public DateTime ValidTo
        {
            get { return validTo; }
            set { validTo = value; }
        }

        [DataMember]
        public decimal Tax
        {
            get { return tax; }
            set { tax = value; }
        }

    }

    [DataContract]
    public class MunicipalityTaxResponse : MunicipalityTax
    {

        private string message;
        private bool status;

        [DataMember]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
