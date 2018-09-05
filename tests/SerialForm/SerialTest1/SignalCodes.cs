using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialTest1
{
    class SignalCodes
    {
        public const byte START_STREAM  = 100;
        public const byte END_STREAM    = 101;
        public const byte NEXT_STREAM   = 102;
        public const byte RESEND_STREAM = 103;

        public const byte YELL_STREAM   = 200;
        public const byte YELL_8        = 201;
        public const byte YELL_32       = 202;
        public const byte YELL_64       = 203;
    }

    enum COM_STATE
    {
        COM_STATE_IDLE,
        COM_STATE_LISTEN_BURST,
        COM_STATE_LISTEN_STREAM,
        COM_STATE_TALKING
    }
}
