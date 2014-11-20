using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarOfTank.Base.Bullet;
namespace WarOfTank.Base
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left,
    }
   public abstract class Element
   {
      
       public Element(int x, int y)
       {
           this.posX = x;
           this.posY = y;
           this.Blood = 1;
       }

        #region 属性
        protected int posX, posY;   //位置    
        protected int blood;        //血量
        protected bool isDead = false;

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
        public  int Blood
        {
            get { return blood; }
            set { blood = value; }
        }
        protected int speed;        //移动速度
        protected Image image;      //外观图片
        public static int width;    //显示图片的宽度
        protected IImpactBehavior imp;  //碰撞行为
        protected Direction direction;  //方向

        public Direction EleDirection   //只读属性
        {
            get { return direction; }
        }
        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        /// <summary>
        /// 显示区域的宽度
        /// </summary>
        public static int Width
        {
            get { return width; }
            set { width = value; }
        }
       #endregion
        #region 基本公共方法
        /// <summary>
       /// 在指定位置绘制图片
       /// </summary>
       /// <param name="g">画布</param>
       /// <param name="Rect">位置</param>
       /// <param name="imageName">图片名称</param>
        public void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle(this.posX * width, this.posY * width + 20, width, width);
            g.DrawImage(image, rect);
        }
 
       /// <summary>
       /// 爆炸方法
       /// </summary>
        public virtual void Boom()
        {
            
            this.image = Image.FromFile("BMP/explode2.bmp");
        }
        #endregion

        #region 需要子类实现的方法

        /// <summary>
        /// 撞击行为
        /// </summary>
        public void Impact()
        {
            imp.Impact(this);
        }

        public virtual void Move()
        { }
        public virtual void setDirection(Direction dir)
        { }
        public virtual Element shot()
        { return null; }
        #endregion
    }
}
