using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class MainForm : Form
    {
        private GameField _gameField;

        public MainForm()
        {
            InitializeComponent();
            _gameField = new GameField();
            panelMainWindow.Controls.Add(_gameField.gameFieldControl);
            timer_updSnake.Enabled = true;
        }



        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void timer_updSnake_Tick(object sender, EventArgs e)
        {
            _gameField.Update();
            
        }
    }
}
