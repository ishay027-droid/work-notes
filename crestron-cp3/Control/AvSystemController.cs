using System;

namespace CrestronCp3Av
{
    /// <summary>
    /// High-level AV controller for a Crestron CP3.
    /// Routes four HDMI inputs to four matrix outputs and controls
    /// the projector and Symetrix audio DSP through isolated interfaces.
    /// </summary>
    public class AvSystemController
    {
        private readonly IProjector _projector;
        private readonly IAudioDsp _audio;
        private readonly IHdmiMatrix _matrix;

        public AvSystemController(
            IProjector projector,
            IAudioDsp audio,
            IHdmiMatrix matrix)
        {
            _projector = projector;
            _audio = audio;
            _matrix = matrix;
        }

        public void SystemOn()
        {
            _projector.PowerOn();
            _audio.Unmute();
            _audio.SetVolume(0);

            // Default route: HDMI input 1 to projector output 1.
            _matrix.Route(1, 1);
        }

        public void SystemOff()
        {
            _audio.Mute();
            _projector.PowerOff();
        }

        public void SelectSource(int input)
        {
            if (input < 1 || input > 4)
                throw new ArgumentOutOfRangeException(nameof(input));

            // Output 1 is assumed to feed the Sony projector.
            _matrix.Route(input, 1);
        }

        public void Route(int input, int output)
        {
            if (input < 1 || input > 4)
                throw new ArgumentOutOfRangeException(nameof(input));
            if (output < 1 || output > 4)
                throw new ArgumentOutOfRangeException(nameof(output));

            _matrix.Route(input, output);
        }

        public void VolumeUp() => _audio.VolumeUp();
        public void VolumeDown() => _audio.VolumeDown();
        public void ToggleMute() => _audio.ToggleMute();

        public void SelectHdmi1() => SelectSource(1);
        public void SelectHdmi2() => SelectSource(2);
        public void SelectHdmi3() => SelectSource(3);
        public void SelectHdmi4() => SelectSource(4);
    }

    public interface IHdmiMatrix
    {
        /// <summary>Connects one of 4 inputs to one of 4 outputs.</summary>
        void Route(int input, int output);
    }

    public interface IProjector
    {
        void PowerOn();
        void PowerOff();
        void SelectInput(string input);
    }

    public interface IAudioDsp
    {
        void SetVolume(int level);
        void VolumeUp();
        void VolumeDown();
        void Mute();
        void Unmute();
        void ToggleMute();
    }
}
