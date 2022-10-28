using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timers
{
    public partial class Form1 : Form
    {

        Timer timer;
        Timer timerUpdate;
        public Form1()
        {
            timer = new Timer();
            timerUpdate = new Timer();
            timer.Tick += new EventHandler(ShouTimer);
            timerUpdate.Tick += new EventHandler(UpdateValueTimer);
            timerUpdate.Interval = 1000;
            timerUpdate.Enabled = false;
            timer.Enabled = false;
            InitializeComponent();
            button2.Enabled = false;
        }

        private void UpdateValueTimer(object sender, EventArgs e)
        {
            if(numericUpDown1.Value - 1 >= numericUpDown1.Minimum)
            {
                var value = numericUpDown1.Value--;
                //value--;
                //numericUpDown1.Value = value;
            }
            
        }

        private void ShouTimer(object sender, EventArgs e)
        {
            timer.Stop();
            
            button2.Enabled = false;
            button1.Enabled = true;
            MessageBox.Show("Таймер закончил работать", "Таймер");
            stopUpdateTimer();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            
            try
            {
                timer.Interval = (int)numericUpDown1.Value * 1000;
                timer.Enabled = true;
                timerUpdate.Enabled = true;
                timer.Start();
                timerUpdate.Start();
                button1.Enabled = false;
                button2.Enabled = true;
                
                

            }
            catch
            {
                MessageBox.Show("Error");
            }

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            
            button2.Enabled = false;
            button1.Enabled = true;
            MessageBox.Show("Таймер остановил работу", "Таймер");
            stopUpdateTimer();
        }
        private void stopUpdateTimer()
        {
            timerUpdate.Enabled = false;
            timerUpdate.Stop();
            //numericUpDown1.Value = 0;
        }

    }

}
