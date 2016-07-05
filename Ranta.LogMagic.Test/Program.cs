using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger<Program>();

            logger.Debug("this is debug.");
            logger.Info("This is info.");
            logger.Warn("This is warn.");
            logger.Error("This is error.");
            logger.Fault("This is fault.");

            logger.Debug("this is debug.", "no more detail.");
            logger.Info("This is info.", "no more detail.");
            logger.Warn("This is warn.", "no more detail.");
            logger.Error("This is error.", "no more detail.");
            logger.Fault("This is fault.", "no more detail.");
        }
    }
}
