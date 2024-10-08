using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Firefox;
using Microsoft.Win32;
using System.Net;



namespace AutoCodeSF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Setup Save And Loads
        public void Loads()
        {

            //โหลดคีย์เวิดที่เคยบันทึกไว้
       
            cb_EbID.Checked = AutoCodeSF.Properties.Settings.Default.CK_SaveID;
            cb_Showweb.Checked = AutoCodeSF.Properties.Settings.Default.webShow;
            txt_time.Text = AutoCodeSF.Properties.Settings.Default.Time;
            txt_keyDay.Text = AutoCodeSF.Properties.Settings.Default.Keydaytime;
            txt_0.Text = AutoCodeSF.Properties.Settings.Default.ZeroTime;
            txt_60.Text = AutoCodeSF.Properties.Settings.Default.SixtyTime;
            txt_120.Text = AutoCodeSF.Properties.Settings.Default.onetwenty;
            txt_180.Text = AutoCodeSF.Properties.Settings.Default.oneeighty;
            txt_240.Text = AutoCodeSF.Properties.Settings.Default.twoforty;
            txt_300.Text = AutoCodeSF.Properties.Settings.Default.Threehundred;
            txt_360.Text = AutoCodeSF.Properties.Settings.Default.ThreeSixty;
            txt_420.Text = AutoCodeSF.Properties.Settings.Default.fortytwenty;
            txt_480.Text = AutoCodeSF.Properties.Settings.Default.foryeighty;
            txt_540.Text = AutoCodeSF.Properties.Settings.Default.fiveforty;
            txt_600.Text = AutoCodeSF.Properties.Settings.Default.Sixhundred;
            txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username01;
            txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password01;
            rb_DfLogin.Checked = AutoCodeSF.Properties.Settings.Default.LoginSaveDF;
            rb_GGID.Checked = AutoCodeSF.Properties.Settings.Default.LoginSaveGG;
           


        }
        public void SaveSettings()
        {

            //เซฟคีย์เวิร์ดที่ ดึงมาจากหน้าเว็ป

            //AutoCodeSF.Properties.Settings.Default.Username01 = txt_Username.Text;
            //AutoCodeSF.Properties.Settings.Default.Password01 = txt_Password.Text;


            //

            AutoCodeSF.Properties.Settings.Default.CK_SaveID = cb_EbID.Checked;
            AutoCodeSF.Properties.Settings.Default.Time = txt_time.Text;
            AutoCodeSF.Properties.Settings.Default.Keydaytime = txt_keyDay.Text;
            AutoCodeSF.Properties.Settings.Default.ZeroTime = txt_0.Text;
            AutoCodeSF.Properties.Settings.Default.SixtyTime = txt_60.Text;
            AutoCodeSF.Properties.Settings.Default.onetwenty = txt_120.Text;
            AutoCodeSF.Properties.Settings.Default.oneeighty = txt_180.Text;
            AutoCodeSF.Properties.Settings.Default.twoforty = txt_240.Text;
            AutoCodeSF.Properties.Settings.Default.Threehundred = txt_300.Text;
            AutoCodeSF.Properties.Settings.Default.ThreeSixty = txt_360.Text;
            AutoCodeSF.Properties.Settings.Default.fortytwenty = txt_420.Text;
            AutoCodeSF.Properties.Settings.Default.foryeighty = txt_480.Text;
            AutoCodeSF.Properties.Settings.Default.fiveforty = txt_540.Text;
            AutoCodeSF.Properties.Settings.Default.Sixhundred = txt_600.Text;
            AutoCodeSF.Properties.Settings.Default.webShow = cb_Showweb.Checked;
            AutoCodeSF.Properties.Settings.Default.LoginSaveDF = rb_DfLogin.Checked;
            AutoCodeSF.Properties.Settings.Default.LoginSaveGG = rb_GGID.Checked;
           
            AutoCodeSF.Properties.Settings.Default.Save();


        }
        #endregion
        #region setUp
        private void HandleGGIDLogin(FirefoxDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                IWebElement bt_loginsGG = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/ul/li[1]/a")));
                LogMessage($"โหลดข้อมูลเว็ปล็อคอินไอดีแบบ GG ID");
                bt_loginsGG.Click();
                Loong();


                IWebElement IDs = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[1]/ul/div/div[1]/div[1]/input")));
                LogMessage("ส่งข้อมูลไอดีสู่เว็ปไซต์");
                IDs.SendKeys(txt_Username.Text);

                IWebElement Passwords = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[1]/ul/div/div[1]/div[2]/input")));
                Passwords.SendKeys(txt_Password.Text);
                LogMessage("ส่งข้อมูลพาสเวิร์ดสู่เว็ปไซต์");
                Loong();


                IWebElement Bt_LoginGGs = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[1]/ul/div/div[2]")));
                Bt_LoginGGs.Click();
                LogMessage("ล็อคอินไอดี");

                IWebElement Bt_Nets = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[6]")));
                Bt_Nets.Click();
                LogMessage("โหลดข้อมูลไอดี");
                Loong();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการล็อคอิน GG ID: {ex.Message}");
                driver.Quit();
            }
        }
        private void HandleDfLogin(FirefoxDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                IWebElement IDs = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[2]/ul/div/div[1]/div[1]/input[1]")));
                LogMessage("ส่งข้อมูลไอดีสู่เข้าสู่เว็ปไซต์");
                IDs.SendKeys(txt_Username.Text);
                IWebElement Passwords = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[2]/ul/div/div[1]/div[2]/input")));
                Passwords.SendKeys(txt_Password.Text);
                LogMessage("ส่งข้อมูลสู่พาสเวิร์ดเข้าสู่เว็ปไซต์");
                Loong();
                rtb_01.ScrollToCaret();

                IWebElement Bt_LoginGGs = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[2]/ul/div/div[2]")));
                Bt_LoginGGs.Click();
                LogMessage("ล็อคอินไอดี");
                Loong();
                IWebElement Bt_Nets = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[4]/div[2]/div[2]/div/div[2]/div[6]")));
                Bt_Nets.Click();
                LogMessage("โหลดข้อมูลไอดี");
                Loong();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการล็อคอิน Df: {ex.Message}");
                driver.Quit();
            }
        }
        #endregion
        #region SetUP Driver
        private void NavigateToGame(FirefoxDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                //driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/");
                //IWebElement MenuQ = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[1]/div/div[1]/ul/li[6]/a")));
                //MenuQ.Click();
                driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                LogMessage("โหลดหน้าเล่นเกมรับไอเทม");
                Loong();
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการโหลดหน้าเกม: {ex.Message}");
                GC.Collect();
                driver.Quit();
            }
        }
        private void HandleTimeTaskItem(FirefoxDriver driver, string timeLabel, string xpath)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                IWebElement timeElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                LogMessage($"โหลดหน้า {timeLabel} ");
                timeElement.Click();
                IWebElement TimeQuestCheck = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[1]/p[2]")));
                IWebElement TimeMeCheck = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[2]/p[2]")));
                IWebElement txt_TimeQuest = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[1]/p[1]")));
                IWebElement txt_TimeMe = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[2]/p[1]")));
                LogMessage($"{TimeQuestCheck.Text} {txt_TimeQuest.Text}");
                LogMessage($"{TimeMeCheck.Text} {txt_TimeMe.Text}");

                IWebElement Status = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[5]/a")));
                HandleStatusItem(driver, Status, timeLabel);
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการโหลดหน้า {timeLabel}: {ex.Message}");
                driver.Quit();
            }
        }
        private void HandleTimeTaskExp(FirefoxDriver driver, string timeLabel, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {

                IWebElement timeElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                timeElement.Click();
                LogMessage2($"โหลดหน้า {timeLabel}");
                IWebElement txt_Dayinsites = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[1]/p[1]")));
                IWebElement txt_Inday = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[1]/p[2]")));
                string T_Inday = txt_Inday.Text;
                string Dayinsitess = txt_Dayinsites.Text;
                LogMessage2($"{Dayinsitess}: [ {T_Inday} ]");

                IWebElement txt_dayMe = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[2]/p[1]")));
                IWebElement txt_IndayMe = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[2]/p[2]")));
                string T_Indays = txt_dayMe.Text;
                string Dayinsitesss = txt_IndayMe.Text;
                LogMessage2($"{T_Indays}: [ {Dayinsitesss} ]");
                Loong();
                IWebElement Status = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div/div[5]")));
                HandleStatusExp(driver, Status, timeLabel);
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการโหลดหน้า {ex.Message}");
                driver.Quit();
            }
        }
        private void HandleStatusExp(FirefoxDriver driver, IWebElement Status, string timeLabel)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                if (Status.Text.Contains("ทำกิจกรรมเพิ่ม"))
                {
                    LogMessage2($"{Status.Text}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");


                }
                else if (Status.Text.Contains("รับไอเทมไปแล้ว"))
                {
                    LogMessage2($"{Status.Text}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");

                }
                else if (Status.Text.Contains("รับไอเทม"))
                {
                    LogMessage2($"{timeLabel}");
                    Status.Click();
                    Thread.Sleep(100);
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    else if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                   Thread.Sleep(100);
                    IWebElement ButtonCmp = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[2]/a[1]")));
                    ButtonCmp.Click();
                    IWebElement Itemlist = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/h1/div")));
                    string ExpList = Itemlist.Text;
                    LogMessage(ExpList);
                    IWebElement End = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/div/a")));
                    End.Click();
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                    LogMessage("กลับหน้าเช็คEvent");


                }
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการจัดการสถานะ: {ex.Message}");
                driver.Quit();
            }
        }
        private void HandleStatusItem(FirefoxDriver driver, IWebElement Status, string timeLabel)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                if (Status.Text.Contains("ทำกิจกรรมเพิ่ม"))
                {
                    LogMessage($"{Status.Text}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                    LogMessage("กลับหน้าเช็คEvent");

                }
                else if (Status.Text.Contains("รับไอเทมไปแล้ว"))
                {
                    LogMessage($"{Status.Text}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                    LogMessage("กลับหน้าเช็คEvent");

                }
                else if (Status.Text.Contains("รับไอเทม"))
                {
                    LogMessage($"{Status.Text}");
                    Status.Click();
                    IWebElement SendItemBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[2]/a[1]")));
                    LogMessage("กำลังส่งไอเทมเข้าตัวละคร");
                    SendItemBox.Click();
                    IWebElement Itemlist = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/h1/div")));
                    string Item = Itemlist.Text;
                    LogMessage(Item);
                    IWebElement End = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/div/a")));
                    End.Click();
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                    LogMessage("กลับหน้าเช็คEvent");

                }
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในการจัดการสถานะ: {ex.Message}");
                driver.Quit();
            }
        }
        private void ProcessSingleMode(FirefoxDriver driver, WebDriverWait wait)
        {
            try
            {
                IWebElement CheckSingleMode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[4]/a")));
                LogMessage("กำลังเช็คข้อมูลเควส โหมด Single");
                CheckSingleMode.Click();
                Loong();
                IWebElement Scroe_S = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[5]/div[3]")));
                string SingleScore_ = Scroe_S.Text;
                LogMessage($"เควสที่ต้องทำ {SingleScore_} รอบ ");

                IWebElement ScoreMe_S = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[1]/p[2]")));
                string Score_me = ScoreMe_S.Text;
                LogMessage($"{Score_me}");
                Loong();


                IWebElement CheckButtonTextSingel = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[3]/a")));
                string CheckButtonText_Sigel = CheckButtonTextSingel.Text;

                if (CheckButtonText_Sigel.Contains("ยังไม่ถึงเกณฑ์"))
                {
                    LogMessage($"{CheckButtonText_Sigel}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion");
                    Loong();

                }
                else if (CheckButtonText_Sigel.Contains("รับไอเทมไปแล้ว"))
                {
                    LogMessage($"{CheckButtonText_Sigel}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion");
                    Loong();
                    rtb_01.ScrollToCaret();
                }
                else if (CheckButtonText_Sigel.Contains("รับไอเทม"))
                {
                    IWebElement dones = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[3]/a")));
                    dones.Click();
                    LogMessage("โหลดข้อมูลของรางวัล");
                    if(RB_ExpR1.Checked)
                    {
                        IWebElement R1Exp = wait.Until(CustomExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        R1Exp.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement R2Exp = wait.Until(CustomExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        R2Exp.Click();
                    }
                    IWebElement DoneSingle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[2]/a[1]")));
                    DoneSingle.Click();
                    Loong();
                    IWebElement text_Item = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/h1/div/span/font")));
                    string ItemText = text_Item.Text;
                    LogMessage($" {ItemText}");
                    IWebElement End_popUpitem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/div/a")));
                    End_popUpitem.Click();
                    LogMessage("ทำการเคลมของรางวัลโหมด ซิงเกิล เรียบร้อยแล้ว");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion");
                    Loong();

                }
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในโหมด Single: {ex.Message}");
                driver.Quit();
            }
        }
        private void ProcessTeamMode(FirefoxDriver driver, WebDriverWait wait)
        {
            try
            {
                IWebElement CheckTeamMode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[4]/a")));
                CheckTeamMode.Click();
                LogMessage("กำลังเช็คข้อมูลเควส โหมด Team");
                IWebElement Scroe_T = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[5]/div[3]/p")));
                string TeamScore = Scroe_T.Text;
                LogMessage($"เควสที่ต้องทำ {TeamScore} รอบ");
                IWebElement ScoreMe_T = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[1]/p[2]")));
                string Score_me_T = ScoreMe_T.Text;
                LogMessage($"{Score_me_T}");
                Loong();


                IWebElement CheckButtonTextTeam = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[3]/a")));
                string CheckButtonText_Team = CheckButtonTextTeam.Text;

                if (CheckButtonText_Team.Contains("ยังไม่ถึงเกณฑ์"))
                {
                    LogMessage($"{CheckButtonText_Team}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion"); ;
                    Loong();

                }
                else if (CheckButtonText_Team.Contains("รับไอเทมไปแล้ว"))
                {
                    LogMessage($"{CheckButtonText_Team}");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion");
                    Loong();
                    rtb_01.ScrollToCaret();
                }
                else if (CheckButtonText_Team.Contains("รับไอเทม"))
                {
                    IWebElement donet = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[3]/a")));
                    LogMessage("โหลดข้อมูลของรางวัล");
                    donet.Click();
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement R1Exp = wait.Until(CustomExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        R1Exp.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement R2Exp = wait.Until(CustomExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        R2Exp.Click();
                    }
                    IWebElement DoneTeam = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[5]/div/div/div[2]/a[1]")));
                    DoneTeam.Click();
                    Loong();
                    rtb_01.ScrollToCaret();
                    IWebElement text_Item = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/h1/div/span/font")));
                    string ItemText = text_Item.Text;
                    LogMessage($" {ItemText}");
                    rtb_01.ScrollToCaret();
                    IWebElement End_popUpitem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/div/a")));
                    End_popUpitem.Click();

                    LogMessage("ทำการเคลมของรางวัลโหมด ทีม เรียบร้อยแล้ว");
                    driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                    LogMessage("กลับไปหน้า Misssion");
                    Loong();

                }
            }
            catch (Exception ex)
            {
                LogMessage($"เกิดข้อผิดพลาดในโหมด Team: {ex.Message}");
                driver.Quit();
            }
        }
        #endregion
        #region Logmessage
        private void LogMessage(string message)
        {
            rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")}: {message}" + Environment.NewLine);
            rtb_01.ScrollToCaret();
            lb_Statusc.Text = message;

        }
        private void LogMessage2(string message)
        {
            rtb_01.AppendText($"{message}" + Environment.NewLine);
            rtb_01.ScrollToCaret();
            lb_Statusc.Text = message;
        }
        private void Loong()
        {
            rtb_01.AppendText("===============================================" + Environment.NewLine);
            rtb_01.ScrollToCaret();
        }
        #endregion
        #region CL
        string delta = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]";
        string EID = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]";
        string Forcrecon = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[4]/td[1]/input[1]";
        string GIGN = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[5]/td[1]/input[1]";
        string GSG9 = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[6]/td[1]/input[1]";
        string KSF = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[7]/td[1]/input[1]";
        string PSU = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[8]/td[1]/input[1]";
        string ROKMC = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[9]/td[1]/input[1]";
        string SAS = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[10]/td[1]/input[1]";
        string SASR = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[11]/td[1]/input[1]";
        string SIAM = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[12]/td[1]/input[1]";
        string SpetSnaz = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[13]/td[1]/input[1]";
        string SRG = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[14]/td[1]/input[1]";
        string SSD = "/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[15]/td[1]/input[1]";
        #endregion
        #region Work
        private void GetItemCodes()
        {

            //web http://keyword.gg.in.th/
            //ตั้งค่าให้google ซ่อนไว้จะได้ไม่รกจอ
            var hidecs = FirefoxDriverService.CreateDefaultService();
            hidecs.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--width=800");
            options.AddArgument("--height=500");
            options.SetPreference("permissions.default.image", 2);
            if (!cb_Showweb.Checked)
            {
                options.AddArgument("--headless");
            }

            FirefoxDriver driver = new FirefoxDriver(hidecs, options);

            //

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                rtb_01.Clear();
                Loong();
                LogMessage("ระบบดึงคีย์อัตโนมัติเริ่มทำงาน !");
                Loong();
                driver.Navigate().GoToUrl("http://keyword.gg.in.th/");
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} โหลดข้อมูลหน้าเว็ป " + Environment.NewLine);
                rtb_01.ScrollToCaret();

                IWebElement OpenCode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[12]/div[1]/div[3]/a")));
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} กำลังโหลดไอเทมโค๊ดรายวัน " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                OpenCode.Click();
                var tabs = driver.WindowHandles;
                if (tabs.Count > 1)
                {
                    driver.SwitchTo().Window(tabs[1]);
                    driver.Close();
                    driver.SwitchTo().Window(tabs[0]);
                }

                //กลับไปหน้าเดิมเพื่อเปิดโค๊ด
                driver.Navigate().GoToUrl("http://keyword.gg.in.th/");
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} โหลดหน้าคีย์ไอเทม " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                //ก๊อปปี้โค๊ด
                IWebElement Codekeyday = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[12]/div[1]/div[3]/div[1]")));
                string keyday = Codekeyday.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์รายวัน {Codekeyday.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_keyDay.Text = keyday;

                IWebElement Key0 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[11]/div[1]/div[3]/div[1]")));
                string key_0 = Key0.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 0 นาที {Key0.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_0.Text = key_0;

                IWebElement Key60 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[10]/div[1]/div[3]/div[1]")));
                string key_60 = Key60.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 60 นาที {Key60.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_60.Text = key_60;

                IWebElement key120 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[9]/div[1]/div[3]/div[1]")));
                string key_120 = key120.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 120 นาที {key120.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_120.Text = key_120;

                IWebElement key180 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[8]/div[1]/div[3]/div[1]")));
                string key_180 = key180.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 180 นาที {key180.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_180.Text = key_180;

                IWebElement key240 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[7]/div[1]/div[3]/div[1]")));
                string key_240 = key240.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 240 นาที {key240.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_240.Text = key_240;

                IWebElement key300 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[6]/div[1]/div[3]/div[1]")));
                string key_300 = key300.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 300 นาที {key300.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_300.Text = key_300;

                IWebElement key360 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[5]/div[1]/div[3]/div[1]")));
                string key_360 = key360.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 360 นาที {key360.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_360.Text = key_360;

                IWebElement key420 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[4]/div[1]/div[3]/div[1]")));
                string key_420 = key420.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 420 นาที {key420.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_420.Text = key_420;

                IWebElement key480 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[3]/div[1]/div[3]/div[1]")));
                string key_480 = key480.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 480 นาที {key480.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_480.Text = key_480;

                IWebElement key540 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[2]/div[1]/div[3]/div[1]")));
                string key_540 = key540.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 540 นาที {key540.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_540.Text = key_540;

                IWebElement key600 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[5]/div/div[1]/div[1]/div[1]/div[3]/div[1]")));
                string key_600 = key600.Text;
                rtb_01.AppendText($"{DateTime.Now.ToString("hh:mm:ss")} คีย์ 600 นาที {key600.Text} " + Environment.NewLine);
                rtb_01.ScrollToCaret();
                txt_600.Text = key_600;

            }

            catch (NoAlertPresentException)
            {

            }
            catch (Exception ex)
            {
                //MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage($"เกิดข้อผิดพลาด: {ex.Message}");
               
                driver.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            finally
            {
                try
                {
                    // ตรวจสอบว่ามี Alert หรือไม่
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    //alert.Accept();
                    //MessageBox.Show("มีข้อความแจ้งเตือน: " + alertText, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogMessage(alertText);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }
                catch (NoAlertPresentException)
                {


                }
                finally
                {

                    driver.Quit();
                    DateTime currentTime = DateTime.Now;
                    DayOfWeek currentDay = currentTime.DayOfWeek;
                    txt_time.Text = currentTime.ToString("yyy-MM-dd");

                    Loong();
                    rtb_01.ScrollToCaret();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }



        }
        public void EventCode3()
        {
            var hidecs = FirefoxDriverService.CreateDefaultService();
            hidecs.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            options.SetPreference("permissions.default.image", 2);
            if (!cb_Showweb.Checked)
            {
                options.AddArgument("--headless");
            }

            FirefoxDriver driver = new FirefoxDriver(hidecs, options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                rtb_01.Clear();
                Loong();
                LogMessage("ระบบส่งคีย์อัตโนมัติ");
                Loong();
                driver.Navigate().GoToUrl("https://auth.gg.in.th/authenticate_v3/Auth_Full/Login.aspx?appid=1&scope=&state=1&sourceid=1&redirecturi=http%3a%2f%2fmember.sf.in.th%2fLandingPlatform.aspx&fblogin=true");
                if (rb_GGID.Checked)
                {
                    HandleGGIDLogin(driver);
                }
                else if (rb_DfLogin.Checked)
                {
                    HandleDfLogin(driver);

                }
                Thread.Sleep(100);
                driver.Navigate().GoToUrl("http://member.sf.in.th/Keyword/");
                LogMessage("กำลังไปหนน้าโหลดข้อมูลส่คีย์เววิร์ด");
                IWebElement keyText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[1]/div[2]/input")));
                LogMessage("รอส่งข้อมูลคีย์เวิร์ด");
                Loong();
                #region RB_keyFuntion
                if (RB_Daliy.Checked)
                {
                    keyText.SendKeys(txt_keyDay.Text);
                    IWebElement sendKeyCodes = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]")));
                    sendKeyCodes.Click();
                    LogMessage("ส่งคีย์รายวันแล้ว");
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_0.Checked)
                {
                    keyText.SendKeys(txt_0.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");

                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }

                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");

                }
                if (RB_60.Checked)
                {
                    keyText.SendKeys(txt_60.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_120.Checked)
                {
                    keyText.SendKeys(txt_120.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_180.Checked)
                {
                    keyText.SendKeys(txt_180.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_240.Checked)
                {
                    keyText.SendKeys(txt_240.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_300.Checked)
                {
                    keyText.SendKeys(txt_300.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_360.Checked)
                {
                    keyText.SendKeys(txt_360.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_420.Checked)
                {
                    keyText.SendKeys(txt_420.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_480.Checked)
                {
                    keyText.SendKeys(txt_480.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_540.Checked)
                {
                    keyText.SendKeys(txt_540.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_600.Checked)
                {
                    keyText.SendKeys(txt_0.Text);
                    IWebElement sendkeycode = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]/a")));
                    sendkeycode.Click();
                    LogMessage("ส่งคีย์ไอเทมแล้ว");
                    if (RB_ExpR1.Checked)
                    {
                        IWebElement Exp_R1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[2]/td[1]/input[1]")));
                        Exp_R1.Click();
                    }
                    if (RB_ExpR2.Checked)
                    {
                        IWebElement Exp_R2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[1]/table/tbody/tr[3]/td[1]/input[1]")));
                        Exp_R2.Click();
                    }
                    IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                    GetItem.Click();
                    LogMessage("ยืนยันการรับไอเทม");
                }
                if (RB_Itemcode.Checked)
                {
                    if (RB_character.Checked)
                    {
                        keyText.SendKeys(txt_ItemCode.Text);
                        IWebElement sendKeyCodes = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]")));
                        sendKeyCodes.Click();
                        LogMessage("ส่งคีย์เวิร์ด");
                        LogMessage("รอเลือกตัวละคร");

                        #region Character
                        if (RB_delta.Checked)
                        {
                            IWebElement CheckDelta = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(delta)));
                            CheckDelta.Click();
                            LogMessage("คลิกเลือกตัวละคร Delta");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");

                        }
                        if (RB_EID.Checked)
                        {
                            IWebElement CheckEID = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(EID)));
                            CheckEID.Click();
                            LogMessage("คลิกเลือกตัวละคร EID");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_Forcrecon.Checked)
                        {
                            IWebElement CheckForcrecon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Forcrecon)));
                            CheckForcrecon.Click();
                            LogMessage("คลิกเลือกตัวละคร Forcrecon");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_GIGN.Checked)
                        {
                            IWebElement CheckGIGN = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(GIGN)));
                            CheckGIGN.Click();
                            LogMessage("คลิกเลือกตัวละคร GIGN");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_GSG9.Checked)
                        {
                            IWebElement CheckGSG9 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(GSG9)));
                            CheckGSG9.Click();
                            LogMessage("คลิกเลือกตัวละคร GSG9");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_KSF.Checked)
                        {
                            IWebElement CheckKSF = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(KSF)));
                            CheckKSF.Click();
                            LogMessage("คลิกเลือกตัวละคร KSF");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_PSU.Checked)
                        {
                            IWebElement CheckPSU = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PSU)));
                            CheckPSU.Click();
                            LogMessage("คลิกเลือกตัวละคร PSU");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_ROKMC.Checked)
                        {
                            IWebElement CheckROKMC = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ROKMC)));
                            CheckROKMC.Click();
                            LogMessage("คลิกเลือกตัวละคร ROKMC");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SAS.Checked)
                        {
                            IWebElement CheckSAS = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SAS)));
                            CheckSAS.Click();
                            LogMessage("คลิกเลือกตัวละคร SAS");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SAS.Checked)
                        {
                            IWebElement CheckSASR = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SASR)));
                            CheckSASR.Click();
                            LogMessage("คลิกเลือกตัวละคร SASR");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SIAM.Checked)
                        {
                            IWebElement CheckSIAM = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SIAM)));
                            CheckSIAM.Click();
                            LogMessage("คลิกเลือกตัวละคร SIAM");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SpetSnaz.Checked)
                        {
                            IWebElement CheckSpetSnaz = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SpetSnaz)));
                            CheckSpetSnaz.Click();
                            LogMessage("คลิกเลือกตัวละคร SpetSnaz");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SRG.Checked)
                        {
                            IWebElement CheckSRG = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SRG)));
                            CheckSRG.Click();
                            LogMessage("คลิกเลือกตัวละคร SRG");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        if (RB_SSD.Checked)
                        {
                            IWebElement CheckSSD = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SSD)));
                            CheckSSD.Click();
                            LogMessage("คลิกเลือกตัวละคร SSD");
                            IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                            GetItem.Click();
                            LogMessage("ยืนยันการรับไอเทม");
                        }
                        #endregion

                    }
                    if (RB_items.Checked)
                    {
                        keyText.SendKeys(txt_ItemCode.Text);
                        IWebElement sendKeyCodes = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[3]/div/div[1]/div[2]")));
                        sendKeyCodes.Click();
                        LogMessage("ส่งคีย์เวิร์ด กิจกรรมแล้ว");
                        IWebElement GetItem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[2]/div/div[3]/div/div/div[2]/a[1]")));
                        GetItem.Click();
                        LogMessage("ยืนยันการรับไอเทม");
                    }
                }
                Loong();
                IWebElement itemlists = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/h1/div/span"))); ;
                string itemlist = itemlists.Text;
                Loong();
                LogMessage2($"{itemlist}");
                Loong();
                IWebElement Getitems = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div[1]/div/div/a")));
                Getitems.Click();
                LogMessage("ยืนยันการรับไอเทม");
                Loong();

                #endregion
            }
            catch (NoAlertPresentException)
            {

            }
            catch (WebDriverTimeoutException ex)
            {
               
                LogMessage($"การโหลดหน้าเว็บใช้เวลานานเกินไป : {ex.Message}");
                driver.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                LogMessage($"{ex.Message}");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                driver.Quit();
            }
            finally
            {
                try
                {


                    IAlert alert = driver.SwitchTo().Alert();
                    string alerttext = alert.Text;
                    alert.Accept();
                    LogMessage($"เกิดข้อผิดพลาด: {alerttext}");
                    
                    //driver.Quit();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }
                catch (NoAlertPresentException)
                {

                }
                finally
                {
                    driver.Quit();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
        public void QuestItemBoxs()
        {
            rtb_01.Clear();
            Loong();
            LogMessage2("ระบบรับไอเทม อีเว้น อัตโนมัติ เริ่มทำงาน !");
            Loong();
            var hidecs = FirefoxDriverService.CreateDefaultService();
            hidecs.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            options.SetPreference("permissions.default.image", 2);
            if (!cb_Showweb.Checked)
            {
                options.AddArgument("--headless");
            }

            FirefoxDriver driver = new FirefoxDriver(hidecs, options);



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {

                if (rb_GGID.Checked)
                {
                    driver.Navigate().GoToUrl("https://auth.gg.in.th/authenticate_v3/Auth_Full/Login.aspx?appid=1&scope=&state=1&sourceid=1&redirecturi=http%3a%2f%2fmember.sf.in.th%2fLandingPlatform.aspx&fblogin=true");
                    HandleGGIDLogin(driver);
                }
                else if (rb_DfLogin.Checked)
                {
                    driver.Navigate().GoToUrl("https://auth.gg.in.th/authenticate_v3/Auth_Full/Login.aspx?appid=1&scope=&state=1&sourceid=1&redirecturi=http%3a%2f%2fmember.sf.in.th%2fLandingPlatform.aspx&fblogin=true");
                    HandleDfLogin(driver);
                }

                driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_PlayGame_Accumulate.aspx");
                LogMessage("โหลดหน้าเล่นเกมรับไอเทม");
                Loong();

                IWebElement txt_Event1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[1]")));
                IWebElement txt_Event2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[1]")));
                //IWebElement txt_Event3 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[3]/div[1]")));
                //IWebElement txt_Event4 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[4]/div[1]")));
                //IWebElement txt_Event5 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[5]/div[1]")));
                //IWebElement txt_Event6 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div[3]/div[3]/div/div/div[4]/div[6]/div[1]")));
                string Event1 = txt_Event1.Text;
                string Event2 = txt_Event2.Text;
                //string Event3 = txt_Event3.Text;
                //string Event4 = txt_Event4.Text;
                //string Event5 = txt_Event5.Text;
                //string Event6 = txt_Event6.Text;
                LogMessage2("รายชื่อกิจกรรม");
                LogMessage2(Event1);
                LogMessage2(Event2);
                //LogMessage2(Event3);
                //LogMessage2(Event4);
                //LogMessage2(Event5);
                //LogMessage2(Event6);
                Loong();
                LogMessage2("กำลังประมวลผลรอสักครู่..");
                Loong();
                if (RB_Event1.Checked)
                {
                    HandleTimeTaskItem(driver, Event1, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[4]/a");
                    Loong();
                    HandleTimeTaskExp(driver, Event2, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[4]/a");
                }
                if (RB_Event2.Checked)
                {
                    HandleTimeTaskExp(driver, Event1, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[1]/div[4]/a");
                    Loong();
                    HandleTimeTaskItem(driver, Event2, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[2]/div[4]/a");

                }
                Loong();
                //HandleTimeTask(driver, Event3, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[3]/div[4]/a");
                //Loong();
                //rtb_01.ScrollToCaret();
                //Thread.Sleep(100);
                //HandleTimeTask(driver, Event4, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[4]/div[4]/a");
                //Loong();
                //rtb_01.ScrollToCaret();
                //Thread.Sleep(100);
                //HandleTimeTask(driver, Event5, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[5]/div[4]/a");
                //Loong();
                //rtb_01.ScrollToCaret();
                //Thread.Sleep(100);
                //HandleTimeTask(driver, Event5, "/html/body/form/div[3]/div[3]/div/div/div[4]/div[6]/div[4]/a");
                //Loong();
                //rtb_01.ScrollToCaret();


            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
                driver.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            finally
            {

                driver.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

        }
        public void QuestTeamAndSingleV2()
        {

            var hidecs = FirefoxDriverService.CreateDefaultService();
            hidecs.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            options.SetPreference("permissions.default.image", 2);
            if (!cb_Showweb.Checked)
            {
                options.AddArgument("--headless");
            }

            FirefoxDriver driver = new FirefoxDriver(hidecs, options);

            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                rtb_01.Clear();
                Loong();
                LogMessage2("ระบบรับ Exp Quest Team And Single เริ่มทำงาน!");
                Loong();
                driver.Navigate().GoToUrl("https://auth.gg.in.th/authenticate_v3/Auth_Full/Login.aspx?appid=1&scope=&state=1&sourceid=1&redirecturi=http%3a%2f%2fmember.sf.in.th%2fLandingPlatform.aspx&fblogin=true");



                if (rb_GGID.Checked)
                {
                    HandleGGIDLogin(driver);
                }
                else if (rb_DfLogin.Checked)
                {
                    HandleDfLogin(driver);
                }

                driver.Navigate().GoToUrl("http://member.sf.in.th/PIMS/Event_Mission.aspx");
                LogMessage("โหลดหน้าข้อมูลเควส ซิงเกิล และ โหมดทีม");

                ProcessSingleMode(driver, wait);
                ProcessTeamMode(driver, wait);



            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);

            }
            finally
            {
                if (driver != null)
                {
                    try
                    {
                        IAlert alert = driver.SwitchTo().Alert();
                        string alertText = alert.Text;
                        LogMessage($"เกิดข้อผิดพลาด {alertText}");
                    }
                    catch (NoAlertPresentException)
                    {
                    }
                    finally
                    {
                        driver.Quit();
                    }
                }
                Loong();
                GC.Collect();
                GC.WaitForFullGCApproach();
                GC.Collect();
            }

        }
        public void StartGameDump()
        {
            FirefoxOptions options = new FirefoxOptions();
            var hidese = FirefoxDriverService.CreateDefaultService();
            hidese.HideCommandPromptWindow = true;
            options.AddArgument("--width=800");
            options.AddArgument("--height=500");
            options.SetPreference("permissions.default.image", 2);
            options.SetPreference("profile.default_content_setting_values.automatic_downloads", 1);

            options.SetPreference("download.prompt_for_download", false);
            options.SetPreference("download.directory_upgrade", true);

            options.SetPreference("profile.default_content_setting_values.plugins", 1);

            FirefoxDriver driver = new FirefoxDriver(hidese, options);

            try
            {
                rtb_01.Clear();
                Loong();
                LogMessage2("ระบบล็อคอินอัตโนมัติเริ่มทำงาน !");
                Loong();
                driver.Navigate().GoToUrl("https://auth.gg.in.th/authenticate_v3/Auth_Full/Login.aspx?appid=1&scope=&state=1&sourceid=1&redirecturi=https://sf.gg.in.th/newauthen/landingplatform.aspx&fblogin=true");

                if (rb_GGID.Checked)
                {
                    HandleGGIDLogin(driver);
                }
                else if (rb_DfLogin.Checked)
                {
                    HandleDfLogin(driver);
                }

            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
                Loong();
                driver.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            finally
            {

            }

            LogMessage("กำลังเริ่มเกม!");
            Loong();
            LogMessage2("มีเวลา 10 วิในการกดOpen");
            Thread.Sleep(10000);
            driver.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        public void deletItems()
        {
            string[] itemslists = {
                "AutoCodeSF.pdb","Luncher.pdb", "ICSharpCode.SharpZipLib.pdb","Discord.Net.Commands.xml","Discord.Net.Core.xml","Discord.Net.Interactions.xml","Discord.Net.Rest.xml"
                ,"Discord.Net.Webhook.xml","Discord.Net.WebSocket.xml","ICSharpCode.SharpZipLib.xml","Microsoft.Bcl.AsyncInterfaces.xml","Microsoft.Extensions.DependencyInjection.Abstractions.xml",
                "Newtonsoft.Json.xml","System.Buffers.xml","System.Collections.Immutable.xml","System.Interactive.Async.xml","System.Linq.Async.xml",
                "System.Memory.xml","System.Numerics.Vectors.xml","System.Reactive.xml","System.Runtime.CompilerServices.Unsafe.xml","System.Threading.Tasks.Extensions.xml",
                "System.ValueTuple.xml","WebDriver.Support.xml","WebDriver.xml","Bypass.dll","Cheat.dll","Launcher_ZZZ.exe","Launcher_HSR.exe",
                "update.zip","System.Text.Encodings.Web.xml","System.Text.Json.xml","Microsoft.Win32.Registry.xml","System.Security.Principal.Windows.xml","System.Diagnostics.PerformanceCounter.xml"
                ,"Hardware.Info.xml","System.Security.AccessControl.xml","System.CodeDom.xml","Launcher_ip.exe","SFMACRO.exe","Start.bat","launcher.dll","Launcher_HSR","Cheat_HSR.dll","Bypass_HSR.dll"
            };
            foreach (string item in itemslists)
            {
                if (File.Exists(item))
                {
                    File.Delete(item);
                }


            }
        }
        public static void HideFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                directoryInfo.Attributes |= FileAttributes.Hidden;
            }
            else
            {

            }
        }
        #endregion
        #region SetupDriver
        public static class CustomExpectedConditions
        {
            public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
            {
                return driver =>
                {
                    try
                    {
                        var element = driver.FindElement(locator);
                        return element.Displayed ? element : null;

                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }

                };
            }

            public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
            {
                return driver =>
                {
                    try
                    {
                        var element = driver.FindElement(locator);
                        return (element != null && element.Enabled && element.Displayed) ? element : null;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                };
            }
        }

        #endregion
        #region FirefoxInstall
        public void StartCheck()
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("CheckFireFox");
            }
            else
            {

            }
        }
        static bool IsFirefoxInstalled()
        {

            if (CheckRegistryKeyForUninstall(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                return true;


            if (CheckRegistryKeyForUninstall(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"))
                return true;


            if (CheckRegistryKeyForUninstall(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", Registry.CurrentUser))
                return true;


            return CheckFirefoxInAppPaths();
        }
        static bool CheckRegistryKeyForUninstall(string registryKeyPath, RegistryKey baseKey = null)
        {
            if (baseKey == null)
                baseKey = Registry.LocalMachine;

            using (RegistryKey key = baseKey.OpenSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    foreach (string subkeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                        {
                            if (subkey != null && subkey.GetValue("DisplayName") != null)
                            {
                                string displayName = subkey.GetValue("DisplayName").ToString();

                                if (displayName.Contains("Mozilla Firefox") || displayName.Contains("ไฟร์ฟอกซ์"))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void DownloadAndInstallFirefox()
        {
            string downloadUrl = "https://download.mozilla.org/?product=firefox-latest&os=win64&lang=en-US";
            string installerPath = Path.Combine(Path.GetTempPath(), "FirefoxInstaller.exe");

            try
            {
                rtb_01.AppendText("Downloading Firefox...\n");
                progressBar.Value = 0;

                using (WebClient client = new WebClient())
                {

                    client.DownloadProgressChanged += (sender, e) =>
                    {

                        rtb_01.Invoke((Action)(() =>
                        {
                            progressBar.Value = e.ProgressPercentage;
                        }));
                    };


                    client.DownloadFileCompleted += (sender, e) =>
                    {

                        if (e.Error != null)
                        {
                            LogMessage($"Error during download: {e.Error.Message}");
                            MessageBox.Show($"Error during download: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        rtb_01.Invoke((Action)(() =>
                        {
                            rtb_01.AppendText("Download complete. Installing Firefox...\n");
                            progressBar.Value = 0;
                            progressBar.Style = ProgressBarStyle.Marquee;
                        }));


                        Process installProcess = new Process();
                        installProcess.StartInfo.FileName = installerPath;
                        installProcess.StartInfo.Arguments = "/S /TaskbarShortcut=false /DesktopShortcut=false";
                        installProcess.StartInfo.CreateNoWindow = true;
                        installProcess.StartInfo.UseShellExecute = false;
                        installProcess.Start();


                        installProcess.WaitForExit();

                        rtb_01.Invoke((Action)(() =>
                        {

                            progressBar.Style = ProgressBarStyle.Blocks;
                            progressBar.Value = 100;
                            rtb_01.AppendText("Installation complete.\n");
                        }));


                        if (File.Exists(installerPath))
                        {
                            File.Delete(installerPath);
                            LogMessage("Firefox installation completed successfully.");
                            Thread.Sleep(100);
                            MessageBox.Show("เปิดโปรแกรมใหม่อีกครั้ง", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                    };


                    client.DownloadFileAsync(new Uri(downloadUrl), installerPath);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error during installation: {ex.Message}");
                MessageBox.Show($"Error during installation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FirefoxinstallCheck()
        {
            rtb_01.Clear();
            rtb_01.AppendText("Checking Firefox installation...\n");

            if (!IsFirefoxInstalled())
            {
                groupBox3.Enabled = false;
                rtb_01.AppendText("Firefox is not installed. Proceeding with installation...\n");
                DownloadAndInstallFirefox();

            }
            else
            {
                rtb_01.AppendText("Firefox is already installed.\n");
                groupBox3.Enabled = true;
            }
        }
        static bool CheckFirefoxInAppPaths()
        {
            string firefoxAppPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(firefoxAppPath))
            {
                if (key != null)
                {

                    string path = key.GetValue(null)?.ToString();
                    return !string.IsNullOrEmpty(path) && File.Exists(path);
                }
            }
            return false;
        }
        #endregion
        private void RB_character_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_character.Checked == true)
            {
                this.Size = new Size(945, 633);

            }
            else
            {
                this.Size = new Size(771, 633);
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

      
        
        private void bw_01_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string task = (string)e.Argument;
            switch (task)
            {
                case "GetItemcode":
                    GetItemCodes();
                    break;
                case "injectionCode":
                    EventCode3();
                    break;
                case "QuestItem":
                    QuestItemBoxs();
                    break;
                case "ExpQuest":
                    QuestTeamAndSingleV2();
                    break;
                case "StartGame":
                    StartGameDump();
                    break;
                case "CheckFireFox":
                    FirefoxinstallCheck();
                    break;
                default:
                    throw new ArgumentException("Invalid task");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Loads();
            string folderpathh = Path.Combine(baseDirectory, "selenium-manager");
            HideFolder(folderpathh);
            deletItems();
            StartCheck();
           
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("StartGame");
                

            }
            else
            {
                LogMessage("กำลังดำเนินการอยู่รอสักครู่");
            }
        }

        private void โปรแกรมมาโครToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("SF_Macro");
                MessageBox.Show("อย่าปิดโปรแกรมข้างหลังจนกว่าจะออกจาก Macro");

            }
            else
            {
                LogMessage("กำลังทำงานอยู่");
            }
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://member.sf.in.th/EventCenter/");
        }

        private void lenHerYakJakToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http://keyword.gg.in.th/");
        }

        private void btn_ItemSing_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("ExpQuest");

            }
            else
            {
                LogMessage("กำลังดำเนินการอยู่รอสักครู่");
            }
        }

        private void btn_QuestBox_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("QuestItem");

            }
            else
            {
                LogMessage("กำลังดำเนินการอยู่รอสักครู่");
            }
        }

        private void btn_InvCode_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("injectionCode");
            }
            else
            {
                LogMessage("กำลังดำเนินการอยู่รอสักครู่");
            }
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (!bw_01.IsBusy)
            {
                bw_01.RunWorkerAsync("GetItemcode");
            }
            else
            {
                LogMessage("กำลังดำเนินการอยู่รอสักครู่");
            }
        }

        private void coppyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(
               $"Day = {txt_time.Text}\n\n" +
               $"Key = {txt_keyDay.Text}\n " +
               $"0   = {txt_0.Text}\n" +
               $"60  = {txt_60.Text}\n" +
               $"120 = {txt_120.Text}\n" +
               $"180 = {txt_180.Text}\n" +
               $"240 = {txt_240.Text}\n" +
               $"300 = {txt_300.Text}\n" +
               $"360 = {txt_360.Text}\n" +
               $"420 = {txt_420.Text}\n" +
               $"480 = {txt_480.Text}\n" +
               $"540 = {txt_540.Text}\n" +
               $"600 = {txt_600.Text}\n\n"
               );
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username01;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password01;

            }
            if (radioButton2.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username02;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password02;

            }
            if (radioButton3.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username03;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password03;
            }
            if (radioButton4.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username04;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password04;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username01;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password01;

            }
            if (radioButton2.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username02;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password02;

            }
            if (radioButton3.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username03;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password03;
            }
            if (radioButton4.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username04;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password04;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username01;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password01;

            }
            if (radioButton2.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username02;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password02;

            }
            if (radioButton3.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username03;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password03;
            }
            if (radioButton4.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username04;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password04;

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username01;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password01;

            }
            if (radioButton2.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username02;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password02;

            }
            if (radioButton3.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username03;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password03;
            }
            if (radioButton4.Checked)
            {
                txt_Username.Text = AutoCodeSF.Properties.Settings.Default.Username04;
                txt_Password.Text = AutoCodeSF.Properties.Settings.Default.Password04;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                AutoCodeSF.Properties.Settings.Default.Username01 = txt_Username.Text;
                AutoCodeSF.Properties.Settings.Default.Password01 = txt_Password.Text;
                AutoCodeSF.Properties.Settings.Default.Save();
            }
            if (radioButton2.Checked)
            {
                AutoCodeSF.Properties.Settings.Default.Username02 = txt_Username.Text;
                AutoCodeSF.Properties.Settings.Default.Password02 = txt_Password.Text;
                AutoCodeSF.Properties.Settings.Default.Save();
            }
            if (radioButton3.Checked)
            {
                AutoCodeSF.Properties.Settings.Default.Username03 = txt_Username.Text;
                AutoCodeSF.Properties.Settings.Default.Password03 = txt_Password.Text;
                AutoCodeSF.Properties.Settings.Default.Save();
            }
            if (radioButton4.Checked)
            {
                AutoCodeSF.Properties.Settings.Default.Username04 = txt_Username.Text;
                AutoCodeSF.Properties.Settings.Default.Password04 = txt_Password.Text;
                AutoCodeSF.Properties.Settings.Default.Save();
            }
        }

        private void cb_EbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_EbID.Checked)
            {
                txt_Username.Enabled = false;
                txt_Password.Enabled = false;
            }
            else
            {
                txt_Username.Enabled = true;
                txt_Password.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            deletItems();
            
        }

        private void bw_01_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            LogMessage("สิ้นสุดการทำงาน");
            Loong();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
