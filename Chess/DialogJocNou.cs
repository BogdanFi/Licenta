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
            public NewGameInfo( CuloarePiesa color, MarimeTable marime1,MarimeTable marime2)
            {
               
                playerColor = color;
                SizeC = marime1;
                SizeL = marime2;

            }

            /// <summary>Player color (e.g. white or black)</summary>
            public CuloarePiesa PlayerColor { get { return playerColor; } }

           

            public MarimeTable SizeTableC { get { return SizeC; } set { SizeC = value; } }
            public MarimeTable SizeTableL { get { return SizeL; } set { SizeL = value; } }

            private CuloarePiesa playerColor;
            
            private MarimeTable SizeC;
            private MarimeTable SizeL;
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
            
            MarimeTable SizeeL = MarimeTable.Patru;
            MarimeTable SizeeC = MarimeTable.Patru;
            if (String.Equals(comboBox1.Text, "5"))
                SizeeL = MarimeTable.Cinci;
            if (String.Equals(comboBox1.Text, "6"))
                SizeeL = MarimeTable.Sase;
            if (String.Equals(comboBox1.Text, "7"))
                SizeeL = MarimeTable.Sapte;
            if (String.Equals(comboBox1.Text, "8"))
                SizeeL = MarimeTable.Opt;
            if (String.Equals(comboBox1.Text, "9"))
                SizeeL = MarimeTable.Noua;
            if (String.Equals(comboBox1.Text, "10"))
                SizeeL = MarimeTable.Zece;
            if (String.Equals(comboBox2.Text, "5"))
                SizeeC = MarimeTable.Cinci;
            if (String.Equals(comboBox2.Text, "6"))
                SizeeC = MarimeTable.Sase;
            if (String.Equals(comboBox2.Text, "7"))
                SizeeC = MarimeTable.Sapte;
            if (String.Equals(comboBox2.Text, "8"))
                SizeeC = MarimeTable.Opt;
            if (String.Equals(comboBox2.Text, "9"))
                SizeeC = MarimeTable.Noua;
            if (String.Equals(comboBox2.Text, "10"))
                SizeeC = MarimeTable.Zece;

            newGameInfo = new NewGameInfo( culoareajucatorului,SizeeC,SizeeL);
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
