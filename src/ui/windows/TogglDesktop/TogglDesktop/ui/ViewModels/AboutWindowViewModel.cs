using ReactiveUI;

namespace TogglDesktop.ViewModels
{
    public class AboutWindowViewModel : ReactiveObject
    {
        public string[] Channels { get; } = {"Stable", "Beta", "Dev"};

        public string VersionString { get; }

        public AboutWindowViewModel(string versionString)
        {
            VersionString = versionString;
        }
    }
}