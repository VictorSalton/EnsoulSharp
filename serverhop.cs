using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OctaneEngine;
using OctaneEngineCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace BoxDownloader
{
    public partial class Downloader : Form
    {
        private string _file;
        private MainWindow mainWindow;
        public Downloader(string file, MainWindow mainWindow)
        {
            InitializeComponent();
            _file = file;
            this.mainWindow = mainWindow;
            if (_file.Contains("abbj"))
            {
                System.IO.File.Move(_file, _file.Replace("abbj", "json"));
                _file = _file.Replace("abbj", "json");
            }
        }

        private void Downloader_Load(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(System.IO.File.ReadAllText(_file));


            foreach (var favorite in data["favorites"])
            {
                if (!fileIsAnimated(favorite["tags"]) && (string)favorite["sample"]["ext"] != "mp4")
                {
                    total_size++;

                    if (mainWindow.comboBox1.SelectedIndex == 0 || mainWindow.comboBox1.SelectedIndex == 2)
                        image_list.Add(favorite);
                }
                else
                {
                    if (mainWindow.comboBox1.SelectedIndex == 1 || mainWindow.comboBox1.SelectedIndex == 2)
                        animated_list.Add(favorite);
                }
            }

            mainWindow.download_count.Text = "Download: " + total_download + "/" + total_size;


            progressBar1.Maximum = total_size;
            progressBar1.Value = 0;

            StartDownload();
        }

        #region Check File Exist
        private bool fileAlreadyDownloaded(string name)
        {
            string local = AppDomain.CurrentDomain.BaseDirectory;

            List<String> MyFiles = Directory
                   .GetFiles(local, "*.*", SearchOption.AllDirectories).ToList();


            foreach (string file in MyFiles)
            {
                if (file.Contains(name))
                {
                    long length = new System.IO.FileInfo(file).Length;
                    if(length != 0) return true;
                }
            }
            return false;
        }




        private bool fileIsAnimated(JToken tags)
        {
            if (tags.Contains("animated") || tags.Contains("video") || tags.Contains("sound") || tags.Contains("webm")) return true;
            else return false;
        }
        #endregion

        #region Vars
        private int total_size = 0;
        private int total_download = 0;
        List<JToken> image_list = new List<JToken>();
        List<JToken> animated_list = new List<JToken>();
        #endregion

        #region Invoker Functions
        private void modifyLabel(Label label, string text)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                label.Text = text;
            });
        }


        private void increaseProgress(System.Windows.Forms.ProgressBar p)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                p.Value++;
            });
        }
        #endregion

        #region Downloads
        private async Task DownloadFile(JToken file, bool animated = false)
        {
            var nome = file["md5"] + "." + (string)file["sample"]["ext"];
            if (fileAlreadyDownloaded(nome))
            {
                total_size--;
                modifyLabel(mainWindow.download_count, "Download: " + total_download + "/" + total_size);
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    
                    modifyLabel(mainWindow.actual_file, "File: " + nome);

                    string local = AppDomain.CurrentDomain.BaseDirectory;

                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted(nome));



                    if (!animated)
                    {
                        modifyLabel(mainWindow.downloadMode, "Mode: Image");
                        try
                        {
                            await client.DownloadFileTaskAsync(new Uri((string)file["sample"]["url"]), local + @"\imgs\" + nome);
                        }
                        catch { }
                        
                        
                    }
                    else {
                        modifyLabel(mainWindow.downloadMode, "Mode: Animated");
                        try
                        {
                            await client.DownloadFileTaskAsync(new Uri((string)file["file"]["url"]), local + @"\animated\" + nome);
                        }
                        catch { }
                    }
                    
                }
            }
        }

        public async Task DownloadImg(JToken item, bool animated = false)
        {
            try
            {
                string url = (string)item["file"]["url"];
                string local = AppDomain.CurrentDomain.BaseDirectory;
                string filename = "";

                if (!animated) filename = local + @"\imgs\" + item["md5"] + "." + (string)item["sample"]["ext"];
                else filename = local + @"\animated\" + item["md5"] + "." + (string)item["sample"]["ext"];

                using (var sr = new StreamReader(HttpWebRequest.Create(url)
                   .GetResponse().GetResponseStream()))
                using (var sw = new StreamWriter(filename))
                {
                    sw.Write(sr.ReadToEnd());
                }

                DownloadFileCompleted((string)item["sample"]["ext"]);
            }
            catch { }
        }



        private AsyncCompletedEventHandler DownloadFileCompleted(string nome)
        {
            total_download++;

            increaseProgress(progressBar1);
            modifyLabel(mainWindow.download_count, "Download: " + total_download + "/" + total_size);


            Action<object, AsyncCompletedEventArgs> action = (sender, e) => {
                if (mainWindow.showLast)
                {
                    string local = AppDomain.CurrentDomain.BaseDirectory;
                    var _filename = nome;
                    string img = local + @"\imgs\" + _filename;

                    try { pictureBox1.Image = Image.FromFile(img); }
                    catch { modifyLabel(imgName, "Load fail"); }
                }
            };

            return new AsyncCompletedEventHandler(action);
        }




        #endregion




        private async void StartDownload()
        {

            //Parallel.ForEach(image_list, new ParallelOptions { MaxDegreeOfParallelism = 10 }, s =>
            //{
            //    DownloadImg(s);
            //});

            if (mainWindow.fastDownload.Checked)
            {
                foreach (var img in image_list)
                {
                    await Task.Run(async () => await octaneDownload(img));
                }
            }
            else
            {
                foreach (var img in image_list)
                {
                    await Task.Run(async () => await DownloadFile(img));

                }
                total_size = 0;
                foreach (var a in animated_list)
                {
                    total_size++;
                }

                progressBar1.Maximum = total_size;
                progressBar1.Value = 0;
                foreach (var animated in animated_list)
                {
                    await Task.Run(async () => await DownloadFile(animated, true));
                }
            }
        }








        #region High performance download
        Engine octaneEngine = new Engine();

        private async Task octaneDownload(JToken file)
        {
            try
            {
                string url = (string)file["file"]["url"];
                string local = AppDomain.CurrentDomain.BaseDirectory;
                string saida = local + @"\imgs\" + file["md5"] + "." + (string)file["sample"]["ext"];



                var optimalNumberOfParts = Engine.GetOptimalNumberOfParts(url).Result;
                octaneEngine.DownloadFile(url, saida);
                DownloadFileCompleted(saida);
            }
            catch { }
        }


        #endregion
    }



}
