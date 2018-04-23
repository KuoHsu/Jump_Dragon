using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Dargon_Jump_Jump
{

    public struct Object_Side{
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }

    [Serializable]
    public class Game{

        public PictureBox Background_image = new PictureBox();
        private int Game_location_x = 0;
        private int Game_location_y = 0;
        private Control _box ;
        private int _score = 0;
        private bool _reset = true;
        private bool _playing = false;
        private bool _is_stop = false;
        private int _score_standar = 100;
        private int obstacle = 20;
        private uint obstacle_change = 0;
        private List<Bitmap> _obstacles_image = new List<Bitmap>();
        private Dragon _dragon;
        private List<Obstacle> Obstacles = new List<Obstacle>();
        private Random Game_Random = new Random();
        private Timer Obstacle_Generate_Timer = new Timer();
        private Timer Check_Timer = new Timer();
        private int Obstacle_Generate_next = 0;
        private int _fps = 30;
        private int _obstacle_image_count = 0;

        public int Score{
            get{
                return _score;
            }
        }
        public int ScoreStandar
        {
            get
            {
                return _score_standar;
            }
            set
            {
                if (value >= 100) _score_standar = value;
            }
        }

        public delegate void ObstacleAppendHander(Obstacle O);
        public delegate void ObstacleDissappearHander();
        public delegate void DragonDieHander();
        public delegate void GameStatusUpdateHander(int score);
        public delegate void ScoreArriveStandarHander();

        public event ObstacleAppendHander ObstacleAppend;
        public event ObstacleDissappearHander ObstacleDissappear;
        public event DragonDieHander DragonDie;
        public event GameStatusUpdateHander GameStatusUpdate;
        public event ScoreArriveStandarHander ScoreArriveStandar;

        public Game(Control Box,Point location, Dragon_image dragon_image,
            Bitmap obstacle_image,int fps = 30)
        {
            builder(Box, location, dragon_image, fps);
            _obstacles_image.Add(obstacle_image);
            _obstacle_image_count = 1;
        }

        public Game(Control Box, Point location, Dragon_image dragon_image,
            List<Bitmap> obstacle_images, int fps = 30)
        {
            builder(Box, location, dragon_image, fps);
            foreach(Bitmap i in obstacle_images)_obstacles_image.Add(i);
            _obstacle_image_count = obstacle_images.Count;
        }

        private void builder(Control Box, Point location,Dragon_image dragon_image,int fps)
        {
            _box = Box;
            _fps = fps;


            Game_location_x = location.X;
            Game_location_y = location.Y;
            Point dragon_location = new Point(Game_location_x + 50, Game_location_y + 100);
            _dragon = new Dragon(dragon_location, new Size(80, 100), dragon_image);

            _box.Controls.Add(_dragon);

            _box.Controls.Add(Background_image);

            Background_image.Size = new Size(700 + Game_location_x, 250 + Game_location_y);
            
            Check_Timer.Interval = Convert.ToInt32(1000 / _fps);
            Check_Timer.Tick += Check;

            Obstacle_Generate_Timer.Tick += ObstacleGenerate_Tick;
            Obstacle_Generate_Timer.Interval = 500;

        }

        private void Reset(){
            obstacle_change = 0;
            Obstacle_Generate_Timer.Stop();
            Check_Timer.Stop();
            Obstacle_Generate_next = Game_Random.Next(1, 5);
            _dragon.Reset();
            _score = 0;
            Obstacle ot;
            while (Obstacles.Count > 0){
                ot = Obstacles[0];
                Obstacles.RemoveAt(0);
                ot.Dispose();
            }
            _reset = true;
        }

        public void Start()
        {
            if (!_reset) Reset();
            _reset = false;
            Obstacle_Generate_next = Game_Random.Next(4,7);
            _status(true);
            _is_stop = false;
        }

        public void Pause()
        {
            if (!_playing || _is_stop) return;
            foreach (Obstacle O in Obstacles)O.PauseMove();
            _status(false);

        }

        public void Proceed()
        {
            if (_playing || _is_stop) return;
            foreach (Obstacle O in Obstacles) O.ProceedMove();
            _status(true);
        }

        public void Stop()
        {
            if (!_playing || _is_stop) return;
            foreach (Obstacle O in Obstacles) O.StopMove();
            _status(false);
            _is_stop = true;
        }

        private void _status(bool flag)//f = stop t = start
        {
            //if (_is_stop) return;
            _playing = flag;
            if (flag){
                _dragon.Start();
                Check_Timer.Start();
                Obstacle_Generate_Timer.Start();
            }else{
                _dragon.Stop();
                Check_Timer.Stop();
                Obstacle_Generate_Timer.Stop();
            }
            _box.Focus();
        }

        public void DragonJump(){
            _dragon.Jump();
        }

        public void DragonDown(){
            _dragon.Down();
        }

        public void DragonOrigin(){
            if (_dragon.IsDown()) _dragon.Origin();
        }

        private void Check(object o,EventArgs e){
             
            Object_Side _D = _dragon.Check_struct;
            int D_t = _D.Top ;
            int D_b = _D.Bottom ;
            int D_l = _D.Left ;
            int D_r = _D.Right;
            foreach(Obstacle O in Obstacles)
            {
                Object_Side _O = O.Check_struct;
                bool X_b = !(D_r < _O.Left || D_l > _O.Right);
                bool Y_b = !(D_t > _O.Bottom|| D_b < _O.Top);
                if(X_b && Y_b)
                {
                    DragonDie?.Invoke();
                    Stop();
                }
            }
            _score += 1;
            if(_score % ScoreStandar == 0) ScoreArriveStandar?.Invoke();
            GameStatusUpdate?.Invoke(_score);

        }

        private void ObstacleGenerate_Tick(object s,EventArgs e)
        {
            Obstacle_Generate_next -= 1;
            if (Obstacle_Generate_next == 0)
            {
                ObstacleGenerate(0);
                Obstacle_Generate_next = Game_Random.Next(2,4);
                
            }
        }
        
        private void ObstacleGenerate(int type)
        {
            int o = Game_Random.Next(0, 3) * -35;
            Point P = new Point(
                Game_location_x + 700, 
                Game_location_y + 160 + o);

            Obstacle O = new Obstacle(
                P,
                new Size(40,40), 
                _obstacles_image[Game_Random.Next(0,_obstacle_image_count)],
                _fps);

            O.MoveStoped += ObstacleMoveStoped_hander_funciton;
            O.StartMove(obstacle + (int)obstacle_change, 40);

            Obstacles.Add(O);
            
            _box.Controls.Add(O);
            O.BringToFront();
            ObstacleAppend?.Invoke(O);
        }

        private void ObstacleMoveStoped_hander_funciton(Obstacle O,int s)
        {
            if (s == (int)Obstacle.ObstacleStatus.NormalStop)
            {
               if(Obstacles.Count > 0) Obstacles.RemoveAt(0);
                O.Dispose();
                ObstacleDissappear?.Invoke();
            }
        }

        public void VelocityFaster(uint change)
        {
            if (change > 20) throw new Exception("請輸入 >=0 且 <=20 的正整數");
            obstacle_change = change;
        }
        
    }

    [Serializable]
    public class Test
    {
        private int _i = 0;
        private string _s = "";
        public Test(string s,int i)
        {
            _i = i;
            _s = s;
        }
    }
}
