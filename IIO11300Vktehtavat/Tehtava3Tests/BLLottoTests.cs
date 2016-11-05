using Microsoft.VisualStudio.TestTools.UnitTesting;
using JAMK.IT.IIO11300;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JAMK.IT.IIO11300.Tests {
    [TestClass()]

    
    public class BLLottoTests {
        BLLotto lotto = new BLLotto();
        [TestMethod()]
        public void DrawLottoArrayTest() {
            lotto = new BLLotto();

            var array = lotto.DrawLottoArray(7, 39);
            Assert.IsInstanceOfType(array, typeof(int[]), "Output should be an int array.");
            Assert.AreEqual(array.Length, 7, "Arrays lenght's do not match.");
        }

        [TestMethod()]
        public void DrawGameTest() {  
            lotto = new BLLotto();

            int inputLotto = 7;
            int inputVikingLotto = 6;
            int inputEurojackpot = 7;

            string outputLotto = lotto.DrawGame("Lotto", 1);
            string outputVikingLotto = lotto.DrawGame("Viking Lotto", 1);
            string outputEurojackpot = lotto.DrawGame("Eurojackpot", 1);

            var resultLotto = outputLotto.SkipWhile(c => c != ':').Count(x => Char.IsNumber(x));
            var resultVikingLotto = outputVikingLotto.SkipWhile(c => c != ':').Count(x => Char.IsNumber(x));
            var resultEurojackpot = outputEurojackpot.SkipWhile(c => c != ':').Count(x => Char.IsNumber(x));

            Assert.AreEqual(inputLotto, resultLotto, "Input and output must be same.");
            Assert.AreEqual(inputVikingLotto, resultVikingLotto, "Input and output must be same.");
            Assert.AreEqual(inputEurojackpot, resultEurojackpot, "Input and output must be same.");
        }

        [TestMethod()]
        public void WriteLottoNumbersTest() {
            lotto = new BLLotto();
            string path = "Lottorivit" + lotto.GetWeekNumber() + ".txt";
            string input = "Row 1: 1, 2, 3, 4, 5, 6, 7";
            string correctRow = "1 2 3 4 5 6 7";
            lotto.WriteLottoNumbers(input);
            
            Assert.IsTrue(File.Exists(path), "File does not exist.");     
            Assert.IsTrue((File.ReadAllText(path).Contains(correctRow)), "File does not include the written row.");      
        }

        [TestMethod()]
        public void ReadLottoNumbersTest() {
            lotto = new BLLotto();
            string path = "Lottorivit" + lotto.GetWeekNumber() + ".txt";
            int[] test = lotto.ReadLottoNumbers("1 2 3 4 5 6 8");

            Assert.IsTrue(File.Exists(path), "File does not exist.");         
            Assert.AreEqual(test[0], 6, "Results should be equal");        
        }

        [TestMethod()]
        public void GetWeekNumberTest() {
            string test = lotto.GetWeekNumber();
            Assert.IsInstanceOfType(test, typeof(string), "Output is not a string type.");
        }
    }
}