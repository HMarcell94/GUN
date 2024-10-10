using LogCommon.Models;
using LogCommon;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Diagnostics;

namespace LogReader
{
    public partial class Form1 : Form
    {
        private SQL _dbContext = new SQL();
        private List<LogEntry> _logs = new List<LogEntry>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saveAsButton.Enabled = false;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
            }

            var logs = _dbContext.Logs.ToArray();

            dataGridView1.DataSource = logs;
            RowCount.Text = _dbContext.Logs.Count() + "";
            ErrorLabel.Text = _dbContext.Logs.Count(x => x.Level == "ERROR") + "";
            DebugLabel.Text = _dbContext.Logs.Count(x => x.Level == "DEBUG") + "";

        }

        private void formResetButton_Click(object sender, EventArgs e)
        {
            saveAsButton.Enabled = false;
            dataGridView1.DataSource = _dbContext.Logs.ToArray();
            RowCount.Text = _dbContext.Logs.Count() + "";
            ErrorLabel.Text = _dbContext.Logs.Count(x => x.Level.Contains("ERROR")) + "";
            DebugLabel.Text = _dbContext.Logs.Count(x => x.Level.Contains("DEBUG")) + "";
            dataGridView1.Refresh();
            _logs.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            saveAsButton.Enabled = true;
            var field = comboBox1.Text;
            var value = textBox1.Text;
            var list = new List<LogCommon.Models.LogEntry>();
            try
            {

            
            switch (field)
            {
                case "Id":
                    list = _dbContext.Logs.Where(x => x.Id == int.Parse(value)).ToList();
                    dataGridView1.DataSource = list;
                    break;
                case "CorrelationId":
                    list = _dbContext.Logs.Where(x => x.CorrelationId == Guid.Parse(value)).ToList();
                    break;
                case "DateUtc":
                    list = _dbContext.Logs.Where(x => x.DateUtc == DateTime.Parse(value)).ToList();
                    break;
                case "Thread":
                    list = _dbContext.Logs.Where(x => x.Thread == int.Parse(value)).ToList();
                    break;
                case "Logger":
                    list = _dbContext.Logs.Where(x => x.Logger == value).ToList();
                    break;
                case "Message":
                    list = _dbContext.Logs.Where(x => x.Message == value).ToList();
                    break;
                case "Exception":
                    list = _dbContext.Logs.Where(x => x.Exception == value).ToList();
                    break;
                case "Level":
                    list = _dbContext.Logs.Where(x => x.Level == value).ToList();
                    break;
                default:
                    Debug.WriteLine("Selected field not found");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", "Oops", MessageBoxButtons.OK);
            }
            _logs = list;
            RowCount.Text = list.Count + "";
            ErrorLabel.Text = list.Count(x => x.Level.Contains("ERROR")) + "";
            DebugLabel.Text = list.Count(x => x.Level.Contains("DEBUG")) + "";

            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
           using(SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "CSV files (*.csv)|*.csv";
                saveFile.FilterIndex = 1;
                saveFile.RestoreDirectory = true;
                saveFile.ShowDialog();
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    var path = saveFile.FileName;
                    File.Create(path).Close();
                    var preparedRows = new List<string>();
                    preparedRows.Add("Id;CorrelationId;DateUtc;Thread;Level;Logger;Message;Exception");
                    foreach(var item in  _logs)
                    {
                        preparedRows.Add($"{item.Id};{item.CorrelationId};{item.DateUtc};{item.Thread};{item.Level};{item.Logger};{item.Message};{item.Exception}");
                    }
                    StreamWriter sw = new(path, true, System.Text.Encoding.UTF8);
                    foreach(var item in preparedRows)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
            string exception = "";
            string message = "";
            if (r != null)
            {
                exception = r.Cells[r.Cells.Count-1].Value + "";
                message = r.Cells[r.Cells.Count-2].Value + "";
            }
            messageTextBox.Text = message;
            exceptionTextBox.Text = exception;
        }
    }
}
