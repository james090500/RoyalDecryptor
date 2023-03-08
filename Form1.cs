using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System.Diagnostics;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RoyalDecrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            chkSubDir.Enabled = false;
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            chkSubDir.Enabled = true;
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Reset
            resetForm();

            // Set Vars
            String rsaKey = txtPrivateKey.Text;
            String royalPath = txtFilePath.Text;

            // Check values filled in
            if (rsaKey.Length == 0 || royalPath.Length == 0)
            {
                MessageBox.Show("Please fill in the RSA Key and Royal Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetForm();
                return;
            }

            //Check if file or folder exists
            FileAttributes attributes = File.GetAttributes(royalPath);
            switch (attributes)
            {
                case FileAttributes.Directory:
                    if (Directory.Exists(royalPath)) {
                        SearchOption searchOption = chkSubDir.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                        string[] allRoyalFiles = Directory.GetFiles(royalPath, "*.royal_w", searchOption);
                        foreach (string royalFile in allRoyalFiles) {
                            startDecryption(royalFile);
                        }
                    } else {
                        MessageBox.Show("Folder does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetForm();
                    }
                    break;
                default:
                    if (File.Exists(royalPath)) {
                        startDecryption(royalPath);
                    } else {
                        MessageBox.Show("File does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetForm();
                    }
                    break;
            }

            // Completed
            lblStatus.Text = "Done!";
            btnStart.Enabled = true;
        }

        private void resetForm()
        {
            btnStart.Enabled = true;
            lblStatus.Text = "Waiting...";
        }

        private void startDecryption(String royalFile)
        {
            //To show a new decryption
            lblStatus.Text = "Decrypting " + Path.GetFileName(royalFile) + "...";

            // Set Vars
            String rsaKey = txtPrivateKey.Text;
            String cleanFile = royalFile.Replace(".royal_w", "");

            // Read the bytes needed from the file
            BinaryReader reader = new BinaryReader(new FileStream(royalFile, FileMode.Open, FileAccess.Read, FileShare.None));

            // Move reader to end of the file
            reader.BaseStream.Position = reader.BaseStream.Length - 1;

            // Layout
            // Encrpyted Contents (Various)
            // 512 Bytes (AES Key/IV encrypted with RSA)
            // 8 Bytes (Original File Length)
            // 8 Bytes (Encryption Type (64 = Full, 32 = Half)            
            long encryptedDataLength = reader.BaseStream.Length - (8 + 8 + 512);

            // Move reader to start
            reader.BaseStream.Position = 0;

            // Read data
            byte[] encryptedData = reader.ReadBytes((int)encryptedDataLength);
            byte[] encryptedKey = reader.ReadBytes(512);
            byte[] fileLength = reader.ReadBytes(8);
            byte[] encryptionType = reader.ReadBytes(8);

            // Close the reader
            reader.Close();

            // Decrypt the AES Key - OpenSSL Command
            // openssl pkeyutl -decrypt -in encrypted.txt -out decrypted.txt -inkey rsa.txt -pkeyopt rsa_padding_mode:oaep            
            AsymmetricCipherKeyPair certificate = (AsymmetricCipherKeyPair)new PemReader(new StringReader(rsaKey)).ReadObject();
            OaepEncoding rsaEngine = new OaepEncoding(new RsaEngine());
            rsaEngine.Init(false, certificate.Private);
            byte[] decryptedKey = rsaEngine.ProcessBlock(encryptedKey, 0, encryptedKey.Length);

            // Split decryptedKey into a AES KEY and AES IV
            byte[] aesKey = new byte[32];
            byte[] aesIv = new byte[16];
            Array.Copy(decryptedKey, 0, aesKey, 0, 32);
            Array.Copy(decryptedKey, 32, aesIv, 0, 16);

            // Prepare AES Decryption
            KeyParameter keyParam = new KeyParameter(aesKey);
            ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, aesIv, 0, 16);
            var cipher = CipherUtilities.GetCipher("AES/CTS/NOPADDING");
            cipher.Init(false, keyParamWithIV);

            // Decrypt Data
            var decryptedData = cipher.DoFinal(encryptedData);

            // Write file to drive
            File.WriteAllBytes(cleanFile, decryptedData);
            lblStatus.Text = "Decrypted " + Path.GetFileNameWithoutExtension(royalFile) + "!";
        }
    }
}