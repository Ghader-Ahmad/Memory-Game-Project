using Memory_Game_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Random rand = new Random();

        short Counter = 0;
        Button CurrentButton;

        struct stGameDetails
        {
           public short Time;
           public byte Score;
           public byte Moves;
           public Button FisrtMove;
           public Button PreviousMove;
        }

        stGameDetails GameDetails;
        private int RandomNumber(int From, int To)
        {
            return rand.Next(From, To);
        }

        private void FillArrayWithOrderedNumber(short[,]array, short Rows, short Cols)
        {
            short Counter = 1;
            for (int i = 0; i < Rows; i++)
            {
                for (int j =0; j < Cols; j++)
                {
                    array[i,j] = Counter;
                    
                    Counter++;
                }
            }
        }

        private void SwapTwoNumbers(ref short Num1, ref short Num2)
        {
            short temp = Num1;
            Num1 = Num2;
            Num2 = temp;
        }

        private void ShuffleArray(short[,] array, short Rows, short Cols)
        {
            for (int i = 0; i < Rows * Cols; i++)
            {
                SwapTwoNumbers(ref array[RandomNumber(0, Rows), RandomNumber(0, Cols)],
                    ref array[RandomNumber(0, Rows), RandomNumber(0, Cols)]);
            }
        }

        private void SetTagInTheButtons()
        {
            short[,] Matrix = new short[4, 7];

            FillArrayWithOrderedNumber(Matrix, 4, 7);
            ShuffleArray(Matrix, 4, 7);

            short Index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (Index == 14)
                        Index = 0;

                    string btn = "btn" + Matrix[i, j];
                    Button button = panel1.Controls[btn] as Button;

                    button.Tag = Index;

                    Index++;
                }
            }
        }

        private void DisaplyImagesForThreeMinutes()
        {
            for (int i = 1; i <= 28; i++)
            {
                string btn = "btn" + i;
                Button button = panel1.Controls[btn] as Button;

                button.ImageIndex = Convert.ToByte(button.Tag);
            }
            Counter = 1;
            TimerForDisplayImagesInStart.Enabled = true;
        }

        private void ReturnThePhotoAfterThreeMinutes()
        {
            for (int i = 1; i <= 28; i++)
            {
                string btn = "btn" + i;
                Button button = panel1.Controls[btn] as Button;

                button.ImageIndex = Flowers.Images.Count - 1;
            }
        }


        private void UpdateGameDetailsAfterMatchingOrEndOfTime()
        {
            TimerAfterEachClick.Enabled = false;
            GameDetails.PreviousMove = null;
            GameDetails.FisrtMove = null;
            Counter = 5;
        }

        private void AfterTheTwoPicturesMatch(Button CurrebtOption, Button PreviousOption)
        {
            CurrebtOption.ImageIndex = CurrebtOption.ImageIndex;
            PreviousOption.ImageIndex = CurrebtOption.ImageIndex;
            SystemSounds.Asterisk.Play();
            GameDetails.Score++;

            UpdateGameDetailsAfterMatchingOrEndOfTime();
        }

        private void Check(Button CurrebtOption, Button PreviousOption)
        {
            if (PreviousOption == null)
                return;

            if (Convert.ToByte(CurrebtOption.Tag) == Convert.ToByte(PreviousOption.Tag) && (CurrebtOption != PreviousOption))
            {
                AfterTheTwoPicturesMatch(CurrebtOption, PreviousOption);
            }
        }


        
        private void UpdateGameDetailsAfterEachClick()
        {
            GameDetails.Moves++;
            GameDetails.PreviousMove = GameDetails.FisrtMove;
            GameDetails.FisrtMove = CurrentButton;
        }

        private void FirstStep()
        {
            TimerAfterEachClick.Enabled = true;
            Counter = 5;
            CurrentButton.ImageIndex = Convert.ToByte(CurrentButton.Tag);
        }

        private void UpdateLabelInUserInterface()
        {
            lblScore.Text = GameDetails.Score.ToString();
            lblMoves.Text = GameDetails.Moves.ToString();
        }

        private void UpdateUserInterfaceAfterEachClick()
        {
            FirstStep();
            UpdateGameDetailsAfterEachClick();
            Check(GameDetails.FisrtMove, GameDetails.PreviousMove);
            UpdateLabelInUserInterface();
        }

        private void LoadCurrentButtonAndStart()
        {
            if (CurrentButton.ImageIndex == Flowers.Images.Count - 1)
            {
                UpdateUserInterfaceAfterEachClick();
            }

            else
                return;
        }



        private void ReturnTheButtonToItsOriginalState()
        {
            GameDetails.FisrtMove.ImageIndex = Flowers.Images.Count - 1;

            //I set this condition because the user is expected to click one click within
            //the specified time, not two clicks...

            if (GameDetails.PreviousMove != null)
                GameDetails.PreviousMove.ImageIndex = Flowers.Images.Count - 1;
        }

        private void UpdateGameDetailsAfterTheTimerStopsAfterEachClick()
        {
            ReturnTheButtonToItsOriginalState();
            UpdateGameDetailsAfterMatchingOrEndOfTime();
        }



        private void ThePlayerLossesTheGame()
        {
            TimerGame.Enabled = false;

            GameDetails.Time = 0;
            if (MessageBox.Show("Game Over, Play Again?", "Game Over :", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MessageBox.Show("Please enter on restart");
            }
        }

        private void CheckThePlayerWin()
        {
            if (GameDetails.Score == 14)
            {
                TimerGame.Enabled = false;
                SystemSounds.Beep.Play();
                MessageBox.Show("Congratulations You Win");
            }
        }

        private void UpdateUserInterfaceAfterEnterStartGame()
        {
            CheckThePlayerWin();

          

            if (GameDetails.Time < 10)
            {
                lblTime.ForeColor = Color.Red;
            }
        }


        private void UpdateControlsAfterStartGame()
        {
            GameDetails.Time = Convert.ToInt16(lblTime.Text);

            TimerGame.Enabled = true;

            panel1.Visible = true;
            btnExist.Visible = true;
            btnRestart.Visible = true;
            btnPause.Visible = true;
            btnStart.Visible = false;
        }
       
        private void StartGame()
        {
            DisaplyImagesForThreeMinutes();
            UpdateControlsAfterStartGame();
        }

        private void ResetLabel()
        {
            lblMoves.Text = "0";
            lblScore.Text = "0";
            lblTime.Text = "120";
            lblTime.ForeColor = Color.Purple;
        }

        private void ResetButtons()
        {
            TimerGame.Enabled = false;
            btnStart.Visible = true;
            btnPause.Visible = false;
            btnRestart.Visible = false;
            btnExist.Visible = false;
        }

        void ResetControls()
        {
            ResetButtons();
            ResetLabel();
            ReturnThePhotoAfterThreeMinutes();
            SetTagInTheButtons();
        }

        private void Restart()
        {
            GameDetails = new stGameDetails();
            ResetControls();
        }
            
        private void SaveTimeAfterUpdateIt()
        {
            lblTime.Text = numericUpDown1.Value.ToString();
            pUpdateTime.Visible = false;
        }




        private void Form2_Load(object sender, EventArgs e)
        {
            SetTagInTheButtons();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CurrentButton = (Button)sender;
            LoadCurrentButtonAndStart();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            TimerGame.Enabled = false;
            this.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (TimerGame.Enabled)
            {
                TimerGame.Enabled = false;
                panel1.Enabled = false;
            }

            else
            {
                panel1.Enabled = true;
                TimerGame.Enabled = true;
            }
        }

        private void TimerAfterEachClick_Tick(object sender, EventArgs e)
        {
            if (Counter > 0)
            {
                --Counter;
            }
            else
            {
                UpdateGameDetailsAfterTheTimerStopsAfterEachClick();
            }
        }

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            if (GameDetails.Time > 0)
            {
                lblTime.Text = GameDetails.Time.ToString();
                GameDetails.Time--;
                UpdateUserInterfaceAfterEnterStartGame();
            }
            else 
            {
                TimerGame.Enabled = false;
                ThePlayerLossesTheGame();
            }
        }

        private void TimerForDisplayImagesInStart_Tick(object sender, EventArgs e)
        {
            if (Counter > 0)
                Counter--;

            else
            {
                TimerForDisplayImagesInStart.Enabled = false;
                ReturnThePhotoAfterThreeMinutes();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void lblTime_DoubleClick(object sender, EventArgs e)
        {
            pUpdateTime.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTimeAfterUpdateIt();
        }
    }
}
