﻿using System;
using Microsoft.Extensions.Hosting;

namespace StepperApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(App.ConfigureServices);
    }
}
