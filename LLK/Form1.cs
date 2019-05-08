using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLK
{
    public partial class Main : Form
    {
        Random Ran = new Random(DateTime.Now.Millisecond);
        BlockMap map;
        ResourceManager rm = Images.ResourceManager;
        enum GameStatus
        {
            Playing, OnHit, Fail, Paused
        };
        GameStatus gameStatus;
        int prew = 0,preh = 0;
        int tipaw, tipah, tipbw, tipbh;
        int messUpTime, tipTime;
        long preHit;
        double timeLeft;
        int combo,score, maxCombo;
        System.Threading.Timer timer;
        public Main()
        {
            InitializeComponent();
            CountDown.Visible = false;
            Tip.Enabled = false;
            MessUp.Enabled = false;
            GameBox.Visible = false;
        }


        private void PaintMap(Graphics g)
        {
            if (map == null) return;
            Image image = null;
            for (int h = 1; h <= BlockMap.Height; h++)
                for (int w = 1; w <= BlockMap.Width; w++)
                    if (map[h, w] > 0)
                    {
                        image = (Bitmap)rm.GetObject("_" + map[h, w]);
                        g.DrawImage(image, Block.BlockWidth * w, Block.BlockHeight * h);
                    }

            //Console.WriteLine("_" + map[preh, prew] + "_L2");
            if (map[preh, prew] != 0)
            {
                image = (Bitmap)rm.GetObject("_" + map[preh, prew] + "_L2");
                g.DrawImage(image, Block.BlockWidth * prew, Block.BlockHeight * preh);
            }

            if (gameStatus == GameStatus.OnHit)
            {
                image = (Bitmap)rm.GetObject("_" + map[tipah, tipaw] + "_L2");
                g.DrawImage(image, Block.BlockWidth * tipaw, Block.BlockHeight * tipah);
                image = (Bitmap)rm.GetObject("_" + map[tipbh, tipbw] + "_L2");
                g.DrawImage(image, Block.BlockWidth * tipbw, Block.BlockHeight * tipbh);
            }

        }
               
        private void GameBox_Paint(object sender, PaintEventArgs e)
        {
            PaintMap(e.Graphics);
        }

        private void update(object state)
        {
            Action<string> actionDelegate = (x) => { CountDown.Text = ((int)timeLeft).ToString(); };
            CountDown.Invoke(actionDelegate, state);
            //CountDown.Text = ((int)timeLeft).ToString();
            if (gameStatus != GameStatus.Paused)
            {
                int t1,t2,t3,t4;
                if (map.getTip(out t1, out t2, out t3, out t4)==false)
                {
                    map.MessUp();
                    GameBox.Invalidate();
                }
                timeLeft -= 0.5;
                if (timeLeft <= 0)
                {
                    gameStatus = GameStatus.Fail;
                    Lose(state);
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            GameBox.Visible = true;
            map = new BlockMap();
            GameBox.Size = map.GetMapSize();
            Graphics g = GameBox.CreateGraphics();
            PaintMap(g);
            Start.Enabled = false;
            Tip.Enabled = true;
            MessUp.Enabled = true;
            gameStatus = GameStatus.Playing;
            preHit = DateTime.Now.Ticks;
            combo = 0;
            score = 0;
            maxCombo = 0;
            messUpTime = 1;
            tipTime = 3;
            MessUp.Text = string.Format("打乱({0})", messUpTime);
            Tip.Text = string.Format("提示({0})", tipTime);
            timeLeft = 60;
            CountDown.Visible = true;
            timer = new System.Threading.Timer(update, null, 0, 500);
        }


        private void MessUp_Click(object sender, EventArgs e)
        {
            gameStatus = GameStatus.Playing;
            map.MessUp();
            prew = 0;
            preh = 0;
            messUpTime--;
            MessUp.Text = string.Format("打乱({0})", messUpTime);
            if (messUpTime == 0) MessUp.Enabled = false;
            GameBox.Invalidate();
        }

        private void Tip_Click(object sender, EventArgs e)
        {
            if (map.getTip(out tipaw,out tipah,out tipbw,out tipbh))
            {
                gameStatus = GameStatus.OnHit;
                preh = 0;
                prew = 0;
                tipTime--;
                Tip.Text = string.Format("提示({0})", tipTime);
                if (tipTime == 0) Tip.Enabled = false;
                GameBox.Invalidate();
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (Pause.Text == "暂停")
            {
                Tip.Enabled = false;
                MessUp.Enabled = false;
                GameBox.Visible = false;
                Pause.Text = "继续";
                gameStatus = GameStatus.Paused;
            }
            else
            {
                GameBox.Visible = true;
                if (tipTime>0) Tip.Enabled = true;
                if (messUpTime > 0) MessUp.Enabled = true;
                Pause.Text = "暂停";
                gameStatus = GameStatus.Playing;
            }
        }

        private void GameBox_MouseClick(object sender, MouseEventArgs e)
        {
            gameStatus = GameStatus.Playing;
            GameBox.Invalidate();
            int h = e.Y / Block.BlockHeight;
            int w = e.X / Block.BlockWidth;
            int aw, ah, bw, bh;
            if (map[h, w] == 0) return;
            if (h == preh && w == prew)
            {
                preh = 0; prew = 0;
            }
            else if (map[preh, prew] == map[h, w] && map.CanLink(prew, preh, w, h,out aw,out ah,out bw,out bh))
            {
                timeLeft += 2;
                map.BlockNum -= 2;
                long timeNow = DateTime.Now.Ticks;
                Console.WriteLine(timeNow);
                if (timeNow - preHit <= 25000000) combo++;
                else combo = 1;
                preHit = timeNow;
                maxCombo = Math.Max(maxCombo, combo);
                // 直连
                List<Point> points = new List<Point>();
                points.Add(new Point(prew * Block.BlockWidth + Block.BlockWidth / 2, preh * Block.BlockHeight + Block.BlockHeight / 2));
                if (aw != -1) points.Add(new Point(aw * Block.BlockWidth + Block.BlockWidth / 2, ah * Block.BlockHeight + Block.BlockHeight / 2));
                if (bw != -1) points.Add(new Point(bw * Block.BlockWidth + Block.BlockWidth / 2, bh * Block.BlockHeight + Block.BlockHeight / 2));
                points.Add(new Point(w * Block.BlockWidth + Block.BlockWidth / 2, h * Block.BlockHeight + Block.BlockHeight / 2));
                map[preh, prew] = map[h, w] = 0;

                int hh = preh, ww = prew;
                // 本来应该写一个类用来保存状态的 但是 一开始不知道 也懒得改了
                new Thread(() => Boom(ww, hh, w, h, points.ToArray())).Start();
                preh = 0; prew = 0;
                score += 10;
                score += combo;
                Score.Text = score.ToString();
                Combo.Text = string.Format("{0}/{1}", combo, maxCombo);
                
                //new Thread(PlayComboSound).Start();
                PlayComboSound();
                if (map.BlockNum == 0) Win();

            }
            else
            {
                preh = h;
                prew = w;
            }
           
            GameBox.Invalidate();
        }

        private void PlayComboSound()
        {
            if (combo == 15)
            {
                SoundPlayer player;
                player = new SoundPlayer("Sound/jianjiao.wav");
                player.Play();
            }
            else if (combo == 10)
            {
                SoundPlayer player;
                player = new SoundPlayer("Sound/koushao.wav");
                player.Play();
            }
            else if (combo == 5)
            {
                SoundPlayer player;
                player = new SoundPlayer("Sound/zhangsheng.wav");
                player.Play();
            }
        }
        private void Boom(int ww, int hh, int w, int h, Point[] points)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = GameBox.CreateGraphics();
            Image image;
            SoundPlayer player;
            player = new SoundPlayer(string.Format("Sound/exp{0}.wav", Ran.Next(1, 3)));
            player.Play();
            for (int i = 1; i <= 6; ++i)
            {
                image = (Bitmap)rm.GetObject("B" + i);
                if (i <= 3) g.DrawLines(pen, points);
                g.DrawImage(image, Block.BlockWidth * ww, Block.BlockHeight * hh, Block.BlockWidth, Block.BlockHeight);
                g.DrawImage(image, Block.BlockWidth * w, Block.BlockHeight * h, Block.BlockWidth, Block.BlockHeight);
                Thread.Sleep(100);
            }
            GameBox.Invalidate();
        }

        private void Win()
        {
            timer.Change(-1,-1);
            Start.Text = "重新开始";
            Start.Enabled = true;
            CountDown.Visible = false;
            Tip.Enabled = false;
            MessUp.Enabled = false;
            GameBox.Visible = false;
            MessageBox.Show("挑战成功", "", MessageBoxButtons.OKCancel);
        }
        private void Lose(object state)
        {
            timer.Change(-1, -1);
            Action<string> actionDelegate = (x) => { Start.Text = "重新开始"; Start.Enabled = true; };
            Start.Invoke(actionDelegate, state);
            actionDelegate = (x) => { CountDown.Visible = false; };
            CountDown.Invoke(actionDelegate, state);
            actionDelegate = (x) => { Tip.Enabled = false; };
            Tip.Invoke(actionDelegate, state);
            actionDelegate = (x) => { MessUp.Enabled = false; };
            MessUp.Invoke(actionDelegate, state);
            actionDelegate = (x) => { GameBox.Visible = false; };
            GameBox.Invoke(actionDelegate, state);
            MessageBox.Show("挑战失败", "", MessageBoxButtons.OKCancel);
        }
    }
}
