using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;

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
        public string Country { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public WFPlatform[] Platforms { get; set; }

        public WFExit[] Exits { get; set; }

        public WFPointOfInterest[] PointsOfInterest { get; set; }

        public WFGraph NodesGraph { get; set; }


        public static WFVenue FromJson(string jsonData)
        {
            try
            {
                JObject jo = JObject.Parse(jsonData);

                WFVenue result = new WFVenue();
                result.Id = (string)jo["venue"]["id"];
                result.Name = (string)jo["venue"]["name"];
                result.Description = (string)jo["venue"]["description"];
                result.Address = (string)jo["venue"]["address"];
                result.Zip = (string)jo["venue"]["zip"];
                result.City = (string)jo["venue"]["city"];
                result.Country = (string)jo["venue"]["country"];
                result.Phone = (string)jo["venue"]["phone"];
                result.Email = (string)jo["venue"]["email"];result.Address = (string)jo["venue"]["address"];
                result.Web = (string)jo["venue"]["web"];
                

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

                
                try
                {
                    var jpois = jo["venue"]["pointsofinterest"].Children();
                    List<WFPointOfInterest> wfpois = new List<WFPointOfInterest>();
                    foreach (var jpoi in jpois)
                    {
                        WFPointOfInterest wfpoi = new WFPointOfInterest();                        
                        wfpoi.Name = (string)jpoi["name"];
                        wfpoi.DescriptiveName = (string)jpoi["descriptive_name"];

                        wfpoi.BeaconUuid = (string)jpoi["beacon_uuid"];
                        wfpoi.BeaconMajor = (int)jpoi["beacon_major"];
                        wfpoi.BeaconMinor = (int)jpoi["beacon_minor"];

                        string cat = (string)jpoi["category"];


                        try
                        {
                            var jinfos = jpoi["information"].Children();
                            List<WFPOIInformation> wfinfos = new List<WFPOIInformation>();
                            foreach (var jinfo in jinfos)
                            {
                                WFPOIInformation wfinfo = new WFPOIInformation();

                                wfinfo.Information = (string)jinfo["information"];
                                wfinfo.Category = wfinfo.CategoryFromString(
                                    (string)jinfo["category"]
                                    );
                                wfinfo.StartsAt = (DateTime?)jinfo["starts_at"];
                                wfinfo.EndsAt = (DateTime?)jinfo["ends_at"];

                                wfinfos.Add(wfinfo);

                            } // foreach jinfo

                            wfpoi.Information = wfinfos.ToArray();

                        }
                        catch
                        {
                            // No info attached to this poi.
                        }



                        wfpois.Add(wfpoi);

                    } // foreach pointofinterest
                    result.PointsOfInterest = wfpois.ToArray();

                }
                catch
                {
                    // No points of interest
                }


                return result;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static WFVenue LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                WFVenue v = WFVenue.FromJson(
                        File.ReadAllText(fileName, Encoding.UTF8)
                        );

                return v;

            } // file exists

            return null;
            
        }
        
        public string ToJson()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);

                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("venue");
                    writer.WriteStartObject();

                    writer.WritePropertyName("id");
                    writer.WriteValue(Id);
                    writer.WritePropertyName("name");
                    writer.WriteValue(Name);
                    writer.WritePropertyName("description");
                    writer.WriteValue(Description);

                    writer.WritePropertyName("address");
                    writer.WriteValue(Address);
                    writer.WritePropertyName("zip");
                    writer.WriteValue(Zip);
                    writer.WritePropertyName("city");
                    writer.WriteValue(City);
                    writer.WritePropertyName("country");
                    writer.WriteValue(Country);

                    writer.WritePropertyName("phone");
                    writer.WriteValue(Phone);
                    writer.WritePropertyName("email");
                    writer.WriteValue(Email);
                    writer.WritePropertyName("web");
                    writer.WriteValue(Web);








                    if (Platforms != null &&
                        Platforms.Length > 0)
                    {
                        writer.WritePropertyName("platforms");
                        writer.WriteStartArray();
                        foreach (WFPlatform pf in Platforms)
                        {
                            writer.WriteStartObject(); // Platform

                            writer.WritePropertyName("name");
                            writer.WriteValue(pf.Name);
                            writer.WritePropertyName("entrance_beacon_major");
                            writer.WriteValue(pf.EntranceBeaconMajor);
                            writer.WritePropertyName("entrance_beacon_minor");
                            writer.WriteValue(pf.EntranceBeaconMinor);
                            writer.WritePropertyName("exit_beacon_major");
                            writer.WriteValue(pf.ExitBeaconMajor);
                            writer.WritePropertyName("exit_beacon_minor");
                            writer.WriteValue(pf.ExitBeaconMinor);

                            writer.WritePropertyName("destinations");
                            writer.WriteStartArray(); // Destinations
                            foreach (string dest in pf.Destinations)
                            {
                                writer.WriteValue(dest);

                            } // foreach destination
                            writer.WriteEnd(); // Destinations

                            writer.WriteEndObject(); // Platform

                        } // foreach platform
                        writer.WriteEnd(); // Platform

                    } // Has platforms


                    if (Exits != null &&
                        Exits.Length > 0)
                    {
                        writer.WritePropertyName("exits");
                        writer.WriteStartArray();
                        foreach (WFExit wfe in Exits)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("name");
                            writer.WriteValue(wfe.Name);
                            writer.WritePropertyName("entrance_beacon_major");
                            writer.WriteValue(wfe.EntranceBeaconMajor);
                            writer.WritePropertyName("entrance_beacon_minor");
                            writer.WriteValue(wfe.EntranceBeaconMinor);
                            writer.WritePropertyName("exit_beacon_major");
                            writer.WriteValue(wfe.ExitBeaconMajor);
                            writer.WritePropertyName("exit_beacon_minor");
                            writer.WriteValue(wfe.ExitBeaconMinor);
                            writer.WritePropertyName("mode");
                            writer.WriteValue(wfe.Mode);

                            writer.WriteEndObject();

                        } // foreach exit
                        writer.WriteEnd();

                    } // Has exits

                    if (PointsOfInterest != null &&
                        PointsOfInterest.Length > 0)
                    {
                        writer.WritePropertyName("pointsofinterest");
                        writer.WriteStartArray();
                        foreach (WFPointOfInterest wfpoi in PointsOfInterest)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("name");
                            writer.WriteValue(wfpoi.Name);
                            writer.WritePropertyName("descriptive_name");
                            writer.WriteValue(wfpoi.DescriptiveName);
                            writer.WritePropertyName("beacon_uuid");
                            writer.WriteValue(wfpoi.BeaconUuid);
                            writer.WritePropertyName("beacon_major");
                            writer.WriteValue(wfpoi.BeaconMajor);
                            writer.WritePropertyName("beacon_minor");
                            writer.WriteValue(wfpoi.BeaconMinor);
                            writer.WritePropertyName("category");
                            writer.WriteValue(wfpoi.Category.ToString().ToLower());

                            if (wfpoi.Information != null &&
                                wfpoi.Information.Length > 0)
                            {
                                writer.WritePropertyName("information");
                                writer.WriteStartArray();
                                foreach (WFPOIInformation wfpoinfo in wfpoi.Information)
                                {
                                    writer.WriteStartObject();

                                    writer.WritePropertyName("information");
                                    writer.WriteValue(wfpoinfo.Information);
                                    writer.WritePropertyName("category");
                                    writer.WriteValue(wfpoinfo.Category.ToString().ToLower());

                                    writer.WritePropertyName("starts_at");
                                    writer.WriteValue(wfpoinfo.StartsAt);
                                    writer.WritePropertyName("ends_at");
                                    writer.WriteValue(wfpoinfo.EndsAt);
                                    
                                    writer.WriteEndObject();

                                } // foreach wfpoinfo
                                writer.WriteEnd();

                            } // Has information

                            writer.WriteEndObject();

                        } // foreach pointofinterest
                        writer.WriteEnd();

                    } // Has points of interest

                    writer.WriteEndObject(); // venue
                    writer.WriteEndObject();

                } // using

                return sb.ToString();

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

        public void SaveToFile(string fileName)
        {
            try
            {
                string data = ToJson();
                File.WriteAllText(fileName, data, Encoding.UTF8);

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public WFPointOfInterest POIFromBeacon(int major, int minor)
        {
            try
            {
                if (PointsOfInterest == null ||
                    PointsOfInterest.Length == 0)
                {
                    return null;

                }

                WFPointOfInterest poi = (
                    from x in PointsOfInterest
                    where x.BeaconMajor == major && x.BeaconMinor == minor
                    select x
                    ).FirstOrDefault();

                return poi;

            }
            catch
            {
                throw;

            }

        }

        public void AddPOIsFromGraph()
        {
            try
            {
                if (NodesGraph == null)
                {
                    return;
                } // No graph

                List<WFPointOfInterest> newpois = new List<WFPointOfInterest>();
                foreach (WFNode node in NodesGraph.Vertices)
                {
                    WFPointOfInterest poi = POIFromBeacon(
                        node.Major,
                        node.Minor
                        );

                    if (poi == null)
                    {
                        poi = new WFPointOfInterest();
                        poi.BeaconMajor = node.Major;
                        poi.BeaconMinor = node.Minor;

                        newpois.Add(poi);

                    }

                    poi.Name = node.Name;
                    poi.DescriptiveName = node.DescriptiveName;
                    
                } // foreach graph.node

                if (PointsOfInterest != null)
                {
                    List<WFPointOfInterest> allpois = PointsOfInterest.ToList();
                    allpois.AddRange(newpois);
                    PointsOfInterest = allpois.ToArray();

                }
                else
                {
                    PointsOfInterest = newpois.ToArray();

                }
                
            }
            catch
            {
                throw;

            }

        }


    }
}
