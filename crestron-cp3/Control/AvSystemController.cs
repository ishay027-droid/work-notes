using System;

namespace CrestronCp3Av
{
    /// <summary>
    /// High-level AV controller for a Crestron CP3.
    /// Hardware-specific transport commands are intentionally isolated
    /// behind the projector and DSP interfaces.
    /// </summary>
    public class AvSystemController
    {
        private readonly IProjector _projector;
        private readonly IAudioDsp _audio;

        public AvSystemController(IProjector projector, IAudioDsp audio)
        {
            _projector = projector;
            _audio = audio;
        }

        public void SystemOn()
        {
            _projector.PowerOn();
            _audio.Unmute();
            _audio.SetVolume(0);
        }

        public void SystemOff()
        {
            _audio.Mute();
            _projector.PowerOff();
        }

        public void VolumeUp()
        {
            _audio.VolumeUp();
        }

        public void VolumeDown()
        {
            _audio.VolumeDown();
        }

        public void ToggleMute()
        {
            _audio.ToggleMute();
        }

        public void SelectHdmi1()
        {
            _projector.SelectInput("HDMI1");
        }

        public void SelectHdmi2()
        {
            _projector.SelectInput("HDMI2");
        }
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
