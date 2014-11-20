using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarOfTank.Base;
using WarOfTank.Base.Tank;
using WarOfTank.Base.Factory;
using WarOfTank.Base.Bullet;
using WarOfTank.Base.Barrier;
namespace WarOfTank
{
   public class Game  //此类为一个单例类，用于处理游戏的运行
    {
        private static Game instance = null;    //单例实体
        private Barrier[,] map;               //障碍物数组
        private const int CROSS = 13;                    //格数
        private static int width;           //每一格的宽度
        private Element p1Tank;  //定义坦克字段
        private List<Bullet> bullets = new List<Bullet>();  //存放子弹对象 
        private List<PlayerTank> playerTanks = new List<PlayerTank>();  //存放坦克对象 
        private List<EnemyTank> enemyTanks = new List<EnemyTank>();  //存放坦克对象 
        private IFactory tankFactory = new PlayerTankFactory();
        private IFactory enemyFactory = new EnemyTankFactory();
        private const int ENEMYCOUNT=5;          //电脑坦克最大数量
        private int enemyCount;                 //记录当前电脑数量
      //  private bool IsStart;                   //是否开始游戏
        public Element P1Tank
        {
            get { return p1Tank; }
            set { p1Tank = value; }
        }

        public static int Width
        {
            get { return Game.width; }
            set { Game.width = value; }
        }

        public static Game Instance         //构造单例实体
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return Game.instance;
            }
        }
        private Game()
            {
                //const int VERTICAL = 13;              //纵向格数
                Element.width = width;              //每一格的宽度
                map = new Barrier[CROSS, CROSS];    //定义游戏数组
                p1Tank = tankFactory.factory(TankType.PlayerTank, 10, 10);
                AddElement(p1Tank);
            }
        #region 公共方法
        /// <summary>
       /// 添加对象
       /// </summary>
       /// <param name="e">要添加的对象</param>
        public void AddElement(Element e)
        {
            if (e is Bullet)
            {
                bullets.Add(e as Bullet);
            }
            else if (e is PlayerTank)
            {
                playerTanks.Add(e as PlayerTank);
            }
            else if (e is EnemyTank)
            {
                enemyTanks.Add(e as EnemyTank);
            }
            else if (e != null)
            {
                map[e.PosX, e.PosY] = e as Barrier;
            }
            
        }
       /// <summary>
       /// 删除对象
       /// </summary>
       /// <param name="e"></param>
        public void RemoveElement(Element e)
        {
            if (e is Bullet)
            {
                bullets.Remove(e as Bullet);
            }
            else if (e is PlayerTank)
            {
                playerTanks.Remove(e as PlayerTank);
            }
            else if (e is EnemyTank)
            {
                enemyTanks.Remove(e as EnemyTank);
            }
            else if (e!=null)
            {
                map[e.PosX, e.PosY] = null;
            }
            
        }
     
       /// <summary>
       /// 遍历各个对象并调用对象的draw方法
       /// </summary>
       /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            for (int i = 0; i < bullets.Count; i++) //绘制子弹
            {
                if (bullets[i] != null && !IsDead(bullets[i]))
                {
                    bullets[i].Draw(g);
                }
            }

      
            for (int i = 0; i < playerTanks.Count; i++) //绘制玩家坦克
            {
                if (playerTanks[i] != null && !IsDead(playerTanks[i]))
                {
                    playerTanks[i].Draw(g);
                }
            }
            for (int i = 0; i < enemyTanks.Count; i++) //绘制敌方坦克
            {
                if (enemyTanks[i] != null && !IsDead(enemyTanks[i]))
                {
                    enemyTanks[i].Draw(g);
                }

            }
            foreach (Element ele in map)//画地图
            {
                if (ele != null && !IsDead(ele))
                {
                    ele.Draw(g);
                }
            }
            
        }
       /// <summary>
       /// 能自动移动的坦克的控制
       /// </summary>
        public void TankMove()
        {
            for (int i = 0; i < enemyTanks.Count; i++)
            {
                if (!IsCanMove(enemyTanks[i]))
                {
                    enemyTanks[i].NewDirection();
                    return;
                }
                else
                {
                    enemyTanks[i].Move();
                }
                Random r = new Random();
                int isFire = r.Next(0, 8);
                EnemyBullet enemyBullet;
                if (isFire==0)
                {
                    enemyBullet = (EnemyBullet)enemyTanks[i].shot();
                    AddElement(enemyBullet);
                }
            }
        }
       /// <summary>
       /// 子弹自动移动的控制
       /// </summary>
        public void BulletMove()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                HitCheck(bullets[i]);
                if (!IsCanMove(bullets[i]))
                {
                    RemoveElement(bullets[i]);  //如果子弹射出画面则移除子弹
                }
                else
                {
                    bullets[i].Move();
                }
            }
        }
        /// <summary>
        /// 键盘按下事件处理
        /// </summary>
        /// <param name="e"></param>
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        if (p1Tank.PosY == 0 || !IsCanMove(p1Tank)) { }    //遇到边界或障碍则不动
                        else if (p1Tank.EleDirection == Direction.Up)     //方向与原方向相同才移动
                            p1Tank.Move();
                        p1Tank.setDirection(Direction.Up);          //调整方向
                    } break;

                case Keys.S:
                    {
                        if (p1Tank.PosY == CROSS - 1 || !IsCanMove(p1Tank)) { }    //遇到边界或障碍则不动
                        else if (p1Tank.EleDirection == Direction.Down)     //方向与原方向相同才移动
                            p1Tank.Move();
                        p1Tank.setDirection(Direction.Down);          //调整方向
                    } break;
                case Keys.A:
                    {
                        if (p1Tank.PosX == 0 || !IsCanMove(p1Tank)) { }    //遇到边界或障碍则不动
                        else if (p1Tank.EleDirection == Direction.Left)     //方向与原方向相同才移动
                            p1Tank.Move();
                        p1Tank.setDirection(Direction.Left);          //调整方向
                    } break;
                case Keys.D:
                    {
                        if (p1Tank.PosX == CROSS - 1 || !IsCanMove(p1Tank)) { }    //遇到边界或障碍则不动
                        else if (p1Tank.EleDirection == Direction.Right)     //方向与原方向相同才移动
                            p1Tank.Move();
                        p1Tank.setDirection(Direction.Right);          //调整方向
                    } break;
                case Keys.Enter:
                    {
                        this.AddElement(p1Tank.shot());
                        //this.AddElement(bulletFactory.factory(BulletType.PlayerBullet, p1Tank.PosX, p1Tank.PosY, p1Tank.EleDirection));
                    } break;
                default:
                    break;
            }

        }
       /// <summary>
       /// 设置电脑坦克
       /// </summary>
        public void SetEnemy()
        {
            if (enemyCount < ENEMYCOUNT)
            {
                EnemyTank eTank1 = (EnemyTank)enemyFactory.factory(TankMod.Mod1, 0, 0);
                EnemyTank eTank2 = (EnemyTank)enemyFactory.factory(TankMod.Mod2, 5, 0);
                this.AddElement(eTank1);
                this.AddElement(eTank2);
                enemyCount += 2;
            }

        }
        /// <summary>
        /// 玩家是否胜利
        /// </summary>
        /// <returns>玩家胜利则返回true</returns>
        public bool IsWin()
        {
            if (enemyTanks.Count == 0 && enemyCount >= ENEMYCOUNT)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 玩家是否失败
        /// </summary>
        /// <returns>玩家失败返回true</returns>
        public bool IsLose()
        {
            if (playerTanks.Count == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 重置game对象
        /// </summary>
        public void ReStart()
        {
            instance = new Game();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 检测对象是否死亡,如死亡则移除
        /// </summary>
        /// <param name="ele">要检测的对象</param>
        private bool IsDead(Element ele)
        {
            if (ele.Blood <= 0)
            {
                ele.Boom();
                if (ele is Bullet)  //子弹直接爆炸
                {
                    this.RemoveElement(ele);
                    return true;
                }
                if (ele.IsDead)
                {
                    this.RemoveElement(ele);
                    return true;
                }
                ele.IsDead = true;
                return false;
            }
            return false;
        }
       /// <summary>
       /// 检查对象是否可以继续移动
       /// </summary>
       /// <param name="ele">要检查的对象</param>
       /// <returns>如果可以移动返回true</returns>
        private bool IsCanMove(Element ele)
        {
            if (ele is Bullet)
            {
                switch (ele.EleDirection)
                {
                    case Direction.Up:
                        if (ele.PosY <= 0 )
                            return false;
                        break;
                    case Direction.Down:
                        if (ele.PosY >= CROSS - 1 )
                            return false;
                        break;
                    case Direction.Right:
                        if (ele.PosX >= CROSS - 1 )
                            return false;
                        break;
                    case Direction.Left:
                        if (ele.PosX <= 0 )
                            return false;
                        break;
                    default:
                        break;
                }
                return true;
            }
            if (ele.IsDead)
            {
                return false;
            }
            switch (ele.EleDirection)
            {
                case Direction.Up:
                    if (ele.PosY <= 0 || map[ele.PosX, ele.PosY - 1] != null && map[ele.PosX, ele.PosY - 1].IsCanCross==false)
                        return false;
                    break;
                case Direction.Down:
                    if (ele.PosY >= CROSS - 1 || map[ele.PosX, ele.PosY + 1] != null && map[ele.PosX, ele.PosY + 1].IsCanCross == false)
                        return false;
                    break;
                case Direction.Right:
                    if (ele.PosX >= CROSS - 1 || map[ele.PosX + 1, ele.PosY] != null && map[ele.PosX + 1, ele.PosY].IsCanCross == false)
                        return false;
                    break;
                case Direction.Left:
                    if (ele.PosX <= 0 || map[ele.PosX - 1, ele.PosY] != null && map[ele.PosX - 1, ele.PosY].IsCanCross == false)
                        return false;
                    break;
                default:
                    break;
            }
            return true;
        }
       /// <summary>
       /// 检测并处理子弹的撞击事件
       /// </summary>
       /// <param name="bullet">要检测的子弹</param>
        private void HitCheck(Bullet bullet)
        {
            for (int i = 0; i < playerTanks.Count; i++) //检测是否碰撞到玩家坦克
            {
                if (playerTanks[i].PosX==bullet.PosX && playerTanks[i].PosY==bullet.PosY)
                {
                    if (bullet is EnemyBullet&&playerTanks[i] is PlayerTank)
                    {
                        playerTanks[i].Impact();
                        bullet.Impact();
                    }

                }
            }
            for (int i = 0; i < enemyTanks.Count; i++) //检测是否碰撞到电脑坦克
            {
                if (enemyTanks[i].PosX == bullet.PosX && enemyTanks[i].PosY == bullet.PosY)
                {
                    if (bullet is PlayerBullet && enemyTanks[i] is EnemyTank)
                    {
                        enemyTanks[i].Impact();
                        bullet.Impact();
                    }
                }
            }
            foreach (Barrier ele in map)    //检测是否碰撞到障碍物
            {
                if (ele!=null&&!ele.IsCanCross&&ele.PosX==bullet.PosX&&ele.PosY==bullet.PosY)
                {
                    ele.Impact();
                    bullet.Impact();
                }

            }
        }
        #endregion

    }
}
