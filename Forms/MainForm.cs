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
            try
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.FileName;
                    using (FileStream fstream = new FileStream(openFileDialog.FileName, FileMode.Open)) // Здесь происходит чтение из файла.
                    {
                        // Выделяем массив для считывания данных из файла
                        byte[] buffer = new byte[fstream.Length];
                        // Считываем данные
                        fstream.Read(buffer, 0, buffer.Length);
                        Encoder.InitialBytes = buffer;
                    }
                    pathTextBox.Text = fileName;
                    EnableButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Exception message: {ex.Message}\nInner exception message: {ex.InnerException.Message}\nStack trace: {ex.StackTrace}", "Непредвиденная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Включение/отключение кнопок.
        /// </summary>
        private void EnableButtons()
        {
            encodeButton.Enabled = !string.IsNullOrEmpty(pathTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text);
            decodeButton.Enabled = !string.IsNullOrEmpty(pathTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text);
        }

        /// <summary>
        /// Сохранение файла-результат.
        /// </summary>
        /// <param name="encode">True - зашифровка.</param>
        private void CreateResultTxtFile(bool encode)
        {
            try
            {
                if (encode)
                    Encoder.Encode();
                else
                    Encoder.Decode();
                // Сохраняем файл-результат.
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
                MessageBox.Show(this, ex.Message, "Ошибка в данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Exception message: {ex.Message}\nInner exception message: {ex.InnerException.Message}\nStack trace: {ex.StackTrace}", "Непредвиденная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}