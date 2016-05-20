using Snake.Logic;
using Snake.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeWPFUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SnakeGame game;
        System.Windows.Forms.Timer stepTimer;
        UIElementCollection cells;

        public MainWindow()
        {
            InitializeComponent();
            cells = AreaGrid.Children;

            int rows = 23;
            int columns = 51;

            AreaGrid.Rows = rows;
            AreaGrid.Columns = columns;
            SetBackground(AreaGrid, "Black");

            DrawRegion(rows, columns);

            game = new SnakeGame();
            game.Draw += this.Draw;

            stepTimer = new System.Windows.Forms.Timer();
            stepTimer.Interval = 200;
            stepTimer.Enabled = false;
            stepTimer.Tick += OnStepTimer;
        }

        private void DrawRegion(int rows, int columns)
        {
            for (int y = 0; y < rows; y++)
                for (int x = 0; x < columns; x++)
                    AreaGrid.Children.Add(CreateSectionCanvas(y, x));
        }

        private Canvas CreateSectionCanvas(int y, int x)
        {
            Canvas section = new Canvas();
            section.Name = "Section_" + y.ToString() + "_" + x.ToString();
            section.Margin = new Thickness(1);
            SetBackground(section, "White");

            return section;
        }

        private void SetBackground(Panel control, string color)
        {
            control.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
        }

        private void OnStepTimer(object sender, EventArgs e)
        {
            game.Step();

            if (game.State == GameState.End)
            {
                stepTimer.Stop();
                MessageBox.Show("The End");
            }
        }

        private void Draw(Snake.Logic.Point point, Item item)
        {
            string color;
            switch (item)
            {
                case Item.Border: color = "red"; break;
                case Item.Prize: color = "green"; break;
                case Item.SnakeSegment: color = "black"; break;
                case Item.Zerro: color = " white"; break;
                default: color = "white"; break;
            }

            foreach(Canvas c in cells)
            {
                if(c.Name == ("Section_" + point.Y + "_" + point.X))
                {
                    SetBackground(c, color);
                }
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            foreach (Canvas i in cells)
                SetBackground(i, "white");
            game.Initialization();
            game.Start();
            stepTimer.Start();
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Up: game.Instruction(Direction.Up); break;
                case Key.Down: game.Instruction(Direction.Down); break;
                case Key.Left: game.Instruction(Direction.Left); break;
                case Key.Right: game.Instruction(Direction.Right); break;
            }
        }
    }
}
