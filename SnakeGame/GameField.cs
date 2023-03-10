using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class GameField
    {
        private PictureBox _gameFieldControl;


        private Snake.Snake _snake;

        public Snake.Snake Snake
        {
            get 
            { 
                return _snake; 
            }

        }

        public PictureBox gameFieldControl
        {
            get { return _gameFieldControl; }
        }

        public GameField()
        {
            _gameFieldControl = new PictureBox();
            _gameFieldControl.BackColor = Color.LightGray;
            _gameFieldControl.Dock = DockStyle.Fill;
            _gameFieldControl.Paint += _gameFieldControl_Paint;

            _snake = new Snake.Snake();
        }

        private void _gameFieldControl_Paint(object sender, PaintEventArgs e)
        {
            _snake.Draw(e.Graphics);
        }

        public void Update() 
        {
            _snake.Move();
            _gameFieldControl.Refresh();

        }

    }
}
