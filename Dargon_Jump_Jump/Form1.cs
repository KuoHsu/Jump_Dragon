using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Dargon_Jump_Jump
{
    public partial class MainForm : Form
    {
        Game G;

        bool flag = false;
        int color_n = 240;
        int color_change = -12;
        int change_t = 15;
        Timer Change_timer = new Timer();
        List<Bitmap> Obstacles_image = new List<Bitmap>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Change_timer.Tick += change_tick;
            Change_timer.Interval = 50;
            
            Dragon_image dragon_images = new Dragon_image();
            dragon_images.Normal = (Bitmap)Image.FromFile(Application.StartupPath + @"/image/people.png");
            dragon_images.Jump = (Bitmap)Image.FromFile(Application.StartupPath + @"/image/people_jump.png");

            List<Bitmap> obs = new List<Bitmap>();
            for(int i = 1; i <= 4; i++)obs.Add((Bitmap)Image.FromFile(Application.StartupPath + @"/image/obstacle_"+ i.ToString()+".png"));

            G = new Game(this, new Point(10, 50), dragon_images, obs, 60);

            G.Background_image.Image = (Bitmap)Image.FromFile(Application.StartupPath + @"/image/Land.png");

            G.ScoreStandar = 1000;
            G.DragonDie += DragonDie;
            G.GameStatusUpdate += score_update;
            G.ScoreArriveStandar += Faster;


        }

  

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up){
                G.DragonJump();
            }else if(e.KeyCode == Keys.Down){
                G.DragonDown();
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            G.DragonOrigin();
        }

        private void DragonDie()
        {
            DiedLabel.Visible = true;
            DiedLabel.BringToFront();
            Restart.Visible = true;
            Restart.BringToFront();
        }

        private void score_update(int score)
        {
            Score_label.Text = score.ToString();
        }

     

 



        private void Reset()
        {
            DiedLabel.Visible = false;
            ScoreText.ForeColor = Color.Black;
            Score_label.ForeColor = Color.Black;
            color_n = 240;
            change_t = 15;
            color_change = -12;
            BackColor = Color.FromArgb(color_n, color_n, color_n);
            flag = false;
        }

        private void Faster()
        {
            G.VelocityFaster(3);
            if (flag){
                ScoreText.ForeColor = Color.Black;
                Score_label.ForeColor = Color.Black;
                flag = false;
            }
            else
            {
                ScoreText.ForeColor = Color.White;
                Score_label.ForeColor = Color.White;
                flag = true;
            }
            Change_timer.Start();
        }


        private void change_tick(object o,EventArgs e)
        {
            color_n += color_change;
            BackColor = Color.FromArgb(color_n, color_n, color_n);
            change_t--;
            if(change_t == 0)
            {
                Change_timer.Stop();
                change_t = 15;
                color_change *= -1;
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Reset();
            G.Start();
            Restart.Visible = false;
        }

        private void PauseGame_Click(object sender, EventArgs e)
        {
            G.Pause();
        }

        private void ProceedGame_Click(object sender, EventArgs e)
        {
            G.Proceed();
        }

        private void StopGame_Click(object sender, EventArgs e)
        {
            G.Stop();
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            G.Start();
            Start_button.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //File.Create(Application.StartupPath + @"/test.txt");
           
            using (FileStream fs = new FileStream("test.txt", FileMode.Open, FileAccess.Write))
            {

                BinaryFormatter bf = new BinaryFormatter();
                Test t = new Test("87", 87);
                bf.Serialize(fs,t);

                fs.Close();

                StringBuilder sb = new StringBuilder();

                foreach(Byte a in File.ReadAllBytes("test.txt"))
                {
                    sb.Append(a + " ");
                }
                


                StreamWriter sw = new StreamWriter("out_test.txt");
                sw.Write(sb);
                sw.Flush();
                sw.Close();


            }

            Process.Start("out_test.txt");
        }
    }
}
