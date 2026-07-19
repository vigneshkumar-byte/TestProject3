using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject3.Config
{
    public class TestSettings
    {
        public bool Headless { get; set; }
        //public bool DevTools { get; set; }
        
        public DriverType DriverType { get; set; }
        public string[] Args;
        public float timeout;
      

    }
    public enum DriverType
    {
        Chromium,
        Firefox,
        Edge,
        Chrome,
        WebKit
    }
}
