using Microsoft.VisualStudio.TestTools.UnitTesting;
using JAMK.IT.IIO11300;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300.Tests {
    [TestClass()]
    public class BLLottoTests {
        [TestMethod()]
        public void DrawLottoArrayTest() {
            BLLotto lotto = new BLLotto();

            var array = lotto.DrawLottoArray(7, 39);
            Assert.IsInstanceOfType(array, typeof(int[]));
            Assert.AreEqual(array.Length, 7);
        }

        [TestMethod()]
        public void DrawGameTest() {
            BLLotto lotto = new BLLotto();
            String input = "Lotto";
            lotto.DrawGame(input, 1);
        }

        [TestMethod()]
        public void WriteLottoNumbersTest() {
            BLLotto lotto = new BLLotto();

            Assert.
        }

        [TestMethod()]
        public void ReadLottoNumbersTest() {
           
        }

        [TestMethod()]
        public void GetWeekNumberTest() {
            
        }
    }
}