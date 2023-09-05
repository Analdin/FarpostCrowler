using OpenQA.Selenium;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarpostCrowler
{
    public class BidCounting
    {
        public List<string> allNums = new List<string>();
        public void bidSet(IWebDriver driver)
        {
            string inputFile = Directory.GetCurrentDirectory() + @"\Files\EnterData.xlsx";

            //using (var package = new ExcelPackage(new FileInfo(inputFile)))
            //{
            //    var sheet = package.Workbook.Worksheets[0];

            //    count++;

            //    int rows = sheet.Dimension.Rows + 1;
            //    Console.WriteLine("rows - " + rows);

            //    if (count >= rows)
            //    {
            //        Console.WriteLine("Прошли все строки в таблице, следующий круг мониторинга...");
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
            //    Console.WriteLine("Ставка от: " + limitStart);
            //    Console.WriteLine("Ставка до: " + limitStop);
            //    Console.WriteLine("Лимит ставки: " + fullLimit);
            //    Console.WriteLine("Время начала работу: " + TimeStart);
            //    Console.WriteLine("Время окончания работы: " + TimeEnd);
            //    Console.WriteLine("Рубрика для работы: " + boxRubrika);
            //    Console.WriteLine("Id объявления: " + Variables.idAdv);
            //    Console.WriteLine("Время применения ставки от: " + TimeSetFrom);
            //    Console.WriteLine("Время применения ставки до: " + TimeSetTo);
            //    Console.WriteLine("Логин: " + loginField);
            //    Console.WriteLine("Пароль: " + passField);
            //    package.Dispose();
            //}

            while (true)
            {
                allNums.Clear();

                List<IWebElement> allAdvs = driver.FindElements(By.XPath("//div[contains(@class, 'bull-item-content__content-wrapper')]//div[contains(@class, 'bull-item-content__subject-container')]/a")).ToList();
                if(allAdvs.Count > 0)
                {
                    foreach(var elm in allAdvs)
                    {
                        allNums.Add(elm.GetAttribute("name"));
                        Console.WriteLine($"Пишем id - {elm.GetAttribute("name")}");
                    }
                }

                allAdvs.RemoveAt(0);
                allNums.RemoveAt(0);

                // Определяем индекс нашего объявления
                double ourAdvPlace = allNums.IndexOf(Variables.idAdv);
                Console.WriteLine($"Наше объявление на {ourAdvPlace + 1} месте");

                if (ourAdvPlace + 1 == 1)
                {
                    Console.WriteLine($"Наше объявление на {ourAdvPlace + 1} месте, ничего не делаем со ставкой");
                    break;
                }
                else
                {
                    double newSet = 0;

                    // Читаем ставки на сайте
                    List<IWebElement> setForFirstPlace = driver.FindElements(By.XPath("//div[contains(@class, 'stick-applier-steps__details')]/div/a/span[1]")).ToList();
                    double setForFirstPlaceTxt = Convert.ToDouble(setForFirstPlace[0].Text);
                    double minPriceSetTxt = Convert.ToDouble(setForFirstPlace.Last().Text);

                    // Цена в окошке
                    List<IWebElement> priceInWindow = driver.FindElements(By.XPath("//div[contains(@class, 'controlBody')]/input")).ToList();
                    IWebElement lonePrice = priceInWindow.First();
                    double priceInWinTxt = Convert.ToDouble(lonePrice.GetAttribute("value"));

                    // Цикл по подбору 1ого места                        
                    Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt));

                    setForFirstPlaceTxt = setForFirstPlaceTxt + 1;

                    Clipboard.SetText(Convert.ToString(setForFirstPlaceTxt));
                    // Ставка
                    IWebElement stickSet3 = driver.FindElement(By.XPath("//input[contains(@name, 'stickPrice')]"));
                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "delete");
                    stickSet3.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                    Thread.Sleep(3000);

                    IWebElement submit = driver.FindElement(By.XPath("//button[contains(@name,'confirm')]"));
                    if(submit != null)
                    {
                        submit.Click();
                    }

                    Thread.Sleep(3000);
                }
            }
        }
    }
}
