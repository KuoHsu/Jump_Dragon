using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Dargon_Jump_Jump
{
    public struct Dragon_image
    {
        public Bitmap Normal;
        public Bitmap Jump;
        public Bitmap Down;
    }





    public class Dragon:PictureBox
    {
        private Timer anime_move = new Timer();
        private Timer anime_jump = new Timer();
        private int[] anime_num = new int[] 
        { 55,30,20,10,5,0,-5,-10,-20,-30,-55 };
        private int anime_index = 0;
        private int y = 0;
        private int x = 0;
        private int w = 0;
        private int h = 0;

        private bool flag = false;
        private bool _jump_bool = false;
        private bool _down_bool = false;

        private int _fps = 30;

        private Dragon_image _dragon_image;


        public Object_Side Check_struct = new Object_Side();


        public Dragon(Point location,Size size, Dragon_image images,int fps = 30)
        {
            _fps = fps;
            anime_jump.Interval = Convert.ToInt32(1000/_fps);
            anime_jump.Tick += Jump_anime_hander_fun;
            BackColor = Color.Transparent;
            Location = location;

            _dragon_image = images;
            Image = _dragon_image.Normal;

            x = location.X;
            y = location.Y;
            Size = size;
            w = size.Width;
            h = size.Height;
            Check_struct.Left = x + w / 5;
            Check_struct.Right = x + (w * 4) /5;
            Check_struct.Top = y;
            Check_struct.Bottom = y + (h * 4) / 5;
            SizeMode = PictureBoxSizeMode.StretchImage;

            
        }


        public void Reset()
        {
            flag = false;
            Location = new Point(x, y);
            Size = new Size(w, h);
            Check_struct.Left = x;
            Check_struct.Right = x + w;
            Check_struct.Top = y;
            Check_struct.Bottom = y + h;
            anime_index = 0;
            anime_jump.Stop();
            Image = _dragon_image.Normal;
        }

        public void Start()
        {
            flag = true;
            if(_jump_bool) anime_jump.Start();
        }
        public void Stop()
        {
            flag = false;
            anime_jump.Stop();
        }


        public void Jump()
        {
            if (flag && !_down_bool) {
                _jump_bool = true;
                anime_jump.Start();
                Image = _dragon_image.Jump;
                //Size = new Size( (int)(w * 1.2), h);

            }
        }



        public void Down()
        {
            if (flag && !_jump_bool && !_down_bool)
            {
                _down_bool = true;
                Size = new Size(w, h / 2);
                Location = new Point(x, y + h / 2);
                Check_struct.Top += h / 2;
            }
        }

        public bool IsDown()
        {
            return _down_bool;
        }
        public void Origin()
        {
            if(flag && _down_bool) { 
                _down_bool = false;
                Size = new Size(w, h);
                Location = new Point(x, y);
                Check_struct.Top = y;
            }
        }




        private void Jump_anime_hander_fun(object s,EventArgs e)
        {
            int difference = anime_num[anime_index];
            int _y = Location.Y - difference;
            Check_struct.Top -= difference;
            Check_struct.Bottom -= difference;

            Location = new Point(x, _y);
            anime_index++;
            if(anime_index == 11){
                anime_jump.Stop();
                anime_index = 0;
                _jump_bool = false;
                Image = _dragon_image.Normal;
            }
        }
        
    }
}
