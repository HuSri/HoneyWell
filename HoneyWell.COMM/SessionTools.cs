using System.Web;
using System.Web.SessionState;

namespace HoneyWell.COMM
{
    public class SessionTools
    {
        private static HttpSessionState _session = HttpContext.Current.Session;
        public static void SetSession(string key, object value)
        {
            _session[key] = value;
        }
        public static int GetSessionNumber(string key)
        {
            int result = 0;
            if (_session[key] != null)
            {
                int.TryParse(_session[key].ToString(), out result);
            }
            return result;
        }
        public static string GetSessionString(string key)
        {
            string result = "";
            if (_session[key] != null)
            {
                result = _session[key].ToString();
            }
            return result;
        }
        public static void Clear()
        {
            _session.Clear();
        }
    }

}
