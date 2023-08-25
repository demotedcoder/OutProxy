using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace OutProxy__Scraper_
{
    public partial class Form1 : Form
    {
        

        int MouseinX = 0, MouseinY = 0;
        int MouseX = 0, MouseY = 0;
        bool mouseDown;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                MouseX = MousePosition.X - MouseinX;
                MouseY = MousePosition.Y - MouseinY;

                this.SetDesktopLocation(MouseX, MouseY);
            }
        }

        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            if (CheckBox1.Checked)
            {
                Directory.CreateDirectory("Scraped Proxies");
                string contents = new WebClient().DownloadString("https://api.proxyscrape.com?request=displayproxies&proxytype=http&ssl=no");
                Console.WriteLine(contents);
                System.IO.File.WriteAllText("Scraped Proxies\\HTTP Proxies.txt", contents);
                MessageBox.Show("Done! ");
                Console.ReadLine();
            }
            if(CheckBox2.Checked)
            {
                Directory.CreateDirectory("Scraped Proxies");
                string contents = new WebClient().DownloadString("https://api.proxyscrape.com?request=displayproxies&proxytype=http&ssl=yes");
                Console.WriteLine(contents);
                System.IO.File.WriteAllText("Scraped Proxies\\HTTP (SSL) Proxies.txt", contents);
                MessageBox.Show("Done! ");
                Console.ReadLine();
            }
            if (CheckBox3.Checked)
            {
                Directory.CreateDirectory("Scraped Proxies");
                string contents = new WebClient().DownloadString("https://api.proxyscrape.com?request=displayproxies&proxytype=socks4");
                Console.WriteLine(contents);
                System.IO.File.WriteAllText("Scraped Proxies\\Socks 4 Proxies.txt", contents);
                MessageBox.Show("Done! ");
                Console.ReadLine();
            }
            if(CheckBox4.Checked)
            {
                Directory.CreateDirectory("Scraped Proxies");
                string contents = new WebClient().DownloadString("https://api.proxyscrape.com?request=displayproxies&proxytype=socks5");
                Console.WriteLine(contents);
                System.IO.File.WriteAllText("Scraped Proxies\\Socks 5 Proxies.txt", contents);
                MessageBox.Show("Done! ");
                Console.ReadLine();

            }

            else if(!CheckBox4.Checked && !CheckBox3.Checked && !CheckBox2.Checked && !CheckBox1.Checked)
            {
                MessageBox.Show("Error");
                
            }
           

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            MouseinX = MousePosition.X - Bounds.X;
            MouseinY = MousePosition.Y - Bounds.Y;

        }
    }
}
