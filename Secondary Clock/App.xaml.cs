﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Shell;

namespace Secondary_Clock
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application, ISingleInstanceApp
  {
        private const string Unique = "My_Unique_Application_String";

    [STAThread]
    public static void Main()
    {
      if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
      {
        var application = new App();

        application.InitializeComponent();
        application.Run();

        // Allow single instance code to perform cleanup operations
        SingleInstance<App>.Cleanup();
      }
    }

    #region Implementation of ISingleInstanceApp

    public bool SignalExternalCommandLineArgs(IList<string> args)
    {
      return true;
    }

    #endregion
  }
}
