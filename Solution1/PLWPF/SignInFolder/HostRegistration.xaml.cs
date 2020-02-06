using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostRegistraion.xaml
    /// </summary>
    public partial class HostRegistraion : Window
    {
        String hostPath = "@HostXml.xml";
        XElement guestRoot = new XElement("guestsInfo");
        XElement hostRoot = new XElement("hostsInfo");
        BE.BankBranch banky = new BE.BankBranch();
        IBL bl;
        BackgroundWorker bg = new BackgroundWorker();
        HttpWebRequest httpRequest;
        bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public HostRegistraion()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            LoadData();
            comboBoxBanks.ItemsSource = null;
            bg.DoWork += Bg_DoWork;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.WorkerReportsProgress = true;
            bl = FactoryBL.getIBL();
        }
        private void hebChange()
        {
            Title = "רישוםכאורח";
            txtUsername.Text = "שם משתמש";
            textBlockPassword.Text = "סיסמה";
            textBlockConfirmPwd.Text = "אימות סיסמה";
            mail.Content = "מייל";
            coll.Content = "אישור גבייה";
            pname.Content = "שם פרטי";
            fname.Content = "שם משפחה";
            phone.Content = "מספר מפלאפון";
            bak.Content = "מספר חשבון בנק";
            Submit.Content = "הירשם";
            button2.Content = "מחק"; 
            button3.Content = "בטל";
            login.Content = "כניסה";
            populateBanksBtn.Content = "מלאבנקים";
        }
        private void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }
        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dt = e.Result as DataTable;
            DataView dv = dt.DefaultView;
            this.banksDatagrid.DataContext = dv;
            var banknames = dv.ToTable(true, "Bank_Name").AsEnumerable();

            comboBoxBanks.ItemsSource = banknames.Select(dr => dr["Bank_Name"].ToString().Trim()).Distinct();
        }
        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            bg.ReportProgress(10);
            // Construct HTTP request to get the file
            string uriString = (String)e.Argument;
            httpRequest = (HttpWebRequest)WebRequest.Create(uriString);
            httpRequest.Method = WebRequestMethods.Http.Get;
            bg.ReportProgress(30);
            // Get back the HTTP response for web server
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream httpResponseStream = httpResponse.GetResponseStream();
            bg.ReportProgress(40);
            // Construct the Datset and read the data from the stream
            DataSet ds = new DataSet();
            ds.ReadXml(httpResponseStream);
            bg.ReportProgress(90);
            DataTable dt = ds.Tables[0];
            e.Result = dt;
            bg.ReportProgress(100);
        }
        private void populateBanksBtn_Click(object sender, RoutedEventArgs e)
        {
            bg.RunWorkerAsync(@"https://www.boi.org.il/en/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_en.xml");
        }
        private void comboBoxBanks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxBanks.ItemsSource != null)
            {
                string str = comboBoxBanks.SelectedItem as String;

                foreach (DataRowView drv in (DataView)banksDatagrid.ItemsSource)
                {
                    if (drv["Bank_Name"].ToString() == str)
                    {
                        // This is the data row view record you want...
                        banksDatagrid.SelectedItem = drv;
                        banksDatagrid.ScrollIntoView(drv);
                        break;
                    }
                }
            }
        }
        public void saveHost()
        {
            BE.Host host = new BE.Host();
            host.PrivateName1 = privateName1TextBox.Text;
            host.FamilyName1 = familyName1TextBox.Text;
            host.MailAddress1 = mailAddress1TextBox.Text;
            host.PhoneNumber1 = phoneNumber1TextBox.Text;
            host.BankAccountNumber1 = int.Parse(bankAccountNumber1TextBox.Text);
            host.CollectionClearance1 = bool.Parse(collectionClearance1CheckBox.IsChecked.ToString());
            host.BankBranchDetails1 = banky;
            XElement username = new XElement("username", textBoxUserName.Text);
            XElement password = new XElement("password", passwordBox1.Password);
            bl.AddHost(host, textBoxUserName.Text, passwordBox1.Password);
            MessageBox.Show("added to the system, Host Key: " + host.HostKey1);
            SignInPage login = new SignInPage();
            login.Show();
            Close();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int int1;
            if (textBoxUserName.Text.Length == 0)
            {
                MessageBox.Show("Enter a username.");
                textBoxUserName.Focus();
            }
            else if (passwordBox1.Password.Length == 0)
            {
                MessageBox.Show("Enter a password.");
                passwordBox1.Focus();
            }

            else if (passwordBoxConfirm.Password.Length == 0)
            {
                MessageBox.Show("confirm your password.");
                passwordBoxConfirm.Focus();
            }
            else if (privateName1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your private name.");
                privateName1TextBox.Focus();
            }
            else if (familyName1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your family name.");
                familyName1TextBox.Focus();
            }
            else if (phoneNumber1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your phone number.");
                phoneNumber1TextBox.Focus();
            }
            else if (bankAccountNumber1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your bank account number.");
                bankAccountNumber1TextBox.Focus();
            }
            else if (!(int.TryParse(bankAccountNumber1TextBox.Text, out int1)))
            {
                MessageBox.Show("bank account number has to ba a number.");
                bankAccountNumber1TextBox.Clear();
                bankAccountNumber1TextBox.Focus();
            }
            else if (!(IsValidEmail(mailAddress1TextBox.Text)) || mailAddress1TextBox.Text == "")
            {
                MessageBox.Show("Enter a valid email address");
                mailAddress1TextBox.Clear();
                mailAddress1TextBox.Focus();
            }
            else if (!(IsPhoneNumber(phoneNumber1TextBox.Text, "000-000-0000") || IsPhoneNumber(phoneNumber1TextBox.Text, "(000) 000-0000")))////////////////////////////////////////////////////////////////////////////////
            {
                MessageBox.Show("phone number has to ba a valid phone number.");
                phoneNumber1TextBox.Clear();
                phoneNumber1TextBox.Focus();
            }
            else
            {
                if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    MessageBox.Show("password do not match.");
                    passwordBoxConfirm.Clear();
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    if (checkInputGuest() || checkInputHost())
                    {
                        MessageBox.Show("user already exists, try again");
                    }
                    else
                    {
                        saveHost();

                    }
                }

            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SignInPage login = new SignInPage();
            login.Show();
            Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            privateName1TextBox.Text = "";
            textBoxUserName.Text = "";
            familyName1TextBox.Text = "";
            mailAddress1TextBox.Text = "";
            phoneNumber1TextBox.Text = "";
            bankAccountNumber1TextBox.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool checkInputGuest()
        {
            var v = from use in guestRoot.Elements()
                    where use.Element("username").Value == textBoxUserName.Text
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
        private bool checkInputHost()
        {
            var v = from use in hostRoot.Elements()
                    where use.Element("username").Value == textBoxUserName.Text
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
        private void LoadData()
        {
            try
            {
                guestRoot = XElement.Load("@GuestXml.xml");
                hostRoot = XElement.Load("@HostXml.xml");
            }
            catch
            {

                throw new Exception("File upload problem");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }
        bool IsPhoneNumber(string input, string pattern)
        {
            if (input.Length != pattern.Length) return false;

            for (int i = 0; i < input.Length; ++i)
            {
                bool ith_character_ok;
                if (Char.IsDigit(pattern, i))
                    ith_character_ok = Char.IsDigit(input, i);
                else
                    ith_character_ok = (input[i] == pattern[i]);

                if (!ith_character_ok) return false;
            }
            return true;
        }
        private void getBankDetails(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = banksDatagrid.SelectedItem as DataRowView;
            banky.BankName1 = rowView["Bank_Name"].ToString();
            banky.BranchCity1 = rowView["City"].ToString();
            banky.BranchNumbner1 = int.Parse(rowView["Branch_Code"].ToString());
            banky.BranchAddress1=rowView["Address"].ToString();
        }
    }
}