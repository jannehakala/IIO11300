using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
    class BLLotto{
        Random random = new Random();
        public int[] drawLottoArray(int numbers, int max) {
            int tempRand;
            int[] lottoArray = new int[numbers];

            for (int i = 0; i < numbers; i++) {
                
                tempRand = random.Next(1, max + 1);
                if (lottoArray.Contains(tempRand)) {
                    i--;
                }
                else {
                    lottoArray[i] = tempRand;
                }
            }
            Array.Sort(lottoArray);
            return lottoArray;
        }

        public string drawGame(string gamename) {
            switch (gamename) {
                case "Lotto":
                    return "Numerot: " + string.Join(", ", drawLottoArray(7, 39));
                case "Viking Lotto":
                    return "Numerot: " + string.Join(", ", drawLottoArray(6, 48));
                case "Eurojackpot":
                    return "Numerot: " + string.Join(", ", drawLottoArray(5, 50)) + " + " + string.Join(", ", drawLottoArray(2, 8));
                default:
                    return "Select game first.";
            }
        }

    }
}
