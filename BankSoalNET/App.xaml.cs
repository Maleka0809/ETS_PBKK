using System.Configuration;
using System.Data;
using System.Windows;

namespace BankSoalNET;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\onstartup_reached.txt", "OnStartup reached at " + System.DateTime.Now);
        DispatcherUnhandledException += (s, args) =>
        {
            string err = $"[DispatcherUnhandledException] {args.Exception}";
            System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\app_error.txt", err);
            MessageBox.Show(err);
        };

        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            string err = $"[AppDomainUnhandledException] {args.ExceptionObject}";
            System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\app_error.txt", err);
        };

        base.OnStartup(e);

        try
        {
            var login = new Views.LoginWindow();
            login.Loaded += (s, e) => System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\login_loaded.txt", "Loaded");
            login.Closed += (s, e) => System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\login_closed.txt", "Closed");
            this.MainWindow = login;
            login.Show();
        }
        catch (System.Exception ex)
        {
            System.IO.File.WriteAllText(@"c:\Users\Maleka Ghaniya\Downloads\PBKK-web\ETS\BankSoalNET\app_error.txt", ex.ToString());
            MessageBox.Show("Error starting app: " + ex.Message);
        }
    }
}

