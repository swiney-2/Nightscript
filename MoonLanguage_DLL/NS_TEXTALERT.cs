using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nightscript
{
    class NS_TEXTALERT
    {
        public enum NS_TEXTALERT_BUTTON {
            TXTALRT_OK,
            TXTALRT_OKCANCEL,
            TXTALRT_YESNO,
            TXTALRT_YESNOCANCEL,
            TXTALRT_ABORT_RETRY_IGNORE,
            TXTALRT_RETRY_CANCEL,
        }
        public static void CREATE_TEXTALERT(string text, string label, NS_TEXTALERT_BUTTON button) {
            switch (button) {
                case NS_TEXTALERT_BUTTON.TXTALRT_OK:
                    MessageBox.Show(text, label, MessageBoxButtons.OK);
                    break;
                case NS_TEXTALERT_BUTTON.TXTALRT_OKCANCEL:
                    MessageBox.Show(text, label, MessageBoxButtons.OKCancel);
                    break;
                case NS_TEXTALERT_BUTTON.TXTALRT_YESNO:
                    MessageBox.Show(text, label, MessageBoxButtons.YesNo);
                    break;
                case NS_TEXTALERT_BUTTON.TXTALRT_YESNOCANCEL:
                    MessageBox.Show(text, label, MessageBoxButtons.YesNoCancel);
                    break;
                case NS_TEXTALERT_BUTTON.TXTALRT_ABORT_RETRY_IGNORE:
                    MessageBox.Show(text, label, MessageBoxButtons.AbortRetryIgnore);
                    break;
                case NS_TEXTALERT_BUTTON.TXTALRT_RETRY_CANCEL:
                    MessageBox.Show(text, label, MessageBoxButtons.RetryCancel);
                    break;
            }
        }
    }
}
