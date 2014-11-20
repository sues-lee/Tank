using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarOfTank.Base;
using WarOfTank.Base.Factory;
namespace WarOfTank
{
    public partial class FormMain : Form
    {
        IFactory barrierFactory=new BarrierFactory();
        IFactory tankFactory = new PlayerTankFactory();
        int map = 0;            //地图选择
        public FormMain()
        {
            InitializeComponent();
            const int CROSS = 13;                    //格数
            //const int VERTICAL = 13;               //纵向格数
            Game.Width = this.Width / CROSS;               //每一格的宽度

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void InitMap(int map) //初始化地图，可更改为保存在文件中
        {
            switch (map)
            {
                case 0: {
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 3, 1));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 3, 2));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 1, 3));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 2, 3));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 3, 3));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.RockBarrier, 4, 3));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 3, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 1, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 2, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 3, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 4, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 5, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 6, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 7, 4));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.BrickBarrier, 8, 4));
;
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 12, 3));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 12, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 11, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 10, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 9, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 8, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 7, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 6, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier,5, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 4, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 3, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 2, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 1, 5));
                    Game.Instance.AddElement(barrierFactory.factory(BarrierType.GrassBarrier, 0, 5));
                }
                    break;
               
            }
            
        }
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {

            this.Invalidate();
            Game.Instance.KeyDown(e);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.Instance.TankMove();
           // this.Invalidate();
            
            Game.Instance.SetEnemy();
            this.CheckWin();
            this.CheckLose();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Game.Instance.Draw(g);
       
        }
        /// <summary>
        /// 检查是否玩家赢
        /// </summary>
        private void CheckWin()
        {
            if (Game.Instance.IsWin())
            {
                timer1.Enabled = false;
                MessageBox.Show("胜利！", "提示");
            }
        }
        /// <summary>
        /// 检查是否玩家失败
        /// </summary>
        private void CheckLose()
        {
            if (Game.Instance.IsLose())
            {
                timer1.Enabled = false;
                MessageBox.Show("失败！", "提示");
            }
        }
        /// <summary>
        /// 游戏开始
        /// </summary>
        private void Start()
        {
            Game.Instance.ReStart();
            InitMap(map);
            timer1.Enabled = true;
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void 地图1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 0;
        }

        private void 地图2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 1;
        }

        private void timer_Bullet_Tick(object sender, EventArgs e)  //控制子弹移动
        {
            this.Invalidate();
            Game.Instance.BulletMove();
        }

    }
}
