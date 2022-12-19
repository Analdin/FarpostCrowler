using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Globalization;
using System.Runtime.InteropServices;

namespace FarpostCrowler
{
    public partial class Form1 : Form
    {
        IWebDriver driver = new ChromeDriver();
        Random rnd = new Random();

        public static string loginField { get; set; }
        public static string passField { get; set; }
        public static double limitFrom { get; set; }
        public static double limitTo { get; set; }
        public static double fullLimit { get; set; }
        public static string TimeStart { get; set; }
        public static string TimeEnd { get; set; }
        public static int TimeSetFrom { get; set; }
        public static int TimeSetTo { get; set; }
        public static string boxRubrika { get; set; }

        public Form1()
        {
            InitializeComponent();
            Task.Factory.StartNew(ConsoleOpen);
        }
        private void ConsoleOpen()
        {
            if (AllocConsole())
            {
                System.Console.WriteLine("For close, print - exit.");
                while (true)
                {
                    string output = Console.ReadLine();
                    if (output == "exit")
                        break;
                    Action action = () => passBox.Text += output + Environment.NewLine;
                    if (InvokeRequired)
                        Invoke(action);
                    else
                        action();
                }
                //FreeConsole();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();

        private void stopBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            TimeCheck.TimeOfTheJobCheck(TimeStart,TimeEnd);

            // ������ ��������
            driver.Navigate().GoToUrl("https://www.farpost.ru/");
            Thread.Sleep(rnd.Next(3500, 5500));

            List<IWebElement> login = driver.FindElements(By.XPath("//a[contains(@class, 'login')]")).ToList();
            if(login.Count > 0)
            {
                // ������ �� ����
                IWebElement lonelogin = login.First();
                lonelogin.Click();
                Thread.Sleep(rnd.Next(7500, 14500));

                // ����� 
                List<IWebElement> loginField = driver.FindElements(By.XPath("//input[contains(@class, 'text')]")).ToList();
                if(loginField.Count > 0)
                {
                    IWebElement lone = loginField.First();
                    lone.Click();

                    Thread.Sleep(rnd.Next(3500, 4500));

                    ActionsOnWeb.TextEnter(lone, loginBox.Text.ToString(), 50, 250);
                }

                // ������
                List<IWebElement> passField = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input[contains(@name, 'password')]")).ToList();
                if (passField.Count > 0)
                {
                    IWebElement lone = passField.First();
                    lone.Click();

                    Thread.Sleep(rnd.Next(3500, 4500));

                    ActionsOnWeb.TextEnter(lone, passBox.Text.ToString(), 50, 250);
                }

                // ������ �����
                List<IWebElement> enterBtn = driver.FindElements(By.XPath("//div[contains(@class, 'submitBlock')]/button[contains(@type, 'submit')]")).ToList();
                if (enterBtn.Count > 0)
                {
                    IWebElement lone = enterBtn.First();
                    lone.Click();

                    Thread.Sleep(rnd.Next(3500, 4500));

                    // ���� ��������� ��������� - "�������� ���"
                    List<IWebElement> btnLogin = driver.FindElements(By.XPath("//button[contains(@type, 'submit')]")).ToList();
                    if(btnLogin.Count > 0)
                    {
                        IWebElement getSms = btnLogin.First();
                        getSms.Click();

                        Thread.Sleep(rnd.Next(3500, 4500));

                        MessageBox.Show("����� ��� ����� ���");
                    }
                }

                List<string> allAdvInCabLst = new List<string>();

                // ���������� ������ ����� ��� ���� � ������ ��������
                driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                Thread.Sleep(rnd.Next(3500, 4500));

                // ���� �������� ���������� � ��������� ������
                while(true)
                {
                    //div[contains(@class, 'bull-item-content__content-wrapper')]
                    // ������� ������ � ������ ��� ��� ���� �� ��������
                    List<IWebElement> advs = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                    foreach(var elm in advs)
                    {
                        allAdvInCabLst.Add(elm.Text);
                    }

                    // ����������� ��������

                    // ��������� �� ������ ���������� � ������ ������, �������� ���������� � ���������
                    foreach(var elm in allAdvInCabLst)
                    {
                        List<IWebElement> loneElms = driver.FindElements(By.XPath(String.Format("//div[contains(@class, 'bull-item-content__subject-container')]/a[contains(text(), '{0}')]", elm))).ToList();
                        if(loneElms.Count > 0)
                        {
                            IWebElement one = loneElms.First();
                            one.Click();
                        }

                        // ��������� ������� ������ "���������" - ���� ��� ����, ������ ���������� �������
                        List<IWebElement> stickBtn = driver.FindElements(By.XPath("//a[contains(@class, 'serviceStick')]")).ToList();
                        if(stickBtn.Count > 0)
                        {
                            IWebElement lone = stickBtn.First();
                            lone.Click();

                            Thread.Sleep(rnd.Next(6500, 7500));

                            // ����� ��������� ������������ �������
                            Console.WriteLine("���� - ���������");

                            // ����������� �� ��������� �������
                            List<IWebElement> rubrika = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", boxRubrika))).ToList();
                            if(rubrika.Count > 0)
                            {
                                Console.WriteLine($"�������� ������� ��� ������: {boxRubrika}");
                                IWebElement loneRub = rubrika.First();
                                loneRub.Click();
                                Thread.Sleep(rnd.Next(1500, 2500));
                            }

                            // ������ ������ �� �����
                            List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                            double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace.First().Text);
                            double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);

                            // ��������� �����
                            if (setForFirstPlaceTxt <= fullLimit)
                            {
                                IntervalSet run = new IntervalSet();
                                run.Interval(TimeSetFrom, TimeSetTo);

                                Console.WriteLine("������ �� ������ ����� � ��������� ���������, ������ ������ �� ������ ����� + 2���");
                                IWebElement set = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                set.Click();

                                Thread.Sleep(rnd.Next(1500, 2500));

                                Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt + 2));
                                // ������
                                IWebElement stickSet = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                Thread.Sleep(rnd.Next(1500, 2500));

                                // ���� ���������
                                IWebElement stickBtnF = driver.FindElement(By.XPath("//button[contains(@type, 'submit')]"));
                                stickBtnF.Click();

                                Thread.Sleep(rnd.Next(4500, 6500));

                                // ������������� ������������ ����������
                                IWebElement stickAdv = driver.FindElement(By.XPath("//button[contains(@class, 'submit')]"));
                                stickAdv.Click();

                                // ��� �����
                                driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                            }
                            else
                            {
                                Console.WriteLine("�� ���������� �������� �����, ������ �� ������ � ���");
                            }
                        }
                        else
                        {
                            Console.WriteLine("���������� �� �������, ��� �����");
                            driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                            Thread.Sleep(rnd.Next(1500, 2500));
                        }
                    }
                }
            }
        }

        private void boxLimit_TextChanged(object sender, EventArgs e)
        {
            fullLimit = Convert.ToDouble(boxLimit.Text);
        }

        private void timeFrom_TextChanged(object sender, EventArgs e)
        {
            TimeStart = timeFrom.Text;
        }

        private void timeTo_TextChanged(object sender, EventArgs e)
        {
            TimeEnd = timeTo.Text;
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {
            loginField = loginBox.Text;
        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {
            passField = passBox.Text;
        }

        private void timeToSetFrom_TextChanged(object sender, EventArgs e)
        {
            TimeSetFrom = Convert.ToInt32(timeToSetFrom.Text);
        }

        private void timeToSetTo_TextChanged(object sender, EventArgs e)
        {
            TimeSetTo = Convert.ToInt32(timeToSetTo.Text);
        }

        private void rubrikaBox_TextChanged(object sender, EventArgs e)
        {
            boxRubrika = rubrikaBox.Text;
        }
    }

    /// <summary>
    /// ����� ����� ���������� ������
    /// </summary>
    public class IntervalSet
    {
        Random rnd = new Random();

        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="timeFrom"> ����� �� � ����</param>
        /// <param name="timeTo"> ����� �� � ����</param>
        public void Interval(int timeFrom, int timeTo)
        {
            Console.WriteLine($"����� ����� ����������� ������: {rnd.Next(timeFrom, timeTo)}");
            Thread.Sleep(rnd.Next(timeFrom, timeTo));
        }
    }

    public class ActionsOnWeb
    {
        /// <summary>
        /// ����������� ���� ������
        /// </summary>
        /// <param name="elm"> � ����� ������� ���������� �����: ���� ��� �����, ��������</param>
        /// <param name="Variable"> ����� ��� ��������</param>
        /// <param name="speedFrom"> �������� "��" � ����</param>
        /// <param name="speedTo"> �������� "��" � ����</param>
        public static void TextEnter(IWebElement elm, string Variable, int speedFrom, int speedTo)
        {
            Random rnd = new Random();

            for (int m = 0; m < Variable.Length; m++)
            {
                elm.SendKeys(Variable[m].ToString());
                Thread.Sleep(rnd.Next(speedFrom, speedTo));
            }
        }
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public class TimeCheck
    {
        public static DateTime nowTime { get; set; } = DateTime.Now;

        public static void TimeOfTheJobCheck(string startJob, string endJob)
        {
            // �������� �������� �� ������ ������ �� ��������

            nowTime = DateTime.ParseExact(endJob, "HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));
            DateTime dto = DateTime.ParseExact(startJob, "HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));

            Console.WriteLine("����� ������ ������: " + dto);

            // ������� ������� ����� ������� �������� � ������������� � �������

            double diff = nowTime.Subtract(dto).TotalMilliseconds;
            Console.WriteLine("������� ����� ������: " + diff);
            Console.WriteLine("�������� ������ �������: " + diff);

            while (true)
            {
                if (diff < 0)
                {
                    Console.WriteLine("������� ����� ������ �������");
                    Thread.Sleep(10000);
                }
                else
                {
                    Console.WriteLine("��������� ����� ������ ������� - ���������");
                    //Thread.Sleep(Convert.ToInt32(diff));
                    break;
                }
            }
        }        
    }
}