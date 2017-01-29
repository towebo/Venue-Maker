using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WayfindR.Models
{
    public class WFVenue
    {

        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public WFPlatform[] Platforms { get; set; }

        public WFExit[] Exits { get; set; }

        public WFGraph NodesGraph { get; set; }



        public static WFVenue FromJson(string jsonData)
        {
            try
            {
                JObject jo = JObject.Parse(jsonData);

                WFVenue result = new WFVenue();
                result.Id = (string)jo["venue"]["id"];
                result.Name = (string)jo["venue"]["name"];

                try
                {
                    var jplatforms = jo["venue"]["platforms"].Children();
                    List<WFPlatform> pfs = new List<WFPlatform>();
                    foreach (var jp in jplatforms)
                    {
                        WFPlatform pf = new WFPlatform();
                        pf.Name = (string)jp["name"];
                        pf.EntranceBeaconMajor = (int)jp["entrance_beacon_major"];
                        pf.EntranceBeaconMinor = (int)jp["entrance_beacon_minor"];
                        pf.ExitBeaconMajor = (int)jp["exit_beacon_major"];
                        pf.ExitBeaconMinor = (int)jp["exit_beacon_minor"];
                        pf.Destinations = jp["destinations"].Values<string>().ToArray();

                        pfs.Add(pf);

                    } // foreach
                    result.Platforms = pfs.ToArray();
                }
                catch
                {
                    // No plattforms
                }

                try
                {
                    var jexits = jo["venue"]["exits"].Children();
                    List<WFExit> wfes = new List<WFExit>();
                    foreach (var je in jexits)
                    {
                        WFExit wfe = new WFExit();
                        wfe.Name = (string)je["name"];
                        wfe.EntranceBeaconMajor = (int)je["entrance_beacon_major"];
                        wfe.EntranceBeaconMinor = (int)je["entrance_beacon_minor"];
                        wfe.ExitBeaconMajor = (int)je["exit_beacon_major"];
                        wfe.ExitBeaconMinor = (int)je["exit_beacon_minor"];
                        wfe.Mode = (string)je["mode"];

                        wfes.Add(wfe);

                    } // foreach exit
                    result.Exits = wfes.ToArray();
                }
                catch
                {
                    // No exits
                }


                return result;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void LoadNodesGraph(Stream stream)
        {
            try
            {
                this.NodesGraph = WFGraph.LoadFromGraphML(stream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

    }
}
