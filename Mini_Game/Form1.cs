using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mini_Game
{
    public class BK
    {
        public int x, y;
        public Bitmap img;
    }

    public class melon
    {
        public int X;
        public int Y;
        public int dy=1;
        public Bitmap img;
        public int Speed = 50;
    }
    public class apple
    {
        public int X;
        public int Y;
        public int dy=1;
        public Bitmap img;
        public int Speed = 50;
    }
    public class pinapple
    {
        public int X;
        public int Y;
        public int dy = 1;
        public Bitmap img;
        public int Speed = 50;
    }
    public class orange
    {
        public int X;
        public int Y;
        public int dy = 1;
        public Bitmap img;
        public int Speed = 50;
    }
    public class Score
    {
        public float x, y;
        public Bitmap[] S;
        public int iFrame = 0;

    }
    public class Score2
    {
        public float x, y;
        public Bitmap[] SS;
        public int iFrame = 0;

    }
    public class one
    {
        public float x, y;
        public Bitmap o;



    }
    public class two
    {
        public float x, y;
        public Bitmap t;



    }
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer tt = new Timer();
        Timer ttt = new Timer();
        
      
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        int counter4 = 0;
        int counter5 = 0;
        int counter6 = 0;
        int live = 3;
        int flags = 0;
        int flagst = 0;
        bool isDragmelon = false;
        bool isDragapple = false;
        bool isDragorange = false;
        bool isDragpinapple = false;
        bool isStart = false;
        List<melon> melon = new List<melon>();
        List<apple> apple = new List<apple>();
        List<pinapple> pinapple = new List<pinapple>();
        List<orange> orange = new List<orange>();
        List<Score> Score = new List<Score>();
        List<Score2> Score2 = new List<Score2>();
        List<one> one = new List<one>();
        List<two> two = new List<two>();
        List<BK> BK = new List<BK>();
        int menu = 0;
        int score;
        int x, y, z, flag = 0;
      
        int ctTick = 0;
        int timer = 21;
      
        int iWhichmelon = 0;
        int iWhichapple = 0;
        int iWhichpinapple = 0;
        int iWhichorange = 0;
        //left=0,right=1
        int direction = 0;
        public Form1()
        {
            this.Paint += Form1_Paint;
            this.Load += Form1_Load1;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.KeyDown += Form1_KeyDown;

            this.WindowState = FormWindowState.Maximized;
            
            tt.Tick += Tt_Tick;
         
            //tt.Interval = 10;

            tt.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            

            if(isDragmelon == true)
            {
                melon[iWhichmelon].img = new Bitmap("cutmelon.bmp");
                score += 1;
                for (int i = 0; i < Score.Count; i++)
                {

                    Score[i].iFrame++;
                }
                melon[iWhichmelon].Speed = 100;
                melon[iWhichmelon].dy = -1;
              
                isDragmelon = false;
            }
            if (isDragapple == true)
            {
                apple[iWhichapple].img = new Bitmap("cutapple.bmp");
                score += 1;
                for (int i = 0; i < Score.Count; i++)
                {

                    Score[i].iFrame++;
                }
                apple[iWhichapple].Speed = 100;
                apple[iWhichapple].dy = -1;
               
                isDragapple = false;
            }
            if (isDragpinapple == true)
            {
                pinapple[iWhichpinapple].img = new Bitmap("cutpinapple.bmp");
                score += 1;
                for (int i = 0; i < Score.Count; i++)
                {
                    
                    Score[i].iFrame++;
                }

                pinapple[iWhichpinapple].Speed = 100;
                pinapple[iWhichpinapple].dy = -1;
               
                isDragpinapple = false;
            }
            if (isDragorange == true)
            {
                orange[iWhichorange].img = new Bitmap("cutorange.bmp");
                score += 1;
                for (int i = 0; i < Score.Count; i++)
                {

                    Score[i].iFrame++;
                }
                orange[iWhichorange].Speed = 100;
                orange[iWhichorange].dy = -1;
               
                isDragorange = false;
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragapple = false;
            isDragmelon = false;
            isDragorange = false;
            isDragpinapple = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                
                case Keys.W:
                    BK[0].img = new Bitmap("BK.bmp");
                    break;
                case Keys.E:
                    BK[0].img = new Bitmap("wp7567364-fruit-ninja-wallpapers.bmp");
                    break;
                case Keys.R:
                    BK[0].img = new Bitmap("wp7567385-fruit-ninja-wallpapers.bmp");
                    break;
                case Keys.Escape:
                    isStart = false;
                    MessageBox.Show("Pause | Click OK to Resume");
                    isStart = true;
                    break;
                case Keys.Enter:
                    delete_game();
                    create_game();
                    break;
               

            }
           
        }

    

    private void Ttt_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iWhichmelon = HitImg(e.X, e.Y);
            iWhichapple = Hitapple(e.X, e.Y);
            iWhichpinapple = Hitpinapple(e.X, e.Y);
            iWhichorange = Hitorange(e.X, e.Y);
            isStart = true;
            if (iWhichmelon != -1)
            {
                isDragmelon = true;
               
                //MessageBox.Show(score+"");
                //AnimatecutStars();
            }
            
            if (iWhichapple != -1)
            {
                isDragapple = true;

                //MessageBox.Show(score+"");


            }
            if (iWhichpinapple != -1)
            {
               
                isDragpinapple = true;
                //MessageBox.Show(score+"");


            }
            if (iWhichorange != -1)
            {
                isDragorange = true;
                
                //MessageBox.Show(score+"");


            }
            


        }



        void createapple()
        {

            Random RR = new Random();
            apple pnn2 = new apple();
            pnn2.img = new Bitmap("apple.bmp");
            pnn2.img.MakeTransparent(pnn2.img.GetPixel(0, 0));
            pnn2.X = RR.Next(0, this.ClientSize.Height);
            pnn2.Y = 1000;
            apple.Add(pnn2);

        }
        void createpinapple()
        {

            Random RR = new Random();
            pinapple pnn2 = new pinapple();
            pnn2.img = new Bitmap("pinapple.bmp");
        
            pnn2.X = RR.Next(0, this.ClientSize.Height);
            pnn2.Y = 1000;
            pinapple.Add(pnn2);

        }
        void createmelon()
        {

            Random RR = new Random();
            melon pnn2 = new melon();
            pnn2.img = new Bitmap("melon.bmp");
            pnn2.X = RR.Next(0, this.ClientSize.Height);
            pnn2.Y = 1000;
            melon.Add(pnn2);

        }
        void Create_Score(float x, float y)
        {
            Score pnn = new Score();
            pnn.x = x;
            pnn.y = y;
            pnn.S = new Bitmap[10];
            for (int i = 0; i < 10; i++)
            {
                pnn.S[i] = new Bitmap("T" + i + ".jpg");
                pnn.S[i].MakeTransparent(pnn.S[i].GetPixel(0, 0));
            }
            Score.Add(pnn);
        }
        void Create_Score2(float x, float y)
        {
            Score2 pnn = new Score2();
            pnn.x = x;
            pnn.y = y;
            pnn.SS = new Bitmap[10];
            for (int i = 1; i < 10; i++)
            {
                pnn.SS[i] = new Bitmap("T" + i + ".jpg");
                pnn.SS[i].MakeTransparent(pnn.SS[i].GetPixel(0, 0));
            }
            Score2.Add(pnn);
        }
        void createorange()
        {

            Random RR = new Random();
            orange pnn2 = new orange();
            pnn2.img = new Bitmap("orange.bmp");
            pnn2.X = RR.Next(0, this.ClientSize.Height);
            pnn2.Y = 1000;
            orange.Add(pnn2);

        }
        void createone(float x,float y)
        {


            one pnn2 = new one();
            
            pnn2.x = x;
            pnn2.y = y;
            pnn2.o = new Bitmap("T1.jpg");
            pnn2.o.MakeTransparent(pnn2.o.GetPixel(0, 0));
            one.Add(pnn2);

        }
        void createtwo(float x, float y)
        {


            two pnn2 = new two();

            pnn2.x = x;
            pnn2.y = y;
            pnn2.t = new Bitmap("T2.jpg");
            pnn2.t.MakeTransparent(pnn2.t.GetPixel(0, 0));
            two.Add(pnn2);

        }
        void CreateBk()
        {

            BK pnn = new BK();
            pnn.x = 0;
            pnn.y = 0;
            pnn.img = new Bitmap("BK.bmp");

            BK.Add(pnn);

        }
        void create_game()
        {
            timer = 21;
            live = 3;
            score = 0;
            flags = 0;
            flagst = 0;
            tt.Start();
            CreateBk();
            Create_Score(880, 50);
            createone(780, 50);
            createtwo(775, 50);
            this.Text = " Fruit Ninja " + "";
            timer--;
        }
        void animatemelon()
        {

            for (int i = 0; i < melon.Count; i++)
            {
                
                melon[i].Y -= melon[i].Speed*melon[i].dy;
                if (melon[i].Y == 0)
                {
                    live-- ;
                 
                   
                    if(live==0)
                    {
                        tt.Stop();
                        MessageBox.Show("Game Over " + " Your score : " + score + "              |          Press Enter to restart the Game");

                        break;
                    }
                }

            }

        }
        void animateapple()
        {

            for (int i = 0; i < apple.Count; i++)
            {

                apple[i].Y -= apple[i].Speed*apple[i].dy;
                if (apple[i].Y == 0)
                {
                    live--;
                  
                    
                    if (live == 0)
                    {
                        tt.Stop();
                        MessageBox.Show("Game Over " + " Your score : " + score + "              |         Press Enter to restart the Game");
                       
                        break;
                       
                    }
                }
            }

        }
        void animatepinapple()
        {

            for (int i = 0; i < pinapple.Count; i++)
            {

                pinapple[i].Y -= pinapple[i].Speed * pinapple[i].dy;
                if (pinapple[i].Y == 0)
                {
                    live--;
                    
                    
                    if (live == 0)
                    {
                        tt.Stop();
                        MessageBox.Show("Game Over " + " Your score : " + score + "              |          Press Enter to restart the Game");

                        break;
                    }
                }
            }

        }
        void animateorange()
        {

            for (int i = 0; i < orange.Count; i++)
            {

                orange[i].Y -= orange[i].Speed * orange[i].dy;
                if (orange[i].Y == 0)
                {
                    live--;
                    

                    if (live == 0)
                    {
                        tt.Stop();
                        MessageBox.Show("Game Over " + " Your score : " + score + "            |            Press Enter to restart the Game");

                        break;
                    }
                }
            }

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if(isStart==true)
            {
                if (score < 4)
                {

                    if (ctTick % 17 == 0)
                    {

                        if (counter == 0 && counter2 == 0 && counter4 == 0)
                        {

                            createmelon();
                            counter = 1;
                            counter2 = 1;
                            counter4 = 1;


                        }
                        else if (counter == 1 && counter3 == 0 && counter5 == 0)
                        {

                            createapple();
                            counter = 0;
                            counter3 = 1;
                            counter5 = 1;

                        }
                        else if (counter2 == 1 && counter3 == 1 && counter6 == 0)
                        {

                            createpinapple();
                            counter2 = 0;
                            counter3 = 0;
                            counter6 = 1;
                        }
                        else if (counter4 == 1 && counter5 == 1 && counter6 == 1)
                        {

                            createorange();
                            counter4 = 0;
                            counter5 = 0;
                            counter6 = 0;

                        }
                    }
                    animatemelon();

                    animateapple();

                    animatepinapple();

                    animateorange();


                }
                if (score >= 4)
                {
                    //MessageBox.Show("Level 1 Completed");
                    if (ctTick % 15 == 0)
                    {
                        if (counter == 0 && counter2 == 0 && counter4 == 0)
                        {
                            createmelon();
                            counter = 1;
                            counter2 = 1;
                            counter4 = 1;


                        }
                        else if (counter == 1 && counter3 == 0 && counter5 == 0)
                        {
                            createapple();
                            counter = 0;
                            counter3 = 1;
                            counter5 = 1;

                        }
                        else if (counter2 == 1 && counter3 == 1 && counter6 == 0)
                        {
                            createpinapple();
                            counter2 = 0;
                            counter3 = 0;
                            counter6 = 1;
                        }
                        else if (counter4 == 1 && counter5 == 1 && counter6 == 1)
                        {
                            createorange();
                            counter4 = 0;
                            counter5 = 0;
                            counter6 = 0;

                        }
                    }
                    animatemelon();

                    animateapple();

                    animatepinapple();

                    animateorange();

                }
                if (score >= 21)
                {
                    //MessageBox.Show("Level 2 Completed");
                    if (ctTick % 15 == 0)
                    {
                        if (counter == 0 && counter2 == 0 && counter4 == 0)
                        {
                            createmelon();
                            counter = 1;
                            counter2 = 1;
                            counter4 = 1;


                        }
                        else if (counter == 1 && counter3 == 0 && counter5 == 0)
                        {
                            createapple();
                            counter = 0;
                            counter3 = 1;
                            counter5 = 1;

                        }
                        else if (counter2 == 1 && counter3 == 1 && counter6 == 0)
                        {
                            createpinapple();
                            counter2 = 0;
                            counter3 = 0;
                            counter6 = 1;
                        }
                        else if (counter4 == 1 && counter5 == 1 && counter6 == 1)
                        {
                            createorange();
                            counter4 = 0;
                            counter5 = 0;
                            counter6 = 0;

                        }
                    }
                    animatemelon();
                    //
                    animateapple();
                    //
                    animatepinapple();
                    //
                    animateorange();


                }
                if (score >= 22)
                {
                    //MessageBox.Show("Level 3 Completed");
                    if (ctTick % 14 == 0)
                    {
                        if (counter == 0 && counter2 == 0 && counter4 == 0)
                        {
                            createmelon();
                            counter = 1;
                            counter2 = 1;
                            counter4 = 1;


                        }
                        else if (counter == 1 && counter3 == 0 && counter5 == 0)
                        {
                            createapple();
                            counter = 0;
                            counter3 = 1;
                            counter5 = 1;

                        }
                        else if (counter2 == 1 && counter3 == 1 && counter6 == 0)
                        {
                            createpinapple();
                            counter2 = 0;
                            counter3 = 0;
                            counter6 = 1;
                        }
                        else if (counter4 == 1 && counter5 == 1 && counter6 == 1)
                        {
                            createorange();
                            counter4 = 0;
                            counter5 = 0;
                            counter6 = 0;

                        }
                    }
                    animatemelon();
                    //
                    animateapple();
                    //
                    animatepinapple();
                    //
                    animateorange();

                }


                if (ctTick % 10 == 0)
                {
                    timer--;


                    if (timer == 0 && score < 10)
                    {
                        tt.Stop();
                        MessageBox.Show("TIME OUT !");
                    }
                    if (timer <= 0 && score > 10)
                    {
                        tt.Stop();
                        MessageBox.Show("Congratulation LEVEL 1 IS COMPLETEDTED....");

                        BK[0].img = new Bitmap("wp7567364-fruit-ninja-wallpapers.bmp");
                        tt.Start();
                        timer = 30;
                    }

                    if (timer == 0 && score > 15)
                    {
                        tt.Stop();
                        MessageBox.Show("Congratulation LEVEL 2 IS COMPLETEDTED....");
                        BK[0].img = new Bitmap("wp7567385-fruit-ninja-wallpapers.bmp");
                        tt.Start();
                        timer = 30;
                    }

                }
                ctTick++;



                DrawDubb(this.CreateGraphics());
            }
           

        }

        private void Form1_Load1(object sender, EventArgs e)
        {
           
                off = new Bitmap(ClientSize.Width, ClientSize.Height);
            create_game();
         
          

        }
        void delete_game()
        {
            while (BK.Count > 0)
            {
                BK.RemoveAt(0);
            }

            while (melon.Count > 0)
            {
                melon.RemoveAt(0);
            }

            while (pinapple.Count > 0)
            {
                pinapple.RemoveAt(0);
            }

            while (apple.Count > 0)
            {
                apple.RemoveAt(0);
            }

            while (orange.Count > 0)
            {
                orange.RemoveAt(0);
            }

            while (Score.Count > 0)
            {
                Score.RemoveAt(0);
            }
            while (Score.Count > 0)
            {
                Score.RemoveAt(0);
            }
            while (one.Count > 0)
            {
                one.RemoveAt(0);
            }
            while (two.Count > 0)
            {
                two.RemoveAt(0);
            }
            while (Score2.Count > 0)
            {
                Score2.RemoveAt(0);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
      
        void DrawScene(Graphics g)
        {
            Font f = new Font(Name, 20);
            Brush brush = new SolidBrush(Color.White);
            Brush brush2 = new SolidBrush(Color.Yellow);
            Brush brush3 = new SolidBrush(Color.White);
            Brush brush5 = new SolidBrush(Color.Red);
            Brush brush6 = new SolidBrush(Color.DarkBlue);
            for (int i = 0; i < BK.Count; i++)
            {

                Rectangle rcDst = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
                Rectangle rcSrc = new Rectangle(0, 0, BK[i].img.Width, BK[i].img.Height);
                g.DrawImage(BK[i].img, rcDst, rcSrc, GraphicsUnit.Pixel);
            }
            if(!isStart)
            {
                g.DrawString("Welcome to Fruit Ninja Game", f, brush, 725, 300);
                g.DrawString("|Instructions|", f, brush, 800, 370);
                g.DrawString("1) Cut the fruits to increase your score", f, brush6, 660, 420);
                g.DrawString("2) You should score more than 10 points before the timer stop", f, brush6, 500, 500);
                g.DrawString("3) As the score increase the fruits move fast ", f, brush6, 600, 600);
                g.DrawString("The Game consist of 3 Levels ", f, brush6, 700, 700);
                g.DrawString("You can restart the game by pressing Enter ", f, brush2, 620, 760);
                g.DrawString("Click on the Mouse to start the Game...", f, brush5, 650,820);
            }


            for (int i = 0; i < melon.Count; i++)
            {
                g.DrawImage(melon[i].img, melon[i].X, melon[i].Y);
            }
            for (int i = 0; i < apple.Count; i++)
            {
                g.DrawImage(apple[i].img, apple[i].X, apple[i].Y);
            }
            for (int i = 0; i < pinapple.Count; i++)
            {
                g.DrawImage(pinapple[i].img, pinapple[i].X, pinapple[i].Y);
            }
            for (int i = 0; i < orange.Count; i++)
            {
                g.DrawImage(orange[i].img, orange[i].X, orange[i].Y);
            }
            for (int i = 0; i < Score.Count; i++)
            {
                if (Score[i].iFrame < 10)
                {

                    g.DrawImage(Score[i].S[Score[i].iFrame], Score[i].x, Score[i].y);
                    if(flags==1)
                    {
                        g.DrawImage(one[0].o, one[0].x, one[0].y);
                    }
                    if (flagst == 1)
                    {
                       
                       // one.Remove(one[0]);
                        g.DrawImage(two[0].t, two[0].x, two[0].y);
                    }
                }
                else if (Score[i].iFrame==10 && score!=20)
                {
                    Score[i].iFrame = 0;
                    //Create_Score2(700,50);
                    flags = 1;
                    
                }
                else if(Score[i].iFrame==10 &&score==20)
                {
                    Score[i].iFrame = 0;
                    flags = 0;
                    flagst = 1;
                }

            }
           
           
           
            g.DrawString("score : " + score.ToString(), f, brush, 10, 10);
            g.DrawString("Live : " + live.ToString(), f, brush, 10, 50);
            g.DrawString("Timer : " + timer.ToString(), f, brush2, 10, 90);
            if (timer < 10)
            {
                g.DrawString("Timer : " + timer.ToString(), f, brush5, 10, 90);
            }
            g.DrawString("By: Mostafa Hassan ", f, brush3, 1600, 10);
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        int HitImg(float XM, float YM)
        {
            for (int i = 0; i < melon.Count; i++)
            {
                float xs = melon[i].X;
                float xe = melon[i].X + melon[i].img.Width;
                float ys = melon[i].Y;
                float ye = melon[i].Y + melon[i].img.Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;
                    
                }


            }
            return -1;
        }
        int Hitapple(float XM, float YM)
        {
            for (int i = 0; i < apple.Count; i++)
            {
                float xs = apple[i].X;
                float xe = apple[i].X + apple[i].img.Width;
                float ys = apple[i].Y;
                float ye = apple[i].Y + apple[i].img.Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;

                }


            }
            return -1;
        }
        int Hitpinapple(float XM, float YM)
        {
            for (int i = 0; i < pinapple.Count; i++)
            {
                float xs = pinapple[i].X;
                float xe = pinapple[i].X + pinapple[i].img.Width;
                float ys = pinapple[i].Y;
                float ye = pinapple[i].Y + pinapple[i].img.Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;

                }
            }
            return -1;
        }
        int Hitorange(float XM, float YM)
        {
            for (int i = 0; i < orange.Count; i++)
            {
                float xs = orange[i].X;
                float xe = orange[i].X + orange[i].img.Width;
                float ys = orange[i].Y;
                float ye = orange[i].Y + orange[i].img.Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;

                }
            }
            return -1;
        }    
    }

}

