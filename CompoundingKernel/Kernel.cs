using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPCMessages;
using System.IO.Pipes;

namespace CompoundingKernel {
    class Kernel {
        static void Main(string[] args) {
            // Create the server named pipe and tell it to wait for a connection
            NamedPipeServerStream npssServer = new NamedPipeServerStream("CompoundingKernel");
            npssServer.WaitForConnection();
            // Send a list of the methods we can handle to the UI
            MessageUtils.SendMsg(npssServer, "methods", "Annual,Monthly,Continuous");
            // Receive and process messages
            vProcessMsgs(npssServer);
        }

        private static void vProcessMsgs(NamedPipeServerStream npssServer)
        {
            // Variables for the principal interest rate and compounding method
            double dPrinc = 0;
            double dIntRate = 0;
            string strCompMeth = "";
            // Variable to control whether we continue to receive messages
            bool bRunning = true;
            // Loop forever
            while (bRunning)
            {
                // Receive the next message and process it
                (string strCmd, string strArg) = MessageUtils.ReceiveMsg(npssServer);
                // What to do depends on the command
                switch (strCmd.ToLower())
                {
                    case "principal":
                        // Store the principal for use in the next calculation
                        dPrinc = MessageUtils.HexToDouble(strArg);
                        break;

                    case "rate":
                        // Store the interest rate
                        dIntRate = MessageUtils.HexToDouble(strArg);
                        break;

                    case "method":
                        strCompMeth = strArg.ToLower();
                        break;

                    case "compute":
                        // Comput interest earned and send it back
                        double dIntEarned = CalcInterest(dPrinc, dIntRate, strCompMeth);
                        MessageUtils.SendMsg(npssServer, "result", MessageUtils.DoubleToHex(dIntEarned));
                        break;

                    case "quit":
                        // Tell the loop that it no longer needs to run
                        bRunning = false;
                        break;
                }
            }
        }

        // Comput the interest earned given the principal, interest rate, and method
        private static double CalcInterest(double dPrinc, double dIntRate, string strMethod)
        {
            // A variable to hold the interest earned
            double dIntEarned = 0;
            // Call the appropriate function based on the method specified
            switch (strMethod)
            {
                case "annual":
                    dIntEarned = dAnnual(dPrinc, dIntRate);
                    break;
                case "monthly":
                    dIntEarned = dMonthly(dPrinc, dIntRate);
                    break;
                case "continuous":
                    dIntEarned = dContinuous(dPrinc, dIntRate);
                    break;
                // If the method is not recognized, return interest earned as 0
                default:
                    dIntEarned = 0;
                    break;
            }
            return dIntEarned;
        }

        private static double dAnnual(double dPrincipal, double dIntRate) {
            return dPrincipal * dIntRate;
        }

        private static double dMonthly(double dPrincipal, double dIntRate) {
            return dPrincipal * (Math.Pow(1.0 + dIntRate / 12.0, 12) - 1.0);
        }

        private static double dContinuous(double dPrincipal, double dIntRate) {
            return dPrincipal * (Math.Exp(dIntRate) - 1.0);
        }
    }
}
