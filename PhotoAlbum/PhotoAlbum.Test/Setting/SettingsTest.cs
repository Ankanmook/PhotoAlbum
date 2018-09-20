using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Settings;

namespace PhotoAlbum.Test.Setting
{
    public class SettingsTest
    {
        [Test]
        public void CheckSettings()
        {
            Assert.IsTrue(Settings.Settings.AlbumAPI.ToLower() == "http://jsonplaceholder.typicode.com/albums");
            Assert.IsTrue(Settings.Settings.PhotoAPI.ToLower() == "http://jsonplaceholder.typicode.com/photos");
        }
    }
}
