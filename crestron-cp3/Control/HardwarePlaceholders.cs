namespace CrestronCp3Av
{
    // Replace these placeholder implementations with the actual
    // Crestron serial/IP protocol drivers after the hardware models
    // are known.

    public sealed class SonyProjectorPlaceholder : IProjector
    {
        public void PowerOn() { }
        public void PowerOff() { }
        public void SelectInput(string input) { }
    }

    public sealed class SymetrixDspPlaceholder : IAudioDsp
    {
        private int _volume;
        private bool _muted;

        public void SetVolume(int level) => _volume = level;
        public void VolumeUp() => SetVolume(_volume + 1);
        public void VolumeDown() => SetVolume(_volume - 1);
        public void Mute() => _muted = true;
        public void Unmute() => _muted = false;
        public void ToggleMute() => _muted = !_muted;
    }

    public sealed class HdmiMatrix4x4Placeholder : IHdmiMatrix
    {
        private readonly int[,] _routes = new int[4, 4];

        public void Route(int input, int output)
        {
            if (input < 1 || input > 4)
                return;
            if (output < 1 || output > 4)
                return;

            _routes[input - 1, output - 1] = 1;
        }
    }
}
