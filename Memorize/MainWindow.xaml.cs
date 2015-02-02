using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Memorize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Storyboard white1Pressed; //1
        Storyboard white2Pressed; //2
        Storyboard white3Pressed; //3
        Storyboard white4Pressed; //4
        Storyboard white5Pressed; //5 
        Storyboard white6Pressed; //6

        int secondw6 = 0;
        int secondb4 = 0;

        int sec = 0;
        int min = 0;

        int w6alreadyPassed = 0; //postoje tipke koje se u izu klik. vise puta.
        int b4alreadyPassed = 0;

        //Storyboard playMessage;

        List<int> playLevel1 = new List<int> { 2 };  //Ovako je def. sekvenca, tesko je proiz. zbog animacije.
        List<int> playLevel2 = new List<int> { 2, 6 };
        List<int> playLevel3 = new List<int> { 2, 6, 4 };
        List<int> playLevel4 = new List<int> { 2, 6, 4, 8 };
        List<int> playLevel5 = new List<int> { 2, 6, 4, 8, 6 };
        List<int> playLevel6 = new List<int> { 2, 6, 4, 8, 6, 10 };
        List<int> playLevel7 = new List<int> { 2, 6, 4, 8, 6, 10, 5 };
        List<int> playLevel8 = new List<int> { 2, 6, 4, 8, 6, 10, 5, 7 };
        List<int> playLevel9 = new List<int> { 2, 6, 4, 8, 6, 10, 5, 7, 11 };
        List<int> playLevel10 = new List<int> { 2, 6, 4, 8, 6, 10, 5, 7, 11, 10 };

        List<int> userLevel1;
        List<int> userLevel2;
        List<int> userLevel3;
        List<int> userLevel4;
        List<int> userLevel5;
        List<int> userLevel6;
        List<int> userLevel7;
        List<int> userLevel8;
        List<int> userLevel9;
        List<int> userLevel10;

        Storyboard black1Pressed; //7
        Storyboard black2Pressed; //8
        Storyboard black3Pressed; //9
        Storyboard black4Pressed; //10
        Storyboard black5Pressed; //11

        Storyboard mistake;
        Storyboard dancingStar;     //kad korisnik "obori" score zvijezda "treperi"
        Storyboard enable;
        Storyboard disable;
        Storyboard dancingClock; //nakon isteka min animiraj!

        DispatcherTimer w2Timer = new DispatcherTimer();
        DispatcherTimer w26Timer = new DispatcherTimer(); //napravi pauzu izmedju klik posebnih tipki, kako ne bi isle simultano
        DispatcherTimer w64Timer = new DispatcherTimer();
        DispatcherTimer w48Timer = new DispatcherTimer();
        DispatcherTimer w86Timer = new DispatcherTimer();
        DispatcherTimer w610Timer = new DispatcherTimer();
        DispatcherTimer w105Timer = new DispatcherTimer();
        DispatcherTimer w57Timer = new DispatcherTimer();
        DispatcherTimer w711Timer = new DispatcherTimer();
        DispatcherTimer w1110Timer = new DispatcherTimer();
        DispatcherTimer mistakeTimer = new DispatcherTimer();
        DispatcherTimer disableTimer = new DispatcherTimer();
        DispatcherTimer enableTimer = new DispatcherTimer();


        DispatcherTimer w6Timer = new DispatcherTimer(); //ovi tajmeri obezbijedjuju da cp ne pocne svirati ranije (zbog efekata koji traju)
        DispatcherTimer w4Timer = new DispatcherTimer();
        DispatcherTimer b2Timer = new DispatcherTimer();
        DispatcherTimer b4Timer = new DispatcherTimer();
        DispatcherTimer w5Timer = new DispatcherTimer();
        DispatcherTimer b1Timer = new DispatcherTimer();
        DispatcherTimer b5Timer = new DispatcherTimer();

        DispatcherTimer endTimer = new DispatcherTimer(); 
        DispatcherTimer elapsedTimer = new DispatcherTimer(); //tajmer vezan za time labelu, daje elapsed time 
        
        DateTime start;
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Memorize";

            //inicijalizuj tajmere za posljendje tipke u nizu 
            w2Timer.Tick += new EventHandler(w2Timer_Tick);
            w2Timer.Interval = new TimeSpan(0, 0, 2); 

            w6Timer.Tick += new EventHandler(w6Timer_Tick);
            w6Timer.Interval = new TimeSpan(0, 0, 3); 

            w4Timer.Tick += new EventHandler(w4Timer_Tick);
            w4Timer.Interval = new TimeSpan(0, 0, 3); 

            b2Timer.Tick += new EventHandler(b2Timer_Tick);
            b2Timer.Interval = new TimeSpan(0, 0, 3);

            b4Timer.Tick += new EventHandler(b4Timer_Tick);
            b4Timer.Interval = new TimeSpan(0, 0, 3); 

            w5Timer.Tick += new EventHandler(w5Timer_Tick);
            w5Timer.Interval = new TimeSpan(0, 0, 3); 

            b1Timer.Tick += new EventHandler(b1Timer_Tick);
            b1Timer.Interval = new TimeSpan(0, 0, 3);

            b5Timer.Tick += new EventHandler(b5Timer_Tick);
            b5Timer.Interval = new TimeSpan(0, 0, 3); 

            //-----------------------------------------------------------

            w26Timer.Tick += new EventHandler(w26Timer_Tick);
            w26Timer.Interval = new TimeSpan(0, 0, 2);

            w64Timer.Tick += new EventHandler(w64Timer_Tick);
            w64Timer.Interval = new TimeSpan(0, 0, 2);

            w48Timer.Tick += new EventHandler(w48Timer_Tick);
            w48Timer.Interval = new TimeSpan(0, 0, 2);

            w86Timer.Tick += new EventHandler(w86Timer_Tick);
            w86Timer.Interval = new TimeSpan(0, 0, 2);

            w610Timer.Tick += new EventHandler(w610Timer_Tick);
            w610Timer.Interval = new TimeSpan(0, 0, 2);

            w105Timer.Tick += new EventHandler(w105Timer_Tick);
            w105Timer.Interval = new TimeSpan(0, 0, 2);

            w57Timer.Tick += new EventHandler(w57Timer_Tick);
            w57Timer.Interval = new TimeSpan(0, 0, 2);

            w711Timer.Tick += new EventHandler(w711Timer_Tick);
            w711Timer.Interval = new TimeSpan(0, 0, 2);

            w1110Timer.Tick += new EventHandler(w1110Timer_Tick);
            w1110Timer.Interval = new TimeSpan(0, 0, 2);

            endTimer.Tick += new EventHandler(endTimer_Tick);
            endTimer.Interval = new TimeSpan(0, 0, 2);

            disableTimer.Tick += new EventHandler(disableTimer_Tick);

            enableTimer.Tick += new EventHandler(enableTimer_Tick);
            enableTimer.Interval = new TimeSpan(0, 0, 5, 0);

            mistakeTimer.Tick += new EventHandler(mistakeTimer_Tick);
            mistakeTimer.Interval = new TimeSpan(0, 0, 0, 6, 500);
            //-----------------------------------------------------------------------------------------

            elapsedTimer.Interval = new TimeSpan(0, 0, 0,1, 0);
            elapsedTimer.Tick += new EventHandler(elapsedTimer_Tick);

            this.level.Content = "1";
            this.bestTime.Content = "";
            this.messageToUser.Content = "Computer is playing.";

            white1.Click += white1_Click;
            white2.Click += white2_Click;
            white3.Click += white3_Click;
            white4.Click += white4_Click;
            white5.Click += white5_Click;
            white6.Click += white6_Click;

            black1.Click += black1_Click;
            black2.Click += black2_Click;
            black3.Click += black3_Click;
            black4.Click += black4_Click;
            black5.Click += black5_Click;

            //incijalizuj storyboards
            white1Pressed = (Storyboard)this.Resources["white1Pressed"];
            white2Pressed = (Storyboard)this.Resources["white2Pressed"];
            white3Pressed = (Storyboard)this.Resources["white3Pressed"];
            white4Pressed = (Storyboard)this.Resources["white4Pressed"];
            white5Pressed = (Storyboard)this.Resources["white5Pressed"];
            white6Pressed = (Storyboard)this.Resources["white6Pressed"];

            black1Pressed = (Storyboard)this.Resources["blackPressed"];
            black2Pressed = (Storyboard)this.Resources["black2Pressed"];
            black3Pressed = (Storyboard)this.Resources["black3Pressed"];
            black4Pressed = (Storyboard)this.Resources["black4Pressed"];
            black5Pressed = (Storyboard)this.Resources["black5Pressed"];

            mistake = (Storyboard)this.Resources["mistake"];
            dancingStar = (Storyboard)this.Resources["dancingStar"]; //za nju ne treba tajmer, nije vezana ni za sta drugo
            dancingClock = (Storyboard)this.Resources["dancingClock"];

            enable = (Storyboard)this.Resources["enable"];
            disable = (Storyboard)this.Resources["disable"];
            //-----------------------------------------------------------------------------------------
            initializeUserLists();

            playLevel(1); //kad tek loadujes prvi nivo
        }

        private void endTimer_Tick(object sender, EventArgs e)
        {
            endTimer.Stop();
            playLevel(1);
        }

        private void b5Timer_Tick(object sender, EventArgs e)
        {
            b5Timer.Stop();
            b5Check();
        }

        private void b1Timer_Tick(object sender, EventArgs e)
        {
            b1Timer.Stop();
            b1Check();
        }

        private void w5Timer_Tick(object sender, EventArgs e)
        {

            w5Timer.Stop();
            w5Check();
        }

        private void b4Timer_Tick(object sender, EventArgs e)
        {

            b4Timer.Stop();
            b4Check();
        }

        private void b2Timer_Tick(object sender, EventArgs e)
        {
            b2Timer.Stop();
            b2Check();
        }

        private void w4Timer_Tick(object sender, EventArgs e)
        {
            w4Timer.Stop();
            w4Check();
        }

        private void w6Timer_Tick(object sender, EventArgs e)
        {
            w6Timer.Stop();
            w6Check();
        }

        private void enableTimer_Tick(object sender, EventArgs e)
        {
            enable.Stop(); //stopiraj samo ako 
            enableTimer.Stop();
            disable.Begin();
            disableTimer.Start();
        }

        private void disableTimer_Tick(object sender, EventArgs e)
        {
            disableTimer.Stop();
            messageToUser.Content = "User is playing.";

            enable.Begin();
            enableTimer.Start();
        }

        private void initializeUserLists()
        {
            userLevel1 = new List<int>(1);
            userLevel2 = new List<int>(2);
            userLevel3 = new List<int>(3);
            userLevel4 = new List<int>(4);
            userLevel5 = new List<int>(5);
            userLevel6 = new List<int>(6);
            userLevel7 = new List<int>(7);
            userLevel8 = new List<int>(8);
            userLevel9 = new List<int>(9);
            userLevel10 = new List<int>(10);
        }

        private void black3_Click(object sender, RoutedEventArgs e)
        {
            black3Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) > 0)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void white3_Click(object sender, RoutedEventArgs e)
        {
            white3Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) > 1)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
            if (Convert.ToInt32(currentLevel.Content) == 1)
            {
                userLevel1.Add(3);
                if (!checkIfEqual(userLevel1, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
        }
        
        private void mistakeTimer_Tick(object sender, EventArgs e)
        {
            mistakeTimer.Stop();
            elapsedTimer.Stop();    //pocni brojati od pocetka.
            initializeUserLists(); //isprazni user unose za pojedini level!
            sec = 0;
            min = 0;
            playLevel(1);   //pocni od pocetka, cuvaj skore za vrijeme jednog igranja
        }

        private void w1110Timer_Tick(object sender, EventArgs e)
        {
            black4Pressed.Begin();
            w1110Timer.Stop();
        }

        private void w711Timer_Tick(object sender, EventArgs e)
        {
            black5Pressed.Begin();
            w711Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 9)
                w1110Timer.Start();
        }

        private void black1_Click(object sender, RoutedEventArgs e)
        {
            black1Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 8)
                b1Timer.Start();
            else
                b1Check();
            e.Handled = true;
        }

        private void b1Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(7);
                if (checkIfEqual(userLevel8, playLevel8))
                    playLevel(9);
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(7);
                if (!checkIfEqual(userLevel9, playLevel8))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(7);
                if (!checkIfEqual(userLevel10, playLevel8))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 8)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }

        }

        private void w57Timer_Tick(object sender, EventArgs e)
        {
            black1Pressed.Begin();
            w57Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 8)
                w711Timer.Start();
        }

        private void white5_Click(object sender, RoutedEventArgs e)
        {
            white5Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 7)
                w5Timer.Start();
            else
                w5Check();
            e.Handled = true;
        }

        private void w5Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(5);
                if (checkIfEqual(userLevel7, playLevel7))
                    playLevel(8);
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(5);
                if (!checkIfEqual(userLevel8, playLevel7))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(5);
                if (!checkIfEqual(userLevel9, playLevel7))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(5);
                if (!checkIfEqual(userLevel10, playLevel7))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 7)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void w105Timer_Tick(object sender, EventArgs e)
        {
            white5Pressed.Begin();
            w105Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 7)
                w57Timer.Start();
        }

        private void black4_Click(object sender, RoutedEventArgs e)
        {
            black4Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 6)
                b4Timer.Start();
            else if (Convert.ToInt32(currentLevel.Content) == 10 && b4alreadyPassed == 1)
                b4Timer.Start();
            else
                b4Check();
            e.Handled = true;
            b4alreadyPassed = 1;
        }

        private void b4Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 6)
            {
                userLevel6.Add(10);
                if (checkIfEqual(userLevel6, playLevel6))
                    playLevel(7);
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(10);
                if (!checkIfEqual(userLevel7, playLevel6))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(10);
                if (!checkIfEqual(userLevel8, playLevel6))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(10);
                if (!checkIfEqual(userLevel9, playLevel6))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(10);

                if (secondb4 == 0)
                {
                    if (!checkIfEqual(userLevel10, playLevel6))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondb4 = 1;
                }
                else
                {
                    if (checkIfEqual(userLevel10, playLevel10))
                    {
                        messageToUser.Content = "Congrats!";
                        endTimer.Start();
                        
                    }
                    else
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondb4 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 6)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void w610Timer_Tick(object sender, EventArgs e)
        {
            black4Pressed.Begin();
            w610Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 6)
                w105Timer.Start();
        }

        private void w86Timer_Tick(object sender, EventArgs e)
        {
            white6Pressed.Begin();
            w86Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 5)
                w610Timer.Start();
        }

        private void white6_Click(object sender, RoutedEventArgs e)
        {
            white6Pressed.Begin();      
            if (Convert.ToInt32(currentLevel.Content) == 2)
                w6Timer.Start();
            else if (Convert.ToInt32(currentLevel.Content) == 5 && w6alreadyPassed==1 ) //ako je drugi prolazak
                w6Timer.Start();
            else
                w6Check();
            e.Handled = true; //obavezno fired twice!    
            w6alreadyPassed = 1;
        }

        private void w6Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 2) //ako sam drugi nivo
            {
                userLevel2.Add(6);
                if (checkIfEqual(userLevel2, playLevel2))
                    playLevel(3);
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 3)
            {
                userLevel3.Add(6);
                if (!checkIfEqual(playLevel2, userLevel3))
                {
                    
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 4)
            {
                userLevel4.Add(6);
                if (!checkIfEqual(userLevel4, playLevel2))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 5)
            {
                userLevel5.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel5, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(userLevel5, playLevel5))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    else
                        playLevel(6);
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 6)
            {
                userLevel6.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel6, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(userLevel6, playLevel5))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel7, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(playLevel5, userLevel7))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel8, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(playLevel5, userLevel8))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel9, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(playLevel5, userLevel9))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(6);
                if (secondw6 == 0)
                {
                    if (!checkIfEqual(userLevel10, playLevel2))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 1;
                }
                else
                {
                    if (!checkIfEqual(playLevel5, userLevel10))
                    {
                        mistake.Begin();
                        mistakeTimer.Start();
                    }
                    secondw6 = 0;
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 2)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void elapsedTimer_Tick(object sender, EventArgs e)
        {
            if (sec < 59)
                sec++;
            else
            {
                min++;
                sec = 0;
                dancingClock.Begin();
            }         
            if (sec < 10  && min < 10)
                time.Content = "0" + min + ":0" + sec;
            else if ( sec < 10 && min > 9)
                time.Content = "" + min + ":0" + sec;
            else if ( sec > 9 && min < 10)
                time.Content = "0" + min + ":" + sec;
        }

        private void writeScore()
        {
           if (Convert.ToInt32(currentLevel.Content) > Convert.ToInt32(level.Content))
            {
                level.Content = currentLevel.Content;
                bestTime.Content = time.Content;

                dancingStar.Begin();   //animiraj zvijezdu!
           }
        }

        private void black2_Click(object sender, RoutedEventArgs e)
        {
            black2Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 4)
                b2Timer.Start();
            else
                b2Check();
            e.Handled = true;
        }

        private void b2Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 4)
            {
                userLevel4.Add(8);
                if (checkIfEqual(userLevel4, playLevel4))
                    playLevel(5);
                else
                {

                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 5)
            {
                userLevel5.Add(8);
                if (!checkIfEqual(userLevel5, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 6)
            {
                userLevel6.Add(8);
                if (!checkIfEqual(userLevel6, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(8);
                if (!checkIfEqual(userLevel7, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(8);
                if (!checkIfEqual(userLevel8, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(8);
                if (!checkIfEqual(userLevel9, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(8);
                if (!checkIfEqual(userLevel10, playLevel4))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 4)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void playLevel(int idLevel)
        {
            messageToUser.Content = "Computer is playing.";
            currentLevel.Content = idLevel;
            if (idLevel == 1)
            {
                start = DateTime.Now;
                elapsedTimer.Start();
                disableTimer.Interval = new TimeSpan(0, 0, 0, 2, 500);
            }
            else if (idLevel == 2)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 4, 400);
            else if (idLevel == 3)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 6, 200);
            else if (idLevel == 4)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 7, 800);
            else if (idLevel == 5)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 9, 400);
            else if (idLevel == 6)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 11, 500);
            else if (idLevel == 7)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 13, 300);
            else if (idLevel == 8)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 15, 300);
            else if (idLevel == 9)
                disableTimer.Interval = new TimeSpan(0, 0, 0, 17, 400);
            else
                disableTimer.Interval = new TimeSpan(0, 0, 0, 19, 300);
            disable.Begin();
            disableTimer.Start();
            writeScore();
            white2Pressed.Begin(); //odsviraj w2
            if (idLevel == 1)
                w2Timer.Start(); //cekaj neko vrijeme
            else
                w26Timer.Start();
        }

        private void w48Timer_Tick(object sender, EventArgs e)
        {
            black2Pressed.Begin();
            w48Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 4)
                w86Timer.Start();
        }

        private void w64Timer_Tick(object sender, EventArgs e)
        {
            white4Pressed.Begin();
            w64Timer.Stop();
            if (Convert.ToInt32(currentLevel.Content) > 3)
                w48Timer.Start();
        }

        private void w26Timer_Tick(object sender, EventArgs e)
        {
            w26Timer.Stop();
            white6Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) > 2)
                w64Timer.Start();
        }

        private void black5_Click(object sender, RoutedEventArgs e)
        {
            black5Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 9)
                b5Timer.Start();
            else
                b5Check();
            e.Handled = true;
        }

        private void b5Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(11);
                if (checkIfEqual(userLevel9, playLevel9))
                    playLevel(10);
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(11);
                if (!checkIfEqual(userLevel10, playLevel9))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 9)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }

        private void white1_Click(object sender, RoutedEventArgs e)
        {
            white1Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) > 1)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
            if (Convert.ToInt32(currentLevel.Content) == 1)
            {
                userLevel1.Add(1);
                if (!checkIfEqual(userLevel1, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
        }

        private void white2_Click(object sender, RoutedEventArgs e)
        {
            white2Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 1) //ako je prvi novo
            {
                userLevel1.Add(2);
                if (checkIfEqual(userLevel1, playLevel1))  //ako je user pogodio sekvencu, idi na sljedeci nivo
                    playLevel(2);
            }
            else if (Convert.ToInt32(currentLevel.Content) == 2)
                userLevel2.Add(2);

            else if (Convert.ToInt32(currentLevel.Content) == 3)
                userLevel3.Add(2);
            else if (Convert.ToInt32(currentLevel.Content) == 4)
            {
                userLevel4.Add(2);
                if (!checkIfEqual(userLevel4, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 5)
            {
                userLevel5.Add(2);
                if (!checkIfEqual(playLevel1, userLevel5))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 6)
            {
                userLevel6.Add(2);
                if (!checkIfEqual(userLevel6, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(2);
                if (!checkIfEqual(userLevel7, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(2);
                if (!checkIfEqual(userLevel8, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(2);
                if (!checkIfEqual(userLevel9, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(2);
                if (!checkIfEqual(userLevel10, playLevel1))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            e.Handled = true; //obavezno fired twice!    
        }

        private bool checkIfEqual(List<int> userLevel, List<int> playLevel)
        {
            bool result = true;

            int j = 0;
            if (userLevel.Count != playLevel.Count)
                result = false;
            else
            {
                for (int i = 0; i < userLevel.Count; i++)
                {
                    if (userLevel[i] != playLevel[j])
                        result = false;
                    j++;
                }
            }
            return result;
        }

        private void w2Timer_Tick(object sender, EventArgs e)
        {
            w2Timer.Stop(); //kad prodju 2 sec, stopiraj inace bi ponavljao!
        }

        private void white4_Click(object sender, RoutedEventArgs e)
        {
            white4Pressed.Begin();
            if (Convert.ToInt32(currentLevel.Content) == 3)
                w4Timer.Start();
            else
                w4Check();
            e.Handled = true; //obavezno fired twice!    
        }

        private void w4Check()
        {
            if (Convert.ToInt32(currentLevel.Content) == 3)
            {
                userLevel3.Add(4);

                if (checkIfEqual(userLevel3, playLevel3))
                {
                    playLevel(4);
                }
                else
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 4)
            {
                userLevel4.Add(4);
                if (!checkIfEqual(userLevel4, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 5)
            {
                userLevel5.Add(4);
                if (!checkIfEqual(userLevel5, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 6)
            {
                userLevel6.Add(4);
                if (!checkIfEqual(playLevel3, userLevel6))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 7)
            {
                userLevel7.Add(4);
                if (!checkIfEqual(userLevel7, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 8)
            {
                userLevel8.Add(4);
                if (!checkIfEqual(userLevel8, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 9)
            {
                userLevel9.Add(4);
                if (!checkIfEqual(userLevel9, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) == 10)
            {
                userLevel10.Add(4);
                if (!checkIfEqual(userLevel10, playLevel3))
                {
                    mistake.Begin();
                    mistakeTimer.Start();
                }
            }
            else if (Convert.ToInt32(currentLevel.Content) < 3)
            {
                mistake.Begin();
                mistakeTimer.Start();
            }
        }


    }
}