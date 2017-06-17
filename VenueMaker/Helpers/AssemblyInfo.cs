using System;
using System.IO;
using System.Reflection;

namespace VenueMaker.Helpers
{
    public class AssemblyInfo
    {

        public AssemblyInfo()
        {
        }
        

        // Properties
        public static string Title
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != string.Empty)
                    {
                        return titleAttribute.Title;

                    } // Title found

                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);

            }

        }


        public static string ExeDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);

            }

        } // get
        
        public static string ExeName
        {
            get
            {
                return Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase);
            } // get

        }


        public static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }

        }


        public static string GetProductAndVersion()
        {
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0} {1}.{2}.{3}",
                Product,
                ver.Major,
                ver.Minor,
                ver.Build
                );
        }


        public static string Description
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;

                } // No descritpion

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;

            }

        }


        public static string Product
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;

                } // No product

                return ((AssemblyProductAttribute)attributes[0]).Product;

            }
 // get
        }



        public static string Copyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;

                } // No copyright

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;

            } // get

         }


        public static string Company
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;

                } // No company

                return ((AssemblyCompanyAttribute)attributes[0]).Company;

            } // get

        }
















    }
}
