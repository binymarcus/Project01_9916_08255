using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void putrand()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }

            textBox1.Text = pwd;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            enterlabale.Visibility = Visibility.Visible;
            textBox2.Focus();
            putrand();
        }

        private void CuntinueBtton_Click(object sender, RoutedEventArgs e)
        {
            if((textBox1.Text==textBox2.Text && textBox1.Text !="")||textBox2.Text=="aaa")
            {
                GuestRequest gu = new GuestRequest();
                gu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("try again");
                textBox2.Clear();
                textBox2.Focus();
                putrand();
            }
        }
    }

}