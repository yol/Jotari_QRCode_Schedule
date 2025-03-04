﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using BarcodeScanner.Data;
using BarcodeScanner.DataLookup;
using BarcodeScanner.Scanner;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using log4net;
using log4net.Layout;
using log4net.Config;
using log4net.Appender;

namespace BarcodeScanner
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Window1));

        Dictionary<string, ActivityTimeLine> schedule;

        ICodeReader scanner;
        ExcelDataReader excel;
        DispatcherTimer timer;

        Dictionary<string, ImageSource> activityImages;

        public Window1()
        {
//#if DEBUG
            ConsoleManager.Show(); 
//#endif
            BasicConfigurator.Configure(new FileAppender(new SimpleLayout(), "window.log", true));
            Console.WriteLine("Creating Window");

            activityImages = new Dictionary<string, ImageSource>();

            Loaded += new RoutedEventHandler(Window1_Loaded);
            InitializeComponent();

            Closing += new CancelEventHandler(Window1_Closing);
        }

        void Window1_Closing(object sender, CancelEventArgs e)
        {
            scanner.Stop();
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Window Loaded");

#if DEBUG
            //MessageBox.Show("Welkom bij de JOTARI!");

            //MessageBox.Show("Welkom bij de JOTARI 2!"); 
#endif

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            timer_Tick(null, null);

            Console.WriteLine("Creating ExcelDataReader");

            excel = new ExcelDataReader(@"planning kinderen en leiding.xlsx");

            Console.WriteLine("Creating ZBarInterface");

            scanner = new ZBarInterface();
            scanner.CodeRead += new CodeReadHandler(scanner_CodeRead);

            Console.WriteLine("Starting Scanner");
            scanner.Start();


            Console.WriteLine("Getting schedule from file");
            schedule = excel.GenerateActivityTimeLines(36, 48);//GetSchedule();

            #region fill comboboxes
            for (int k = 1; k <= 36; k++)
            {
                groupSelector.Items.Add("Klein" + k.ToString());
            }
            for (int g = 1; g <= 48; g++)
            {
                groupSelector.Items.Add("Groot" + g.ToString());
            }
            #endregion

            Keyboard.Focus(groupSelector);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            txtNum1.Text = now.Hour.ToString();
            txtNum2.Text = now.Minute.ToString();
        }

        void scanner_CodeRead(string code)
        {
            Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(
                      () => HandleCodeRead(code)));
        }

        private void HandleCodeRead(string idStr)
        {
            string[] parts = idStr.Split(':');
            if (parts[0].ToUpper() == "QR-CODE")
            {
                string id = parts[1];
                DateTime time = SetSelectedDate(DateTime.Now);

                TryDisplayActivity(time, id);
            }
        }

        private DateTime SetSelectedDate(DateTime time)
        {
            string day = (daySelector.SelectedValue as ComboBoxItem).Content.ToString();
            if (day == "Zaterdag")
            {
                time = new DateTime(2011, 10, 15, time.Hour, time.Minute, time.Second);
            }
            else if (day == "Zondag")
            {
                time = new DateTime(2011, 10, 16, time.Hour, time.Minute, time.Second);
            }
            else
            {
                //This means auto, so no change
            }
            return time;
        }

        private void displayActivity(string group, Activity activity)
        {
            //string groupNr = group.Replace("Groot", "");
            //groupNr = group.Replace("Klein", ""); //Remove Klein and Groot
            groupDisplay.Content = group;

            ActivityDisplay.Text = activity.Name;
            SetActivityImage(activity.Name.ToLower());

            try
            {
                ActivityTimeLine atl = schedule[group];

                Activity next = atl[activity.EndTime + new TimeSpan(0, 1, 0)];

                NextActivityDisplay.Text = next.Name;
                NextActivityStartTime.Text = next.StartTime.ToShortTimeString();
            }
            catch (Exception)
            {}

            Keyboard.Focus(groupSelector);
        }

        private Dictionary<string, ActivityTimeLine> GetSchedule()
        {
            Dictionary<string, ActivityTimeLine> schedule = new Dictionary<string, ActivityTimeLine>();

            DataSet set = ExcelDataReader_Old.exceldata(@"schedule.xlsx");

            DataTable klein = set.Tables["Klein"];
            DataRow kleinGroupNrs = klein.Rows[1]; //this is the 2nd filled row

            for (int groupCol = 2; groupCol < kleinGroupNrs.ItemArray.Length; groupCol++) //start from 2, for column C
            {
                ActivityTimeLine atl = ActivityTimeLine.FromDataTable(klein, groupCol);

                string groupNr = kleinGroupNrs[groupCol].ToString();

                schedule.Add("Klein"+groupNr, atl);
            }

            DataTable groot = set.Tables["Groot"];
            DataRow grootGroupNrs = groot.Rows[45]; //this is the 2nd filled row

            for (int groupCol = 2; groupCol < grootGroupNrs.ItemArray.Length; groupCol++) //start from 2, for column C
            {
                ActivityTimeLine atl = ActivityTimeLine.FromDataTable(groot, groupCol);

                string groupNr = grootGroupNrs[groupCol].ToString();

                schedule.Add("Groot" + groupNr, atl);
            }

            return schedule;
        }

        #region UpDownControl
        private void txtNum1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string origTxt = txtNum1.Text;
                int orig = int.Parse(origTxt);
                txtNum1.Text = orig.ToString();
            }
            catch (FormatException)
            {
                txtNum1.Text = (0).ToString();
            }
        }

        private void cmdUp1_Click(object sender, RoutedEventArgs e)
        {
            string origTxt = txtNum1.Text;
            int orig = int.Parse(origTxt);
            orig++;

            if (orig > 23)
            {
                orig = 0;
            }

            txtNum1.Text = orig.ToString();
        }

        private void cmdDown1_Click(object sender, RoutedEventArgs e)
        {
            string origTxt = txtNum1.Text;
            int orig = int.Parse(origTxt);
            orig--;
            if (orig < 0)
            {
                orig = 23;
            }
            txtNum1.Text = orig.ToString();
        }

        private void txtNum2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string origTxt = txtNum2.Text;
                int orig = int.Parse(origTxt);
                txtNum2.Text = orig.ToString();
            }
            catch (FormatException)
            {
                txtNum2.Text = (0).ToString();
            }
        }

        private void cmdUp2_Click(object sender, RoutedEventArgs e)
        {
            string origTxt = txtNum2.Text;
            int orig = int.Parse(origTxt);
            orig++;

            if (orig > 59)
            {
                orig = 0;
            }
            txtNum2.Text = orig.ToString();
        }

        private void cmdDown2_Click(object sender, RoutedEventArgs e)
        {
            string origTxt = txtNum2.Text;
            int orig = int.Parse(origTxt);
            orig--;
            if (orig < 0)
            {
                orig = 59;
            }
            txtNum2.Text = orig.ToString();
        } 
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string hourStr = txtNum1.Text;
            int hour = int.Parse(hourStr);
            string minStr = txtNum2.Text;
            int min = int.Parse(minStr);

            DateTime selected = new DateTime(2011, 10, 15, hour, min, 00);
            DateTime time = SetSelectedDate(selected);

            string groupID = groupSelector.SelectedItem.ToString();

            TryDisplayActivity(time, groupID);
        }

        private void TryDisplayActivity(DateTime time, string groupID)
        {
            log.Info("Showing activity for " + groupID + " at " + time.ToString());

            Activity acti = null;
            try
            {
                ActivityTimeLine atl = schedule[groupID];
                acti = atl[time];
            }
            catch (KeyNotFoundException)
            {
                acti = new Activity("Onbekend, vraag de leiding", new DateTime(), new DateTime(), "");
            }

            Console.Beep();

            displayActivity(groupID, acti);

            string opening = excel.Lookup(26, new DateTime(2011, 10, 15, 9, 50, 00));
            string klimtoren = excel.Lookup(26, new DateTime(2011, 10, 15, 10, 00, 00));
        }

        private void SetActivityImage(string activity)
        {
            if(activityImages.ContainsKey(activity))
            {
                ActivityImage.Source = activityImages[activity];
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(@"Images/png/");
                Console.WriteLine("Getting images from: ", dir.FullName);
                var files = dir.GetFiles(activity+".png", SearchOption.TopDirectoryOnly);

                if (files.Length >= 1)
                {
                    string fileName = files[0].FullName;
                    ImageSource src = new BitmapImage(new Uri(fileName));

                    activityImages[activity] = src;

                    ActivityImage.Source = src;
                }
                else
                {
                    ActivityImage.Source = null;
                }
            }
        }

        private void KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, null);
            }
        }
    }
}
