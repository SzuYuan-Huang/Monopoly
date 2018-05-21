using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Player
    {
        private Bitmap imagerecord;
        private int block_index;
        private int blood;
        private int attack;
        private int armor;
        private bool skill_used;
        private Point location;
        private PlayerState state;
        private PictureBox image;
        private string imagestring;

        public Player(string path)
        {
            BlockIndex = 0;
            blood = 8000;
            attack = 500;
            armor = 0;
            imagestring = path;
            skill_used = false;
            state = PlayerState.Normal;
            image = new PictureBox();
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(50, 50);
            image.Load(path);
            imagerecord = new Bitmap(path); 
        }

        public int BlockIndex
        {
            get { return block_index; }
            set { block_index = (value < 0 ? 0 : value); }
        }

        public int Blood
        {
            get { return blood; }
            set { blood = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public bool SkillUsed
        {
            get { return skill_used; }
            set { skill_used = value; }
        }

        public Point Location
        {
            get { return location; }
            set 
            {
                location = value;
                image.Location = new Point(location.X + 578, location.Y + 45);
            }
        }

        public PlayerState State
        {
            get { return state; }
            set { state = value; }
        }

        public PictureBox Image
        {
            get { return image; }
        }

        public string ImageString
        {
            get { return imagestring; }
        }

        public Bitmap ImageRecord
        {
            get { return imagerecord; }
        }

        public virtual void Skill(ref Player[]players)
        {

        }

    }
}
