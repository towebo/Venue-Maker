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
        ButtonCreateAccount = 1011,
        ButtonVerifyAccount = 1012,
        ButtonLogin = 1013,
        ButtonLogOut = 1014,
        ButtonAssignRights = 1015,
        TabStart = 2001,
        TabAccount = 2002,
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
