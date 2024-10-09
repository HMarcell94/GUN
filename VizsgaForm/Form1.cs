using System.Windows.Forms.VisualStyles;
using VizsgaCommon;

namespace VizsgaForm
{
    public partial class Form1 : Form
    {
        List<LogEntry> _logs;
        List<LogEntry> _logsBackup;

        public Form1()
        {
            InitializeComponent();
            _LoadData();
            _LoadSearchFields();
        }

        private void _LoadData()
        {
            using (SQL sql = new SQL())
            {
                _logs = sql.Logs.ToList();
            }
            this.dataGridView1.DataSource = _logs;
            _logsBackup = _logs;
        }

        private void _LoadSearchFields()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                this.comboBox1.Items.Add(col.HeaderText);
            }
            this.comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            this.lblDebugs.Text = this._logs.Where(a => a.Level == "DEBUG").Count().ToString();
            this.lblErrors.Text = this._logs.Where(a => a.Level == "ERROR").Count().ToString();
            this.lblSorokSzama.Text =
            this._logs.Count().ToString();
        }

        private void _Search()
        {
            _logs = _logsBackup;
            switch (this.comboBox1.SelectedItem)
            {
                case "Id":
                    {
                        _logs = _logs.Where(a => a.Id.ToString() == this.txtSearchValue.Text).ToList();
                        break;
                    }
                case "CorrelationId":
                    {
                        _logs = _logs.Where(a => a.CorrelationId.ToString() == this.txtSearchValue.Text).ToList();
                        break;
                    }
                case "DateUtc":
                    {
                        _logs = _logs.Where(a => a.DateUtc.ToString() == this.txtSearchValue.Text).ToList();
                        break;
                    }
                case "Thread":
                    {
                        _logs = _logs.Where(a => a.Thread.ToString() == this.txtSearchValue.Text).ToList();
                        break;
                    }
                case "Level":
                    {
                        _logs = _logs.Where(a => a.Level.Contains(this.txtSearchValue.Text)).ToList();
                        break;
                    }
                case "Logger":
                    {
                        _logs = _logs.Where(a => a.Logger.Contains(this.txtSearchValue.Text)).ToList();
                        break;
                    }
                case "Message":
                    {
                        _logs = _logs.Where(a => a.Message.Contains(this.txtSearchValue.Text)).ToList();
                        break;
                    }
                case "Exception":
                    {
                        _logs = _logs.Where(a => a.Exception.Contains(this.txtSearchValue.Text)).ToList();
                        break;
                    }
            }
            dataGridView1.DataSource = _logs;
            GC.Collect();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                MessageBox.Show("Keresési szöveg nincs megadva!");
                this.txtSearchValue.Focus();
                return;
            }
            _Search();
            this.btnExport.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _logs = _logsBackup;
            dataGridView1.DataSource = _logs;
            this.btnExport.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                string[] lines = _logs.Select(d => $"{d.Id};{d.CorrelationId};{d.DateUtc};{d.Thread};{d.Level};{d.Logger};{d.Message};{d.Exception}").ToArray();
                File.AppendAllLines(dlg.FileName, lines);
            }
        }
    }
}
