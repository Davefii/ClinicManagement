using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BussinessLayer
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser = new clsUsers();
        public static bool RememberUserNameandPassword(string username, string password)
        {
            try
            {
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
                string NameValue = "Username";
                string DataValue = username;
                Registry.SetValue(keyPath,NameValue,DataValue,RegistryValueKind.String);
                string keyPath2 = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
                string NameValue2 = "Password";
                string DataValue2 = password;
                Registry.SetValue(keyPath2, NameValue2, DataValue2, RegistryValueKind.String);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
                string NameValue = "Username";
                string Valueforusermane = Registry.GetValue(keyPath,NameValue,null) as string;
                if (Valueforusermane != null)
                {
                    Username = Valueforusermane;
                }
                string keyPath2 = @"HKEY_CURRENT_USER\SOFTWARE\CMS";
                string NameValue2 = "Password";
                string Valueforpassword = Registry.GetValue(keyPath2, NameValue2,null) as string;
                if (Valueforpassword != null)
                {
                    Password = Valueforpassword;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool CheckPermition(clsUsers.enMainMenuPermitions mainMenuPermitions)
        {
            if (CurrentUser.Permition == clsUsers.enMainMenuPermitions.All)
                return true;
            if ((CurrentUser.Permition & mainMenuPermitions) == mainMenuPermitions)
                return true;
            else
                return false;
        }
    }
}
