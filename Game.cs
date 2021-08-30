using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace seainvaders
{
    class Game
    {
        public Canvas window;
        private Thread gameLoopThread;
        public bool canvasClosed = false;
        public float courseWidth;
        public float courseHeight;
        public int leftScore = 0;
        public int rightScore = 0;
        public Enemyblob blob;
        public Player player;
        // adding too many static methods is considered 'bad coding'. Static methods should be used for things that are global for a class.
        public static HashSet<string> keys;

        public Game(Canvas canvas)
        {
            courseWidth = 700;
            courseHeight = 700;
            blob = new Enemyblob();
            player = new Player();
            window = canvas;
            keys = new HashSet<string>();
            canvas.Paint += Canvas_Paint; // this is listening for when the window is painted
           
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.IsBackground = true; //attempt to solve thread running after window closes
            gameLoopThread.Start();
            canvas.KeyDown += Canvas_KeyPress;
            canvas.KeyUp += Canvas_KeyRelease;

        }


        private void Canvas_KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            { keys.Remove("a"); }                // if the player releases the A key, the velocity is set to 0
            else if (e.KeyCode == Keys.D)
            { keys.Remove("d"); }                // if the player releases the A key, the velocity is set to 0
        }
        //Key release listener and logic.

        private void Canvas_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            { keys.Add("a"); }             // if the player presses the A key, the velocity is set to -2 (moves to the left at "2-speed")
            else if (e.KeyCode == Keys.D)
            { keys.Add("d"); }              // if the player presses the A key, the velocity is set to 2 (moves to the right at "2-speed")
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font scoreFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font bigscoreFont = new System.Drawing.Font("Consolas", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            graphics.Clear(Color.Black);
        
            graphics.DrawString("Score", scoreFont, new SolidBrush(Color.White), new PointF(courseWidth / 2, courseHeight + 20));
            graphics.DrawString(leftScore.ToString(), scoreFont, new SolidBrush(Color.White), new PointF((courseWidth / 2) - 50, courseHeight + 40));
            graphics.DrawString(rightScore.ToString(), scoreFont, new SolidBrush(Color.White), new PointF((courseWidth / 2) + 75, courseHeight + 40));
            graphics.FillRectangle(new SolidBrush(Color.White), 0, courseHeight, courseWidth, 10);
            if (leftScore >= 5)
            {
                graphics.DrawString("Player Wins!", bigscoreFont, new SolidBrush(Color.White), new PointF(((courseWidth / 2) - 200), (courseHeight / 2)));
            }
            else if (rightScore >= 5)
            {
                graphics.DrawString("Computer Wins!", bigscoreFont, new SolidBrush(Color.White), new PointF(((courseWidth / 2) - 200), (courseHeight / 2)));
            }
            blob.Update();
            player.Update();
            blob.Render(graphics);
            player.Render(graphics);
            

        }

        

       public void GameLoop()
        {
            while (gameLoopThread.IsAlive && !canvasClosed) // the && checks for a logical condition  - if canvasClosed is NOT closed
            {
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
            }
        }

    }
}