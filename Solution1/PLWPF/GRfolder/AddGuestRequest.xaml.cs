﻿using System;
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
using System.Globalization;
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddGuestrequest.xaml
    /// </summary>
    public partial class AddGuestRequest : Window
    {
        BE.GuestRequest guest;
        BL.IBL bl;
        public AddGuestRequest()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            guest = new BE.GuestRequest();
            this.GuestRequestDetailsGrid.DataContext = guest;
            bl = BL.FactoryBL.getIBL();
            
        }
        private void hebChange()
        {
            Title = "הוסףבקשתאירוח";
            header.Content = "הוסף בקשת אירוח חדשה";
            pname.Content = "שם פרטי";
            fname.Content = "שם משפחה";
            mail.Content = "אימייל";
            edate.Content = "תאריך כניסה";
            rdate.Content = "תאריך יציאה";
            adults.Content = "מבוגרים";
            children.Content = "ילדים";
            area.Content = "איזור מבוקש";
            sub.Content = "תת איזור";
            type.Content = "סוג";
            pool.Content = "בריכה";
            garden.Content = "גינה";
            jac.Content = "גקוזי";
            child.Content = "אטרקציות לילדים";
            addButton.Content = "הוסף";
            cancelButton.Content = "בטל";
            PrivateName1TextBox.Watermark = "נא להכניס שם פרטי";
            FamilyName1TextBox.Watermark = "נא להכניס שפ משפחה";
            mailAddress1TextBox.Watermark = "נא להכניס את האימייל";
            adults1TextBox.Watermark = "נא להכניס מספר מבוגרים ";
            children1TextBox.Watermark = "נא להכניס מספר ילדים";
            subArea1TextBox.Watermark = "נא להכניס תת איזור";



        }
        bool IsValidEmail(string email) // checks if email is valid
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
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int int1;
            int adultint;
            int.TryParse(adults1TextBox.Text, out adultint);
            int childrenint;
            int.TryParse(children1TextBox.Text, out childrenint);
            int error = 0;
            try
            {
                if (PrivateName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out private name");
                    error++;
                    PrivateName1TextBox.Clear();
                    PrivateName1TextBox.Focus();
                }
                else if (FamilyName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out family name");
                    error++;
                    FamilyName1TextBox.Clear();
                    FamilyName1TextBox.Focus();
                }
                else if ((adults1TextBox.Text != "") && (!(int.TryParse(adults1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                {
                    MessageBox.Show("num of adults has to be filled with a number");
                    error++;
                    adults1TextBox.Clear();
                    adults1TextBox.Focus();
                }

                else if ((children1TextBox.Text != "") && (!(int.TryParse(children1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                {
                    MessageBox.Show("num of children has to be filled with a number");
                    error++;
                    children1TextBox.Clear();
                    children1TextBox.Focus();
                }
                else if (adultint < 0)
                {
                    MessageBox.Show("num of adults has to be equel or larger then 0");
                    error++;
                    adults1TextBox.Clear();
                    adults1TextBox.Focus();
                }
                else if (childrenint < 0)
                {
                    MessageBox.Show("num of children has to be equel or larger then 0");
                    error++;
                    children1TextBox.Clear();
                    children1TextBox.Focus();
                }
                else if ((childrenint+adultint) <= 0)
                {
                    MessageBox.Show("num of guests must be be equel or larger then 1");
                    error++;
                    adults1TextBox.Clear();
                    children1TextBox.Clear();
                    adults1TextBox.Focus();
                }

                else if (!(IsValidEmail(mailAddress1TextBox.Text))|| mailAddress1TextBox.Text=="")
                {
                    MessageBox.Show("Enter a valid email address");
                    error++;
                    mailAddress1TextBox.Clear();
                    mailAddress1TextBox.Focus();
                }
                    if (error == 0)
                {
                    bl.AddGuestRequest(guest);
                    MessageBox.Show("Guest Request Added, Key:" + guest.GuestRequestKey1);
                    this.GuestRequestDetailsGrid.DataContext = guest;
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();

                    this.Close();
                }
            }

            catch (FormatException)
            {

                MessageBox.Show("Please check your input and try again");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_4(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_5(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_6(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window guestRequestWindow = new GuestRequest();
            guestRequestWindow.Show();
            this.Close();
        }

        private void numOfAdults_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void adults1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void privateName1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
