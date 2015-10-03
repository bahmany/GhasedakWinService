using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GhasedakWinService.SMSService;
using GhasedakWinService.MainDataModuleTableAdapters;
using System.Threading;
using GhasedakWinService;
using System.Xml;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;


namespace GhasedakWinService
{


    public partial class Form1 : Form
    {

        public string Label2Caption = "";
        public string Label3Caption = "";
        public string NewLog = "";
        public string OldLog = "";
        public int LastRowIndex = 0;
        public bool IsSendingProcessBusy = false;
        public bool IsRecievingProcessBusy = false;
        public string strConnectionString = "";

        public Form1()
        {

            InitializeComponent();
            strConnectionString = ConfigurationManager.ConnectionStrings["GhasedakWinService.Properties.Settings.GhasedakConnectionString"].ConnectionString;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SMS_Recieving ss = new SMS_Recieving();
                Thread oThread = new Thread(new ThreadStart(ss.RecieveSMS));
                oThread.Start();
            }
            catch (Exception dd)
            {
                NewLog = "Error in creating Thread ln :" + dd.Message.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            smsSoapClient sc = new smsSoapClient();
            string str = sc.doReceiveSMS("dideban", "1234", 0);
            if (str != "")
            {
                DataSet dataSet = new DataSet();

                DataTable dataTable = new DataTable("sms");
                dataTable.Columns.Add("rowID", typeof(string));
                dataTable.Columns.Add("origAddr", typeof(string));
                dataTable.Columns.Add("destAddr", typeof(string));
                dataTable.Columns.Add("time", typeof(string));
                dataTable.Columns.Add("message", typeof(string));
                dataSet.Tables.Add(dataTable);

                System.IO.StringReader xmlSR = new System.IO.StringReader(str);

                dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);


                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        new tbl_sms_recievedTableAdapter().Insert(
                            dr["message"].ToString(),
                            dr["origAddr"].ToString(),
                            " ",
                            Convert.ToInt32(dr["rowID"].ToString()), DateTime.Now);

                    }
                }
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                CheckRegistryIntegrity();
                lb_logger.Items.Clear();
            }
            catch (Exception __e)
            {
                NewLog = "Error in Checking Registry :" + __e.Message.ToString();
            }
            // TODO: This line of code loads data into the 'mainDataModule.tbl_sms_send' table. You can move, or remove it, as needed.
           // this.tbl_sms_sendTableAdapter.Fill(this.mainDataModule.tbl_sms_send);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                InternetConnectionChecker ss = new InternetConnectionChecker();
                Thread oThread = new Thread(new ThreadStart(ss.CheckIt));
                oThread.Start();

                SMSConnectionChecker sso = new SMSConnectionChecker();
                Thread ooThread = new Thread(new ThreadStart(sso.CheckIt));
                ooThread.Start();
            }
            catch (Exception ee)
            {
                NewLog = "Error in Connecting to Internet :" + ee.Message.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label2.Text = Label2Caption;
            label3.Text = Label3Caption;

            if (txt_LastRowIndex.Text != LastRowIndex.ToString())
            {
                txt_LastRowIndex.Text = LastRowIndex.ToString();
                setRegistryKey("", txt_LastRowIndex.Text);
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void tmr_logChecker_Tick(object sender, EventArgs e)
        {
            if (OldLog != NewLog)
            {
                lb_logger.Items.Add(DateTime.Now.ToString() + " " + NewLog);
                OldLog = NewLog;
                lb_logger.SelectedIndex = lb_logger.Items.Count - 1;
            }
        }

        private void tmr_schadualSmsGroup_Tick(object sender, EventArgs e)
        {
            try
            {
                SendSMS ss = new SendSMS();
                Thread oThread = new Thread(new ThreadStart(ss.SendIt));
                oThread.Start();

               // SMS_Recieving sr = new SMS_Recieving();
               // Thread ooThread = new Thread(new ThreadStart(sr.RecieveSMS));
              //  ooThread.Start();
            }
            catch (Exception dd)
            {
                NewLog = "Error in creating Thread ln :" + dd.Message.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public string KeyAddr = @"Software\Ghasedak";

        public void CheckRegistryIntegrity()
        {
         

            RegistryKey rk = Registry.CurrentUser.CreateSubKey(KeyAddr);
            string str_hostAddr = "http://sms1000.ir";
            string str_TelNo = "10009125248398";
            string str_Username = new Encrypting().Encode("123");
            string str_Pass = new Encrypting().Encode("123");

            if (rk.ValueCount == 0)
            {
                rk.SetValue("HostAddr", str_hostAddr);
                rk.SetValue("TelNo", str_TelNo);
                rk.SetValue("UserName", str_Username);
                rk.SetValue("Password", str_Pass);
                rk.SetValue("LastRowIndex", "9251574");
            }
            // Getting and checking integrity of Keys in registry 
            str_hostAddr = rk.GetValue("HostAddr", "").ToString();
            str_TelNo = rk.GetValue("TelNo", "").ToString();
            str_Username = rk.GetValue("UserName", "").ToString();
            str_Pass = rk.GetValue("Password", "").ToString();
            if (str_hostAddr == "") { rk.SetValue("HostAddr", "http://sms1000.ir"); }
            if (str_TelNo == "") { rk.SetValue("TelNo", "10009125248398"); }
            if (str_Username == "") { rk.SetValue("UserName", new Encrypting().Encode("123")); }
            if (str_Pass == "") { rk.SetValue("Password", new Encrypting().Encode("123")); }
            if (str_Pass == "") { rk.SetValue("LastRowIndex", "9251574"); }
            //-------------------------
            txt_HostAddr.Text = rk.GetValue("HostAddr", "").ToString();
            txt_TelNo.Text = rk.GetValue("TelNo", "").ToString();
            txt_UserName.Text = rk.GetValue("UserName", "").ToString();
            txt_Pass.Text = rk.GetValue("Password", "").ToString();
            txt_Pass.Text = rk.GetValue("LastRowIndex", "").ToString();

            rk.Close();
        }

        public void setRegistryKey(string keyname, string value)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(KeyAddr);
            rk.SetValue(keyname, value);
            rk.Close();
        }
        public string GetRegistryKey(string keyname, string defaultValue)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(KeyAddr);
            string str = rk.GetValue(keyname, defaultValue).ToString();
            rk.Close();
            return str;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            setRegistryKey("HostAddr", txt_HostAddr.Text);
            setRegistryKey("TelNo", txt_TelNo.Text);
            setRegistryKey("UserName", new Encrypting().Encode(txt_UserName.Text));
            setRegistryKey("Password", new Encrypting().Encode(txt_Pass.Text));
            setRegistryKey("LastRowIndex", txt_LastRowIndex.Text);


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void lb_logger_ControlAdded(object sender, ControlEventArgs e)
        {
            if ((sender as ListBox).Items.Count > 500)
            {
                (sender as ListBox).Items.Clear();
            }
        }
    }

    public class SMS_Recieving
    {
        public void RecieveSMS()
        {
            bool isRecieving = ((Form1)Application.OpenForms["Form1"]).IsRecievingProcessBusy;
            if (!isRecieving)
            {
                ((Form1)Application.OpenForms["Form1"]).IsRecievingProcessBusy = true;
                try
                {
                    int LastRowIDFromWeb = new GhasedakWinService.niazpardaz.Send().GetInboxCount("c.alireza.a","2014",true);

                    // connecting to service
                    smsSoapClient sc = new smsSoapClient();
                    //niazpardaz.Send sc = new GhasedakWinService.niazpardaz.Send();
                    string str = sc.doReceiveSMS("mobtakeran", "mobtakeran", LastRowIDFromWeb);
                    //-------------

                    // parsing 
                    DataSet dataSet = new DataSet();
                    DataTable dataTable = new DataTable("sms");
                    dataTable.Columns.Add("rowID", typeof(string));
                    dataTable.Columns.Add("origAddr", typeof(string));
                    dataTable.Columns.Add("destAddr", typeof(string));
                    dataTable.Columns.Add("time", typeof(string));
                    dataTable.Columns.Add("message", typeof(string));
                    dataSet.Tables.Add(dataTable);
                    System.IO.StringReader xmlSR = new System.IO.StringReader(str);
                    dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);
                    //----------------------------
                    foreach (DataTable dt in dataSet.Tables)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string msg = dr["message"].ToString();
                            string orgadd = dr["origAddr"].ToString();
                            int rowid =0;
                            DateTime tm = DateTime.Now;
                            if (dr["rowID"]!=null) rowid = Convert.ToInt32(dr["rowID"].ToString());
                            if (dr["time"] != null) tm = Convert.ToDateTime(dr["time"].ToString());
                            string destAddr = dr["destAddr"].ToString();

                            if (msg.Contains(".."))
                            {
                                msg = msg.Replace(".", " ");

                            }
                            
                            

                            //msg = Regex.Replace(msg, "..", "");
                            //msg = Regex.Replace(msg, "...", " ");
                            //msg = Regex.Replace(msg, "....", " ");
                           // msg = Regex.Replace(msg, ".....", " ");


                            new tbl_sms_recievedTableAdapter().Insert(
                                    msg,
                                    orgadd,
                                    " ",
                                    rowid,
                                    tm,
                                    DateTime.Now,
                                    destAddr
                                    );
                        }
                    }
                }
                catch (Exception __e)
                {
                    string err = "Error in Recieving SMS Last RowID:" + __e.Message.ToString();
                    if (err.IndexOf("enough") > 10)
                    {
                    } else 
                    { 
                        ((Form1)Application.OpenForms["Form1"]).NewLog = err;
                    }
                   
                    
                }
                ((Form1)Application.OpenForms["Form1"]).IsRecievingProcessBusy = false;


            }
            
            /*
            smsSoapClient sc = new smsSoapClient();
            int lastRowID = 0;
            try
            {
                 lastRowID = (int)new tbl_sms_recievedTableAdapter().GetLastRowID();
                
            }
            catch (Exception ee)
            {
                lastRowID = 0;
                ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Recieving SMS Last RowID:" + ee.Message.ToString();
            }
            string str = "";

            try
            {
                str = sc.doReceiveSMS("dideban", "1234", lastRowID);
            }
            catch (Exception ee)
            {
                ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Recieving SMS SOAP :" + ee.Message.ToString();
            }

            if (lastRowID > 0) { ((Form1)Application.OpenForms["Form1"]).LastRowIndex = lastRowID; }
            
            if (str != "")
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable("sms");
                dataTable.Columns.Add("rowID", typeof(string));
                dataTable.Columns.Add("origAddr", typeof(string));
                dataTable.Columns.Add("destAddr", typeof(string));
                dataTable.Columns.Add("time", typeof(string));
                dataTable.Columns.Add("message", typeof(string));
                dataSet.Tables.Add(dataTable);
                try
                {

                    System.IO.StringReader xmlSR = new System.IO.StringReader(str);
                    dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);

                }
                catch (Exception ee)
                {

                    ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Parsing SMS XML :" + ee.Message.ToString();

                }
                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {




                            new tbl_sms_recievedTableAdapter().Insert(
                                dr["message"].ToString(),
                                dr["origAddr"].ToString(),
                                " ",
                                Convert.ToInt32(dr["rowID"].ToString()), Convert.ToDateTime(dr["time"].ToString()));


                        }
                        catch (Exception ee)
                        {
                            ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Updating SMS Position in DB :" + ee.Message.ToString();
                        }
                    }
                }
            }*/
        }
    };
    public class InternetConnectionChecker
    {
        public void CheckIt()
        {
            try
            {

                System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry("www.google.com");

                ((Form1)Application.OpenForms["Form1"]).Label2Caption = "Connect";
                

            }
            catch (Exception ee)
            {
                ((Form1)Application.OpenForms["Form1"]).Label2Caption = "Disconnected";
                ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Connecting to Internet :" + ee.Message.ToString();
            }
        }
    };
    public class SMSConnectionChecker
    {
        public void CheckIt()
        {
            try
            {

                System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry("www.sms1000.ir");

                ((Form1)Application.OpenForms["Form1"]).Label3Caption = "Connect";

            }
            catch (Exception ee)
            {
                ((Form1)Application.OpenForms["Form1"]).Label3Caption = "Disconnected";
                ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in Connecting to SMS Server :" + ee.Message.ToString();
            }
        }
    };



    public class SendSMS
    {
        public void SendIt()
        {
            if (((Form1)Application.OpenForms["Form1"]).IsSendingProcessBusy == false)
            {
               
                ((Form1)Application.OpenForms["Form1"]).IsSendingProcessBusy = true;
                 string updatesql="";
                //MainDataModuleTableAdapters.tbl_sms_sendTableAdapter unsendsmstbl = new tbl_sms_sendTableAdapter();
                try
                {
                    DataTable dt = new tbl_sms_sendTableAdapter().GetDataByPosition(0);




                    updatesql = "";
                    string res = "";
                    //NiazPardaz.SendSoap ss = new NiazPardaz.SendSoap();

                    niazpardaz.Send ss = new GhasedakWinService.niazpardaz.Send();


                    foreach (DataRow dr in dt.Rows)
                    {

                        


                        



                        

                        ss.SendSimpleSMS2(
                            dr["s_username"].ToString(),
                            dr["s_password"].ToString(),
                            dr["s_cell_no"].ToString(),
                            dr["s_smsCenterNo"].ToString(),
                            dr["s_body"].ToString(),
                            true);
                        
                        /*

                        res = ss.doSendSMS(
                            dr["s_username"].ToString(),
                            dr["s_password"].ToString(),
                            dr["s_smsCenterNo"].ToString(),
                            dr["s_cell_no"].ToString(),
                            dr["s_body"].ToString(),
                            true);*/

                        Int64 _res = 0;
                        try
                        {
                            _res = Convert.ToInt64(res);
                        }
                        catch
                        {
                            _res = -1;

                        }
                        //if (_res != -1)
                        {
                            Int64 gid = -1;
                            try
                            {
                                if (dr["s_group_link"] != null) { gid = Convert.ToInt64(dr["s_group_link"].ToString()); }
                            }
                            catch
                            {
                                gid = -1;
                            }

                            updatesql = updatesql + " update tbl_sms_send set s_position=1,s_send_id=" + _res + "  where s_id=" + dr["s_id"].ToString() + "; update tbl_sms_send_groups set sg_position=1 where sg_id=" + gid.ToString();
                        }

                    }



                }
                catch (Exception __e)
                {
                    ((Form1)Application.OpenForms["Form1"]).NewLog = "Error in creating SoapClient " + __e.Message;
                }

                if (updatesql != "")
                {
                    System.Data.SqlClient.SqlConnection sqlc = new System.Data.SqlClient.SqlConnection(((Form1)Application.OpenForms["Form1"]).strConnectionString);
                    sqlc.Open();
                    System.Data.SqlClient.SqlCommand sqlcm = new System.Data.SqlClient.SqlCommand(updatesql, sqlc);
                    sqlcm.ExecuteNonQuery();
                    sqlc.Close();
                }
                ((Form1)Application.OpenForms["Form1"]).IsSendingProcessBusy = false;
            }
        }

    }        
    public class Encrypting
        {


            public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                // Convert strings into byte arrays.
                // Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                // encoding.
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our plaintext into a byte array.
                // Let us assume that plaintext contains UTF8-encoded characters.
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                // First, we must create a password, from which the key will be derived.
                // This password will be generated from the specified passphrase and 
                // salt value. The password will be created using the specified hash 
                // algorithm. Password creation can be done in several iterations.
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream();

                // Define cryptographic stream (always use Write mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);
                // Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                // Finish encrypting.
                cryptoStream.FlushFinalBlock();

                // Convert our encrypted data from a memory stream into a byte array.
                byte[] cipherTextBytes = memoryStream.ToArray();

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert encrypted data into a base64-encoded string.
                string cipherText = Convert.ToBase64String(cipherTextBytes);

                // Return encrypted string.
                return cipherText;
            }
            public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a byte array.
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                // Define cryptographic stream (always use Read mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                // Start decrypting.
                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert decrypted data into a string. 
                // Let us assume that the original plaintext string was UTF8-encoded.
                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);

                // Return decrypted string.   
                return plainText;
            }
            public string Encode(string str)
            {
                string plainText = str;    // original plaintext

                string passPhrase = "bahmanymb@gmail.com";        // can be any string
                string saltValue = "mohammad_mrb@yahoo.com";        // can be any string
                string hashAlgorithm = "SHA1";             // can be "MD5"
                int passwordIterations = 2;                  // can be any number
                string initVector = "@1B2ceD4e5F6g7H8"; // must be 16 bytes
                int keySize = 128;                // can be 192 or 128
                return Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);


            }
            public string Decode(string str)
            {
                string plainText = str;    // original plaintext

                string passPhrase = "bahmanymb@gmail.com";        // can be any string
                string saltValue = "mohammad_mrb@yahoo.com";        // can be any string
                string hashAlgorithm = "SHA1";             // can be "MD5"
                int passwordIterations = 2;                  // can be any number
                string initVector = "@1B2ceD4e5F6g7H8"; // must be 16 bytes
                int keySize = 128;                // can be 192 or 128
                return Decrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);


            }


        }
}

