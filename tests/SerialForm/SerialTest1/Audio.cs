using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://stackoverflow.com/questions/4671158/c-sharp-speechsynthesizer-makes-service-unresponsive

namespace SerialTest1
{
    class Audio
    {
        private System.Speech.Synthesis.SpeechSynthesizer _synth;

        public Audio()
        {
            _synth = new System.Speech.Synthesis.SpeechSynthesizer();
            _synth.SelectVoiceByHints(System.Speech.Synthesis.VoiceGender.Male, System.Speech.Synthesis.VoiceAge.Senior);
        }

        public void Speek(String s)
        {
            _synth.SpeakAsync(s);
        }

        public byte [] TextToAudioStream(String s)
        {

            byte[] stream = null;

            var t = new System.Threading.Thread(() => {
                using (MemoryStream memStream = new MemoryStream())
                {
                    _synth.SetOutputToWaveStream(memStream);
                    _synth.Speak(s);
                    stream = memStream.ToArray();
                }
            });

            t.Start();
            t.Join();

            return stream;
        }

    }
}
