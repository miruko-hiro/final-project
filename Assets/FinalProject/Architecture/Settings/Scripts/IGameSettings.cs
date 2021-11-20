using FinalProject.Architecture.Settings.Music;
using FinalProject.Architecture.Settings.SoundEffects;
using FinalProject.Architecture.Settings.Vibration;

namespace FinalProject.Architecture.Settings.Scripts
{
    public interface IGameSettings: ISettings
    {
        IMusicSettings MusicSettings { get; }
        ISoundEffectsSettings SoundEffectsSettings { get; }
        IVibrationSettings VibrationSettings { get; }
    }
}