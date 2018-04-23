using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Dargon_Jump_Jump
{
    public class Obstacle:PictureBox
    {

        public enum ObstacleStatus {Error = -1, Moving , NormalStop, UnnormalStop  }

        public Object_Side Check_struct = new Object_Side();


        private Timer Run_timer = new Timer();
        private int x = 0;
        private int y = 0;
        

        private int _distance = 0;
        private int _step = 0;
        private int _status = 1;
        private int _fps = 30;


        public delegate void MoveStopedHander(Obstacle Stopedobstacle,int status);
        public event MoveStopedHander MoveStoped;

        public Obstacle(Point location,Size size,Bitmap image = null, int fps = 30)
        {
            _fps = fps;
            Run_timer.Interval = Convert.ToInt32(1000 / _fps);

            BackColor = Color.Transparent;
            x = location.X;
            y = location.Y;
            Image = image;
            Location = location;
            Run_timer.Tick += _move;
            Run_timer.Interval = 40;
            Size = size;
            Check_struct.Left = x;
            Check_struct.Right = x + size.Width;
            Check_struct.Top = y ;
            Check_struct.Bottom = y + size.Height;
            SizeMode = PictureBoxSizeMode.StretchImage;
            
        }


        public void StartMove(int distance,int step)
        {
            if (distance <= 0 || step <= 0) throw new Exception("distance或step須為正數。");
            _step = step;
            _status = 0;
            _distance = distance;
            Run_timer.Start();
        }


        public void PauseMove()
        {
            Run_timer.Stop();
            MoveStoped(this, 2);
            _status = 2;
        }
        public void ProceedMove()
        {
            Run_timer.Start();
            _status = 0;
        }

        public void StopMove()
        {
            Run_timer.Stop();
            MoveStoped(this, 2);
            //Dispose();
        }

        private void _move(object s,EventArgs e)
        {
            int _x = Location.X - _distance;
            Location = new Point(_x, y);
            Check_struct.Left -= _distance;
            Check_struct.Right -= _distance;



            _step--;
            if (_step == 0)
            {
                Run_timer.Stop();
                MoveStoped(this, 1);
            }
        }


        public int GetStatus()
        {
            return _status;
        }

        
        public new void Dispose()
        {
            Run_timer.Dispose();
            base.Dispose(true);
        }

    }
}
