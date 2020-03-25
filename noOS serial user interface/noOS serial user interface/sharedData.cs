using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noOS_serial_user_interface
{
    class sharedData
    {
        // rx data
        public static byte batteryPercentage = 0;
        public static bool[] lineSegment = new bool[12];
        public static byte currentLineCalibration = 0;
        public static float absoluteCompass = 0;
        public static float relativeCompass = 0;

        // tx data
        public static bool ledState = false;
        public static bool setLineCalibration = false;
        public static byte newLineCalibration = 0;
    }
}
