using System.IO;
using Xunit;
using Plugin_Naveego_Legacy.Helper;

namespace Plugin_Naveego_Legacy.Helper
{
    public class LoggerTest
    {
        private static string _path = @"plugin-zoho-log.txt";
        
        [Fact]
        public void VerboseTest()
        {
            // setup
            File.Delete(_path);
            Logger.SetLogLevel(Logger.LogLevel.Verbose);
            
            // act
            Logger.Verbose("verbose");
            Logger.Debug("debug");
            Logger.Info("info");
            Logger.Error("error");

            // assert
            string[] lines = File.ReadAllLines(_path);

            Assert.Equal(4, lines.Length);
            
            // cleanup
            File.Delete(_path);
        }
        
        [Fact]
        public void DebugTest()
        {
            // setup
            File.Delete(_path);
            Logger.SetLogLevel(Logger.LogLevel.Debug);
            
            // act
            Logger.Verbose("verbose");
            Logger.Debug("debug");
            Logger.Info("info");
            Logger.Error("error");

            // assert
            string[] lines = File.ReadAllLines(_path);

            Assert.Equal(3, lines.Length);
            
            // cleanup
            File.Delete(_path);
        }
        
        [Fact]
        public void InfoTest()
        {
            // setup
            File.Delete(_path);
            Logger.SetLogLevel(Logger.LogLevel.Info);
            
            // act
            Logger.Verbose("verbose");
            Logger.Debug("debug");
            Logger.Info("info");
            Logger.Error("error");

            // assert
            string[] lines = File.ReadAllLines(_path);

            Assert.Equal(2, lines.Length);
            
            // cleanup
            File.Delete(_path);
        }
        
        [Fact]
        public void ErrorTest()
        {
            // setup
            File.Delete(_path);
            Logger.SetLogLevel(Logger.LogLevel.Error);
            
            // act
            Logger.Verbose("verbose");
            Logger.Debug("debug");
            Logger.Info("info");
            Logger.Error("error");

            // assert
            string[] lines = File.ReadAllLines(_path);

            Assert.Single(lines);
            
            // cleanup
            File.Delete(_path);
        }
        
        [Fact]
        public void OffTest()
        {
            // setup
            File.Delete(_path);
            Logger.SetLogLevel(Logger.LogLevel.Off);
            
            // act
            Logger.Verbose("verbose");
            Logger.Debug("debug");
            Logger.Info("info");
            Logger.Error("error");

            // assert
            string[] lines = File.Exists(_path) ? File.ReadAllLines(_path) : new string[0];

            Assert.Empty(lines);
            
            // cleanup
            File.Delete(_path);
        }
    }
}