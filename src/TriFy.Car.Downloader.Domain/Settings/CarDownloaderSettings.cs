namespace TriFy.Car.Downloader.Settings;

public static class CarDownloaderSettings
{
    private const string Prefix = "CarDownloader";

    public static class Write
    {
        private const string Default = Prefix + ".Write";

        public static class File
        {
            public const string Default = Write.Default + ".File";

            public const string OutputPath = Default + ".OutputPath";
        }
    }
}
