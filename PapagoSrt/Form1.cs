using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace PapagoSrt
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Task> tasks = new();

        public Form1()
        {
            InitializeComponent();

            dgvFile.AutoGenerateColumns = false;
            dgvFile.DataSource = tasks;

            txtFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "SRT files | *.srt";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var newFiles = dialog.FileNames.Except(tasks.Select(x => x.Filename)).ToList();
                foreach (var filename in newFiles)
                    tasks.Add(new Task(filename));
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            var rowCount = dgvFile.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (rowCount > 0)
            {
                for (var i = 0; i < rowCount; i++)
                {
                    dgvFile.Rows.RemoveAt(dgvFile.SelectedRows[0].Index);
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            tasks.Clear();
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (Path.IsPathRooted(txtFolder.Text))
            {
                dialog.SelectedPath = txtFolder.Text;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = dialog.SelectedPath;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (Path.IsPathRooted(txtFolder.Text))
            {
                Process.Start(new ProcessStartInfo { FileName = txtFolder.Text, UseShellExecute = true });
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var folder = txtFolder.Text;
            var isSameFolder = cbxSameFolder.Checked;

            if (string.IsNullOrWhiteSpace(folder) && !isSameFolder)
            {
                MessageBox.Show("저장 폴더가 지정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pendingTasks = tasks.Where(x => x.Status == TaskStatus.Pending).ToList();
            if (pendingTasks.Count == 0)
                return;

            btnStart.Enabled = false;

            await System.Threading.Tasks.Task.Run(() =>
            {
                SrtTranslator.Initialize();
                try
                {
                    foreach (var task in pendingTasks)
                    {
                        var sourceFile = task.Filename;
                        var targetFile = isSameFolder ? AddSuffixToFileName(task.Filename, "-kr") : Path.Combine(folder, Path.GetFileName(task.Filename));
                        SrtTranslator.Run(task.Filename, targetFile);

                        task.SetStatus(TaskStatus.Success);
                    }
                }
                finally
                {
                    SrtTranslator.Cleanup();
                }
            });

            MessageBox.Show("작업이 완료 되었습니다", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnStart.Enabled = true;
        }

        private string previousFolderText;

        private void cbxSameFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSameFolder.Checked)
            {
                previousFolderText = txtFolder.Text;
                txtFolder.Text = "원본 위치에 저장 됩니다";
            }
            else
            {
                txtFolder.Text = previousFolderText;
            }
        }

        private void dgvFile_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvFile.Rows.Count; i++)
            {
                dgvFile.Rows[i].Cells["colNumber"].Value = i + 1;
            }
        }

        private void dgvFile_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            dgvFile.Rows[e.Row.Index].Cells["colNumber"].Value = e.Row.Index + 1;
        }

        private void dgvFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemoveFile.PerformClick();
            }
        }

        private string AddSuffixToFileName(string filePath, string suffix)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var extension = Path.GetExtension(filePath);

            return Path.Combine(directory, $"{fileName}{suffix}{extension}");
        }
    }
}
