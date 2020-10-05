using RaceAssessment.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceAssessment
{
    public partial class Form1 : Form
    {
        Frog[] frog = new Frog[4];
        Punter[] myPunter = new Punter[3];

        Punter CurrentPunter = new Joel();

        public int PunterNum { get; set; }
        private string FrogWinner;




        public Form1()
        {
            InitializeComponent();
            LoadFrogs();
            LoadPunters();
        }

        private void LoadFrogs()
        {
            //make an instance of our monster
            frog[0] = new Frog { Length = 0, FrogPB = pb1, FrogName = "Bufo" };
            frog[0].FrogPB.Image = Resource1.BufoEdit;
            frog[1] = new Frog { Length = 0, FrogPB = pb2, FrogName = "Kermit" };
            frog[1].FrogPB.Image = Resource1.KermitDone;
            frog[2] = new Frog { Length = 0, FrogPB = pb3, FrogName = "HypnoFrog" };
            frog[2].FrogPB.Image = Resource1.HT;
            frog[3] = new Frog { Length = 0, FrogPB = pb4, FrogName = "Pepe" };
            frog[3].FrogPB.Image = Resource1.Pepe;
        }

        private void LoadPunters()
        {
            for (int i = 0; i < 3; i++)
            {
                myPunter[i] = Factory.GetAPunter(i);

                //  myPunter[i].LabelWinner = lblWinner;

               
            }
                myPunter[0].lblPunter = lblJeff;
                myPunter[1].lblPunter = lblArnald;
                myPunter[2].lblPunter = lblJoel;


        }

        private void RunRace()
        {
            var myrand = new Random();
            bool end = false;

            while (end != true)
            {
                int distance = Form1.ActiveForm.Width - pb1.Width - 30;


                for (int i = 0; i < frog.Length; i++)
                {
                   Application.DoEvents(); //Slows program down enough to allow rnd to be random - seed is millseconds

                    Thread.Sleep(2);


                    frog[i].FrogPB.Left += myrand.Next(10, 15);

                    if (frog[i].FrogPB.Left > distance)
                    {
                        end = true;
                        FrogWinner = frog[i].FrogName;
                        this.Text = FrogWinner;

                        FindWinner(FrogWinner);

                    }


                }




            }


        }
        private void FindWinner(string FrogWinner)
        {
            for (int i = 0; i < 3; i++)
            {
                if (myPunter[i].Frog == FrogWinner)
                {

                    myPunter[i].Balance += myPunter[i].Bet;
                    myPunter[i].lblPunter.Text = FrogWinner + " and " + myPunter[i].PunterName + " Won and now has $"
                        + myPunter[i].Balance;
                }

                else
                {
                    myPunter[i].Balance -= myPunter[i].Bet;
                    myPunter[i].lblPunter.Text = " " + myPunter[i].PunterName + " Lost and now has $"
                        + myPunter[i].Balance;
                }


            }


        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RunRace();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < frog.Length; i++)
            {
                frog[i].FrogPB.Left = 10;
            }
        }

        private void AllRB_Changed(object sender, EventArgs e)
        {
            RadioButton fakeRB = (RadioButton) sender;

            if (fakeRB.Checked) 
            {
            
                
                switch (fakeRB.Text)
                {
                    case "Joel":
                        CurrentPunter = new Joel();
                        break;
                    case "Jeff":
                        CurrentPunter = new Joel();
                        break;
                    case "Arnald":
                        CurrentPunter = new Joel();
                        break;

                }

                PunterNum = Factory.SetPunterNumber(CurrentPunter.PunterName);

                /// cbxParty.SelectedItem = null;
                nudBet.Maximum = (decimal)myPunter[PunterNum].Balance;
                nudBet.Value = (decimal)myPunter[PunterNum].Balance;
            
            
            }

        }
    }
}
