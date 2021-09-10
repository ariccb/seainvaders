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
        public int leftScore = 0;
        public int rightScore = 0;
        public Enemyblob blob;
        public Player player;
        public static List<Shield> shields = new List<Shield>();
        // adding too many static methods is considered 'bad coding'. Static methods should be used for things that are global for a class.
        public static HashSet<string> keys;
        public static List<Entity> EntityList;

        public Game(Canvas canvas)
        {
            EntityList = new List<Entity>();
            blob = new Enemyblob();
            player = new Player();
            for (int i = 0; i < 4; i++) // because there are 4 shields
            {
                shields.Add(new Shield((i + 1) * (28) + (i * 22), 211 - 32)); // shields are 28 pixels apart, and 22 pixels wide
            }          
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
            if (e.KeyCode == Keys.Left)
            { keys.Remove("left"); }                // if the player releases the A key, the velocity is set to 0
            else if (e.KeyCode == Keys.Right)
            { keys.Remove("right"); }                // if the player releases the A key, the velocity is set to 0
            else if (e.KeyCode == Keys.Space)
            { keys.Remove("space"); }
        }
        //Key release listener and logic.

        private void Canvas_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            { 
                keys.Add("left"); 
            }             // if the player presses the A key, the velocity is set to -2 (moves to the left at "2-speed")
            else if (e.KeyCode == Keys.Right)
            { 
                keys.Add("right"); 
            }              // if the player presses the A key, the velocity is set to 2 (moves to the right at "2-speed")
            else if (e.KeyCode == Keys.Space)
            { 
                keys.Add("space"); 
            }
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font scoreFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font bigscoreFont = new System.Drawing.Font("Consolas", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            graphics.Clear(Color.Black);

            blob.Update();

            for (int i = 0; i < EntityList.Count; i++)
            {
                EntityList[i].Update();
            }
            for (int i = 0; i < EntityList.Count; i++)
            {
                EntityList[i].Render(graphics);
            }
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