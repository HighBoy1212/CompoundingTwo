using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IPCMessages {
    public static class MessageUtils {
        // Send a message out over a stream. The command and argument are provided
        // separately and combined before being sent.
        public static void SendMsg(Stream sOut, string strCommand, string strArgument) {
            // Combine the command and argument, convert to bytes using ASCII, and send.
            string strMessage = strCommand + ":" + strArgument;
            byte[] byMessage = Encoding.ASCII.GetBytes(strMessage);
            sOut.Write(byMessage, 0, byMessage.Length);
        }

        // Receive a message from a stream. The command and argument are separated
        // and returned individually.
        public static (string, string) ReceiveMsg(Stream sIn) {
            // Receive the message, convert to a string using ASCII, split into command
            // and argument.
            byte[] byBuffer = new byte[4096];
            int iBytesRcvd = sIn.Read(byBuffer, 0, byBuffer.Length);
            string strMessage = Encoding.ASCII.GetString(byBuffer, 0, iBytesRcvd);
            string[] astrParts = strMessage.Split(':');
            string strCommand = astrParts[0];
            string strArgument = astrParts[1];
            return (strCommand, strArgument);
        }

        // Convert a double to hex.
        public static string DoubleToHex(double dX) {
            // Convert the double to a byte array, then convert the array to hex and
            // remove the dashes.
            byte[] byXBytes = BitConverter.GetBytes(dX);
            string strBytesAsHex = BitConverter.ToString(byXBytes);
            return strBytesAsHex.Replace("-", "");
        }

        // Convert a hex string to a double.
        public static double HexToDouble(string strHex) {
            // Trick from Microsoft: Parse the hex string to a ulong, convert the ulong
            // to an array of bytes, then interpret the bytes as a double. Note that we
            // have to reverse the order of the bytes from the ulong, because the hex
            // string is effectively big-endian, whereas the ulong is little-endian.
            ulong ulDummy = ulong.Parse(strHex, System.Globalization.NumberStyles.AllowHexSpecifier);
            byte[] byBytes = BitConverter.GetBytes(ulDummy);
            Array.Reverse(byBytes);
            return BitConverter.ToDouble(byBytes, 0);
        }
    }
}
