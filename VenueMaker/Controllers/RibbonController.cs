using RibbonLib.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Controllers
{
    public enum RibbonMarkupCommands : uint
    {
        ButtonNew = 1001,
        ButtonOpen = 1002,
        ButtonSave = 1003,
        ButtonSaveAs = 1004,
        ButtonSelectDataFolder = 1005,

        ButtonCreateAccount = 1021,
        ButtonVerifyAccount = 1022,
        ButtonLogin = 1023,
        ButtonLogOut = 1024,
        ButtonSetPermissions = 1025,

        ButtonViewVenue = 1040,
        ButtonVenueSetPhoto = 1041,
        ButtonVenueMapAdd = 1042,
        ButtonVenueMapDelete = 1043,
        ButtonVenueMapProperties = 1044,

        ButtonViewNodes = 1060,
        ButtonNodeAdd = 1061,
        ButtonNodeDelete =1062,
        ButtonNodeImport = 1063,
        ButtonNodePinOnMap = 1064,

        ButtonViewElevators = 1080,
        ButtonElevatorsGenerate = 1081,
        ButtonElevatorDelete = 1082,

        ButtonViewPOIs = 1100,

        ButtonPOIInfoAdd = 1121,
        ButtonPOIInfoDelete = 1122,
        ButtonPOIInfoMoveUp = 1123,
        ButtonPOIInfoMoveDown = 1124,
        ButtonPOIInfoSelectMediaFile = 1125,

        ButtonViewDirections = 1140,
        ButtonDirectionAdd = 1141,
        ButtonDirectionDelete = 1142,
        ButtonDirectionEdit = 1143,
        ButtonDirectionPinOnMap = 1144,

        ButtonExit = 1999,

        TabStart = 2001,
        TabAccount = 2002,
        TabVenue = 2003,
        TabNodes = 2004,
        TabDirections = 2005,
        TabElevators = 2006,
        TabPointsOfInterest = 2007,

        GroupFileAction = 3001,
        GroupAccount = 3002
    }

    public class RibbonController
    {
        private static RibbonController _me;
        private RibbonLib.Ribbon _ribbon;
        private Dictionary<RibbonMarkupCommands, RibbonButton> buttons;


        public static RibbonController Me
        {
            get
            {
                return _me;
            } // get
        } // Me
        

        public RibbonController(RibbonLib.Ribbon theRibbon)
        {
            _ribbon = theRibbon;
            buttons = new Dictionary<RibbonMarkupCommands, RibbonButton>();

        }

        public static void Init(RibbonLib.Ribbon theRibbon)
        {
            _me = new RibbonController(theRibbon);

        }


        public RibbonButton Button(RibbonMarkupCommands id)
        {
            try
            {
                if (!buttons.ContainsKey(id))
                {
                    RibbonButton btn = new RibbonButton(_ribbon, (uint)id);
                    buttons.Add(id, btn);

                } // Doesn't exist

                return buttons[id];

            }
            catch
            {
                throw;

            }
        }


    }
}
