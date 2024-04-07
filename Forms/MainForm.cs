using ModernSymmetricCiphers.Enums;
using ModernSymmetricCiphers.Exceptions;
using ModernSymmetricCiphers.Helpers;
using ModernSymmetricCiphers.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace ModernSymmetricCiphers.Forms
{
    public partial class MainForm : Form
    {
        public AesEncoder Encoder;

        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Encoder = new AesEncoder() { BlockType = BlockEnum.Bit128 };
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pathButton_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                using (FileStream fstream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(buffer, 0, buffer.Length);
                    Encoder.InitialBytes = buffer;
                }
                pathTextBox.Text = fileName;
                EnableButtons();
            }
        }

        private void encodeButton_Click(object sender, System.EventArgs e)
        {
            CreateResultTxtFile(true);
        }

        private void decodeButton_Click(object sender, System.EventArgs e)
        {
            CreateResultTxtFile(false);
        }

        private void secretKeyTextBox_TextChanged(object sender, System.EventArgs e)
        {
            Encoder.SecretKey = secretKeyTextBox.Text;
            EnableButtons();
        }

        private void EnableButtons()
        {
            encodeButton.Enabled = !string.IsNullOrEmpty(pathTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text);
            decodeButton.Enabled = !string.IsNullOrEmpty(pathTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text);
        }

        private void CreateResultTxtFile(bool encode)
        {
            try
            {
                if (encode)
                    Encoder.Encode();
                else
                    Encoder.Decode();

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    saveFileDialog.Filter = "All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, Encoder.FinishedBytes);
                    }
                }
            }
            catch (EncodeException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}