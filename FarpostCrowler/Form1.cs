using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Policy;
using OfficeOpenXml;
using System.Diagnostics.Metrics;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        public static string limitStart { get; set; }
        public static string limitStop { get; set; }
        public static string TimeStart { get; set; }
        public static string TimeEnd { get; set; }
        public static int TimeSetFrom { get; set; }
        public static int TimeSetTo { get; set; }
        public static string boxRubrika { get; set; }
        public static bool stop { get; set; } = false;
        public static int count { get; set; } = 1;
        public static string stepByStep { get; set; }
        public Form1()
        {
            //DateTime goToDead = new DateTime(2023, 08, 31);

            //if (DateTime.Now > goToDead)
            //{
            //    Console.WriteLine("�������� ������ ��������.");
            //    Environment.Exit(0);
            //}

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
            stop = true;
            this.Close();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                string loginTxt = String.Empty;
                string passwordTxt = String.Empty;

                //string inputFile = Directory.GetCurrentDirectory() + @"\Files\EnterData.xlsx";

                //using (var package = new ExcelPackage(new FileInfo(inputFile)))
                //{
                //    var sheet = package.Workbook.Worksheets[0];

                //    count++;

                //    int rows = sheet.Dimension.Rows + 1;
                //    Console.WriteLine("rows - " + rows);

                //    if (count >= rows)
                //    {
                //        Console.WriteLine("������ ��� ������ � �������, ��������� ���� �����������...");
                //        Environment.Exit(0);
                //    }

                //    var cellValueA = sheet.Cells[$"A{count}"].Value;
                //    limitStart = cellValueA != null ? cellValueA.ToString() : string.Empty;

                //    var cellValueB = sheet.Cells[$"B{count}"].Value;
                //    limitStop = cellValueB != null ? cellValueB.ToString() : string.Empty;

                //    fullLimit = (double)sheet.Cells[$"C{count}"].Value;
                //    TimeStart = sheet.Cells[$"D{count}"].Value.ToString();
                //    TimeEnd = sheet.Cells[$"E{count}"].Value.ToString();
                //    boxRubrika = (string)sheet.Cells[$"F{count}"].Value;
                //    Variables.idAdv = sheet.Cells[$"G{count}"].Value.ToString();
                //    TimeSetFrom = Convert.ToInt32(sheet.Cells[$"H{count}"].Value);
                //    TimeSetTo = Convert.ToInt32(sheet.Cells[$"I{count}"].Value);
                //    loginTxt = sheet.Cells[$"J{count}"].Value.ToString();
                //    passwordTxt = sheet.Cells[$"K{count}"].Value.ToString();
                //    Console.WriteLine("������ ��: " + limitStart);
                //    Console.WriteLine("������ ��: " + limitStop);
                //    Console.WriteLine("����� ������: " + fullLimit);
                //    Console.WriteLine("����� ������ ������: " + TimeStart);
                //    Console.WriteLine("����� ��������� ������: " + TimeEnd);
                //    Console.WriteLine("������� ��� ������: " + boxRubrika);
                //    Console.WriteLine("Id ����������: " + Variables.idAdv);
                //    Console.WriteLine("����� ���������� ������ ��: " + TimeSetFrom);
                //    Console.WriteLine("����� ���������� ������ ��: " + TimeSetTo);
                //    Console.WriteLine("�����: " + loginField);
                //    Console.WriteLine("������: " + passField);
                //    package.Dispose();
                //}

                // ������ ��������
                driver.Navigate().GoToUrl("https://www.farpost.ru/");
                Thread.Sleep(rnd.Next(1500, 2500));

                Console.WriteLine("��������� ����");
                //������ ���� �� �����:
                string path = Directory.GetCurrentDirectory() + @"\ProfCookie\cookie.txt";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            var cookiesStr = sr.ReadLine().Split(';');
                            DateTime date;
                            OpenQA.Selenium.Cookie cookie;
                            if (DateTime.TryParse(cookiesStr[4], out date))
                                cookie = new OpenQA.Selenium.Cookie(cookiesStr[0], cookiesStr[1], cookiesStr[2], cookiesStr[3], date);
                            else
                                cookie = new OpenQA.Selenium.Cookie(cookiesStr[0], cookiesStr[1], cookiesStr[2], cookiesStr[3], null);
                            driver.Manage().Cookies.AddCookie(cookie);
                        }
                    }
                }
                driver.Navigate().GoToUrl("https://www.farpost.ru/");
                Thread.Sleep(rnd.Next(1500, 2500));

                List<IWebElement> login = driver.FindElements(By.XPath("//a[contains(@class, 'login')]")).ToList();
                if (login.Count > 0)
                {
                    // �������� �� �������
                    List<IWebElement> loginYes = driver.FindElements(By.XPath("//td[contains(@class, 'col_login')]/a/i")).ToList();
                    if (loginYes.Count > 0)
                    {
                        Console.WriteLine("���� ��� ��������");
                    }
                    else
                    {
                        // ������ �� ����
                        IWebElement lonelogin = login.First();
                        lonelogin.Click();
                        Thread.Sleep(rnd.Next(1500, 2500));

                        // ����� 
                        List<IWebElement> loginField = driver.FindElements(By.XPath("//input[contains(@class, 'text')]")).ToList();
                        if (loginField.Count > 0)
                        {
                            IWebElement lone = loginField.First();
                            lone.Click();

                            Thread.Sleep(rnd.Next(500, 700));

                            ActionsOnWeb.TextEnter(lone, Variables.loginField, 50, 250);
                        }

                        // ������
                        List<IWebElement> passField = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input[contains(@name, 'password')]")).ToList();
                        if (passField.Count > 0)
                        {
                            IWebElement lone = passField.First();
                            lone.Click();

                            Thread.Sleep(rnd.Next(1500, 2500));

                            ActionsOnWeb.TextEnter(lone, Variables.passField, 50, 250);
                        }

                        // ������ �����
                        List<IWebElement> enterBtn = driver.FindElements(By.XPath("//div[contains(@class, 'submitBlock')]/button[contains(@type, 'submit')]")).ToList();
                        if (enterBtn.Count > 0)
                        {
                            IWebElement lone = enterBtn.First();
                            lone.Click();

                            Thread.Sleep(rnd.Next(1500, 2500));

                            // ���� ��������� ��������� - "�������� ���"
                            List<IWebElement> btnLogin = driver.FindElements(By.XPath("//button[contains(@type, 'submit')]")).ToList();
                            if (btnLogin.Count > 0)
                            {
                                IWebElement getSms = btnLogin.First();
                                getSms.Click();

                                Thread.Sleep(rnd.Next(1500, 2500));

                                MessageBox.Show("����� ��� ����� ���");
                            }
                        }
                    }

                    List<string> allAdvInCabLst = new List<string>();

                    // ���������� ������ ����� ��� ���� � ������ ��������
                    driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                    Thread.Sleep(rnd.Next(1500, 2500));

                    // ���� �������� ���������� � ��������� ������
                    while (true)
                    {
                        // ��������� ����� ���������� ���������


                        //div[contains(@class, 'bull-item-content__content-wrapper')]
                        // ������� ������ � ������ ��� ��� ���� �� ��������
                        List<IWebElement> advs = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                        foreach (var elm in advs)
                        {
                            allAdvInCabLst.Add(elm.GetAttribute("href"));
                            Console.WriteLine(elm.Text);
                        }

                        // ����������� ��������

                        // ��������� �� ������ ���������� � ������ ������, �������� ���������� � ���������
                        foreach (var elm in allAdvInCabLst)
                        {
                            //div[contains(@class, 'bull-item-content__subject-container')] / a[contains(@name, '{0}')]
                            List<IWebElement> loneElms = driver.FindElements(By.XPath(String.Format("//a[contains(@href,'{0}')]", Variables.idAdv))).ToList();
                            if (loneElms.Count > 0)
                            {
                                IWebElement one = loneElms.FirstOrDefault();
                                one.Click();
                            }

                            Thread.Sleep(8000);

                            // ����� ������� ��� ������
                            // �������� ������� �������
                            List<IWebElement> rubrikaLst3 = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", Variables.boxRubrika))).ToList();
                            if (rubrikaLst3.Count > 0)
                            {
                                Console.WriteLine($"�������� ������� ��� ������: {Variables.boxRubrika}");
                                IWebElement loneRub3 = rubrikaLst3.First();
                                loneRub3.Click();
                                Thread.Sleep(rnd.Next(1500, 2500));
                            }

                            //button[contains(@class, 'stick-form__save-button')]
                            //a[contains(@class, 'serviceStick')]
                            // ��������� ������� ������ "���������" - ���� ��� ����, ������ ���������� �������
                            List<IWebElement> stickBtn = driver.FindElements(By.XPath("//a[contains(@class, 'serviceStick')]|//button[contains(@class, 'stick-form__save-button')]")).ToList();
                            List<IWebElement> alreadySticked = driver.FindElements(By.XPath("//div[contains(@class, 'service-card-head__link')]")).ToList();

                            if (stickBtn.Count > 0)
                            {
                                IWebElement lone = stickBtn.First();
                                lone.Click();

                                Thread.Sleep(rnd.Next(12500, 13500));

                                // ����� ��������� ������������ �������
                                Console.WriteLine("���� - ���������");

                                // ��������� �� ��������� - ������� ������ ���������� ���������
                                List<IWebElement> offen = driver.FindElements(By.XPath("//div[contains(@class, 'checked-annotation')][2]/p")).ToList();
                                if (offen.Count > 0)
                                {
                                    IWebElement of = offen.FirstOrDefault();

                                    if (of.Text.Contains("������� ������ ���������� ������ ���������"))
                                    {
                                        Console.WriteLine("����� 2 ������ ����� ������������ ����������...");
                                        Thread.Sleep(12000);

                                        // ����� ������������� �� ����������
                                        List<IWebElement> clkOnAdv = driver.FindElements(By.XPath("//button[contains(@id, 'serviceSubmit')]")).ToList();
                                        if (clkOnAdv.Count > 0)
                                        {
                                            IWebElement clkA = clkOnAdv.FirstOrDefault();
                                            clkA.Click();
                                            Thread.Sleep(rnd.Next(1500, 2500));
                                        }

                                        List<IWebElement> stickedLst = driver.FindElements(By.XPath("//div[contains(@class, 'serviceStick')]/div")).ToList();
                                        if (stickedLst.Count > 0)
                                        {
                                            IWebElement st = stickedLst.FirstOrDefault();
                                            st.Click();
                                            Thread.Sleep(rnd.Next(1500, 2500));
                                        }
                                    }
                                }

                                Thread.Sleep(rnd.Next(1500, 2500));
                                // ����������� �� ��������� �������
                                List<IWebElement> rubrika = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", Variables.boxRubrika))).ToList();
                                if (rubrika.Count > 0)
                                {
                                    Console.WriteLine($"�������� ������� ��� ������: {Variables.boxRubrika}");
                                    IWebElement loneRub = rubrika.First();
                                    loneRub.Click();
                                    Thread.Sleep(rnd.Next(1500, 2500));
                                }

                                // ����������� �� ����������
                                List<IWebElement> stick = driver.FindElements(By.XPath("//div[contains(@class, 'serviceStick')]")).ToList();
                                if (stick.Count > 0)
                                {
                                    IWebElement st = stick.FirstOrDefault();
                                    st.Click();
                                    Thread.Sleep(2000);
                                }

                                // ������ ������ �� �����
                                List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                                double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace.First().Text);
                                double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);

                                // ��������� �����
                                if (setForFirstPlaceTxt <= Variables.fullLimit)
                                {
                                    IntervalSet run = new IntervalSet();
                                    run.Interval(Variables.TimeSetFrom, Variables.TimeSetTo);

                                    Console.WriteLine("������ �� ������ ����� � ��������� ���������, ������ ������ �� ������ �����");
                                    IWebElement set = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                    set.Click();

                                    Thread.Sleep(rnd.Next(1500, 2500));

                                    string inputFile2 = Directory.GetCurrentDirectory() + @"\Files\EnterData.xlsx";

                                    //using (var package = new ExcelPackage(new FileInfo(inputFile2)))
                                    //{
                                    //    var sheet = package.Workbook.Worksheets[0];

                                    //    count++;

                                    //    int rows = sheet.Dimension.Rows + 1;
                                    //    Console.WriteLine("rows - " + rows);

                                    //    if (count >= rows)
                                    //    {
                                    //        Console.WriteLine("������ ��� ������ � �������");
                                    //        Environment.Exit(0);
                                    //    }

                                    //    var cellValueA = sheet.Cells[$"A{count}"].Value;
                                    //    limitStart = cellValueA != null ? cellValueA.ToString() : string.Empty;

                                    //    var cellValueB = sheet.Cells[$"B{count}"].Value;
                                    //    limitStop = cellValueB != null ? cellValueB.ToString() : string.Empty;

                                    //    stepByStep = sheet.Cells[$"L{count}"].Value.ToString();
                                    //    Console.WriteLine("������ ��: " + limitStart);
                                    //    Console.WriteLine("������ ��: " + limitStop);
                                    //    Console.WriteLine("��� ������: " + stepByStep);
                                    //}

                                    double setLS = Convert.ToDouble(setForFirstPlaceTxt) + Convert.ToDouble(stepByStep);

                                    Clipboard.SetText(Convert.ToString(setLS));
                                    // ������
                                    IWebElement stickSet = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                    stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                    stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                    stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                    Thread.Sleep(rnd.Next(1500, 2500));

                                    // ���������� ����� �������� ������ � �������
                                    //using (var package = new ExcelPackage(new FileInfo(Directory.GetCurrentDirectory() + @"\Files\EnterData.xlsx")))
                                    //{
                                    //    ExcelWorksheet worksheet = package.Workbook.Worksheets["����1"];
                                    //    worksheet.Cells[count, 1].Value = setLS;
                                    //    package.Save();
                                    //    worksheet.Dispose();
                                    //}

                                    Thread.Sleep(3000);

                                    // �������� ������� �������
                                    List<IWebElement> rubrikaLst2 = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                                    if (rubrikaLst2.Count > 0)
                                    {
                                        Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                                        IWebElement loneRub2 = rubrikaLst2.First();
                                        loneRub2.Click();
                                        Thread.Sleep(rnd.Next(1500, 2500));
                                    }

                                    // ���� ���������
                                    List<IWebElement> stickBtnF = driver.FindElements(By.XPath("//button[contains(@type, 'submit')]")).ToList();
                                    if (stickBtn.Count > 0)
                                    {
                                        IWebElement st = stickBtnF.FirstOrDefault();
                                        st.Click();
                                    }

                                    Thread.Sleep(rnd.Next(6500, 7500));

                                    // ���� ������ �������������
                                    List<IWebElement> notEnoughtMoney = driver.FindElements(By.XPath("//div[contains(@class, 'block-lefted')]/div[contains(text(), '������������ ������� �� �����')]")).ToList();
                                    if (notEnoughtMoney.Count > 0)
                                    {
                                        IWebElement ne = notEnoughtMoney.FirstOrDefault();
                                        if (ne.Text.Contains("������������ ������� �� �����"))
                                        {
                                            MessageBox.Show("������������ ������� �� �����");
                                        }
                                    }
                                    else
                                    {
                                        // ������������� ������������ ����������
                                        List<IWebElement> stickAdv = driver.FindElements(By.XPath("//button[contains(@class, 'submit')]|//div[contains(@class, 'serviceStick')]")).ToList();
                                        if (stickAdv.Count > 0)
                                        {
                                            IWebElement st1 = stickAdv.FirstOrDefault();
                                            st1.Click();
                                        }
                                    }

                                    Console.WriteLine("����� ����������� ����������");
                                    // ��������� ������ �����������
                                    ActionsOnWeb.bidMonitoring(driver, TimeStart, TimeEnd, Variables.boxRubrika, Variables.fullLimit, Variables.TimeSetFrom, TimeSetTo, Variables.idAdv, Variables.limitStart, Variables.limitStop);
                                    TimeCheck.TimeOfTheJobCheck(driver, TimeStart, TimeEnd);
                                    // ��� �����
                                    driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                                }
                                else
                                {
                                    Console.WriteLine("�� ���������� �������� �����, ������ �� ������ � ���");
                                }
                            }
                            else if (alreadySticked.Count > 0)
                            {
                                IWebElement lone = alreadySticked.First();
                                lone.Click();
                                Thread.Sleep(rnd.Next(1500, 2500));
                                // ��������� ������ �����������
                                ActionsOnWeb.bidMonitoring(driver, Variables.TimeStart, Variables.TimeEnd, Variables.boxRubrika, Variables.fullLimit, Variables.TimeSetFrom, Variables.TimeSetTo, Variables.idAdv, Variables.limitStart, Variables.limitStop);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("���������� �� �������, ��� �����");
                                driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                                Thread.Sleep(rnd.Next(1500, 2500));
                                break;
                            }
                        }
                        if (stop) break;
                    }
                }
                TimeCheck.TimeOfTheJobCheck(driver, TimeStart, TimeEnd);
            }
        }

        private void boxLimit_TextChanged(object sender, EventArgs e)
        {
            Variables.fullLimit = Convert.ToDouble(boxLimit.Text);
        }

        private void timeFrom_TextChanged(object sender, EventArgs e)
        {
            Variables.TimeStart = timeFrom.Text;
        }

        private void timeTo_TextChanged(object sender, EventArgs e)
        {
            Variables.TimeEnd = timeTo.Text;
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {
            Variables.loginField = loginBox.Text;
        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {
            Variables.passField = passBox.Text;
        }

        private void timeToSetFrom_TextChanged(object sender, EventArgs e)
        {
            int timeset = 0;
            if (Int32.TryParse(timeToSetFrom.Text, out timeset))
            {
                Variables.TimeSetFrom = timeset;
            }
        }

        private void timeToSetTo_TextChanged(object sender, EventArgs e)
        {
            int timesetTo = 0;
            if (Int32.TryParse(timeToSetFrom.Text, out timesetTo))
            {
                Variables.TimeSetTo = timesetTo;
            }
        }

        private void rubrikaBox_TextChanged(object sender, EventArgs e)
        {
            Variables.boxRubrika = rubrikaBox.Text;
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            Variables.idAdv = idBox.Text;
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
        public static int count { get; set; } = 1;
        public static string stepByStep { get; set; }
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

        /// <summary>
        /// ���������� ������ �� �����
        /// </summary>
        /// <param name="startTime"> ����� ������ ������</param>
        /// <param name="endTime"> ����� ��������� ������</param>
        public static void bidMonitoring(IWebDriver driver, string startTime, string endTime, string rubrika, double limit, int timeSFrom, int timeSTo, string id, double limitStart, double limitStop)
        {
            Random rnd = new Random();
            string myIndex = id;
            List<string> allAdvs = new List<string>();

            // ����� ��������� ��������� ������
            // ����������� ����������
            List<IWebElement> stickAdv = driver.FindElements(By.XPath("//button[contains(@id,'serviceSubmit')]")).ToList();
            if (stickAdv.Count > 0)
            {
                IWebElement sa = stickAdv.FirstOrDefault();
                sa.Click();
                Thread.Sleep(3000);
            }

            // ���� �� ���������
            List<IWebElement> stickedLst = driver.FindElements(By.XPath("//div[contains(@class, 'serviceStick')]")).ToList();
            if (stickedLst.Count > 0)
            {
                IWebElement sl = stickedLst.FirstOrDefault();
                sl.Click();
                Thread.Sleep(3000);
            }

            // � ���� ������� ��������� ������ ����������, ���� �� ������� "��������� ��...", ����� ������� � ������ ����������
            List<IWebElement> stickedPrice = driver.FindElements(By.XPath("//div[contains(@class, 'service-card-head__link')]")).ToList();
            if (stickedPrice.Count > 0)
            {
                IWebElement lone = stickedPrice.First();
                lone.Click();
                Thread.Sleep(rnd.Next(1500, 2500));
            }

            Thread.Sleep(rnd.Next(1500, 2500));
            // ����������� �� ��������� �������
            List<IWebElement> rubrikaLst = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
            if (rubrikaLst.Count > 0)
            {
                Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                IWebElement loneRub = rubrikaLst.First();
                loneRub.Click();
                Thread.Sleep(rnd.Next(1500, 2500));
            }

            // ���� �������� ����������
            while (true)
            {
                int indexOfChar = 0;

                // ���������� ��������
                string url = driver.Url;
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(3000);

                allAdvs.Clear();
                List<IWebElement> listOfAdvs = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                foreach (var index in listOfAdvs)
                {
                    allAdvs.Add(index.GetAttribute("href"));
                    Console.WriteLine(index.GetAttribute("href"));
                }

                allAdvs.RemoveAt(0);
                allAdvs.RemoveAt(0);


                for (int i = 0; i < allAdvs.Count; i++)
                {
                    string elm = allAdvs[i];
                    if (elm.Contains(myIndex))
                    {
                        indexOfChar = i;
                        break;
                    }
                }

                // ���� ����� - �������� ������ ��������� ����������
                List<IWebElement> stickAgain = driver.FindElements(By.XPath("//button[contains(@id,'serviceSubmit')]")).ToList();
                if (stickAgain.Count > 0)
                {
                    IWebElement sa = stickAgain.FirstOrDefault();
                    //sa.Click();
                    Thread.Sleep(4000);
                }

                TimeCheck.TimeOfTheJobCheck(driver, startTime, endTime);

                // ��������� ����
                // ���������� ���� � ����
                string path = Directory.GetCurrentDirectory() + @"\ProfCookie\cookie.txt";

                Console.WriteLine("��������� ����: " + path);

                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var cookie in driver.Manage().Cookies.AllCookies)
                    {
                        sw.WriteLine(cookie.Name + ";" + cookie.Value + ";" + cookie.Domain + ";" + cookie.Path + ";" + cookie.Expiry.ToString());
                    }
                    sw.Close();
                }

                if (indexOfChar > 0)
                {
                    // ���������� �������� �� ������� ���������
                    string url2 = driver.Url;
                    Console.WriteLine("������� url: " + url2);

                    // ������ ������ �� �����
                    List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                    double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace.First().Text);
                    double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);

                    if (setForFirstPlace.Count == 0)
                    {
                        // ����������� ������� �� ����������
                        driver.Navigate().GoToUrl(url);
                        Thread.Sleep(rnd.Next(200, 500));
                    }

                    // ���� � ������
                    List<IWebElement> priceInWindow = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                    IWebElement lonePrice = priceInWindow.First();
                    double priceInWinTxt = Convert.ToDouble(lonePrice.GetAttribute("value"));

                    if (Variables.limitStart > 0)
                    {
                        // ������ ������ �� �����
                        List<IWebElement> setOnSite = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                        double setForTheFirst = Convert.ToDouble(setForFirstPlace.First().Text);
                        double minPrice = Convert.ToDouble(setForFirstPlace.Last().Text);

                        // ���� � ������
                        List<IWebElement> priceNow = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                        IWebElement priceLOne = priceInWindow.First();
                        double loneTxt = Convert.ToDouble(lonePrice.GetAttribute("value"));
                        Console.WriteLine($"������� ������������� ������ �� 1 ����� - {loneTxt} ���");

                        double LS = Convert.ToDouble(limitStart);

                        LS = loneTxt + Convert.ToDouble(stepByStep);

                        if (Convert.ToDouble(loneTxt) <= LS)
                        {
                            Console.WriteLine($"��� ������ - {stepByStep}, ���������");
                            Console.WriteLine("������ �� ������ ����� � ��������� ���������, ������ ������ �� ������ �����");
                            IWebElement set = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                            set.Click();

                            Thread.Sleep(rnd.Next(1500, 2500));

                            //BidCounting bid = new BidCounting();
                            //bid.bidSet(driver);

                            // ��� ������ ������. ������: 170*0,06 �������� ���������� ������,
                            // ����� ���������� +1 �� ������� �����.

                            if (setForTheFirst > LS)
                            {
                                // ���������� ���� ����� ������� 1 � 2
                                List<IWebElement> step1 = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                                double firstSet = Convert.ToDouble(setForFirstPlace.First().Text);
                                double minP = Convert.ToDouble(setForFirstPlace.Last().Text);

                                // ���� � ������
                                List<IWebElement> prInWin = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                                IWebElement prLone = priceInWindow.First();
                                double pLone = Convert.ToDouble(lonePrice.GetAttribute("value"));
                                Console.WriteLine($"������� ������������� ������ �� 1 ����� - {pLone} ���");

                                // ���� �� �������
                                List<IWebElement> spin_down = driver.FindElements(By.XPath("//button[contains(@class, 'spins__spin_down')]")).ToList();
                                if (spin_down.Count > 0)
                                {
                                    IWebElement spin = spin_down.FirstOrDefault();
                                    spin.Click();
                                    Thread.Sleep(2000);

                                    // ��������� ������������ ������
                                    // ���� � ������
                                    List<IWebElement> prWithStep = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                                    IWebElement prStep = priceInWindow.First();
                                    double prS = Convert.ToDouble(lonePrice.GetAttribute("value"));
                                    Console.WriteLine($"����� ���� - {prS} ���");
                                }


                                Clipboard.SetText(Convert.ToString(setForTheFirst));
                                // ������
                                IWebElement stick = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "v");


                            }
                            else if (setForTheFirst < LS)
                            {
                                // ���������� ���� ����� ������� 1 � 2
                                List<IWebElement> step1 = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                                double firstSet = Convert.ToDouble(setForFirstPlace.First().Text);
                                double minP = Convert.ToDouble(setForFirstPlace.Last().Text);

                                // ���� � ������
                                List<IWebElement> prInWin = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                                IWebElement prLone = priceInWindow.First();
                                double pLone = Convert.ToDouble(lonePrice.GetAttribute("value"));
                                Console.WriteLine($"������� ������������� ������ �� 1 ����� - {pLone} ���");

                                List<string> allIds = new List<string>();
                                int ourIndex = 0;

                                // ���� �� ������� 1��� �����
                                Clipboard.SetText(Convert.ToString(setForTheFirst));
                                // ������
                                IWebElement stickSet2 = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                // ��������� ����� �� ������� ���� ���������� ������
                                Clipboard.SetText(Convert.ToString(setForTheFirst));
                                // ����������� ������ �� id ���� ���������� �� ��������
                                List<IWebElement> allIdsNow = driver.FindElements(By.XPath("//tbody[contains(@class, 'native')]/tr[contains(@data-doc-id,'')]")).ToList();
                                if (allIdsNow.Count > 0)
                                {
                                    foreach (var elm in allIdsNow)
                                    {
                                        allIds.Add(elm.Text);
                                        Console.WriteLine("��������� id - " + elm.Text);

                                        // �������� ������ ������ id
                                        if (elm.Text.Contains(Variables.idAdv))
                                        {
                                            Console.WriteLine($"����� ���� ���������� �� {allIdsNow.IndexOf(elm)} �����");
                                            break;
                                        }

                                        // ���� id != 1
                                        if (allIdsNow.IndexOf(elm) != 1)
                                        {
                                            //Console.WriteLine("��������� ��� �� �� ������ �����, ���������� +1 � ������");
                                            //priceMinus = priceMinus + 1;
                                        }
                                    }
                                }

                                Console.WriteLine("������ �� ������ ����� ���������� - ������ ������ �� ������ �����");
                                // �������� - �� ������� ���������� ������?
                                //priceMinus = priceMinus + 1;
                                Clipboard.SetText(Convert.ToString(setForTheFirst));
                                // ������
                                IWebElement stickSet = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                stickSet.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                            }

                            // ��� ���� �� ������� ������ +1

                            Thread.Sleep(rnd.Next(1500, 2500));

                            // ���� ���������
                            IWebElement stickBtnF = driver.FindElement(By.XPath("//button[contains(@type, 'submit')]"));
                            stickBtnF.Click();

                            Thread.Sleep(rnd.Next(4500, 6500));

                            // ������������� ������������ ����������
                            List<IWebElement> payed = driver.FindElements(By.XPath("//div[contains(@class, 'bulletin-user-action-block')]")).ToList();
                            if (payed.Count > 0)
                            {
                                IWebElement lone = payed.First();
                                string txt = lone.Text;
                                if (txt.Contains("��������"))
                                {
                                    Console.WriteLine("��� ���������, ���������...");
                                    // ���� �� "���������", ����� ���������� ������ ����������
                                    IWebElement alreadyStick = driver.FindElement(By.XPath("//div[contains(@class, 'serviceStick')]"));
                                    alreadyStick.Click();
                                    Thread.Sleep(rnd.Next(1500, 2500));

                                    // ����������� �� ��������� �������
                                    List<IWebElement> needRub = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                                    if (needRub.Count > 0)
                                    {
                                        Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                                        IWebElement loneRub = needRub.First();
                                        loneRub.Click();
                                        Thread.Sleep(rnd.Next(1500, 2500));
                                    }
                                }
                                else
                                {
                                    List<IWebElement> stickAdv5 = driver.FindElements(By.XPath("//button[contains(@class, 'submit')]")).ToList();
                                    if (stickAdv5.Count > 0)
                                    {
                                        IWebElement stick5 = stickAdv5.First();
                                        stick5.Click();
                                        Thread.Sleep(rnd.Next(1500, 2500));
                                    }
                                }
                            }

                        }
                    }
                    else if (priceInWinTxt > setForFirstPlaceTxt)
                    {
                        Console.WriteLine($"���� ������� ������� - {priceInWinTxt}, �������� ���������� - {setForFirstPlaceTxt}..."); ;
                        List<IWebElement> stickForTheFirstPlace = driver.FindElements(By.XPath("//a[contains(@class,'stick-applier-steps__price')]/span[contains(@data-role,'price-value')]")).ToList();
                        IWebElement onlyFirst = stickForTheFirstPlace.First();
                        onlyFirst.Click();

                        // ���� ���������
                        IWebElement stickBtnF = driver.FindElement(By.XPath("//button[contains(@type, 'submit')]"));
                        stickBtnF.Click();

                        Thread.Sleep(rnd.Next(1500, 2500));

                        // � ���� ������� ��������� ������ ����������, ���� �� ������� "��������� ��...", ����� ������� � ������ ����������
                        List<IWebElement> stickedPrice2 = driver.FindElements(By.XPath("//div[contains(@class, 'service-card-head__link')]")).ToList();
                        if (stickedPrice2.Count > 0)
                        {
                            IWebElement lone = stickedPrice2.First();
                            lone.Click();
                            Thread.Sleep(rnd.Next(1500, 2500));
                        }

                        Thread.Sleep(rnd.Next(1500, 2500));

                        // ����������� �� ��������� �������
                        List<IWebElement> rubrikaLst22 = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                        if (rubrikaLst22.Count > 0)
                        {
                            Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                            IWebElement loneRub = rubrikaLst22.First();
                            loneRub.Click();
                            Thread.Sleep(rnd.Next(1500, 2500));
                        }
                    }
                    else
                    {
                        //Console.WriteLine("���������� �� 1� �����, ������� ��������� ������...");
                        // ��������� ��������, ����� �������� ��������� � ������� ����������
                        string nowUrl = driver.Url;

                        // ��������� ��������� ������
                        while (true)
                        {
                            Thread.Sleep(2000);

                            List<IWebElement> inToAdv = driver.FindElements(By.XPath("//div[contains(@class, 'serviceStick')]")).ToList();
                            if (inToAdv.Count > 0)
                            {
                                IWebElement itv = inToAdv.FirstOrDefault();
                                itv.Click();
                                Thread.Sleep(2000);
                            }

                            // ����������� �� �������
                            List<IWebElement> rubrikaLst23 = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                            if (rubrikaLst23.Count > 0)
                            {
                                Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                                IWebElement loneRub = rubrikaLst23.First();
                                loneRub.Click();
                                Thread.Sleep(rnd.Next(1500, 2500));
                            }

                            // ���������� ���� ����� ������� 1 � 2
                            List<IWebElement> step1 = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                            double firstSet = Convert.ToDouble(step1.First().Text);
                            double minP = Convert.ToDouble(step1.Last().Text);

                            // ���� � ������
                            List<IWebElement> prInWin = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                            IWebElement prLone = prInWin.FirstOrDefault();
                            double pLone = Convert.ToDouble(prLone.GetAttribute("value"));
                            Console.WriteLine($"������� ������������� ������ �� 1 ����� - {pLone} ���");

                            if (firstSet == pLone)
                            {
                                Console.WriteLine("������ �� ����������, ���� ��������� ������...");
                                Thread.Sleep(6000);
                                driver.Navigate().GoToUrl(nowUrl);

                                TimeCheck.TimeOfTheJobCheck(driver, Variables.TimeStart, Variables.TimeEnd);
                            }
                            else if(firstSet > pLone)
                            {
                                Console.WriteLine("�������� ����������");

                                Thread.Sleep(1500);

                                // ��������� �� ��������� - ������� ������ ���������� ���������
                                List<IWebElement> offen = driver.FindElements(By.XPath("//div[contains(@class, 'checked-annotation')][2]/p")).ToList();
                                if (offen.Count > 0)
                                {
                                    IWebElement of = offen.FirstOrDefault();

                                    if (of.Text.Contains("������� ������ ���������� ������ ���������"))
                                    {
                                        Console.WriteLine("����� 2 ������ ����� ������������ ����������...");
                                        Thread.Sleep(12000);

                                        // ����� ������������� �� ����������
                                        List<IWebElement> clkOnAdv = driver.FindElements(By.XPath("//button[contains(@type, 'submit')]")).ToList();
                                        if (clkOnAdv.Count > 0)
                                        {
                                            IWebElement clkA = clkOnAdv.FirstOrDefault();
                                            clkA.Click();
                                            Thread.Sleep(rnd.Next(1500, 2500));
                                        }

                                        List<IWebElement> stickedLst2 = driver.FindElements(By.XPath("//div[contains(@class, 'serviceStick')]/div")).ToList();
                                        if (stickedLst2.Count > 0)
                                        {
                                            IWebElement st = stickedLst2.FirstOrDefault();
                                            st.Click();
                                            Thread.Sleep(rnd.Next(1500, 2500));
                                        }
                                    }
                                }

                                // ���� � ������
                                //List<IWebElement> prInWin3 = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                                //IWebElement prLone3 = prInWin3.FirstOrDefault();
                                //double pLone3 = Convert.ToDouble(lonePrice.GetAttribute("value"));
                                //Console.WriteLine($"������� ������������� ������ �� 1 ����� - {pLone} ���");

                                // ���� �� �������
                                List<IWebElement> spin_down = driver.FindElements(By.XPath("//button[contains(@class, 'spins__spin_up')]")).ToList();
                                if (spin_down.Count > 0)
                                {
                                    IWebElement spin = spin_down.FirstOrDefault();
                                    //spin.Click();
                                    Thread.Sleep(2000);

                                    // ��������� ������������ ������
                                    // ���� � ������
                                    //List<IWebElement> prWithStep = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                                    //IWebElement prStep = priceInWindow.First();
                                    //double prS = Convert.ToDouble(lonePrice.GetAttribute("value"));
                                    //Console.WriteLine($"����� ���� - {prS} ���");
                                }


                                Clipboard.SetText(Convert.ToString(firstSet));
                                // ������
                                IWebElement stick = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                stick.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                // ���������
                                List<IWebElement> save = driver.FindElements(By.XPath("//button[contains(@class, 'stick-form__save-button')]")).ToList();
                                if(save.Count > 0)
                                {
                                    IWebElement se = save.FirstOrDefault();
                                    se.Click();
                                    Thread.Sleep(4000);
                                }
                            }
                            else
                            {

                                double firstSetAdv = 0;

                                // �������� ������
                                if(Variables.limitStop <= pLone)
                                {
                                    Console.WriteLine("��������� ������������� �����, ���������� ������ �� ������ �� 1� �����...");

                                    // ��������� ������ �� ������ �����
                                    List<IWebElement> setFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__price-cell')]/a/span")).ToList();
                                    if(setFirstPlace.Count > 0)
                                    {
                                        IWebElement sfp = setFirstPlace.FirstOrDefault();
                                        firstSetAdv = Convert.ToDouble(sfp.Text);
                                    }

                                    firstSetAdv = firstSet;

                                    Clipboard.SetText(Convert.ToString(firstSet));
                                    // ��������� ������
                                    IWebElement stick = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                    stick.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                    stick.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                    stick.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                    // ���������
                                    List<IWebElement> save = driver.FindElements(By.XPath("//button[contains(@class, 'stick-form__save-button')]")).ToList();
                                    if (save.Count > 0)
                                    {
                                        IWebElement se = save.FirstOrDefault();
                                        se.Click();
                                        Thread.Sleep(4000);
                                    }
                                }

                                break;
                            }
                        }

                        // ������� ��� 20��� ���������� ���������
                        Thread.Sleep(500);

                        // � ���� ������� ��������� ������ ����������, ���� �� ������� "��������� ��...", ����� ������� � ������ ����������
                        List<IWebElement> stickedPrice2 = driver.FindElements(By.XPath("//div[contains(@class, 'service-card-head__link')]")).ToList();
                        if (stickedPrice2.Count > 0)
                        {
                            IWebElement lone = stickedPrice2.First();
                            lone.Click();
                            Thread.Sleep(rnd.Next(1500, 2500));
                        }

                        Thread.Sleep(rnd.Next(1500, 2500));
                        // ����������� �� ��������� �������
                        List<IWebElement> rubrikaLst22 = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                        if (rubrikaLst22.Count > 0)
                        {
                            Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                            IWebElement loneRub = rubrikaLst22.First();
                            //loneRub.Click();
                            Thread.Sleep(rnd.Next(1500, 2500));
                        }
                    }
                }
                else if (indexOfChar > 1)
                {
                    Console.WriteLine($"������ ����������, ���������� �� {indexOfChar} �����, ��������� ��� �������� ����������, � ����������� �� ��������...");

                    double newSet = 0;

                    // ������ ������ �� �����
                    List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                    double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace[0].Text);
                    double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);

                    // ���� � ������
                    List<IWebElement> priceInWindow = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                    IWebElement lonePrice = priceInWindow.First();
                    double priceInWinTxt = Convert.ToDouble(lonePrice.GetAttribute("value"));

                    // ��������� �����
                    if (setForFirstPlaceTxt <= Variables.fullLimit)
                    {
                        IntervalSet run = new IntervalSet();
                        run.Interval(timeSFrom, timeSTo);

                        Console.WriteLine("������ �� ������ ����� � ��������� ���������, ������ ������ �� ������ �����");
                        IWebElement set = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                        set.Click();

                        Thread.Sleep(rnd.Next(1500, 2500));

                        // (setForFirstPlaceTxt * 0.06)
                        List<string> allIds = new List<string>();

                        //setForFirstPlaceTxt = setForFirstPlaceTxt - 10;

                        // ������� ������ ���������� ������ 111
                        Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt));

                        // ������
                        IWebElement stickSet1 = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                        stickSet1.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                        stickSet1.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                        stickSet1.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                        List<string> allAdvInCabLst = new List<string>();

                        List<IWebElement> advs = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                        foreach (var elm in advs)
                        {
                            allAdvInCabLst.Add(elm.GetAttribute("name"));
                            Console.WriteLine(elm.GetAttribute("name"));
                        }

                        allAdvInCabLst.RemoveAt(0);

                        foreach (var elm in allAdvInCabLst)
                        {
                            Console.WriteLine(elm);
                        }

                        // ������� - ���� ������ 0 ��� 1, �� ������ ��������� ������, ���� ������, �� ������
                        if (allAdvInCabLst.IndexOf(Variables.idAdv) == 0 || allAdvInCabLst.IndexOf(Variables.idAdv) == 1)
                        {
                            Console.WriteLine("���� ���������� �� ������ �����, ��������� ������ ��� ����");
                        }
                        else
                        {
                            // ������
                            IWebElement stickSet2 = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                            stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                            stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                            stickSet2.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                            // ��������� ����� �� ������� ���� ���������� ������
                            Clipboard.SetText(Convert.ToString(priceInWinTxt));
                            double newPrice = 0;

                            //// ���� �� ������� 1��� �����                        
                            Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt));

                            while (true)
                            {
                                allIds.Clear();
                                // ����������� ������ �� id ���� ���������� �� ��������
                                List<IWebElement> allIdsNow = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__content-wrapper')]//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                                if (allIdsNow.Count > 0)
                                {
                                    // ��������� - ������ � �������� ??
                                    for (int i = 0; i < allIdsNow.Count; i++)
                                    {
                                        Variables.nowPlace = allIdsNow[i];
                                        allIds.Add(Variables.nowPlace.GetAttribute("name"));
                                        Console.WriteLine("��������� id - " + Variables.nowPlace.GetAttribute("name"));

                                        // �������� ������ ������ id
                                        if (Variables.nowPlace.Text.Contains(Variables.idAdv))
                                        {
                                            Console.WriteLine($"����� ���� ���������� �� {allIds.IndexOf(Variables.idAdv)} �����");
                                        }

                                        // ���� id != 1
                                        if (allIdsNow.IndexOf(Variables.nowPlace) != 0)
                                        {
                                            Console.WriteLine($"���� ���������� �� {allIds.IndexOf(Variables.idAdv)} �����");
                                            Console.WriteLine("��������� ��� �� �� ������ �����, ���������� +1 � ������");
                                            newPrice = newPrice + 1;
                                            //break;
                                        }
                                    }

                                    setForFirstPlaceTxt = setForFirstPlaceTxt + 1;

                                    Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt));
                                    // ������
                                    IWebElement stickSet3 = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                                    //if (allIdsNow.IndexOf(Variables.nowPlace) == 0 || allIdsNow.IndexOf(Variables.nowPlace) == 1) break;
                                }
                            }
                        }

                        Thread.Sleep(rnd.Next(1500, 2500));

                        // ���� ���������
                        IWebElement stickBtnF = driver.FindElement(By.XPath("//button[contains(@type, 'submit')]"));
                        stickBtnF.Click();

                        Thread.Sleep(rnd.Next(4500, 6500));

                        // ������������� ������������ ����������
                        List<IWebElement> payed = driver.FindElements(By.XPath("//div[contains(@class, 'bulletin-user-action-block')]")).ToList();
                        if (payed.Count > 0)
                        {
                            IWebElement lone = payed.First();
                            string txt = lone.Text;
                            if (txt.Contains("��������"))
                            {
                                Console.WriteLine("��� ���������, ���������...");
                                // ���� �� "���������", ����� ���������� ������ ����������
                                IWebElement alreadyStick = driver.FindElement(By.XPath("//div[contains(@class, 'serviceStick')]"));
                                alreadyStick.Click();
                                Thread.Sleep(rnd.Next(1500, 2500));

                                // ����������� �� ��������� �������
                                List<IWebElement> needRub = driver.FindElements(By.XPath(String.Format("//span[contains(@class, 'competition-context-links__link-container')]/a[contains(text(), '{0}')]", rubrika))).ToList();
                                if (needRub.Count > 0)
                                {
                                    Console.WriteLine($"�������� ������� ��� ������: {rubrika}");
                                    IWebElement loneRub = needRub.First();
                                    loneRub.Click();
                                    Thread.Sleep(rnd.Next(1500, 2500));
                                }
                            }
                            else
                            {
                                List<IWebElement> stickAdv6 = driver.FindElements(By.XPath("//button[contains(@class, 'submit')]")).ToList();
                                if (stickAdv6.Count > 0)
                                {
                                    IWebElement stick6 = stickAdv6.First();
                                    stick6.Click();
                                    Thread.Sleep(rnd.Next(1500, 2500));
                                }
                            }
                        }

                        Thread.Sleep(rnd.Next(1500, 2500));

                        // ��� �����
                        //driver.Navigate().GoToUrl("https://www.farpost.ru/personal/actual/bulletins");
                    }
                    else
                    {
                        Console.WriteLine("�� ���������� �������� �����, ������ �� ������ � ���");
                    }
                }
            }
        }
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public class TimeCheck
    {
        public static DateTime nowTime { get; set; } = DateTime.Now;

        public static void TimeOfTheJobCheck(IWebDriver driver, string startJob, string endJob)
        {
            Random rnd = new Random();
            // �������� �������� �� ������ ������ �� ��������
            string url = driver.Url;

            DateTime endOfJob = DateTime.ParseExact(Variables.TimeEnd, "HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));
            DateTime dto = DateTime.ParseExact(Variables.TimeStart, "HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));

            Console.WriteLine("����� ������ ������: " + dto);

            // ������ ������ �� �����
            List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
            if (setForFirstPlace.Count > 0)
            {
                double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace.First().Text);
                double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);
            }

            if (setForFirstPlace.Count == 0)
            {
                // ����������� ������� �� ����������
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(rnd.Next(1500, 2500));
            }

            // ������� ������� ����� ������� �������� � ������������� � �������

            while (true)
            {
                nowTime = DateTime.Now;
                double diff = nowTime.Subtract(dto).TotalMilliseconds;
                Console.WriteLine("������� ����� ������: " + diff);
                Console.WriteLine("�������� ������ �������: " + diff);

                if (diff < 0)
                {
                    Console.WriteLine("������� ����� ������ �������");
                    Thread.Sleep(1000);
                }
                else if (nowTime > endOfJob)
                {
                    Console.WriteLine("����� ��������� ������. ������� ��� ����������...");

                    // ������ ���������� ����� ������ ������� ��� ������ - ��������
                    IWebElement unstickBtn = driver.FindElement(By.XPath("//a[contains(@class, 'unstick')]"));
                    unstickBtn.Click();
                    Thread.Sleep(1000);
                    throw new Exception("���������� ������");
                }
                else
                {
                    Console.WriteLine("����� ���������� ��� �� ���������");
                    //Thread.Sleep(Convert.ToInt32(diff));
                    break;
                }
            }
        }
    }
}