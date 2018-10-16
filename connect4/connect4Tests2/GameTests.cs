using Microsoft.VisualStudio.TestTools.UnitTesting;
using connect4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void TieTest()
        {
            Game game = new Game();
            for (int i = 0; i < 6; i++)
            {
                game.Grid[i, 0] = 0;
            }
            if (!game.IsTie())
            {
                Assert.Fail("failed detecting the Tie game");
            }
            Game game2 = new Game();
            if (game2.IsTie())
            {
                Assert.Fail("Game shouldn't be tie game!");
            }

        }
    }
}