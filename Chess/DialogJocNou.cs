using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class DialogJocNou : Form
    {
        public struct NewGameInfo
        {
            /// <summary>
            /// Create a record of new game settings
            /// </summary>
            /// <param name="color">Player color</param>
            /// <param name="engineThinkTimeInMs">Ms to allow the engine to come
            /// up with a best move</param>
            public NewGameInfo(TipJoc type, CuloarePiesa color, MarimeTable marime)
            {
                typegame = type;
                playerColor = color;
                Size = marime;

            }

            /// <summary>Player color (e.g. white or black)</summary>
            public CuloarePiesa PlayerColor { get { return playerColor; } }

            public TipJoc Type { get { return typegame; } set { typegame = value; } }

            public MarimeTable SizeTable { get { return Size; } set { Size = value; } }

            private CuloarePiesa playerColor;
            private TipJoc typegame;
            private MarimeTable Size;
        }
        private NewGameInfo newGameInfo;
        public NewGameInfo Info { get { return newGameInfo; } }
        public DialogJocNou()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            CuloarePiesa culoareajucatorului = CuloarePiesa.Alb;
            RadioButton butonculoare = RadioButtonHelper.GetCheckedRadio(groupBox1);
            if (butonculoare == btn_Negru)
                culoareajucatorului = CuloarePiesa.Negru;
            TipJoc tipjoc = TipJoc.Clasic;
            RadioButton butontip = RadioButtonHelper.GetCheckedRadio(groupBox2);
            if (butontip == btn_regulischimbate)
                tipjoc = TipJoc.ReguliSchimbate;
            RadioButton butonmarime = RadioButtonHelper.GetCheckedRadio(groupBox3);
            MarimeTable Sizee = MarimeTable.Patru;
            if (butonmarime == radioButton1)
                Sizee = MarimeTable.Patru;
            else
                if (butonmarime == radioButton2)
                Sizee = MarimeTable.Cinci;
            else
                if (butonmarime == radioButton3)
                Sizee = MarimeTable.Sase;
            else
                if (butonmarime == radioButton4)
                Sizee = MarimeTable.Sapte;
            else
                if (butonmarime == radioButton5)
                Sizee = MarimeTable.Opt;
            else
                if (butonmarime == radioButton6)
                Sizee = MarimeTable.Noua;
            else
                if (butonmarime == radioButton7)
                Sizee = MarimeTable.Zece;
            newGameInfo = new NewGameInfo(tipjoc, culoareajucatorului,Sizee);
        }
    }
    class RadioButtonHelper
    {
        /// <summary>
        /// Helper to find the checked radio button
        /// </summary>
        /// <param name="container">Control that holds the radio buttons, 
        /// i.e. a groupbox</param>
        /// <returns>The RadioButton control that is selected.</returns>
        public static RadioButton GetCheckedRadio(Control container)
        {
            // Loop through each control in the container
            foreach (var control in container.Controls)
            {
                // If the control is a RadioButton (it might not be) and if that
                // RadioButton is currently checked, then we're done looking
                RadioButton radio = control as RadioButton;
                if ((radio != null) && (radio.Checked == true))
                {
                    return radio;
                }
            }
            // In this case we're also done looking, but found no checked 
            // RadioButtons in the container control
            return null;
        }
    }
}
