using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemesananTiketBioskop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Panel container = new Panel();
        //Panel seatPanel = new Panel();
        Panel seatPanel = new Panel();
        public int baris = 0;
        public int count = 0;
        int lokasiY = 30;
        bool sekaliEksekusi = false;

      
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a panel to act as the container for the cards
            
            container.BackColor = Color.White;
            container.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            container.Size = new Size(770, 600);
            container.Location = new Point(this.ClientSize.Width - container.Width - 10, 50);
            container.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(container);

            seatPanel.BackColor = Color.White;
            seatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            seatPanel.Size = new Size(770, 600);
            seatPanel.Location = new Point(this.ClientSize.Width - container.Width - 10, 50);
            seatPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(seatPanel);
            seatPanel.Visible = false;

        }
        private void AddVerticalScrollToPanel(Panel panel)
        {
            // create scrollbar panel
            Panel scrollBarPanel = new Panel();
            scrollBarPanel.Dock = DockStyle.Right;
            scrollBarPanel.Width = SystemInformation.VerticalScrollBarWidth;

            // create vertical scrollbar
            VScrollBar vScrollBar = new VScrollBar();
            vScrollBar.Dock = DockStyle.Fill;
            vScrollBar.Scroll += (sender, e) =>
            {
                panel.VerticalScroll.Value = vScrollBar.Value;
            };

            // add scrollbar to scrollbar panel
            scrollBarPanel.Controls.Add(vScrollBar);

            // enable auto scroll
            panel.AutoScroll = true;

            // set minimum size for auto scroll
            int contentHeight = 0;
            foreach (Control control in panel.Controls)
            {
                contentHeight += control.Height;
            }
            panel.AutoScrollMinSize = new Size(0, contentHeight);

            // add scrollbar panel to main panel
            panel.Controls.Add(scrollBarPanel);
            
        }

      
        private Panel CreateMovieCard(string imagePath, string movieTitle, string showTime, int lokasi)
        {
            // Create the card panel
            
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Size = new Size(180, 250);
            if(baris > 3)
            {
                lokasiY += 270;
                baris = 0;
                //MessageBox.Show("Masuk baris ke " + baris.ToString() + " lokasi y ke " + lokasiY.ToString());
            }
            card.Location = new Point(lokasi, lokasiY);

            // Create the picture box for the movie poster
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(imagePath);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(150, 150);
            pictureBox.Location = new Point(15, 15);
            card.Controls.Add(pictureBox);

            // Create the label for the movie title
            Label titleLabel = new Label();
            titleLabel.Text = movieTitle;
            titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            titleLabel.Size = new Size(150, 20);
            titleLabel.Location = new Point(15, pictureBox.Bottom + 10);
            card.Controls.Add(titleLabel);

            // Create the button for the show time
            Button showTimeButton = new Button();
            showTimeButton.Text = showTime;
            showTimeButton.Tag = movieTitle;
            showTimeButton.Size = new Size(150, 30);
            showTimeButton.Location = new Point(15, titleLabel.Bottom + 10);
            showTimeButton.Click += new EventHandler(showTimeButton_Click);
            card.Controls.Add(showTimeButton);

            return card;
        }

        Dictionary<string, Dictionary<string, List<string>>> bookedSeats = new Dictionary<string, Dictionary<string, List<string>>>();
        string tagValue;
        public string movieTitleee;
        public string showTimeee;
        ListBox listBox = new ListBox();
        Label LabelKursi = new Label();
        private void showTimeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            movieTitleee = button.Tag.ToString();
            showTimeee = button.Text;
           
            if (!bookedSeats.ContainsKey(movieTitleee))
            {
                bookedSeats[movieTitleee] = new Dictionary<string, List<string>>();
            }
            if (!bookedSeats[movieTitleee].ContainsKey(showTimeee))
            {
                bookedSeats[movieTitleee][showTimeee] = new List<string>();
                Random random = new Random();
                foreach (char c in "ABCDEFGHIJ")
                {
                    for (int i = 1; i <= 7; i++)
                    {
                        int halo = random.Next(1, 10);
                        string seatName = c + halo.ToString();
                        bookedSeats[movieTitleee][showTimeee].Add(seatName);
                    }
                }
            }

            seatPanel.Controls.Clear();

            if (button != null)
            {
                tagValue = button.Tag.ToString();
            }
        
            if (bookedSeats.ContainsKey(movieTitleee) && bookedSeats[movieTitleee].ContainsKey(showTimeee))
            {
                List<string> bookedSeatList = bookedSeats[movieTitleee][showTimeee];

                for (int m = 1; m <= 10; m++)
                {
                    char colChar = Convert.ToChar(m + 64);
                    for (int n = 1; n <= 10; n++)
                    {
                        Button seatButton = new Button();
                        seatButton.Text = $"{colChar}{n}"; // seat number, e.g. "A1", "A2", ..., "J9", "J10"
                        seatButton.Width = 40;
                        seatButton.Height = 40;
                        seatButton.BackColor = Color.Gray;
                        seatButton.Tag = movieTitleee + "-" + showTimeee;
                        seatButton.Top = 10 + 50 * (m - 1);
                        seatButton.Left = 10 + 50 * (n - 1);
                        // Mengecek apakah kursi sudah dipesan atau belum
                        if (bookedSeatList.Contains(seatButton.Text))
                        {
                           // MessageBox.Show("masuk ga");
                            foreach (string bookedSeat in bookedSeatList)
                            {
                                if(bookedSeat == seatButton.Text)
                                {
                                    seatButton.BackColor = Color.Red;
                                    seatButton.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            seatButton.BackColor = Color.Gray;
                            seatButton.Click += new EventHandler(Cek);
                        }
                        seatPanel.Controls.Add(seatButton);
                    }
                }
            }
            else
            {
                MessageBox.Show("masokkk else contain");
                for (int m = 1; m <= 10; m++)
                {
                    char colChar = Convert.ToChar(m + 64);
                    for (int n = 1; n <= 10; n++)
                    {
                        Button seatButton = new Button();
                        seatButton.Text = $"{colChar}{n}"; // seat number, e.g. "A1", "A2", ..., "J9", "J10"
                        seatButton.Width = 40;
                        seatButton.Height = 40;
                        seatButton.Tag = movieTitleee + "-" + showTimeee;
                         seatButton.BackColor = Color.Gray;
                        seatButton.Top = 10 + 50 * (m - 1);
                        seatButton.Left = 10 + 50 * (n - 1);
                        // Mengecek apakah kursi sudah dipesan atau belum
                        seatPanel.Controls.Add(seatButton);
                    }
                }
            }

           
            LabelKursi.Text = "Nomer Kursi";
            LabelKursi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            LabelKursi.Size = new Size(100, 30);
            LabelKursi.Location = new Point(580, 30);
            seatPanel.Controls.Add(LabelKursi);
            // Mengatur posisi dan ukuran TextBox
            listBox.Location = new Point(570, 70);
            // listBox.Height = 200;
            listBox.Size = new Size(150, 200);

            Button Booking = new Button();
            Booking.Text = "Booking";
            Booking.Size = new Size(70, 30);
            Booking.Location = new Point(570, 270);
            Booking.BackColor = Color.Gray;
            Booking.Click += new EventHandler(Bookingg);
            seatPanel.Controls.Add(Booking);

            Button resset = new Button();
            resset.Text = "Reset";
           // resset.Tag = movieTitleee;
            resset.Size = new Size(70, 30);
            resset.Location = new Point(650, 270);
            resset.BackColor = Color.Gray;
            resset.Click += new EventHandler(resset_Click);
            seatPanel.Controls.Add(resset);

            // Menambahkan TextBox ke dalam seatPanel
            seatPanel.Controls.Add(listBox);
            this.Controls.Add(seatPanel);
                container.Visible = false;
            seatPanel.Visible = true;
        }

        private void resset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus semua kursi yang telah dipesan?", "Konfirmasi Reset", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bookedSeats[movieTitleee][showTimeee].Clear();
                container.Visible = true;
                seatPanel.Visible = false;
            }
        }
       
        public string message;
        List<string> booking = new List<string>();
        private void Bookingg(object sender, EventArgs e)
        {
            string ucapan = "Anda Memesan Nomer Kursi: ";
            string halo = "";
            foreach(string nomer in booking)
            {
                halo += nomer + ", ";
            }
            halo = halo.TrimEnd(',', ' ');

            ucapan += halo;

            DialogResult result = MessageBox.Show(ucapan);

            if(result == DialogResult.OK)
            {
                container.Visible = true;
                seatPanel.Visible = false;
                listBox.Items.Clear();
            }
        }
        private void Cek(object sender, EventArgs e)
        {
            Button seatButton = sender as Button;

            
            if (seatButton.BackColor == Color.Gray)
            {
                seatButton.BackColor = Color.Green;
              
                string seat = seatButton.Text;
                LabelKursi.Text = seat;
              booking.Add(seat);
                listBox.Items.Add("nomer kursi : " + seat);
                bookedSeats[movieTitleee][showTimeee].Add(seat);
            }
            else
            {
                seatButton.BackColor = Color.Gray;
                string seat = seatButton.Text;
                booking.Remove(seat);
                listBox.Items.Remove("nomer kursi : " + seat);
                bookedSeats[movieTitleee][showTimeee].Remove(seat);
            }
            //Button clickedButton = (Button)sender;
            //string[] data = File.ReadAllLines(@"E:\Bahar Project C#\PemesananTiketBioskop\PemesananTiketBioskop\bin\Debug\datafilm.txt");
            //foreach(string lines in data)
            //{
            //    if (lines.Contains(tagValue))
            //    {
            //        string[] movieInfo = lines.Split(',');
            //        movieTitle = movieInfo[1];
            //        showTime = movieInfo[2];
            //    }
            //}

            //if (clickedButton.BackColor == Color.Gray) // seat is available
            //{
            //    clickedButton.BackColor = Color.Green;
            //    seatNumber = clickedButton.Text;
            //    string seatData = $"{seatNumber}, {movieTitle}, {showTime}";
            //    MessageBox.Show(seatData);
            //    bookedSeats.Add(seatData);
            //    listBox.Items.Add(seatData);

            //}
            //else if (clickedButton.BackColor == Color.Green) // seat is selected
            //{
            //    clickedButton.BackColor = Color.Red;
            //    clickedButton.Enabled = false; // disable button to prevent multiple bookings
            //    bookedSeats.Remove(seatNumber); // add seat number to list of booked seats
            //}
            //else // seat is already booked
            //{
            //    MessageBox.Show("This seat is already booked");
            //}
        }
       

        private void studioRegularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            container.Visible = true;
            seatPanel.Visible = false;
            this.Controls.Remove(seatPanel);
            container.ResumeLayout();
            LoadMoviesFromFile(@"E:\Bahar Project C#\PemesananTiketBioskop\PemesananTiketBioskop\bin\Debug\datafilm.txt");
            AddVerticalScrollToPanel(container);
        }

        Dictionary<string, Dictionary<string, Panel>> seatPanels = new Dictionary<string, Dictionary<string, Panel>>();
        private void LoadMoviesFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            
            string[] judulFilm = new string[8];
            string[] waktuTayang = new string[8];

            int h = 0;
            int j = 0;
            count = 0;

                foreach (string line in lines)
                {
                string[] movieInfo = line.Split(',');
                foreach(string movie in movieInfo)
                {
                    judulFilm[j] = movieInfo[1];
                    waktuTayang[j] = movieInfo[2];
                }
                j++;

                    string imagePath = movieInfo[h];
                    h++;
                    string movieTitle = movieInfo[h];
                   
                    h++;
                    string showTime = movieInfo[h];
                    h++;
                
                h = 0;
                if(baris > 3)
                {
                    count = 0;
                }
                    Panel card = CreateMovieCard(imagePath, movieTitle, showTime, (190*count)+10);
                count++;
                baris++;
                container.Controls.Add(card);
            }
            int k = 0;
        }
    }
}
