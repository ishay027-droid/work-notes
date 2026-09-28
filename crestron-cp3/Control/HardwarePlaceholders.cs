namespace CrestronCp3Av
{
    // Replace these placeholder implementations with the actual
    // Crestron serial/IP modules and protocol commands for the
    // specific Sony projector and Symetrix DSP.

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

        public void SetVolume(int level)
        {
            _volume = level;
        }

        public void VolumeUp()
        {
            SetVolume(_volume + 1);
        }

        public void VolumeDown()
        {
            SetVolume(_volume - 1);
        }

        public void Mute()
        {
            _muted = true;
        }

        public void Unmute()
        {
            _muted = false;
        }

        public void ToggleMute()
        {
            _muted = !_muted;
        }
    }
}
