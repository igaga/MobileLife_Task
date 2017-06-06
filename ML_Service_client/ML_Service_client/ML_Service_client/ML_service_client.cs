using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace ML_Service_client
{
    public partial class ML_service_client : Form
    {
        public ML_service_client()
        {
            InitializeComponent();
        }

        private void ML_service_client_Load(object sender, EventArgs e)
        {
            List<string> TaxTypes = new List<string>();
            TaxManagementClient client = new TaxManagementClient();
            try
            {
                TaxTypes = client.GetTaxTypes().ToList();
                comboBoxTaxTypes.DataSource = TaxTypes;
                client.Close();
            } catch
            {
                MessageBox.Show("Service is unreachable", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            updateDates();
            labelDate.Text = monthCalendar2.SelectionStart.ToString("yyyy.MM.dd");
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            if (!checkEmptyValue("municipality name", textBoxMunicipalityAdd.Text))
            {
                return;
            }
            if (!checkEmptyValue("tax value", textBoxTaxAdd.Text))
            {
                return;
            }
            
            WCF_Service.MunicipalityTax dataRequest = new WCF_Service.MunicipalityTax()
            {
                Municipality = textBoxMunicipalityAdd.Text,
                TaxType = comboBoxTaxTypes.SelectedValue.ToString().Trim(),
                ValidFrom = Convert.ToDateTime(labelValidFrom.Text),
                ValidTo = Convert.ToDateTime(labelValidTo.Text),
                Tax = Decimal.Parse(textBoxTaxAdd.Text)
            };
            TaxManagementClient client = new TaxManagementClient();
            WCF_Service.GeneralResponse resp =  client.AddTaxRecord(dataRequest);
            client.Close();
            toolStripStatusLabel.Text = resp.message;


        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                long l = new FileInfo(openFileDialog1.FileName).Length;
                if (l > 104857600)
                {
                    MessageBox.Show("File is too large. Max allowed size 100 MB","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                textBoxFileName.Text = openFileDialog1.FileName;
                WCF_Service.FileTransferRequest req = new WCF_Service.FileTransferRequest();
                req.FileName = openFileDialog1.SafeFileName;
                
                req.Content = File.ReadAllBytes(openFileDialog1.FileName);
                WCF_Service.MunicipalityTaxResponse TaxResponse = new WCF_Service.MunicipalityTaxResponse();
                List<WCF_Service.MunicipalityTaxResponse> TaxResponseList = new List<WCF_Service.MunicipalityTaxResponse>();
                TaxManagementClient client = new TaxManagementClient();
                TaxResponseList = client.UploadDataFromFile(req).ToList();
                client.Close();

                if ((TaxResponseList.Count() == 1) && (string.IsNullOrWhiteSpace(TaxResponseList.First().Municipality)))
                {
                    MessageBox.Show(TaxResponseList.First().Message, "File transfer error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dataGridView1.DataSource = TaxResponseList;
                    dataGridView1.Columns.Remove("Status");
                    dataGridView1.Columns.Remove("ExtensionData");
                }
            }
        }

        private void getTax_Click_Click(object sender, EventArgs e)
        {
            if (!checkEmptyValue("municipality name", textBoxMunicipality.Text))
            {
                return;
            }

            string s = comboBoxTaxTypes.SelectedValue.ToString();
            WCF_Service.MunicipalityTax req = new WCF_Service.MunicipalityTax();
            req.Municipality = textBoxMunicipality.Text;
            req.ValidFrom = monthCalendar2.SelectionStart;

            TaxManagementClient client = new TaxManagementClient();
            WCF_Service.MunicipalityTaxResponse resp = new WCF_Service.MunicipalityTaxResponse();
            resp = client.GetTaxInfo(req);
            textBoxResult.Text = resp.Tax.ToString();
            client.Close();
            toolStripStatusLabel.Text = resp.Message;
        }

        private void textBoxTaxIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            e.Handled = validateDecimalField(ch, textBoxTaxAdd.Text);
            return;
        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            updateDates();
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            labelDate.Text = monthCalendar2.SelectionStart.ToString("yyyy.MM.dd");
        }
        private void updateDates()
        {
            string dateFrom = monthCalendar1.SelectionStart.ToString("yyyy.MM.dd");
            string dateTo = "";
            int month = monthCalendar1.SelectionStart.Month;
            int year = monthCalendar1.SelectionStart.Year;
            string lastMonthDay;
            DateTime firstDayOfWeek;
            string taxType = comboBoxTaxTypes.SelectedValue.ToString().Trim();
            switch (taxType)
            {
                case "WEEK":
                    firstDayOfWeek = monthCalendar1.SelectionStart.AddDays(DayOfWeek.Monday - monthCalendar1.SelectionStart.DayOfWeek);
                    dateFrom = firstDayOfWeek.ToString("yyyy.MM.dd");
                    dateTo = firstDayOfWeek.AddDays(6).ToString("yyyy.MM.dd");
                    break;
                case "MONTH":
                    dateFrom    = year.ToString() + "." + month.ToString().PadLeft(2,'0') + ".01";
                    lastMonthDay = System.DateTime.DaysInMonth(year, month).ToString().PadLeft(2, '0');
                    dateTo      = year.ToString() + "." + month.ToString().PadLeft(2, '0') + "." + lastMonthDay;
                    break;
                case "YEAR":
                    dateFrom    = year.ToString() + ".01.01";
                    dateTo      = year.ToString() + ".12.31";
                    break;
                default:
                    dateTo = dateFrom;
                    break;
            }
            labelValidFrom.Text = dateFrom;
            labelValidTo.Text   = dateTo;
        }

        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            e.Handled = validateDecimalField(ch, textBoxResult.Text);
            return;
        }

        bool validateDecimalField(char ch, string text)
        {
            if ((ch == 44 && textBoxTaxAdd.Text.IndexOf(',') != -1) || (!Char.IsDigit(ch) && ch != 8 && ch != 44))
            {
                return true;
            }
            return false;
        }

        bool checkEmptyValue(string valueName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            { 
                MessageBox.Show("Please enter " + valueName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            return true;
        }

        private void buttonUpdateResult_Click(object sender, EventArgs e)
        {
            if (!checkEmptyValue("municipality name", textBoxMunicipalityAdd.Text))
            {
                return;
            }
            if (!checkEmptyValue("tax value", textBoxTaxAdd.Text))
            {
                return;
            }

            WCF_Service.MunicipalityTax dataRequest = new WCF_Service.MunicipalityTax()
            {
                Municipality = textBoxMunicipalityAdd.Text,
                TaxType = comboBoxTaxTypes.SelectedValue.ToString().Trim(),
                ValidFrom = Convert.ToDateTime(labelValidFrom.Text),
                Tax = Decimal.Parse(textBoxTaxAdd.Text)
            };
            TaxManagementClient client = new TaxManagementClient();
            WCF_Service.GeneralResponse res = client.UpdateTaxRecord(dataRequest);
            client.Close();
            toolStripStatusLabel.Text = res.message;
        }

        private void comboBoxTaxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDates();
        }
    }
}
