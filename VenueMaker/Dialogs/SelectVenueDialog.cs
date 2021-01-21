using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VenueMaker.Controllers;
using MAWINGU.Logging;
using KWENDA.DTO;
using System.Threading.Tasks;

namespace VenueMaker.Dialogs
{
    public partial class SelectVenueDialog : Form
    {
        private Dictionary<string,string> listdict;
        private Dictionary<string, KWENDAFileItem> filesdict;
        private string _venueid;


        public SelectVenueDialog()
        {
            InitializeComponent();
        }

        public SelectVenueDialog(string venueId)
            : this()
        {
            _venueid = venueId;

        }

        private async Task InitUI()
        {
            try
            {
                KWENDAFileItem[] files = await DataController.Me.ListFiles();
                files = files.Where(w =>
                            w.FileExt.ToLower() == ".venue"
                        ).ToArray();

                filesdict = files.ToDictionary(w => w.VenueId);
                listdict = new Dictionary<string, string>();
                files.ToList().ForEach(w =>
                {
                    string venid = w.VenueId;
                    while (listdict.ContainsKey(venid))
                    {                    
                        venid = venid + "_";

                    } // while

                    listdict.Add(
                        venid,
                        !string.IsNullOrWhiteSpace(w.FileTitle) ?
                            w.FileTitle :
                            w.FileName
                            );

                });

                VenuesBS.DataSource = listdict.OrderBy(w => w.Value);

                if (listdict.Any())
                {
                    VenuesLB.DataSource = VenuesBS;
                    VenuesLB.DisplayMember = "Value";
                    VenuesLB.ValueMember = "Key";

                } // Any venues

                SelectBtn.Enabled = listdict.Any();

                if (!string.IsNullOrWhiteSpace(_venueid))
                {
                    if (listdict.ContainsKey(_venueid))
                    {
                        while (VenuesBS.Position < listdict.Count - 1)
                        {
                            KeyValuePair<string,string> shit = (KeyValuePair<string, string>)VenuesBS.Current;
                            if (shit.Key == _venueid)
                            {
                                break;
                            }

                            VenuesBS.MoveNext();

                        } // while

                    } // Found
                    
                } // Has value


            }
            catch (Exception ex)
            {
                LogCenter.Error("SelectVenueDialog.InitUI", ex.Message);
                throw new Exception($"Fel när SelectVenueDialog.InitUI kördes: {ex.Message}");
            }
        }

        private async void SelectVenueDialog_Load(object sender, EventArgs e)
        {
            try
            {
                await InitUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public KWENDAFileItem SelectedFile
        {
            get
            {
                return filesdict[Convert.ToString(VenuesLB.SelectedValue)];
            }
        }


        
    }
}
