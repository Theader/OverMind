using ClosedXML.Excel;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmDogsFacts : Form
    {
        public frmDogsFacts()
        {
            InitializeComponent();
        }
        string FileName;

        private void frmDogsFacts_Load(object sender, EventArgs e)
        {
            DataSet xlTDS = new DataSet("xlDataSetx");
            openFile.FileName = "";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileName = openFile.FileName;
                PopularComboPlanilha();

                CarregarDataSetcomExcel(ref xlTDS);
                PopularComboOpcoes(xlTDS);
            }
        }
        private void PopularComboPlanilha()
        {
            string connectionString = null;

            if (FileName.Substring(FileName.Length - 1).Contains('s'))
            {
                connectionString = string.Empty;
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + FileName + "; Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }
            if (FileName.Substring(FileName.Length - 1).Contains('x'))
            {
                connectionString = string.Empty;
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=NO;\"";
            }


            OleDbConnection connection = new OleDbConnection(connectionString);

            DataTable dt = new DataTable();
            connection.Open();
            dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            connection.Close();
            connection.Dispose();
            cboPlanilha.DisplayMember = "TABLE_NAME";
            cboPlanilha.ValueMember = "TABLE_NAME";
            cboPlanilha.DataSource = dt;
        }
        private void CarregarDataSetcomExcel(ref DataSet xlTDS)
        {
            string connectionString = null;

            if (FileName.Substring(FileName.Length - 1).Contains('s'))
            {
                connectionString = string.Empty;
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + FileName + "; Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }
            if (FileName.Substring(FileName.Length - 1).Contains('x'))
            {
                connectionString = string.Empty;
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=NO;\"";
            }
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();

                OleDbDataAdapter xlDA = new OleDbDataAdapter("Select * from [" + cboPlanilha.Text + "] ", connection);
                xlDA.Fill(xlTDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                connection.Close();
                connection.Dispose();
            }
        }
        private void PopularComboOpcoes(DataSet dsVariaveis)
        {
            cboEndPoint.Items.Insert(0, "OBTER TODOS");
            for (int i = 0; i < dsVariaveis.Tables[0].Rows.Count; i++)
            {
                cboEndPoint.Items.Insert(i + 1, dsVariaveis.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }
        private void ExportarExcel(int endPointSelecionado, Task<FactsInfo> voFact = null, List<FactsInfo> lstFacts = null)
        {
            using (var workbook = new XLWorkbook())
            {
                if (voFact == null)
                {
                    for (int i = 0; i < lstFacts.Count; i++)
                    {
                        var worksheet = workbook.Worksheets.Add("EndPoint" + lstFacts[i].facts.Count.ToString());
                        worksheet.Cell("A1").Value = "Factos";

                        for (int a = 2; a < lstFacts[i].facts.Count + 2; a++)
                        {
                            worksheet.Cell("A" + a).Value = lstFacts[i].facts[a - 2];
                        }
                    }
                }
                else
                {
                    var worksheet = workbook.Worksheets.Add("EndPoint" + voFact.Result.facts.Count.ToString());
                    worksheet.Cell("A1").Value = "Factos";
                    for (int i = 2; i < voFact.Result.facts.Count + 2; i++)
                    {
                        worksheet.Cell("A" + i).Value = voFact.Result.facts[i - 2];
                    }
                }

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFile.FileName + ".xlsx";
                    workbook.SaveAs(saveFilePath);
                }
            }
        }

        private async Task<FactsInfo> GetFacts(int endPointSelecionado)
        {
            string endPoint = "api/v1/facts/?number=" + endPointSelecionado.ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.dogfactsapi.ducnguyen.dev/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(endPoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    var facts = response.Content.ReadAsAsync<FactsInfo>();
                    return facts.Result;
                }
                return null;
            }
        }

        private void btnGerarExcel_Click(object sender, EventArgs e)
        {
            if(cboEndPoint.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione algum item do comboBox.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Caso o item selecionado for o "ObterTodos" percorre todos os EndPoints nomeia e preenche as Abas
            de acordo com o retorno de cada um, caso não preenche o Excel apenas com o EndPoint selecionado.
           */
            if (cboEndPoint.SelectedIndex == 0)
            {
                List<FactsInfo> lstFacts = new List<FactsInfo>();

                for (int i = 1; i < cboEndPoint.Items.Count; i++)
                {
                    var voFactos = GetFacts(int.Parse(cboEndPoint.Items[i].ToString()));
                    lstFacts.Add(voFactos.Result);
                }

                ExportarExcel(0, null, lstFacts);
            }
            else
            {
                var voFactos = GetFacts(int.Parse(cboEndPoint.SelectedItem.ToString()));
                ExportarExcel(int.Parse(cboEndPoint.SelectedItem.ToString()), voFactos);
            }
        }
    }
}
