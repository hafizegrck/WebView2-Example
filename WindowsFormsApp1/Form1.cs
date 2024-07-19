using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Web.WebView2.Core;
using System.Drawing;
using System.Windows.Controls;
using System.Security.Policy;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Ana forma klavye olaylarını yönlendirme
            this.KeyDown += button1_KeyDown;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            txt_ara.Visible = false;
            btn_ara.Visible = false;
            //treeview yapısı
            await InitializeWebView2Async();
            treeView1.Nodes.Add("SOSYAL MEDYA");
            treeView1.Nodes[0].Nodes.Add("Instagram").Tag=1;
            treeView1.Nodes[0].Nodes.Add("X").Tag=2;
            
            treeView1.Nodes[0].Nodes.Add("Facebook").Tag=3;
            treeView1.Nodes.Add("TARAYICI");
            treeView1.Nodes[1].Nodes.Add("Google").Tag=4;
            treeView1.Nodes[1].Nodes.Add("Yandex").Tag=5;
            treeView1.Nodes[1].Nodes.Add("Yahoo").Tag=6;
            treeView1.Nodes[1].Nodes.Add("Wikipedia").Tag = 7;
            treeView1.Nodes.Add("VİDEO");
            treeView1.Nodes[2].Nodes.Add("Yotube").Tag=8;
            treeView1.Nodes.Add("ALIŞVERİŞ");
            treeView1.Nodes[3].Nodes.Add("Trendyol").Tag=9;
            treeView1.Nodes[3].Nodes.Add("HepsiBurada").Tag=10;
            treeView1.Nodes[3].Nodes.Add("Amazon").Tag=11;
            treeView1.Nodes.Add("MÜZİK");
            treeView1.Nodes[4].Nodes.Add("Spotiyf").Tag=12;
        }

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    //subnode link verme islemi
        //    switch (e.Node.Text)
        //    {
        //        case "Instagram":
        //            webView2.CoreWebView2.Navigate("https://www.instagram.com/");
        //            break;
        //        case "X":
        //            webView2.CoreWebView2.Navigate("https://www.twitter.com/");
        //            break;
        //        case "Facebook":
        //            webView2.CoreWebView2.Navigate("https://www.facebook.com/");
        //            break;
        //        case "Google":
        //            webView2.CoreWebView2.Navigate("https://www.google.com.tr/");
        //            break;
        //        case "Yandex":
        //            webView2.CoreWebView2.Navigate("https://www.yandex.com.tr/");
        //            break;
        //        case "Yahoo":
        //            webView2.CoreWebView2.Navigate("https://www.yahoo.com.tr/");
        //            break;
        //        case "Yotube":
        //            webView2.CoreWebView2.Navigate("https://www.youtube.com/");
        //            break;
        //        case "Amazon":
        //            webView2.CoreWebView2.Navigate("https://www.amazon.com.tr/");
        //            break;
        //        case "Trendyol":
        //            webView2.CoreWebView2.Navigate("https://www.trendyol.com.tr/");
        //            break;
        //        case "HepsiBurada":
        //            webView2.CoreWebView2.Navigate("https://www.hepsiburada.com.tr/");
        //            break;
        //        case "Spotiyf":
        //            webView2.CoreWebView2.Navigate("https://open.spotify.com/");
        //            break;
        //        default:

        //            break;
        //    }


        //}
       
        private void Website(object Tag)
        {
            string url = "";

            switch (Tag)
            {
                case 1:
                    url = "https://www.instagram.com/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 2:
                    url = "https://www.twitter.com/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 3:
                    url = "https://www.facebook.com/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 4:
                    url = "https://www.google.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 5:
                    url = "https://www.yandex.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 6:
                    url = "https://www.yahoo.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 7:
                    url = "https://www.wikipedia.org/";
                    txt_ara.Visible = true;
                    btn_ara.Visible = true;

                    
                        break;

                    
                case 8:
                    url = "https://www.youtube.com/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false; 
                case 9:
                    url = "https://www.amazon.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 10:
                    url = "https://www.trendyol.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                case 11:
                    url = "https://www.hepsiburada.com.tr/";
                    break;
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;
                    

                case 12:
                    url = "https://open.spotify.com/";
                    break;
                default:
                    txt_ara.Visible = false;
                    btn_ara.Visible = false;

                    return;
                    
            }
            webView2.CoreWebView2.Navigate(url);
        }

      
        private async void btn_ara_MouseClick(object sender, MouseEventArgs e)
        {
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
              
                string searchText = txt_ara.Text;
                string script1 = $"document.getElementById('searchInput').value = '{searchText}';";

               
                string script2 = "document.querySelector('.pure-button-primary-progressive').click();";

                
                await webView2.CoreWebView2.ExecuteScriptAsync(script1);

               
                await webView2.CoreWebView2.ExecuteScriptAsync(script2);
            }
        }
     
       
        private async Task InitializeWebView2Async()
        {
            await webView2.EnsureCoreWebView2Async(null);
            webView2.CoreWebView2.NavigationCompleted += webView2_NavigationCompleted;
            webView2.MouseMove += webView2_MouseMove;
        }

        private void button1_Click(object sender, EventArgs e)
        {//git yerine url girmeek icin
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                string searchText = textBox1.Text;
                if (!searchText.StartsWith("http://") && !searchText.StartsWith("https://"))
                {
                    searchText = "https://www.google.com/search?q=" + Uri.EscapeDataString(searchText);
                }
                webView2.CoreWebView2.Navigate(searchText);
                textBox1.Text = "";
            }
        }



        private async void button2_Click(object sender, EventArgs e)
        {//geri gitme ve buton rengini 1 saniye gri yapma
            if (webView2 != null && webView2.CoreWebView2 != null)
            {

                webView2.CoreWebView2.GoBack();


                button2.BackColor = Color.DarkGray;


                await Task.Delay(1000);


                button2.BackColor = SystemColors.Control;
            }
        }






        private async void button3_Click(object sender, EventArgs e)
        {//ileri islemi
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                webView2.CoreWebView2.GoForward();

                button3.BackColor = Color.DarkGray;

                await Task.Delay(1000);

                button3.BackColor = SystemColors.Control;
            }
        }


        private async void button4_Click(object sender, EventArgs e)
        {//yenileme islemi
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                webView2.CoreWebView2.Reload();
                button4.BackColor = Color.DarkGray;

                await Task.Delay(1000); 

                button4.BackColor = SystemColors.Control;
            }
        }


        private async void button5_Click(object sender, EventArgs e)
        {
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                webView2.CoreWebView2.Navigate("https://www.google.com.tr/");

                await Task.Delay(1000);

                button5.BackColor = SystemColors.Control;
            }
            txt_ara.Visible = false;
            btn_ara.Visible = false;
        }


        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private async void webView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                string script = @"
                    document.querySelectorAll('a').forEach(function(link) {
                        link.addEventListener('mouseover', function() {
                            if (link.getAttribute('href') === '/Home/Athena/Corporate') {
                                link.click();
                            }s
                        });
                    });
                ";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
        }

        private async void webView2_MouseMove(object sender, MouseEventArgs e)
        {
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                string script = @"
                    var aboutLink = document.querySelector('a[href=""/Home/Athena/Corporate""]');
                    if (aboutLink) {
                        aboutLink.click();
                    }
                ";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);
            }
        }

       

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            Website(e.Node.Tag);
        }
    }
}
