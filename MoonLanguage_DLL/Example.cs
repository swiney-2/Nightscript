using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightscript
{
    class Example
    {
        static void Main() {
            NS_TEXTALERT.NEW("Sup", "Sup", NS_TEXTALERT.NS_TEXTALERT_BUTTON.TXTALRT_ABORT_RETRY_IGNORE, NS_TEXTALERT.NS_TEXTALERT_ICON.TXTALRT_ASTERISK);
            NS_HTTP.HTTP_REQ(new Uri("https://example.com/test.html/"), NS_HTTP.HTTP_REQ_TYPE.GET);
            NS_HTTP.HTTP_REQ(new Uri("https://example.com/test.html/"), NS_HTTP.HTTP_REQ_TYPE.DELETE);
            NS_STACK.COUT(NS_CRYPT.BASE_64.ENCODE_NEW(NS_CRYPT.HASH_SHA256("Deleted https://example.com/test.html/")));
            NS_STACK.CIN();
        }
    }
}
