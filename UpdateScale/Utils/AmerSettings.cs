
using Alamer_Reporting2.DBConnection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alamer_Reporting2.Utils
{
    class AmerSettings : ApplicationSettingsBase
    {

        private static AmerSettings defaultInstance = (AmerSettings)SettingsBase.Synchronized((SettingsBase)new AmerSettings());
        private static bool addedHandler;
        private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());
        public AmerSettings()
        {


            this.SettingsLoaded += new System.Configuration.SettingsLoadedEventHandler(this.MySettings_SettingsLoaded);
        }


        public static AmerSettings Default
        {
            get
            {
                if (!AmerSettings.addedHandler)
                {
                    object handlerLockObject = AmerSettings.addedHandlerLockObject;
                    ObjectFlowControl.CheckForSyncLockOnValueType(handlerLockObject);
                    bool lockTaken = false;
                    try
                    {
                        Monitor.Enter(handlerLockObject, ref lockTaken);
                        if (!AmerSettings.addedHandler)
                        {
                          //  Program.Application.Shutdown += (ShutdownEventHandler)((sender, e) =>
                          //  {
                          //      if (!MyProject.Application.SaveMySettingsOnExit)
                         //           return;
                          //      MySettingsProperty.Settings.Save();
                         //   });
                            AmerSettings.addedHandler = true;
                        }
                    }
                    finally
                    {
                        if (lockTaken)
                            Monitor.Exit(handlerLockObject);
                    }
                }
                AmerSettings defaultInstance = AmerSettings.defaultInstance;
                return defaultInstance;
            }
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("POSDell")]
        public string ServerName
        {
            get
            {
                return ((string)(this["ServerName"]));
            }
            set
            {
                this["ServerName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("JardData")]
        public string DBName
        {
            get
            {
                return ((string)(this["DBName"]));
            }
            set
            {
                this["DBName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("13455")]
        public string UserPassword
        {
            get
            {
                return ((string)(this["UserPassword"]));
            }
            set
            {
                this["UserPassword"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int AuthinticationMode
        {
            get
            {
                return ((int)(this["AuthinticationMode"]));
            }
            set
            {
                this["AuthinticationMode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int POSID
        {
            get
            {
                return ((int)(this["POSID"]));
            }
            set
            {
                this["POSID"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string POSName
        {
            get
            {
                return ((string)(this["POSName"]));
            }
            set
            {
                this["POSName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ata")]
        public string ServerUserName
        {
            get
            {
                return ((string)(this["ServerUserName"]));
            }
            set
            {
                this["ServerUserName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool WarnIFDublicate
        {
            get
            {
                return ((bool)(this["WarnIFDublicate"]));
            }
            set
            {
                this["WarnIFDublicate"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MainServerName
        {
            get
            {
                return ((string)(this["MainServerName"]));
            }
            set
            {
                this["MainServerName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MainServerUserName
        {
            get
            {
                return ((string)(this["MainServerUserName"]));
            }
            set
            {
                this["MainServerUserName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MainServerPassword
        {
            get
            {
                return ((string)(this["MainServerPassword"]));
            }
            set
            {
                this["MainServerPassword"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MainServerDBName
        {
            get
            {
                return ((string)(this["MainServerDBName"]));
            }
            set
            {
                this["MainServerDBName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server-POS")]
        public string POSDataServerName
        {
            get
            {
                return ((string)(this["POSDataServerName"]));
            }
            set
            {
                this["POSDataServerName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("POSData")]
        public string POSDataName
        {
            get
            {
                return ((string)(this["POSDataName"]));
            }
            set
            {
                this["POSDataName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ata")]
        public string POSDataUserName
        {
            get
            {
                return ((string)(this["POSDataUserName"]));
            }
            set
            {
                this["POSDataUserName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("13455")]
        public string POSDataPassword
        {
            get
            {
                return ((string)(this["POSDataPassword"]));
            }
            set
            {
                this["POSDataPassword"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("710")]
        public int PriceCode
        {
            get
            {
                return ((int)(this["PriceCode"]));
            }
            set
            {
                this["PriceCode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("720")]
        public int WeightCode
        {
            get
            {
                return ((int)(this["WeightCode"]));
            }
            set
            {
                this["WeightCode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("730")]
        public int QuantityCode
        {
            get
            {
                return ((int)(this["QuantityCode"]));
            }
            set
            {
                this["QuantityCode"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("160.153.250.125")]
        public string OnLineServer
        {
            get
            {
                return ((string)(this["OnLineServer"]));
            }
            set
            {
                this["OnLineServer"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("alamer_ads")]
        public string OnLineDatabase
        {
            get
            {
                return ((string)(this["OnLineDatabase"]));
            }
            set
            {
                this["OnLineDatabase"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("alameronline")]
        public string OnLineUserName
        {
            get
            {
                return ((string)(this["OnLineUserName"]));
            }
            set
            {
                this["OnLineUserName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("s@123456")]
        public string OnLinePassword
        {
            get
            {
                return ((string)(this["OnLinePassword"]));
            }
            set
            {
                this["OnLinePassword"] = value;
            }
        }

        //Dynamics

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("172.16.1.3")]
        public string DynamicsServer
        {
            get
            {
                return ((string)(this["DynamicsServer"]));
            }
            set
            {
                this["DynamicsServer"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AlAmerDB")]
        public string DynamicsDatabase
        {
            get
            {
                return ((string)(this["DynamicsDatabase"]));
            }
            set
            {
                this["DynamicsDatabase"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DynamicsSA")]
        public string BCUserName
        {
            get
            {
                return ((string)(this["BCUserName"]));
            }
            set
            {
                this["BCUserName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dy9876543210")]
        public string BCPassword
        {
            get
            {
                return ((string)(this["BCPassword"]));
            }
            set
            {
                this["BCPassword"] = value;
            }
        }




        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseOldMethod
        {
            get
            {
                return ((bool)(this["UseOldMethod"]));
            }
            set
            {
                this["UseOldMethod"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseOnlineServer
        {
            get
            {
                return ((bool)(this["UseOnlineServer"]));
            }
            set
            {
                this["UseOnlineServer"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OnLineTableName
        {
            get
            {
                return ((string)(this["OnLineTableName"]));
            }
            set
            {
                this["OnLineTableName"] = value;
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=POSDell;Initial Catalog=JardData;Integrated Security=True")]
        public string JardConnectionString
        {
            get
            {
                return ((string)(this["JardConnectionString"]));
            }
        }
        private void MySettings_SettingsLoaded(object sender, SettingsLoadedEventArgs e)
        {
            MsgBoxResult msgBoxResult = MsgBoxResult.No;
            try
            {
        
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                msgBoxResult = Interaction.MsgBox((object)"لا يمكن الإتصال بالسيرفر يجب تحديد العنوان الصحيح للسيرفر", MsgBoxStyle.Critical | MsgBoxStyle.MsgBoxRight, (object)"تنبيه");
         
                ProjectData.ClearProjectError();
            }
        }


    }
}
