using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
    public class BLLotto {
        #region variables
        Random random = new Random();
        #endregion
        #region methods
        public int[] DrawLottoArray(int numbers, int max) {
            int tempRand;
            int[] lottoArray = new int[numbers];

            for (int i = 0; i < numbers; i++) {

                tempRand = random.Next(1, max + 1);
                if (lottoArray.Contains(tempRand)) {
                    i--;
                } else {
                    lottoArray[i] = tempRand;
                }
            }
            Array.Sort(lottoArray);
            return lottoArray;
        }

        public string DrawGame(string gamename, int rownumber) {
            switch (gamename) {
                case "Lotto":
                    return "Row " + rownumber + ": " + String.Join(", ", DrawLottoArray(7, 9));
                case "Viking Lotto":
                    return "Row " + rownumber + ": " + String.Join(", ", DrawLottoArray(6, 9));
                case "Eurojackpot":
                    return "Row " + rownumber + ": " + String.Join(", ", DrawLottoArray(5, 9)) + " + " + String.Join(", ", DrawLottoArray(2, 9));
                default:
                    return "Select game first.";
            }
        }
        
        public void WriteLottoNumbers(string numbers) {
            string lotto = "Lottorivit" + GetWeekNumber() + ".txt";    

            try {

                if (!(File.Exists(lotto))) {
                    File.CreateText(lotto);
                }
                StreamWriter file = new StreamWriter(lotto);

                StringReader drawnNumbers = new StringReader(numbers);
                string line = string.Empty;
                do {
                    line = drawnNumbers.ReadLine();
                    if (line != null) {
                        string[] array = Regex.Split(line, @"\D+");
                        file.WriteLine(String.Join(" ", array.Skip(2)));
                    }
                } while (line != null);
                file.Close();
            } catch (Exception ex) {

                throw ex;
            }
           
        }
        public int[] ReadLottoNumbers(string correctrow) {

            string lotto = "Lottorivit" + GetWeekNumber() + ".txt";
            try {
                if (!(File.Exists(lotto))) {
                    File.CreateText(lotto);
                }

                StreamReader sr = new StreamReader(lotto);
                string line = "";
                int counter = 0;
                int lineCount = File.ReadLines(lotto).Count();
                int[] correctNumbers = new int[lineCount];
                string[] array1 = correctrow.Split(' ');
                StreamReader file = new StreamReader(lotto);
                for (int i = 0; i < lineCount; i++) {
                    line = file.ReadLine();
                    string[] array2 = line.Split(' ');
                    counter = 0;
                    foreach (string one in array1) {
                        foreach (string two in array2) {
                            if (one == two) {
                                counter++;
                                correctNumbers[i] = counter;
                            }
                        }
                    }
                }

                return correctNumbers;
            } catch (Exception ex) {

                throw ex;
            }
           
        }
        public string GetWeekNumber() {
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
            string result = "";
            if (weekNumber < 10) {
                result = "0" + weekNumber.ToString();
            } else {
                result = weekNumber.ToString();
            }
            return result;
        }
        #endregion
    }
}